using System.ComponentModel.DataAnnotations;
using WoodMasters2.Core.Data.Entities;

namespace WoodMasters2.Areas.Administration.Models
{
    /// <summary>
    /// Users Table Model
    /// </summary>
    public class UsersModel
    {

        /// <summary>
        /// MP Count
        /// </summary>
        
        public int MasterPiecesCount { get; set; }

        
        public string MasterUserName { get; set; }

        
        public string MasterFirstName { get; set; }

       
        public string MasterLastName { get; set; }

        
        public string MasterEmail { get; set; }
    }
}
