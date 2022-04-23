﻿using ClientApi.Boundary.Client.ResponseModels;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Boundary.Client.RequestModels
{
    public class CreateClientRequestModel : IRequest<ClientResponseModel>
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Surname is 60 characters.")]
        public string Surname { get; set; }

        [Required]
        [Range(0, 150, ErrorMessage = "Age is required and it can`t be lower than 0.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Contact number is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for ContactNumber is 60 characters.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Email is 60 characters.")]
        public string Email { get; set; }

        public bool AllowEmailNotification { get; set; }
    }
}
