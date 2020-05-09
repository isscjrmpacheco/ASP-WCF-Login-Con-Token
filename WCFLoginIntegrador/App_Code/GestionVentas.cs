using RNConnection.DataAbstractionLayer;
using RNConnection.DataStorageLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de GestionVentas
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class GestionVentas : System.Web.Services.WebService
{

    public GestionVentas()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Ventas GenerarVenta(Ventas parametro)
    {
        Ventas respuesta = null;
        DSL dsl = new DSL();
        string cadena = "Data Source = LAPTOP-5SOSB3M3;" + "Initial Catalog = WsLogin;" + " Integrated Security = true;";
        dsl.Open(cadena, Proveedor.SQLServer);
        dsl.InitialSQLStatement("dbo.paGenerarVenta", CommandType.StoredProcedure);
        dsl.SetParameterProcedure("@IdVenta", ParameterDirection.Output, eTypes.Entero, 1);
        dsl.SetParameterProcedure("@IdEmpleado", ParameterDirection.Input, eTypes.Entero, parametro.IdEmpleado);
        dsl.SetParameterProcedure("@IdCliente", ParameterDirection.Input, eTypes.Entero, parametro.IdCliente);
        dsl.SetParameterProcedure("@IdFormaPago", ParameterDirection.Input, eTypes.Entero, parametro.IdFormaDePago);
        dsl.SetParameterProcedure("@TotalVenta", ParameterDirection.Input, eTypes.Cadena, parametro.TotaldeVenta);
        int id = int.Parse(dsl.ExecuteStoredOutPut().ToString());
        int auxid = 0;
        string aux = dsl.ExecuteStoredOutPut().ToString();
        if (id <= 0)

        {
            auxid = int.Parse(aux);
        }
        else
        {
            respuesta = new Ventas()
            {
                IdVentas = auxid
            };
        }
        return respuesta;
    }
    [WebMethod]
    public List<Ventas> ConsultarVentas(Ventas parametro)
    {
        Ventas usu = null;
        Empleado emp = null;
        Cliente cli = null;
        FormaDePago fp = null;
        string Cadena = "Data Source = LAPTOP-5SOSB3M3;" + "Initial Catalog = WsLogin;" + " Integrated Security = true;";
        DSL dsl = new DSL();
        dsl.Open(Cadena, Proveedor.SQLServer);
        dsl.InitialSQLStatement("dbo.paConsultarVenta", System.Data.CommandType.StoredProcedure);
        dsl.SetParameterProcedure("@IdVenta", System.Data.ParameterDirection.Input, eTypes.Cadena, parametro.IdVentas);

        List<Ventas> res = new List<Ventas>();
        System.Data.DataTable table = dsl.ReturnTable();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            emp = new Empleado();
            emp.IdEmpleado = (int)table.Rows[i]["IdEmpleado"];
            usu = new Ventas();
            usu.IdVentas = (int)table.Rows[i]["IdUsuario"];
            cli = new Cliente();
            cli.IdCliente = (int)table.Rows[i]["IdCliente"];
            fp = new FormaDePago();
            fp.IdFormaDePago = (int)table.Rows[i]["IdFormaPago"];

            usu.TotaldeVenta = (float)table.Rows[i]["TotalVenta"];

            res.Add(usu);
        }


        return res;

    }
}

