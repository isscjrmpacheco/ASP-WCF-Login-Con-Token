using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLibraryIntegrador
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.


        //PONER  EL SERVICE CONTRACT DE LO CONTRARIO NO LO RECONOCERA EL WCF
    [ServiceContract]
    public interface IContratoUsuarios
    {
        [OperationContract]
        long RegistrarUsuario(ContratoDatos Usuario);

        [OperationContract]
        long h(ContratoDatos u);

        // TODO: agregue aquí sus operaciones de servicio
    }
    [ServiceContract(Namespace="ISSC311")]
    public interface IContratoJSUsuarios
    {
        [OperationContract]
        Verificador Login(ContratoDatos Usuario);
        [OperationContract]
        long InsertarUsuario(ContratoDatos Usuario);      
        [OperationContract]
        void Update2(ContratoDatos User);//Devuelve un entero
        [OperationContract]
        List<ContratoDatos> ListaDeBusqueda(string ParametrodeBusqueda);
    }
}
