
using System.Linq;
using System.Collections.Generic;

namespace ProjectMvc.Models
{
    public class Departament
    {
      

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Saller> Sallers { get; set; } = new List<Saller>();

        public Departament()
        {
        }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddSeller(Saller seller)
        {
            Sallers.Add(seller);
        }

        public double TotalSalles(DateTime inital, DateTime final)
        {
            return Sallers.Sum(seller => seller.TotalSales(inital, final));
        }

    }
}
