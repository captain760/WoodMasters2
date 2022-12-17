using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Data;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Data.Enums;
using WoodMasters2.Core.Models.MasterPieces;
using WoodMasters2.Core.Services;

namespace WoodMaster2.UnitTests
{
    [TestFixture]
    public class MasterPieceServiceTests
    {
        private MasterPieceService masterPieceService;
        private WMDbContext appDbContext;
        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<WMDbContext>()
                .UseInMemoryDatabase("WoodMasterDB")
                .Options;
            appDbContext = new WMDbContext(contextOptions);
            appDbContext.Database.EnsureDeleted();
            appDbContext.Database.EnsureCreated();
        }
        [Test]
        public async Task TestGetFavoritesAsync()
        {
            var masterPieceService = new MasterPieceService(appDbContext);
            await appDbContext.AddAsync(new Master()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591f",
                UserName = "captain767",
                NormalizedUserName = "CAPTAIN767",
                Email = "b_eftimov7@yahoo.com",
                NormalizedEmail = "B_EFTIMOV7@YAHOO.COM",
                FirstName = "Boriss",
                LastName = "Eftimovv",
                Favorites = new List<Favorite>()
                {
                new Favorite(){Id = 201, Value = 101 },
                new Favorite(){Id = 202, Value = 102 }
                }
            });
            await appDbContext.AddRangeAsync(new List<MasterPiece>()
            {
                new MasterPiece(){ Id = 101, Name = "qtyfglbjh",Width=1,Length = 1,Depth = 1,Description = "ghfhjgj", ImageURL = "gjjhgj",Price=1,Quantity = 1,MasterId ="6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",CategoryId = 1, WoodId =1},
                new MasterPiece(){ Id = 102, Name = "qtyfglbhbjh",Width=1,Length = 1,Depth = 1,Description = "ghfhjgj", ImageURL = "gjjhgj",Price=1,Quantity = 1,MasterId ="6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",CategoryId = 1, WoodId =1}
            });
            await appDbContext.SaveChangesAsync();
                 
            var favorites = await masterPieceService.GetFavoritesAsync("6d5800ce-d726-4fc8-83d9-d6b3ac1f591f");

            Assert.IsTrue(favorites.Count() == 2);

        }

        [Test]
        public async Task TestGetWoodsAsync()
        {
            var masterPieceService = new MasterPieceService(appDbContext);
            var woods = await masterPieceService.GetWoodsAsync();

            Assert.IsNotNull(woods);
            Assert.IsTrue(woods.Any(x => x.Type == "Acer"));
        }

        [Test]
        public async Task TestGetCategoriesAsync()
        {
            var masterPieceService = new MasterPieceService(appDbContext);
            var categories = await masterPieceService.GetCategoriesAsync();

            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Any(x=>x.Name == "Intarsia"));
        }


        [Test]
        public async Task TestGetAllMasterPiecesAsync()
        {
            var masterPieceService = new MasterPieceService(appDbContext);
            await appDbContext.AddRangeAsync(new List<MasterPiece>()
            {
                new MasterPiece(){ Id = 101, Name = "qtyfglbjh",Width=1,Length = 1,Depth = 1,Description = "ghfhjgj", ImageURL = "gjjhgj",Price=1,Quantity = 1,MasterId ="6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",CategoryId = 1, WoodId =1},
                new MasterPiece(){ Id = 102, Name = "qtyfglbhbjh",Width=1,Length = 1,Depth = 1,Description = "ghfhjgj", ImageURL = "gjjhgj",Price=1,Quantity = 1,MasterId ="6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",CategoryId = 1, WoodId =1},
                new MasterPiece(){ Id = 103, Name = "qtyjkfglbjh",Width=1,Length = 1,Depth = 1,Description = "ghfhjgj", ImageURL = "gjjhgj",Price=1,Quantity = 1,MasterId ="6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",CategoryId = 1, WoodId =1},
                new MasterPiece(){ Id = 104, Name = "qtyfgfrdlbjh",Width=1,Length = 1,Depth = 1,Description = "ghfhjgj", ImageURL = "gjjhgj",Price=1,Quantity = 1,MasterId ="6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",CategoryId = 1, WoodId =1}
                
            });
            await appDbContext.SaveChangesAsync();
            var MPCollection = await masterPieceService.GetAllMasterPiecesAsync();

             Assert.That(9, Is.EqualTo(MPCollection.Count()));/// 5 pre-defined + 4 just added = 9
            
        }

        [Test]
        public async Task TestDeleteAsync()
        {
            var masterPieceService = new MasterPieceService(appDbContext);
            await appDbContext.AddRangeAsync(new List<MasterPiece>()
            {
                new MasterPiece(){ Id = 101, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 1, WoodId =1},
                new MasterPiece(){ Id = 103, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 2, WoodId =1},
                new MasterPiece(){ Id = 105, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 3, WoodId =1},
                new MasterPiece(){ Id = 102, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 4, WoodId =1}
            });
            await appDbContext.SaveChangesAsync();
            await masterPieceService.DeleteAsync(105);
            var masterPiecesCollection = await appDbContext.MasterPieces.ToListAsync();
            
            Assert.IsTrue(masterPiecesCollection.FirstOrDefault(mp=>mp.Id ==105).IsDeleted);
        }

            [Test]
        public async Task TestAllCrafts()
        {
            var masterPieceService = new MasterPieceService(appDbContext);
            await appDbContext.AddRangeAsync(new List<MasterPiece>()
            {
                new MasterPiece(){ Id = 101, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 1, WoodId =1},
                new MasterPiece(){ Id = 103, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 2, WoodId =1},
                new MasterPiece(){ Id = 105, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 3, WoodId =1},
                new MasterPiece(){ Id = 102, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 4, WoodId =1}
            });
            await appDbContext.SaveChangesAsync();
            var sorting = MasterPieceSorting.Newest;
            var MPCollection = await masterPieceService.AllCrafts("Woodturning",null,sorting,1,3);
            var craftsCount = MPCollection.TotalMasterPieces;
            Assert.That(2, Is.EqualTo(craftsCount));//Id=3(pre-configured) and Id=103
            Assert.That(MPCollection.CraftPieces.Any(mp => mp.Id == 3), Is.True);

        }


        [Test]
        public async Task TestAddMasterPieceToFavorites()
        {
            var masterPieceService = new MasterPieceService(appDbContext);
            await appDbContext.AddAsync(new Master()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591f",
                UserName = "captain767",
                NormalizedUserName = "CAPTAIN767",
                Email = "b_eftimov7@yahoo.com",
                NormalizedEmail = "B_EFTIMOV7@YAHOO.COM",
                FirstName = "Boriss",
                LastName = "Eftimovv"
            });
            await appDbContext.AddAsync(new MasterPiece()
            {
                Id = 101,
                Name = "Flowers2",
                Width = 60,
                Length = 40,
                Depth = 10,
                ImageURL = "https://www.harvardmagazine.com/sites/default/files/styles/4x3_main/public/img/article/0613/ja13_page_31_02.jpg",
                Price = 2000,
                Quantity = 1,
                IsDeleted = false,
                MasterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591f",
                Description = "Flowers and leaves carved as a 3D model",
                CategoryId = 1,
                WoodId = 5
            });

            await appDbContext.SaveChangesAsync();

            await masterPieceService.AddMasterPieceToFavoritesAsync(101, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591f");

            var user = await appDbContext.Users.FindAsync("6d5800ce-d726-4fc8-83d9-d6b3ac1f591f");
            var favorite = user.Favorites.FirstOrDefault(mp => mp.Value == 101);
            Assert.IsNotNull(user);
            Assert.IsNotNull(favorite);
            Assert.IsTrue(favorite.Value == 101);
           
        }



        [Test]
        public async Task TestAddingMasterPiece()
        {
            var masterPieceService = new MasterPieceService(appDbContext);

            await masterPieceService.AddMasterPieceAsync(new AddMasterPieceViewModel()
            {
                Name = "Flowers101",
                Width = 60,
                Length = 40,
                Depth = 10,
                ImageURL = "https://www.harvardmagazine.com/sites/default/files/styles/4x3_main/public/img/article/0613/ja13_page_31_02.jpg",
                Price = 2000,
                Quantity = 1,
                Description = "Flowers and leaves carved as a 3D model",
                CategoryId = 1,
                WoodId = 5
            }, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            await appDbContext.SaveChangesAsync();

            var masterPiece = await appDbContext.MasterPieces.FirstOrDefaultAsync(m => m.MasterId == "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" && m.Name == "Flowers101" && m.ImageURL == "https://www.harvardmagazine.com/sites/default/files/styles/4x3_main/public/img/article/0613/ja13_page_31_02.jpg");
            Assert.NotNull(masterPiece);
            Assert.That(masterPiece.Description, Is.EqualTo("Flowers and leaves carved as a 3D model"));
        }

        [Test]
        public async Task TestLast3MasterPiecesNumberAndOrder()
        {
            var masterPieceService = new MasterPieceService(appDbContext);
            await appDbContext.AddRangeAsync(new List<MasterPiece>()
            {
                new MasterPiece(){ Id = 101, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 1, WoodId =1},
                new MasterPiece(){ Id = 103, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 1, WoodId =1},
                new MasterPiece(){ Id = 105, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 1, WoodId =1},
                new MasterPiece(){ Id = 102, Name = "",Width=0,Length = 0,Depth = 0,Description = "", ImageURL = "",Price=1,Quantity = 1,MasterId ="",CategoryId = 1, WoodId =1}
            });
            await appDbContext.SaveChangesAsync();
            var MPCollection = await masterPieceService.GetLast3MasterPiecesAsync();

            Assert.That(3, Is.EqualTo(MPCollection.Count()));
            Assert.That(MPCollection.Any(mp => mp.Id == 101), Is.False);
        }

        [Test]
        public async Task TestMasterPieceEdit()
        {
            var masterPieceService = new MasterPieceService(appDbContext);
            await appDbContext.AddAsync(new MasterPiece()
            {
                Id = 101,
                Name = "",
                Width = 0,
                Length = 0,
                Depth = 0,
                Description = "",
                ImageURL = "",
                Price = 1,
                Quantity = 1,
                MasterId = "",
                CategoryId = 1,
                WoodId = 1
            });
            await appDbContext.SaveChangesAsync();
            await masterPieceService.EditMasterPieceAsync(new EditMasterPieceViewModel()
            {
                Id = 101,
                Name = "",
                Width = 0,
                Length = 0,
                Depth = 0,
                Description = "Edited text",
                ImageURL = "",
                Price = 1,
                Quantity = 1,
                CategoryId = 1,
                WoodId = 1
            });
            var masterPiece = await appDbContext.MasterPieces.FindAsync(101);
            Assert.That(masterPiece.Description, Is.EqualTo("Edited text"));
        }


            [TearDown]
        public void TearDowd()
        {
            appDbContext.Dispose();
        }
    }
}
