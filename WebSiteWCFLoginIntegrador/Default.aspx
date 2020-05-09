<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/loginWCF.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Services>
                    <asp:ServiceReference Path="http://localhost:83/WCFLoginIntegrador/ServiceJS.svc" />
                </Services>
            </asp:ScriptManager>
        </div>
        Nick: <input type="text" id="txtNick" />
        <br />
        <br />
        Password: <input type="password" id="txtPassword" />
        <br />
        <br />
        <input type="button" id="btnLogin" value="Login" />
        <br />
    <br />
    <input type="button" id="btnRegistro" onclick="Redirigir()" value="REGISTRATE AHORA!!" />
    </form>
</body>
</html>
