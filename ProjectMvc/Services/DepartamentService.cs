using ProjectMvc.Data;
using ProjectMvc.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectMvc.Services
{
    public class DepartamentService
    {
        private readonly ProjectMvcContext _context;

        public DepartamentService(ProjectMvcContext context)
        {
            _context = context;
        }


        //metodo que retona dos os departamentos
        //metodo sicrono
        /*public  List<Departament> findAll()
        {
            //ordenado por nome
            return _context.Departament.OrderBy(x => x.Name).ToList();
        }*/

        // metodo assicrono
        public async Task <List<Departament>> findAllAssync()
        {
            //ordenado por nome
            return await _context.Departament.OrderBy(x => x.Name).ToListAsync();
        }


    }
}
