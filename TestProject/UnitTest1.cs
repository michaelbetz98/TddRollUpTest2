using TddRollUpTest;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly ProductManager _productManager;

        public UnitTest1()
        {
            _productManager = new ProductManager();
        }
        [Fact]
        public void Gtin4_Variant2_Product1()
        {
            List<ProductInputData> data = new List<ProductInputData>();
            data.Add(new ProductInputData("g1", "v1", "p1", 100f));
            data.Add(new ProductInputData("g2", "v1", "p1", 100f));
            data.Add(new ProductInputData("g3", "v2", "p1", 100f));
            data.Add(new ProductInputData("g4", "v2", "p1", 100f));
            _productManager.ReadData(data);
            NameValueOutput[] result = _productManager.GetEOneForAll();
            Assert.Equal("p1", result[0].name);
            Assert.Equal(100f, result[0].price);
        }

        [Fact]
        public void Gtin5_Variant2_Product1()
        {
            List<ProductInputData> data = new List<ProductInputData>();
            data.Add(new ProductInputData("g1", "v1", "p1", 100f));
            data.Add(new ProductInputData("g2", "v1", "p1", 100f));
            data.Add(new ProductInputData("g3", "v2", "p1", 100f));
            data.Add(new ProductInputData("g4", "v2", "p1", 100f));
            data.Add(new ProductInputData("g5", "v2", "p1", 100f));
            _productManager.ReadData(data);
            NameValueOutput[] result = _productManager.GetEOneForAll();
            Assert.Equal("p1", result[0].name);
            Assert.Equal(100f, result[0].price);
        }

        [Fact]
        public void Gtin5_Variant3_Product1()
        {
            List<ProductInputData> data = new List<ProductInputData>();
            data.Add(new ProductInputData("g1", "v1", "p1", 100f));
            data.Add(new ProductInputData("g2", "v1", "p1", 100f));
            data.Add(new ProductInputData("g3", "v2", "p1", 100f));
            data.Add(new ProductInputData("g4", "v2", "p1", 100f));
            data.Add(new ProductInputData("g5", "v3", "p1", 100f));
            _productManager.ReadData(data);
            NameValueOutput[] result = _productManager.GetEOneForAll();
            Assert.Equal("p1", result[0].name);
            Assert.Equal(100f, result[0].price);
        }

        [Fact]
        public void Gtin5_Product2()
        {
            List<ProductInputData> data = new List<ProductInputData>();
            data.Add(new ProductInputData("g1", "v1", "p1", 100f));
            data.Add(new ProductInputData("g2", "v1", "p1", 100f));
            data.Add(new ProductInputData("g3", "v2", "p1", 100f));
            data.Add(new ProductInputData("g4", "v2", "p1", 100f));
            data.Add(new ProductInputData("g5", "v3", "p2", 100f));
            _productManager.ReadData(data);
            NameValueOutput[] result = _productManager.GetEOneForAll();
            Assert.Equal("p1", result[0].name);
            Assert.Equal(100f, result[0].price);
            Assert.Equal("p2", result[1].name);
            Assert.Equal(100f, result[1].price);
        }

        [Fact]
        public void Gtin5_Product1_Null()
        {
            List<ProductInputData> data = new List<ProductInputData>();
            data.Add(new ProductInputData("g1", "v1", "p1", null));
            data.Add(new ProductInputData("g2", "v1", "p1", 100f));
            data.Add(new ProductInputData("g3", "v2", "p1", 100f));
            data.Add(new ProductInputData("g4", "v2", "p1", 100f));
            _productManager.ReadData(data);
            NameValueOutput[] result = _productManager.GetEOneForAll();
            //Assert.Equal(2, result.Count());
            Assert.Equal("g2", result[0].name);
            Assert.Equal(100f, result[0].price);
            Assert.Equal("v2", result[1].name);
            Assert.Equal(100f, result[1].price);
        }

        [Fact]
        public void Gtin5_Product2_Null()
        {
            List<ProductInputData> data = new List<ProductInputData>();
            data.Add(new ProductInputData("g1", "v1", "p1", null));
            data.Add(new ProductInputData("g2", "v1", "p1", 100f));
            data.Add(new ProductInputData("g3", "v2", "p1", 100f));
            data.Add(new ProductInputData("g4", "v2", "p1", 100f));
            data.Add(new ProductInputData("g5", "v3", "p1", 100f));
            data.Add(new ProductInputData("g6", "v3", "p1", null));
            _productManager.ReadData(data);
            NameValueOutput[] result = _productManager.GetEOneForAll();
            Assert.Equal("p1", result[0].name);
            Assert.Equal(100f, result[0].price);
        }

        [Fact]
        public void Different_From_All_Branches()//no va
        {
            List<ProductInputData> data = new List<ProductInputData>();
            data.Add(new ProductInputData("g1", "v1", "p1", 50f));
            data.Add(new ProductInputData("g2", "v1", "p1", 70f));
            data.Add(new ProductInputData("g3", "v2", "p1", 100f));
            data.Add(new ProductInputData("g4", "v2", "p1", 90f));
            _productManager.ReadData(data);
            NameValueOutput[] result = _productManager.GetEOneForAll();//gli restituisce in ordine sbagliato
            //Assert.Equal(4, result.Count());
            Assert.Equal("p1", result[0].name);
            Assert.Equal(50f, result[0].price);
            Assert.Equal("v2", result[1].name);
            Assert.Equal(90f, result[1].price);
            Assert.Equal("g2", result[2].name);
            Assert.Equal(70f, result[2].price);
            Assert.Equal("g3", result[3].name);
            Assert.Equal(100f, result[3].price);
        }
        //g2 100
        //v2 100
        //g5 100
    }
}