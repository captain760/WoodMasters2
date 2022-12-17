using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Data.Enums;
using WoodMasters2.Core.Models.MasterPieces;

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
        Task<IEnumerable<MasterPieceViewModel>> GetLast3MasterPiecesAsync();

        Task<IEnumerable<Wood>> GetWoodsAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        
        Task AddMasterPieceAsync(AddMasterPieceViewModel model, string userId);
        Task AddMasterPieceToFavoritesAsync(int masterPieceId, string userId);

        Task<IEnumerable<MasterPieceViewModel>> GetFavoritesAsync(string userId);
        
        Task<IEnumerable<MasterPieceViewModel>> GetMineAsync(string userId);

        Task RemoveMasterPieceFromFavoritesAsync(int masterPieceId, string userId);
        Task DeleteAsync(int masterPieceId);

        Task<EditMasterPieceViewModel> GetEditMasterPieceAsync(int id);
        Task EditMasterPieceAsync(EditMasterPieceViewModel model);

        Task <MasterPiece> GetMasterPieceByIdAsync(int id);
        Task<MasterPieceViewModel> GetMasterPieceViewByIdAsync(int id);
        Task<MasterPieceQueryModel> AllCrafts(
            string? category = null,
            string? searchKey = null,
            MasterPieceSorting sorting = MasterPieceSorting.Newest,
            int currentPage = 1,
            int craftsPerPage = 1
            );
        IEnumerable<string> AllCategoriesNames();
        Task<bool> CategoryExists(int categoryId);
        Task<bool> WoodExists(int woodId);
    }
}

