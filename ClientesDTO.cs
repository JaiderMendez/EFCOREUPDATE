using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuSuperService.DTOS
{
    public class ClientesDTO
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool? Deleted { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset? DateBirth { get; set; }
        public string Apellido { get; set; }
        public int Ctrl { get; set; }
        public double? Nivel { get; set; }
        public double? NumeroEnvios { get; set; }
        public string Image { get; set; }
        public bool? RecompensaUsada { get; set; }
        public string Ciudad { get; set; }
        public string Cp { get; set; }
        public string Colonia { get; set; }
        public string Referencia { get; set; }
        public string Estado { get; set; }
        public string Calle { get; set; }
        public string IdConvenio { get; set; }
        public double? Coin { get; set; }
    }
}
