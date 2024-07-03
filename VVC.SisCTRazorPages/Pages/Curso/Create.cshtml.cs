using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VVC.CursoRazorPages.Models;
using VVC.SisCTRazorPages.Data;

namespace VVC.SisCTRazorPages.Pages_Curso
{
    public class CreateModel : PageModel
    {
        private readonly VVC.SisCTRazorPages.Data.ApplicationDbContext _context;

        public CreateModel(VVC.SisCTRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Curso Curso { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cursos.Add(Curso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
