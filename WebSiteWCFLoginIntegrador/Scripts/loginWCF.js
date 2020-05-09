jQuery(document).ready(function () {
    $('#btnLogin').click(function () {
        var nick = $('#txtNick').val();
        var pwd = $('#txtPassword').val();
        if (nick != '' && pwd != '') {
            LoginJS(nick, pwd);
        }
        else
            alert('Ingresa Nickname y Password');
    });
});

function LoginJS(nick, pwd) {
    var jSon =
        {
            "Nick": nick,
            "Password": pwd
        }
    //ISSC311.IContratoJSUsuarios.Login(jSon, OnRequestComplete, onError);
    ISSC311.IContratoJSUsuarios.Login(jSon, OnRequestComplete, onError);
}

function OnRequestComplete(response, state) {
    if (response.Sesion.Estado == 1)
    {
        var user = response.Sesion.Token;
        alert('Bienvenido');
        setCookie("username", user, 30);
        alert('Tu token es'+user);
    }
        
   else
    {
        alert('Usuario y/o Contraseña incorrectos' + getCookie("username"));
    }
        
}

function onError() {
    alert('Ocurrió un error');
}

function Redirigir() {
    window.location.href = "ventana_Registro.aspx";
}


function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}



function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
