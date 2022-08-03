using Microsoft.AspNetCore.Identity;

namespace FinalProject.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool isdeleted { get; set; }

        public ICollection<ShopList> ShopLists { get; set; }
    }
}
