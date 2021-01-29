using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CadastroUsuario.Domain
{
   public class Usuario
    {
        [Key]
        public long IdUsuario { get; set; }
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNacimento { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Senha { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public int IdSexo { get; set; }

      
    }
}
