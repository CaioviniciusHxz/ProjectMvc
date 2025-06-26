using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace ProjectMvc.Models
{
    public class Saller
    {
      
        public int Id { get; set; }


        //Anotação para o campo seja obrigatorio
        [Required(ErrorMessage ="{0} obrigatorio")]
        //Tamnaho do campo
        [StringLength(60, MinimumLength = 3, ErrorMessage ="O tamanho do nome dever ser entre 3 e 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} obrigatorio")]
        [EmailAddress(ErrorMessage ="{0} Valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatorio")]
        [Display(Name =" Data de Aniversario")]
        [DataType( DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public  DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} obrigatorio")]
        [DisplayFormat(DataFormatString="{0:F2}")]
        [Range(100.0, 50000.0, ErrorMessage ="{0} o valor deve ser entre {1} e {2}")]
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
