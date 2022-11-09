using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Models;

namespace WoodMasters2.Core.Contracts
{
    /// <summary>
    /// Handle MasterPiece data
    /// </summary>
    public interface IMasterPieceService
    {
        
        /// <summary>
        /// Gets all MasterPieces
        /// </summary>
        /// <returns>List of MasterPieces</returns>
        Task<IEnumerable<MasterPieceViewModel>> GetAllMasterPiecesAsync();

        Task<IEnumerable<Wood>> GetWoodsAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
        Task AddMasterPieceAsync(AddMasterPieceViewModel model, string userId);
        Task AddMasterPieceToFavoritesAsync(int masterPieceId, string userId);

        Task<IEnumerable<MasterPieceViewModel>> GetFavoritesAsync(string userId);
        Task<IEnumerable<MasterPieceViewModel>> GetMineAsync(string userId);

        Task RemoveMasterPieceFromFavoritesAsync(int masterPieceId, string userId);
        Task DeleteAsync(int masterPieceId, string userId);

    }
}

