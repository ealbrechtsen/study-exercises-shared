namespace surfs_up_api.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int ZipCode { get; set; }
        public string? City { get; set; }

        //// Foreign Key to AppUser (this links Customer to Identity)
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; } // Navigation property to AppUser
    }
}
