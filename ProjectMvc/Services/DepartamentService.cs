using ProjectMvc.Data;
using ProjectMvc.Models;
using System.Linq;

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
        public  List<Departament> findAll()
        {
            //ordenado por nome
            return _context.Departament.OrderBy(x => x.Name).ToList();
        }

     
    }
}
