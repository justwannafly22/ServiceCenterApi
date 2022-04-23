﻿using MediatR;
using System;

namespace RepairApi.Boundary.Repair.RequestModels
{
    public class UpdateRepairRequestModel : IRequest<RepairResponseModel>
    {
        //[Required(ErrorMessage = "Name is a required field.")]
        //[MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Date is a required field.")]
        public DateTime Date { get; set; }

        //[Required(ErrorMessage = "Advanced info is a required field.")]
        //[MaxLength(500, ErrorMessage = "Max length for AdvancedInfo is 500 characters.")]
        public string AdvancedInfo { get; set; }

        //[Required]
        public Guid StatusId { get; set; }
    }
}
