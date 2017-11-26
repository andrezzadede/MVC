using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWEB.Models
{
    [Table("Rank")]
    public class Rank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Evento")]
        [Required(ErrorMessage = "Selecione o Evento")]
        public int eventoId { get; set; }
        public virtual Evento apresentacao { get; set; }
        public virtual string eventoTema { get { return apresentacao.tema; } }

        [Display(Name = "Artista Id")]
        [Required(ErrorMessage = "Selecione o Artista")]
        public int artistaId { get; set; }
        public virtual Artista artista { get; set; }
        public virtual string eventoArtista { get { return artista.nome; } }

        [Display(Name = "Pontos")]
        /* Define um intervalo de valores */
        [Range(0, 10, ErrorMessage = "Permite valores de 0 á 10")]
        public int pontos { get; set; }        
    }
}