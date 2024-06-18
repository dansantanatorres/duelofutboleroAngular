using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace sigSG.Models
{
    [Table("AUTH_CUENTAS_USUARIOS")]
    public class User
    {
        [Key]
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Nombre1 { get; set; }
        [AllowNull]
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        [AllowNull]
        public string Apellido2 { get; set; }
        [AllowNull]
        public string Rut {  get; set; }
        [AllowNull]
        public string Email { get; set; }
        public string Sexo { get; set; }
        public int IdEstado { get; set; }
        public int IdPerfil { get; set; }
        [AllowNull]
        public string Empresa { get; set; }
    }
}
