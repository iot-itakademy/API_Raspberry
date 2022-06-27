using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Roles { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Zipcode { get; set; } = null!;
        public string City { get; set; } = null!;
        /// <summary>
        /// (DC2Type:datetime_immutable)
        /// </summary>
        public DateTime CreatedAt { get; set; }
        public string? GoogleAuthenticatorSecret { get; set; }
    }
}
