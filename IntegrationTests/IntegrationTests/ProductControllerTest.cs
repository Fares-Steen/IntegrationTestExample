using System;
using System.Threading.Tasks;
using IntegrationTests.TestRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Models;
using Newtonsoft.Json;
using S1.Domain;
using S2.Domain.Entities;
using S3.Domain.Entities;

namespace IntegrationTests;

[TestClass]
public class ProductControllerTest
{
    private readonly SetUpTestEnvironment3 _setUpTestEnvironment3;
    private readonly SetUpTestEnvironment2 _setUpTestEnvironment2;
    private readonly SetUpTestEnvironment1 _setUpTestEnvironment1;
    private readonly Service1TestRepository _service1TestRepository;
    private readonly Service2TestRepository _service2TestRepository;
    private readonly Service3TestRepository _service3TestRepository;


    public ProductControllerTest()
    {

        _setUpTestEnvironment2 = new SetUpTestEnvironment2();
        _setUpTestEnvironment3 = new SetUpTestEnvironment3();
        _setUpTestEnvironment1 = new SetUpTestEnvironment1(_setUpTestEnvironment2.TestClient,_setUpTestEnvironment3.TestClient);

        _service1TestRepository = new Service1TestRepository(_setUpTestEnvironment1.service1DbContext);
        _service2TestRepository = new Service2TestRepository(_setUpTestEnvironment2.service2DbContext);
        _service3TestRepository = new Service3TestRepository(_setUpTestEnvironment3.service3DbContext);
    }

    [TestMethod]
    public async Task TestMethod1()
    {
        //Arrange
        Product expectedProduct = new Product {Name = "Beans", Description = "very big beans" };
        await _service1TestRepository.InjectProductInDb(expectedProduct);

        ProductDetails UnexpectedProductDetails = new ProductDetails { Price = 200, Size = 3, ProductId = Guid.NewGuid() };
        await _service2TestRepository.InjectProductDetailsInDb(UnexpectedProductDetails);

        ProductDetails expectedProductDetails = new ProductDetails { Price = 100, Size = 2, ProductId = expectedProduct.Id };
        await _service2TestRepository.InjectProductDetailsInDb(expectedProductDetails);

        User UNexpectedUser1 = new User { FirstName = "Jarek", LastName = "unknown", ProductId = Guid.NewGuid() };
        await _service3TestRepository.InjectUserInDb(UNexpectedUser1);

        User UNexpectedUser2 = new User { FirstName = "Fares", LastName = "Steen", ProductId = Guid.NewGuid() };
        await _service3TestRepository.InjectUserInDb(UNexpectedUser2);

        User expectedUser =new User { FirstName="Jarek",LastName="unknown", ProductId=expectedProduct.Id};
        await _service3TestRepository.InjectUserInDb(expectedUser );


        //Act
        var response = await _setUpTestEnvironment1.TestClient.GetAsync($"/Product/GetFull?id={expectedProduct.Id}");
        var result = await response.Content.ReadAsStringAsync();

        var fullProduct =
            JsonConvert.DeserializeObject<FullProductModel>(result);


        //Assert
        Assert.IsNotNull(fullProduct);
        Assert.IsNotNull(fullProduct.ProductModel);
        Assert.AreEqual(expectedProduct.Id,fullProduct.ProductModel.Id);
        Assert.AreEqual(expectedProduct.Description,fullProduct.ProductModel.Description);
        Assert.AreEqual(expectedProduct.Name,fullProduct.ProductModel.Name);

        Assert.IsNotNull(fullProduct.ProductDetailsModel);
        Assert.AreEqual(expectedProductDetails.Id,fullProduct.ProductDetailsModel.Id);
        Assert.AreEqual(expectedProductDetails.Price,fullProduct.ProductDetailsModel.Price);
        Assert.AreEqual(expectedProductDetails.Size,fullProduct.ProductDetailsModel.Size);

        Assert.IsNotNull(fullProduct.UserModel);
        Assert.AreEqual(expectedUser.Id,fullProduct.UserModel.Id);
        Assert.AreEqual(expectedUser.FirstName,fullProduct.UserModel.FirstName);
        Assert.AreEqual(expectedUser.LastName,fullProduct.UserModel.LastName);

        
    }
}