using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Contracts;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Models;

namespace WoodMasters2.Core.Services
{
    /// <summary>
    /// Handle MasterPiece data
    /// </summary>
    public class MasterPieceService : IMasterPieceService
    {
        public Task AddMasterPieceAsync(AddMasterPieceViewModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all MasterPieces from the DB
        /// </summary>
        /// <returns>List of MasterPieces</returns>

        public Task<IEnumerable<MasterPieceViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MasterPieceViewModel>> GetAllMasterPiecesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wood>> GetWoodsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
