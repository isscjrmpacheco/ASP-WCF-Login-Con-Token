
using RNConnection.DataAbstractionLayer;
using RNConnection.DataStorageLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace WCFLibraryIntegrador
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ImplementacionNET : ImplementacionJS, IContratoUsuarios
    {
        public long RegistrarUsuario(ContratoDatos Usuario)
        {
            return 1;
        }
        public long h(ContratoDatos Usuario)
        {
            return 1;
        }

    }
    public class ImplementacionJS: IContratoJSUsuarios
    {
        public int validar(string v)
        {
            ContratoDatos c = new ContratoDatos();

            int resp=c.IdUsuario;
            string vToken = "";
            string respuesta_validacion="";
            Verificador verificador = null;
            verificador = new Verificador();
            if (verificador.Sesion == null)
            {
                vToken = "0";
            }
            else
            {
                vToken = verificador.Sesion.Token;
            }
            


            /////CONEXION Y LECTURA XML


            DSL dsl = new DSL();

            string ip = IpCliente();
            string connectionstring = "Data Source=DESKTOP-DMUTBHE;" +//Servidor
            "Initial Catalog = WSPracticaDB66;" +//Base de datos
            "Integrated Security=True;";
            dsl.Open(connectionstring, RNConnection.DataAbstractionLayer.Proveedor.SQLServer);
            dsl.InitialSQLStatement("pa_sel_ValidarAccesoSesion", System.Data.CommandType.StoredProcedure);
            dsl.SetParameterProcedure("@TokenSesion", System.Data.ParameterDirection.Input, eTypes.Entero, resp);
            dsl.SetParameterProcedure("@RespuestaXML", System.Data.ParameterDirection.Input, eTypes.Cadena, "");


            DataTable T1 = dsl.ReturnTable();

            //Rows[0] por que solo se quiere leer el primer valor
            string myXML = T1.Rows[0]["Respuesta"].ToString();//Asigna el resultado de la Tabla leída a una propiedad de l Objeto ObjUsers
           
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(myXML);
            XmlNodeList NodoPrincipal = xmldoc.GetElementsByTagName("Usuario");
            XmlNodeList lista = ((XmlElement)NodoPrincipal[0]).GetElementsByTagName("Validez");
            
            foreach (XmlElement nodo in lista)
            {
                XmlNodeList sesi_token = nodo.GetElementsByTagName("Validez");
                //XmlNodeList sesi_status = nodo.GetElementsByTagName("sesi_status");


               
                for (int i = 0; i < sesi_token.Count; i++)
                {
                    respuesta_validacion = sesi_token[i].InnerText;
                }
            }

            if (respuesta_validacion.Equals("1"))
            {
                resp = 1;
            }
            else
            {
                resp = 0;
            }





            return resp;
        }

        
        public string IpCliente()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties messprop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpointProperty = messprop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string x = endpointProperty.Address;
            return x;
        }
        //NO SÉ COMO VA A SER LA LOGICA DE SEGURIDAD PERO CREO QUE LEEREMOS EL XML :v
        public Verificador Login(ContratoDatos Usuario)
        {
            Usuario.IdUsuario = 4;
            DSL dsl = new DSL();

            string ip = IpCliente();
                string connectionstring = "Data Source=DESKTOP-DMUTBHE;" +//Servidor
                "Initial Catalog = WSPracticaDB66;" +//Base de datos
                "Integrated Security=True;";
                dsl.Open(connectionstring, RNConnection.DataAbstractionLayer.Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.pa_sel_AutenticarUsuario", System.Data.CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Nickname", System.Data.ParameterDirection.Input, eTypes.Cadena,Usuario.Nick);
                dsl.SetParameterProcedure("@Contra", System.Data.ParameterDirection.Input, eTypes.Cadena,Usuario.Password);
            dsl.SetParameterProcedure("@IpCliente", System.Data.ParameterDirection.Input, eTypes.Cadena, ip);

                DataTable T1 = dsl.ReturnTable();

            //Rows[0] por que solo se quiere leer el primer valor
            string myXML = T1.Rows[0]["Respuesta"].ToString();//Asigna el resultado de la Tabla leída a una propiedad de l Objeto ObjUsers
                    string vSesistatus="";
                    string vToken = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(myXML);
            XmlNodeList NodoPrincipal = xmldoc.GetElementsByTagName("Usuarios");
            XmlNodeList lista = ((XmlElement)NodoPrincipal[0]).GetElementsByTagName("Sesion");
            //XmlNodeList nodoe= ((XmlElement)NodoPrincipal[1]).GetElementsByTagName("sesi_token");
            foreach (XmlElement nodo in lista)
            {
                XmlNodeList sesi_token = nodo.GetElementsByTagName("sesi_token");
                XmlNodeList sesi_status = nodo.GetElementsByTagName("sesi_status");
               

                for (int i = 0; i < sesi_status.Count; i++)
                    {
                      vSesistatus= sesi_status[i].InnerText;                                  
                    }
                for (int i = 0; i < sesi_token.Count; i++)
                {
                    vToken = sesi_token[i].InnerText;
                }
            }

            Verificador verificador = null;
            if (vSesistatus.Equals("1"))
            {
                verificador = new Verificador()
                {
                    Sesion = new Sesion()
                    {
                        Estado = EstadosSesion.Valido,
                        Token = vToken
                      
                    }
                };
            }

            else
            {
                verificador = new Verificador()
                {
                    Sesion = new Sesion()
                    {
                        Estado = EstadosSesion.NoValido
                    }
                };
            }



//Autenticar & Leer xml guardar el token
//Con el token guardado mandarlo al  procedimiento validar acceso sesion&Nos va a regresar un XML
//Leer ese xml  si en su válido es 1
//permitir la operacion



            return verificador;
        }

        public long InsertarUsuario(ContratoDatos Usuario)
        {           
                DSL dsl = new DSL();


                string connectionstring = "Data Source=DESKTOP-DMUTBHE;" +//Servidor
                    "Initial Catalog = WSPracticaDB66;" +//Base de datos
                    "Integrated Security=True;";
                dsl.Open(connectionstring, Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.InsertUsuario", System.Data.CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Nombre", System.Data.ParameterDirection.Input, eTypes.Cadena, Usuario.Nombre);
                dsl.SetParameterProcedure("@Apellido1", System.Data.ParameterDirection.Input, eTypes.Cadena, Usuario.Ap1);
                dsl.SetParameterProcedure("@Apellido2", System.Data.ParameterDirection.Input, eTypes.Cadena, Usuario.Ap2);
                dsl.SetParameterProcedure("@Edad", System.Data.ParameterDirection.Input, eTypes.Entero, Usuario.Edad);
                dsl.SetParameterProcedure("@Sexo", System.Data.ParameterDirection.Input, eTypes.Cadena, Usuario.Sexo);
                dsl.SetParameterProcedure("@Email", System.Data.ParameterDirection.Input, eTypes.Cadena, Usuario.Email);
                dsl.SetParameterProcedure("@Username", System.Data.ParameterDirection.Input, eTypes.Cadena, Usuario.Nick);
                dsl.SetParameterProcedure("@Passsword", System.Data.ParameterDirection.Input, eTypes.Cadena, Usuario.Password);
                dsl.ExecuteNonQuery();//Ejecutar
                dsl.Close();
                return 1;
        }

        public void Update2(ContratoDatos User)//Devuelve un entero
        {
            
                DSL dsl = new DSL();


                string connectionstring = "Data Source=DESKTOP-DMUTBHE;" +//Servidor
                    "Initial Catalog = WSPracticaDB66;" +//Base de datos
                    "Integrated Security=True;";
                dsl.Open(connectionstring, Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.updatePersona", System.Data.CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Nombre", System.Data.ParameterDirection.Input, eTypes.Cadena, User.Nombre);
                dsl.SetParameterProcedure("@Apellido1", System.Data.ParameterDirection.Input, eTypes.Cadena, User.Ap1);
                dsl.SetParameterProcedure("@Apellido2", System.Data.ParameterDirection.Input, eTypes.Cadena, User.Ap2);
                dsl.SetParameterProcedure("@Edad", System.Data.ParameterDirection.Input, eTypes.Entero, User.Edad);
                dsl.SetParameterProcedure("@Sexo", System.Data.ParameterDirection.Input, eTypes.Cadena, User.Sexo);
                dsl.SetParameterProcedure("@Email", System.Data.ParameterDirection.Input, eTypes.Cadena, User.Email);
                dsl.SetParameterProcedure("@Username", System.Data.ParameterDirection.Input, eTypes.Cadena, User.Nick);
                dsl.SetParameterProcedure("@Password", System.Data.ParameterDirection.Input, eTypes.Cadena, User.Password);
                dsl.SetParameterProcedure("@IdPersona", System.Data.ParameterDirection.Input, eTypes.Cadena, User.IdPersona);
                dsl.SetParameterProcedure("@IdUsuario", System.Data.ParameterDirection.Input, eTypes.Cadena, User.IdUsuario);
                dsl.ExecuteNonQuery();//Ejecutar
                dsl.Close();
        }


        public List<ContratoDatos> ListaDeBusqueda(string ParametrodeBusqueda)
        {

            /*Aqui va la logica a base de datos*/
            List<ContratoDatos> ListaUser = new List<ContratoDatos>();
            ContratoDatos user = null;

            DSL dsl = new DSL();


            string connectionstring = "Data Source=DESKTOP-DMUTBHE;" +//Servidor
                "Initial Catalog = WSPracticaDB66;" +//Base de datos
                "Integrated Security=True;";
            dsl.Open(connectionstring, Proveedor.SQLServer);
            dsl.InitialSQLStatement("dbo.tabla1", System.Data.CommandType.StoredProcedure);
            dsl.SetParameterProcedure("@param", System.Data.ParameterDirection.Input, eTypes.Cadena, ParametrodeBusqueda);
            //dsl.ExecuteNonQuery();//Ejecutar
            DataTable tblResultados = dsl.ReturnTable();
            for (int i = 0; i < tblResultados.Rows.Count; i++)
            {
                user = new ContratoDatos();
                user.IdPersona = int.Parse(tblResultados.Rows[i]["IdPersona"].ToString());
                user.Nombre = tblResultados.Rows[i]["Nombre"].ToString();
                user.Ap1 = tblResultados.Rows[i]["Apellido1"].ToString();
                user.Ap2 = tblResultados.Rows[i]["Apellido2"].ToString();
                user.Edad = int.Parse(tblResultados.Rows[i]["Edad"].ToString());
                user.Password = tblResultados.Rows[i]["Passsword"].ToString();
                ListaUser.Add(user);

            }
            //dsl.Close();
            return ListaUser;

        }
    }

   

}



//https://www.youtube.com/watch?v=xYs8FZKfvKw