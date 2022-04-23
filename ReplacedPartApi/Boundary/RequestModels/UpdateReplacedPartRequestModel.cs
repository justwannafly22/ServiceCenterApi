namespace ReplacedPartApi.Boundary.ReplacedParts.RequestModels
{
    public class UpdateReplacedPartRequestModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        public string AdvancedInfo { get; set; }
    }
}
