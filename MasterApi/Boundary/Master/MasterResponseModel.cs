using System;

namespace MasterApi.Boundary.Master
{
    public class MasterResponseModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
    }
}
