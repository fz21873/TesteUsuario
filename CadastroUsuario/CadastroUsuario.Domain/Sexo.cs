using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CadastroUsuario.Domain
{
    public class Sexo
    {
        [Key]
        public int IdSexo { get; set; }
        [Required]
        [StringLength(15)]
        public string Descricao { get; set; }

       
       
    }
}
