using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class ApplicationUser : IdentityUser
    {
 
        public string FullName { get; set; }



    }
}
