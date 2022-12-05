using Microsoft.EntityFrameworkCore;
using System.Net;
using WoodMasters2.Core.Contracts;
using WoodMasters2.Core.Data;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Data.Enums;
using WoodMasters2.Core.Models;

namespace WoodMasters2.Core.Services
{
    /// <summary>
    /// Handle MasterPiece data
    /// </summary>
    public class MasterPieceService : IMasterPieceService
    {
        private readonly WMDbContext context;

        public MasterPieceService(WMDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Add MasterPiece to the DB
        /// </summary>
        /// <returns>List of MasterPieces</returns>
        public async Task AddMasterPieceAsync(AddMasterPieceViewModel model, string userId)
        {


            var entity = new MasterPiece()
            {
                Name = model.Name,
                Width = model.Width,
                Length = model.Length,
                Depth = model.Depth,
                Description = model.Description,
                CategoryId = model.CategoryId,
                WoodId = model.WoodId,
                MasterId = userId,
                ImageURL = model.ImageURL,
                Price = model.Price,
                Quantity = model.Quantity
            };

            await context.MasterPieces.AddAsync(entity);
            await context.SaveChangesAsync();

        }
        /// <summary>
        /// Add MasterPiece to the Favorites List
        /// </summary>
        /// <param name="masterPieceId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task AddMasterPieceToFavoritesAsync(int masterPieceId, string userId)
        {
            var user = await context.Users
                        .Where(u => u.Id == userId)
                        .Include(f=>f.Favorites)
                        .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var masterPiece = await context.MasterPieces.FirstOrDefaultAsync(u => u.Id == masterPieceId);

            if (masterPiece == null)
            {
                throw new ArgumentException("Invalid MasterPiece ID");
            }
            var favoriteIds = user.Favorites.Select(u => u.Value);
            var favoriteMasterPieces = await context.MasterPieces.Where(f => favoriteIds.Contains(f.Id)).ToListAsync();
            if (favoriteMasterPieces == null || favoriteMasterPieces.Count == 0 || !favoriteMasterPieces.Contains(masterPiece))
            {
                user.Favorites.Add(new Favorite()
                {
                    Value = masterPieceId
                });

                await context.SaveChangesAsync();
            }

        }

        public IEnumerable<string> AllCategoriesNames()
        {
            var categories = context.Categories
            .Select(c => c.Name)
            .Distinct()
            .ToList();
            return categories;
        }


        public MasterPieceQueryModel AllCrafts(string? category = null, string? searchKey = null, MasterPieceSorting sorting = MasterPieceSorting.Newest, int currentPage = 1, int craftsPerPage = 1)
        {
            var masterPiecesQuery =  context.MasterPieces
                .Where(mp => mp.IsDeleted == false)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(category))
            {
                masterPiecesQuery = context.MasterPieces
                    .Where(m => m.Category.Name == category);
            }
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                masterPiecesQuery = masterPiecesQuery
                    .Where(m=>
                    m.Name.ToLower().Contains(searchKey.ToLower()) ||
                    m.Description.ToLower().Contains(searchKey.ToLower()) ||
                    m.Wood.Type.ToLower().Contains(searchKey.ToLower()) 
                        );
            }
            masterPiecesQuery = sorting switch
            {
                MasterPieceSorting.Price => masterPiecesQuery.OrderBy(m => m.Price),
                MasterPieceSorting.Rating => masterPiecesQuery.OrderBy(m => (m.RateTotal/m.RateCount)).ThenByDescending(m => m.Id),
                _=>masterPiecesQuery.OrderByDescending(m=>m.Id)
            };
            var crafts = masterPiecesQuery
                .Skip((currentPage-1)*craftsPerPage)
                .Take(craftsPerPage)
                .Select(m=> new MasterPieceViewModel
                {
                    Id = m.Id,
                    Master = m.Master.UserName,
                    Name = m.Name,
                    Description = m.Description,
                    ImageURL = m.ImageURL,
                    Category = m.Category.Name,
                    Wood = m.Wood.Type,
                    Price = m.Price,
                    Width = m.Width,
                    Length = m.Length,
                    Depth = m.Depth,
                    Quantity = m.Quantity,
                    RateCount = m.RateCount,
                    RateTotal = m.RateTotal
                })
                .ToList();
            var totalCrafts = masterPiecesQuery.Count();

            return new MasterPieceQueryModel
            {
                TotalMasterPieces = totalCrafts,
                CraftPieces = crafts
            };
        }
        

        /// <summary>
        /// Deleting MasterPiece By the master
        /// </summary>
        /// <param name="masterPieceId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteAsync(int masterPieceId)
        {
            var masterPieceToDelete = await context.MasterPieces.FirstOrDefaultAsync(f => f.Id == masterPieceId);

            if (masterPieceToDelete != null)
            {
                masterPieceToDelete.IsDeleted = true;

                await context.SaveChangesAsync();

            }
        }

        public async Task EditMasterPieceAsync(EditMasterPieceViewModel model)
        {
            MasterPiece? entity = await context.MasterPieces.FindAsync(model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Width = model.Width;
                entity.Length = model.Length;
                entity.Depth = model.Depth;
                entity.Description = model.Description;
                entity.CategoryId = model.CategoryId;
                entity.WoodId = model.WoodId;
                entity.ImageURL = model.ImageURL;
                entity.Price = model.Price;
                entity.Quantity = model.Quantity;
            }
            

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all MasterPieces from the DB
        /// </summary>
        /// <returns>List of MasterPieces</returns>   
        public async Task<IEnumerable<MasterPieceViewModel>> GetAllMasterPiecesAsync()
        {
            var entities = await context.MasterPieces
                .Where(mp=>mp.IsDeleted==false)
                .Include(x => x.Master)
                .Include(x => x.Category)
                .Include(x => x.Wood)   
                .Include(x=>x.ratings)
                .ToListAsync();

            var result = entities.Select(m => new MasterPieceViewModel
            {
                Id = m.Id,
                Master = m.Master.UserName,
                Name = m.Name,
                Description = m.Description,
                ImageURL = m.ImageURL,                
                Category = m.Category.Name,
                Wood = m.Wood.Type,
                Price = m.Price,
                Width = m.Width,
                Length = m.Length,
                Depth = m.Depth,
                Quantity = m.Quantity,
                RateCount = m.RateCount,
                RateTotal = m.RateTotal
            });
            return result;
        }
        /// <summary>
        /// Get the Category of the MasterPiece
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        
        public async Task<EditMasterPieceViewModel> GetEditMasterPieceAsync(int id)
        {
            var masterPiece = await context.MasterPieces.FindAsync(id);
            var model = new EditMasterPieceViewModel();
            if (masterPiece!=null)
            {
                model.Id = id;
                model.Depth = masterPiece.Depth;
                model.Width = masterPiece.Width;
                model.Description = masterPiece.Description;
                model.CategoryId = masterPiece.CategoryId;
                model.WoodId = masterPiece.WoodId;
                model.Length = masterPiece.Length;
                model.ImageURL = masterPiece.ImageURL;
                model.Name = masterPiece.Name;
                model.Price = masterPiece.Price;
                model.Quantity = masterPiece.Quantity;
            };
            model.Categories = await GetCategoriesAsync();
            model.Woods = await GetWoodsAsync();

            return model;
        }
                  

        /// <summary>
        /// Get Favorite MasterPieces List
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<IEnumerable<MasterPieceViewModel>> GetFavoritesAsync(string userId)
        {
            var user = await context.Users
                    .Where(u => u.Id == userId)                    
                    .Include(f => f.Favorites)
                    .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }
            var favoriteIds = user.Favorites.Select(u=>u.Value).ToList();
            var favoriteMasterPieces =  await context.MasterPieces
                .Where(f => favoriteIds.Contains(f.Id))
                .Include(mp => mp.Category)
                .Include(mp => mp.Wood)
                .ToListAsync();
                
            
            return favoriteMasterPieces
                 .Where(mp => mp.IsDeleted == false)
                 .Select(m => new MasterPieceViewModel()
                 {
                     Id = m.Id,
                     Master = user.UserName,
                     Name = m.Name,
                     Description = m.Description,
                     ImageURL = m.ImageURL,
                     Category = m.Category.Name,
                     Wood = m.Wood.Type,
                     Price = m.Price,
                     Width = m.Width,
                     Length = m.Length,
                     Depth = m.Depth,
                     Quantity = m.Quantity

                 });

        }

        public async Task<IEnumerable<MasterPieceViewModel>> GetLast3MasterPiecesAsync()
        {
            var last3MasterPieces = await context
                .MasterPieces
                .OrderByDescending(mp => mp.Id)
                .Select(mp => new MasterPieceViewModel
                {
                    Id = mp.Id,
                    Name = mp.Name,
                    ImageURL = mp.ImageURL
                })
                .Take(3)
                .ToListAsync();
            return last3MasterPieces;

        }

        public async Task<MasterPiece> GetMasterPieceByIdAsync(int id)
        {
            var entity = await context.MasterPieces.FindAsync(id);
            if (entity==null)
            {
                throw new ArgumentException("Invalid MasterPiece ID");
            }
            return entity;
        }
        public async Task<MasterPieceViewModel> GetMasterPieceViewByIdAsync(int id)
        {
            var entity = await context.MasterPieces
                .Include(m=>m.Wood)
                .Include(m=>m.Category)
                .Include(m=>m.Master)
                .FirstOrDefaultAsync(m=>m.Id == id);
            if (entity == null)
            {
                throw new ArgumentException("Invalid MasterPiece ID");
            }
            var modelView = new MasterPieceViewModel()
                {
                    Id = entity.Id,
                    Master = entity.Master.UserName,
                    MasterEmail = entity.Master.Email,
                    MasterPhone = entity.Master.PhoneNumber,
                    Name = entity.Name,
                    Description = entity.Description,
                    ImageURL = entity.ImageURL,
                    Category = entity.Category.Name,
                    Wood = entity.Wood.Type,
                    Price = entity.Price,
                    Width = entity.Width,
                    Length = entity.Length,
                    Depth = entity.Depth,
                    Quantity = entity.Quantity,
                    RateCount = entity.RateCount,
                    RateTotal = entity.RateTotal

                };
            return modelView;
        }

        /// <summary>
        /// Get owned MasterPieces
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<IEnumerable<MasterPieceViewModel>> GetMineAsync(string userId)
        {
            var user = await context.Users
                    .Include(mp => mp.MasterPieces)   
                    .ThenInclude(mp=>mp.Category)
                    .Include(mp => mp.MasterPieces)
                    .ThenInclude(mp => mp.Wood)
                    .Where(u => u.Id == userId)
                    .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }
            var mineMasterPieces = user.MasterPieces
                .Where(mp => mp.IsDeleted == false)
                .Select(m => new MasterPieceViewModel()
            {
                Id = m.Id,
                Master = user.UserName,
                Name = m.Name,
                Description = m.Description,
                ImageURL = m.ImageURL,
                Category = m.Category.Name,
                Wood = m.Wood.Type,
                Price = m.Price,
                Width = m.Width,
                Length = m.Length,
                Depth = m.Depth,
                Quantity = m.Quantity

            });
            return mineMasterPieces;
        }
       
        /// <summary>
        /// Get the wood of the MasterPiece
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Wood>> GetWoodsAsync()
        {
            return await context.Woods.ToListAsync();
        }
        /// <summary>
        /// Remove the MasterPiece from the Favorites list
        /// </summary>
        /// <param name="masterPieceId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task RemoveMasterPieceFromFavoritesAsync(int masterPieceId, string userId)
        {
            var user = await context.Users
                   .Include(mp => mp.MasterPieces)
                   .Include(f => f.Favorites)
                   .Where(u => u.Id == userId)
                   .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }
            var favoriteToRemove = user.Favorites.FirstOrDefault(f=>f.Value==masterPieceId);

            if (favoriteToRemove!= null)
            {
                user.Favorites.Remove(favoriteToRemove);

                await context.SaveChangesAsync();
                
            }

        }


    }
}
