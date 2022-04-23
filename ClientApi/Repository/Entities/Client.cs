using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientApi.Repository.Entities
{
    public class Client
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("client_name")]
        [Required]
        public string Name { get; set; }

        [Column("client_surname")]
        [Required]
        public string Surname { get; set; }

        [Column("age")]
        [Range(0, 150)]
        [Required]
        public int Age { get; set; }

        [Column("contact_number")]
        [Required]
        public string ContactNumber { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("allow_email_notifications")]
        public bool AllowEmailNotification { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }
    }
}
