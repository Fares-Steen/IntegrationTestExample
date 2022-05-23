using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Service1;

namespace IntegrationTests;

[TestClass]
public class ProductControllerTest
{
    private readonly SetUpTestEnvironment setUpTestEnvironment;

    public ProductControllerTest()
    {
        setUpTestEnvironment = new SetUpTestEnvironment();
    }

    [TestMethod]
    public async Task TestMethod1()
    {
        var response= await setUpTestEnvironment.TestClient.GetAsync($"/Product");
        var result = await response.Content.ReadAsStringAsync();
        
        var productFromController =
            JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
    }
}