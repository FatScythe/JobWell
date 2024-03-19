using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Table("Accounts")]
    public class Account: IdentityUser
    {
    }
}
