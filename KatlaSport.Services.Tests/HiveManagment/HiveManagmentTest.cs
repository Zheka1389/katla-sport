namespace KatlaSport.Services.Tests.HiveManagment
{
    using System;
    using KatlaSport.DataAccess.ProductStoreHive;
    using KatlaSport.Services.HiveManagement;
    using Moq;
    using Xunit;

    public class HiveManagmentTest
    {
        public Mock<IProductStoreHiveContext> _context;
        public Mock<IUserContext> _userContext;

        //public void Setup()
        //{
        //    _context = new Mock<IProductStoreHiveContext>();
        //    _userContext = new Mock<IUserContext>();
        //}

        [Fact]
        public void CreateHiveManagementServiceWithNullAsParameterTest()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new HiveService(null, null));

            Assert.Equal(typeof(ArgumentNullException), ex.GetType());
        }

        //[Fact]
        //public async Task GetProductCategories_EmptyCollection_Test()
        //{
        //    _context = new Mock<IProductStoreHiveContext>();
        //    _userContext = new Mock<IUserContext>();
        //    _context.Setup(c => c.Hives).ReturnsEntitySet(new StoreHive[1]);

        //    var service = new HiveService(_context.Object, _userContext.Object);

        //    var hivies = await service.GetHivesAsync();

        //    Assert.Equal(0, hivies.Count);
    }

    //[Fact]
    //public void AddProductCategoryTest()
    //{
    //    var context = new Mock<IProductCatalogueContext>();
    //    var service = new CatalogueManagementService(context.Object);

    //    service.AddProductCategory();
    //}
}

