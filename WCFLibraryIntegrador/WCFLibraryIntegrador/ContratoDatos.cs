using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFLibraryIntegrador
{
    [DataContract]
    public class ContratoDatos
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Ap1 { get; set; }
        [DataMember]
        public string Ap2 { get; set; }
        [DataMember]
        public int Edad { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }

        ///Usuario
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Nick { get; set; }
        
    }
    [DataContract]
    public class Sesion
    {
        [DataMember]
        public EstadosSesion Estado { get; set; }
        [DataMember]
        public string Token { get; set; }
    }
    [DataContract]
    public enum EstadosSesion : int
    {
        [EnumMember]
        NoValido = 0,
        [EnumMember]
        Valido = 1,
    }
    [DataContract]
    public class Verificador
    {
        [DataMember]
        public Sesion Sesion { get; set; }
        [DataMember]
        public ContratoDatos Usuario { get; set; }
    }
}
