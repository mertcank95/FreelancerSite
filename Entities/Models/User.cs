using Entities.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        [NotMapped]
        public List<string> Skills { get; set; }
        public string SkilsList
        {
            get { return JsonSerializer.Serialize(Skills); }
            set { Skills = JsonSerializer.Deserialize<List<string>>(value); }
        }
        public String? Address1 { get; set; }
        public String? Address2 { get; set; }
        public String? City { get; set; }
        public String? Country { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public Company? Company { get; set; }
    }
}