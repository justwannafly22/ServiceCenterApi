﻿using MediatR;
using System;

namespace ReplacedPartApi.Boundary.ReplacedParts.RequestModels
{
    public class CreateReplacedPartRequestModel : IRequest<ReplacedPartResponseModel>
    {
        public string Name { get; set; }

        public double Price { get; set; }
        
        public int Count { get; set; }

        public string AdvancedInfo { get; set; }

        public Guid RepairId { get; set; }

        public Guid ProductId { get; set; }
    }
}
