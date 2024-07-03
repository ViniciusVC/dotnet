using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VVC.CursoRazorPages.Models;
using VVC.SisCTRazorPages.Data;

namespace VVC.SisCTRazorPages.Pages_Aluno
{
    public class IndexModel : PageModel
    {
        private readonly VVC.SisCTRazorPages.Data.ApplicationDbContext _context;

        public IndexModel(VVC.SisCTRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Aluno> Aluno { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Aluno = await _context.Alunos.ToListAsync();
        }
    }
}
