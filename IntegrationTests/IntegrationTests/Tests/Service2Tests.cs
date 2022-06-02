using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntegrationTests.Setup;
using IntegrationTests.TestRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using S2.Domain.Entities;

namespace IntegrationTests.Tests;

[TestClass]
public class Service2Tests
{
    private readonly SetUpTestEnvironment2 _setUpTestEnvironment2;
    private readonly Service2TestRepository _service2TestRepository;

    public Service2Tests()
    {
        _setUpTestEnvironment2 = new SetUpTestEnvironment2();
        _service2TestRepository = new Service2TestRepository(_setUpTestEnvironment2.service2DbContext);
    }

    [TestMethod]
    public async Task GetProductDetails()
    {
        ProductDetails expectedProductDetails1 = new ProductDetails { Price = 100, Size = 2, ProductId =Guid.NewGuid() };
        await _service2TestRepository.InjectProductDetailsInDb(expectedProductDetails1); 
        ProductDetails expectedProductDetails2 = new ProductDetails { Price = 200, Size = 3, ProductId =Guid.NewGuid() };
        await _service2TestRepository.InjectProductDetailsInDb(expectedProductDetails2);
        
        //Act
        var response = await _setUpTestEnvironment2.TestClient.GetAsync($"/ProductDetails/GetAll");
        var result = await response.Content.ReadAsStringAsync();
        
        var productsDetails =
            JsonConvert.DeserializeObject<List<ProductDetails>>(result);
        
        Assert.AreEqual(2,productsDetails.Count);
        Assert.AreEqual(expectedProductDetails1.Price,productsDetails[0].Price);
        Assert.AreEqual(expectedProductDetails2.Price,productsDetails[1].Price);

    }
}