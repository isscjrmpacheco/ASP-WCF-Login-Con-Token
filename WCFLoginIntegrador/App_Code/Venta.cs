using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Ventas
/// </summary>
public class Ventas
{
    //public Vendedor IdVendedor { get; set; }
    public int IdVentas { get; set; }
    public Cliente IdCliente { get; set; }
    public Empleado IdEmpleado { get; set; }
    public Productos IdProducto { get; set; }
    //public Sucursal IdSucursal { get; set; }
    public float TotaldeVenta { get; set; }
    //public int Hora { get; set; }
    public DateTime Fecha { get; set; }
    public FormaDePago IdFormaDePago { get; set; }
}