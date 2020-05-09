<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ventana_Registro.aspx.cs" Inherits="ventana_Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/InsertUsuario.js"></script>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
     <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Services>
                    <asp:ServiceReference Path="http://localhost:83/WCFLoginIntegrador/ServiceJS.svc" />
                </Services>
            </asp:ScriptManager>
        </div>
     Nombre:<input type="text" id="txtNombre" />
    Apellido Paterno:<input type="text" id="txtAp1" />
    Apellido Materno:<input type="text" id="txtAp2" />
    Email:<input type="text" id="txtEmail" />
    <br />
    <br />
    Edad:<input type="text" id="txtEdad" />
    Sexo:<input type="text" id="txtSexo" />
    Telefono:<input type="text" id="txtTelefono" />
        <br />
        <br />
     Nombre de Usuario:<input type="text" id="txtUsuario" />
    <br />
    <br />
    Contraseña:<input type="text" id="txtPassword" />
    <br />
    <br />
    <input type="button" id="btnCreateUser" value="Terminar Registro" />
    </div>
    </form>
</body>
</html>
