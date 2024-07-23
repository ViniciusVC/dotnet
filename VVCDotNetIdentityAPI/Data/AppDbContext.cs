//using System;
//using System.Collections.Generic;
//using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; 
using VVCDotNetIdentityAPI.Models; 

namespace VVCDotNetIdentityAPI.Data;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<User>(options); 
