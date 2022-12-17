using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Data;
using WoodMasters2.Core.Data.Entities;
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
        public async Task Test



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
