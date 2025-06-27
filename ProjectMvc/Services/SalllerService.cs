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

        /*metedo sicrono
        public List<Saller> FindAll()
        {
            return _context.Saller.ToList();
        }:*/

        //Metodo assincrono
        public async Task<List<Saller>> FindAllAsync()
        {
            return await _context.Saller.ToListAsync();
        }


        //adiciona um novo vendedor ao banco de dados
        public async  Task InsertAsync(Saller obj)
        { 
            _context.Add(obj);
            await _context.SaveChangesAsync();
          
        }
        public  async Task<Saller> FindByIdAsync(int id)
        {

            return await _context.Saller.Include(obj=>obj.Departament).FirstOrDefaultAsync(obj => obj.Id== id);
        }
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Saller.FindAsync(id);
            _context.Saller.Remove(obj);
            await _context.SaveChangesAsync(); 
        }
        public async Task UpadeteAsync(Saller obj)
        {
            bool hasAny = await _context.Saller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
          
        }

    }
}
