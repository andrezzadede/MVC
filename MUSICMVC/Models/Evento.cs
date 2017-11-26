using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/* Classes Adicionadas*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWEB.Models
{
    [Table("Evento")]
    public class Evento
    {
        public Evento()
        {
            this.Ranks = new HashSet<Rank>();
        }

        public virtual ICollection<Rank> Ranks { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Data e Hora")]
        [Required(ErrorMessage = "Campo a Data/Hora é obrigatório")]
        public DateTime dataHora { get; set; }

        [Display(Name = "Tema")]
        [Required(ErrorMessage = "Informe qual o Tema do Evento")]
        public string  tema { get; set; }
    }
}