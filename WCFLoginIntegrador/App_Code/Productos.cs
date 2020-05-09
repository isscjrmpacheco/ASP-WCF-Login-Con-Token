using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Productos
/// </summary>
public class Productos
{
    public int IdProducto { get; set; }
    public int Precio { get; set; }
    public string NombreDeProducto { get; set; }
    public string Descripcion { get; set; }
    public int EdadMaxima { get; set; }
    public int EdadMinima { get; set; }
    public string Marca { get; set; }
    public int Stock { get; set; }
    public string Fotografia { get; set; }
    public Marca marca { get; set; }

}