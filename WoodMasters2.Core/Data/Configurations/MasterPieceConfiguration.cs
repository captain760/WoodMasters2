using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Data.Entities;

namespace WoodMasters2.Core.Data.Configurations
{
    internal class MasterPieceConfiguration : IEntityTypeConfiguration<MasterPiece>
    {
        public void Configure(EntityTypeBuilder<MasterPiece> builder)
        {
            builder.HasData(SeedMasterPieces());
        }
        private List<MasterPiece> SeedMasterPieces()
        {
            var masterPieces = new List<MasterPiece>();
            var masterPiece = new MasterPiece()
            {
                Id = 1,
                Name = "Flowers",
                Width = 60,
                Length = 40,
                Depth = 10,
                ImageURL = "https://www.harvardmagazine.com/sites/default/files/styles/4x3_main/public/img/article/0613/ja13_page_31_02.jpg",
                Price = 2000,
                Quantity = 1,
                IsDeleted = false,
                MasterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Description="Flowers and leaves carved as a 3D model",
                CategoryId = 1,
                WoodId = 5,
                
            };
            masterPieces.Add(masterPiece);

            masterPiece = new MasterPiece()
            {
                Id = 2,
                Name = "Tribal Mosaic",
                Width = 50,
                Length = 50,
                Depth = 5,
                ImageURL = "https://i0.wp.com/100things2do.ca/wp-content/uploads/2021/06/scrapwood-snowflake-12.jpg",
                Price = 50,
                Quantity = 2,
                IsDeleted = false,
                MasterId = "dea12856-c198-4129-b3f3-b893d8395082",
                Description = "A beautiful tribal mosaics build from stained woods",
                CategoryId = 4,
                WoodId = 3
            };
            masterPieces.Add(masterPiece);

            masterPiece = new MasterPiece()
            {
                Id = 3,
                Name = "Wooden Bowl",
                Width = 20,
                Length = 20,
                Depth = 12,
                ImageURL = "https://www.dougsturnings.com/wp-content/uploads/2020/04/Doug-Heck-Maryland-Woodturner-8636-1024x682-1.jpg",
                Price = 100,
                Quantity = 4,
                IsDeleted = false,
                MasterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Description = "A wooden bowl from cedar tree",
                CategoryId = 2,
                WoodId =8
            };
            masterPieces.Add(masterPiece);

            masterPiece = new MasterPiece()
            {
                Id = 4,
                Name = "Crate",
                Width = 40,
                Length = 60,
                Depth = 40,
                ImageURL = "https://www.ana-white.com/sites/default/files/wood-crate-how-to-build-1.jpg",
                Price = 20,
                Quantity = 100,
                IsDeleted = false,
                MasterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Description = "A wooden crate to store your staff all around!!!",
                CategoryId = 7,
                WoodId=3
            };
            masterPieces.Add(masterPiece);

            return masterPieces;
        }
    }
}
