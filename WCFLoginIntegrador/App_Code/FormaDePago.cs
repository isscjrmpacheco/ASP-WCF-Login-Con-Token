using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de FormaDePago
/// </summary>
public class FormaDePago
{
    public int IdFormaDePago { get; set; }
    public int Efectivo { get; set; }
    public int TarjetaDeCredito { get; set; }
    public int TarjetaDeDebito { get; set; }
    public int ValesDeDespensas { get; set; }
}