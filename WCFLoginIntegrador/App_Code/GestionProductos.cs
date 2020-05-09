using RNConnection.DataAbstractionLayer;
using RNConnection.DataStorageLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de GestionProductos
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class GestionProductos : System.Web.Services.WebService
{

    public GestionProductos()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Productos InsertarPro(Productos productos)
    {
        string Cadena = "DATA SOURCE = Dell-i7460;" + " INITIAL CATALOG = CookieUsuario;" + " INTEGRATED SECURITY= YES;";
        DSL dsl = new DSL();
        dsl.Open(Cadena, Proveedor.SQLServer);
        dsl.InitialSQLStatement("dbo.pa_InsertarProducto", System.Data.CommandType.StoredProcedure);
        dsl.SetParameterProcedure("@NombreP", System.Data.ParameterDirection.Input, eTypes.Cadena, productos.NombreDeProducto);
        dsl.SetParameterProcedure("@Descripcion", System.Data.ParameterDirection.Input, eTypes.Cadena, productos.Descripcion);
        dsl.SetParameterProcedure("@NombreM", System.Data.ParameterDirection.Input, eTypes.Cadena, productos.marca.NombreM);
        dsl.SetParameterProcedure("@EdadMaxima", System.Data.ParameterDirection.Input, eTypes.Entero, productos.EdadMaxima);
        dsl.SetParameterProcedure("@EdadMinima", System.Data.ParameterDirection.Input, eTypes.Entero, productos.EdadMinima);
        dsl.SetParameterProcedure("@Precio", System.Data.ParameterDirection.Input, eTypes.Entero, productos.Precio);
        dsl.SetParameterProcedure("@Stock", System.Data.ParameterDirection.Input, eTypes.Entero, productos.Precio);
        dsl.SetParameterProcedure("@Fotografia", System.Data.ParameterDirection.Input, eTypes.Cadena, productos.Fotografia);
        dsl.SetParameterProcedure("@IdProductoGenerado", System.Data.ParameterDirection.Output, eTypes.Entero, productos.IdProducto);
        dsl.SetParameterProcedure("@IdMarcaGenerado", System.Data.ParameterDirection.Output, eTypes.Entero, productos.marca.IdMarca);
        dsl.ExecuteNonQuery();
        return productos;
    }
    [WebMethod]
    public Productos ActualizarPro(Productos productos)
    {
        string Cadena = "DATA SOURCE = Dell-i7460;" + " INITIAL CATALOG = CookieUsuario;" + " INTEGRATED SECURITY= YES;";
        DSL dsl = new DSL();
        dsl.Open(Cadena, Proveedor.SQLServer);
        dsl.InitialSQLStatement("dbo.pa_ActualizarProducto", System.Data.CommandType.StoredProcedure);
        dsl.SetParameterProcedure("@NombreP", System.Data.ParameterDirection.Input, eTypes.Cadena, productos.NombreDeProducto);
        dsl.SetParameterProcedure("@Descripcion", System.Data.ParameterDirection.Input, eTypes.Cadena, productos.Descripcion);
        dsl.SetParameterProcedure("@NombreM", System.Data.ParameterDirection.Input, eTypes.Cadena, productos.marca.NombreM);
        dsl.SetParameterProcedure("@EdadMaxima", System.Data.ParameterDirection.Input, eTypes.Entero, productos.EdadMaxima);
        dsl.SetParameterProcedure("@EdadMinima", System.Data.ParameterDirection.Input, eTypes.Entero, productos.EdadMinima);
        dsl.SetParameterProcedure("@Precio", System.Data.ParameterDirection.Input, eTypes.Entero, productos.Precio);
        dsl.SetParameterProcedure("@Stock", System.Data.ParameterDirection.Input, eTypes.Entero, productos.Precio);
        dsl.SetParameterProcedure("@Fotografia", System.Data.ParameterDirection.Input, eTypes.Cadena, productos.Fotografia);
        return productos;
    }
}
