using ProjectMvc.Data;
using ProjectMvc.Models;

namespace ProjectMvc.Services
{
    public class SalllerService
    {
        // readonly faz com que a dependencia não seja alterada 
        private readonly ProjectMvcContext _context;

        public SalllerService(ProjectMvcContext context)
        {
            _context = context;
        }

        public List<Saller> FindAll()
        {
            return _context.Saller.ToList();
        }

    }
}
