using Microsoft.EntityFrameworkCore;
using WoodMasters2.Core.Contracts;
using WoodMasters2.Core.Data;
using WoodMasters2.Core.Data.Entities;
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
                MasterId = userId,
                ImageURL = model.ImageURL,
                Price = model.Price,
                Quantity = model.Quantity
            };

            await context.MasterPieces.AddAsync(entity);
            await context.SaveChangesAsync();

        }

        public async Task AddMasterPieceToFavoritesAsync(int masterPieceId, string userId)
        {
            var user = await context.Users
                        .Where(u => u.Id == userId)
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
            var favoriteMasterPieces = context.MasterPieces.Where(f => favoriteIds.Contains(f.Id)).ToList();
            if (favoriteMasterPieces == null || favoriteMasterPieces.Count == 0)
            {
                user.Favorites.Add(new Favorite()
                {
                    Value = masterPieceId
                });

                await context.SaveChangesAsync();
            }

        }

        public Task DeleteAsync(int masterPieceId, string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all MasterPieces from the DB
        /// </summary>
        /// <returns>List of MasterPieces</returns>   
        public async Task<IEnumerable<MasterPieceViewModel>> GetAllMasterPiecesAsync()
        {
            var entities = await context.MasterPieces
                .Include(x => x.Master)
                .Include(x => x.Category)
                .ToListAsync();

            return entities.Select(m => new MasterPieceViewModel
            {
                Id = m.Id,
                Master = m.Master.UserName,
                Name = m.Name,
                Description = m.Description,
                ImageURL = m.ImageURL,
                Rating = m.Rating,
                Category = m.Category.Name,
                Price = m.Price,
                Width = m.Width,
                Length = m.Length,
                Depth = m.Depth,
                Quantity = m.Quantity
            });
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<MasterPieceViewModel>> GetFavoritesAsync(string userId)
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
            var favoriteIds = user.Favorites.Select(u=>u.Value);
            var favoriteMasterPieces = context.MasterPieces.Where(f => favoriteIds.Contains(f.Id));
                
            
            return favoriteMasterPieces
            .Select(m => new MasterPieceViewModel()
            {
                Id = m.Id,
                Master = m.Master.UserName,
                Name = m.Name,
                Description = m.Description,
                ImageURL = m.ImageURL,
                Rating = m.Rating,
                Category = m.Category.Name,
                Price = m.Price,
                Width = m.Width,
                Length = m.Length,
                Depth = m.Depth,
                Quantity = m.Quantity

            });

        }

        public Task<IEnumerable<MasterPieceViewModel>> GetMineAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await context.Suppliers.ToListAsync();
        }

        public async Task<IEnumerable<Wood>> GetWoodsAsync()
        {
            return await context.Woods.ToListAsync();
        }

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
                //context.Entry(favoriteToRemove).State = EntityState.Deleted;
                //context.SaveChanges();
                //context.Entry(favoriteToRemove).State = EntityState.Detached;
            }

        }


    }
}
