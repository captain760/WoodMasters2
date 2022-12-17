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

        /// <summary>
        /// Master's UserName
        /// </summary>
        public string MasterUserName { get; set; } = null!;

        /// <summary>
        /// Master's First Name
        /// </summary>
        public string MasterFirstName { get; set; } = null!;

        /// <summary>
        /// Master's Last Name
        /// </summary>
        public string MasterLastName { get; set; } = null!;

        /// <summary>
        /// Master's Email
        /// </summary>
        public string MasterEmail { get; set; } = null!;
    }
}
