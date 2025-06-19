using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace ProjectMvc.Models
{
    public class Saller
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name =" Data de Aniversario")]
        [DataType( DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public  DateTime BirthDate { get; set; }
        [DisplayFormat(DataFormatString="{0:F2}")]
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Saller()
        {
        }

        public Saller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddSaller(SalesRecord sr)
        {
            SalesRecords.Add(sr);
        }
        public void RemoveSaller(SalesRecord sr)
        {
            SalesRecords.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr=> sr.Amount);
        }
    }
}
