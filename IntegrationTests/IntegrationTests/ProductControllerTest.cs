using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Service1;

namespace IntegrationTests;

[TestClass]
public class ProductControllerTest
{
    private readonly SetUpTestEnvironment3 setUpTestEnvironment3;
    private readonly SetUpTestEnvironment2 setUpTestEnvironment2;
    private readonly SetUpTestEnvironment1 _setUpTestEnvironment1;

    public ProductControllerTest()
    {
        setUpTestEnvironment2 = new SetUpTestEnvironment2();
        setUpTestEnvironment3 = new SetUpTestEnvironment3();
        _setUpTestEnvironment1 = new SetUpTestEnvironment1(setUpTestEnvironment2.TestClient,setUpTestEnvironment3.TestClient);
    }

    [TestMethod]
    public async Task TestMethod1()
    {
        var response= await _setUpTestEnvironment1.TestClient.GetAsync($"/Product");
        var result = await response.Content.ReadAsStringAsync();
        
        var fullProduct =
            JsonConvert.DeserializeObject<FullProduct>(result);
        
        Assert.IsNotNull(fullProduct);
        Assert.AreEqual(fullProduct.Product.Name, "Product 1");
        Assert.AreEqual(fullProduct.Product.Description, "im a product");
        Assert.AreEqual(fullProduct.ProductDetails.Price, 40);
        
        Assert.AreEqual(fullProduct.User.FirstName, "Test");
        Assert.AreEqual(fullProduct.User.LastName, "Testson");
    }
}