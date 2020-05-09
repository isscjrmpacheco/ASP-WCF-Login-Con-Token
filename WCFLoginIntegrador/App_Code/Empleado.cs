using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Empleado
/// </summary>
public class Empleado:Persona
{
    public int IdEmpleado { get; set; }
    //public Sucursal IdSucursal { get; set; }
    public int Salario { get; set; }
    public DateTime FechaIngreso { get; set; }
}