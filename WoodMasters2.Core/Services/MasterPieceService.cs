﻿using Microsoft.EntityFrameworkCore;
using System.Net;
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

        public async Task<MasterPiece> GetMasterPieceByIdAsync(int id)
        {
            var entity = await context.MasterPieces.FindAsync(id);
            if (entity==null)
            {
                throw new ArgumentException("Invalid MasterPiece ID");
            }
            return entity;
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
