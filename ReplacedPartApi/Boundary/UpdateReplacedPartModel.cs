using MediatR;
using ReplacedPartApi.Boundary.ReplacedParts.RequestModels;
using System;

namespace ReplacedPartApi.Boundary.ReplacedParts
{
    public class UpdateReplacedPartModel : IRequest<ReplacedPartResponseModel>
    {
        public UpdateReplacedPartModel(UpdateReplacedPartRequestModel model, Guid id) 
        {
            Id = id;
            Name = model.Name;
            Price = model.Price;
            Count = model.Count;
            AdvancedInfo = model.AdvancedInfo;
        }

        public UpdateReplacedPartModel(UpdateReplacedPartRequestModel model) 
        {
            Name = model.Name;
            Price = model.Price;
            Count = model.Count;
            AdvancedInfo = model.AdvancedInfo;
        }

        public UpdateReplacedPartModel() { }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        public string AdvancedInfo { get; set; }
    }
}
