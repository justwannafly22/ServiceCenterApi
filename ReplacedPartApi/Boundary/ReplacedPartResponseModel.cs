using System;

namespace ReplacedPartApi.Boundary
{
    public class ReplacedPartResponseModel
    {
        public Guid Id { get; set; }

        public double TotalPrice { get; set; }

        public string AdvancedInfo { get; set; }
    }
}
