using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/* classes adicionadas */
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCWEB.Models
{
    [Table("Artista")] /* Define o nome da Tabela */
    public class Artista
    {
        public Artista()
        {
            this.Ranks = new HashSet<Rank>();
        }

        public virtual ICollection<Rank> Ranks { get; set; }

        /* Define como chave primária */
        [Key]
        /* Define que será auto incrementado */
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Display(Name = "ID")]
        public int id { get; set; }

        /* Define o nome que será visualizado pelo Usuário */
        [Display(Name = "Nome do Artista")]
        /* Define a quantidade máxima de caracteres permitida */
        [StringLength(35, ErrorMessage = "Tamanho maximo de 35 caracteres")]
        /* Define que este campo será obrigatório */
        [Required(ErrorMessage = "Campo Nome do Artista Obrigatório")] 
        public string nome { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "Campo Nascimento é obrigatório")]
        public DateTime nascimento { get; set; }
    }
}