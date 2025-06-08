using System.Collections.Generic;

namespace ProjectMvc.Models.ViewModels
{
    public class SallesFormViewModel
    {
        public Saller Saller { get; set; }
        public ICollection<Departament> Departments { get; set; }
    }
}
