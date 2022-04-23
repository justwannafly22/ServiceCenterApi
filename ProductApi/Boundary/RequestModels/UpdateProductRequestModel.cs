namespace ProductApi.Boundary.RequestModels
{
    public class UpdateProductRequestModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
