using Microsoft.EntityFrameworkCore;
using ProjectMvc.Data;
using ProjectMvc.Models;
using ProjectMvc.Services.Exception;

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

        //adiciona um novo vendedor ao banco de dados
        public void Insert(Saller obj)
        { 
            _context.Add(obj);
            _context.SaveChanges();
          
        }
        public Saller FindById(int id)
        {

            return _context.Saller.Include(obj=>obj.Departament).FirstOrDefault(obj => obj.Id== id);
        }
        public void Remove(int id)
        {
            var obj = _context.Saller.Find(id);
            _context.Saller.Remove(obj);
            _context.SaveChanges(); 
        }
        public void Upadete(Saller obj)
        {
            if(!_context.Saller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
          
        }

    }
}
