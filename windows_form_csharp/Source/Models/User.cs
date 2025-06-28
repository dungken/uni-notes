using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Source.Models
{
    public class User 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string? ProvinceCode { get; set; }
        public string? DistrictCode { get; set; }
        public string? CommuneCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullAddress { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsEmailVerified { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public bool IsPhoneNumberVerified { get; set; } = false;
        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Cart Cart { get; set; }

        // Navigation property for user roles
        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<UserVoucher> UserVouchers { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
