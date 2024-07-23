using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore; 
using VVCDotNetAPILogin.API.Models;

namespace VVCDotNetAPILogin.API.Data
{
    public class AppDbContext(DbContextOptions options): IdentityDbContext<User>(options);
}