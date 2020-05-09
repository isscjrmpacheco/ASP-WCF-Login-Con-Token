<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/Update.js"></script>
</head>
<body>
    <form id="form1" runat="server">
  <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Services>
                    <asp:ServiceReference Path="http://localhost:83/WCFLoginIntegrador/ServiceJS.svc" />
                </Services>
            </asp:ScriptManager>
      

    
        <h2>Actualizar Datos del Usuario</h2>
        <br /><br />
        <p>Ingrese el id de la persona que desea actualizar</p>
        <br />
        <br />
         IdPersona:<input type="text" id="txtIdPersona" />
        <br />
        <br />
        <p>Ingrese el id del Usuario que desea actualizar</p>
        <br />
        <br />
         IdUser:<input type="text" id="txtIdUser" />
        <br />
        <br />
         Nombre:<input type="text" id="txtNombre" />
        <br />
        <br />
        Apellido Paterno:<input type="text" id="txtApellido1" />
        <br />
        <br />
        Apellido Materno:<input type="text" id="txtApellido2" />
        <br />
        <br />
       Edad:<input type="text" id="txtEdad" />
        <br />
        <br />
         Sexo:<input type="text" id="txtSexo" />
        <br />
        <br />
        
        Usuario:<input type="text" id="txtUsername" /><br />
&nbsp;<br />
        Password:<input type="text" id="txtPasssword" />
        <br />
        <br />
        Email:<input type="text" id="txtEmail" />
        <br />

        <br />
        <input type="button" id="btnUpdateUser" value="Aceptar" />
          </div>
    </form>
</body>
</html>
