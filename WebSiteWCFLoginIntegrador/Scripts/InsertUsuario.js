jQuery(document).ready(function () {//Aqui recolectamos los datos en el evento click
    $('#btnCreateUser').click(function () {
        var Nombre = $('#txtNombre').val();
        var Ap1 = $('#txtAp1').val();
        var Ap2 = $('#txtAp2').val();
        var Edad = $('#txtEdad').val();
        var Sexo = $('#txtSexo').val();
        var Telefono = $('#txtTelefono').val();
        var Email = $('#txtEmail').val();
        var Nick = $('#txtUsuario').val();
        var Password = $('#txtPassword').val();

        Insert(Nombre, Ap1, Ap2, Edad, Sexo, Email, Nick, Password)
    });
});

function Insert(Nombre, Ap1, Ap2, Edad, Sexo, Email, Nick, Password) {
    var ObjetoJason = {
        "Nombre": Nombre,//Se tienen que llamar igual que el objeto de la calse de .NET
        "Ap1": Ap1,
        "Ap2": Ap2,
        "Edad": Edad,
        "Sexo": Sexo,
        //"Telefono": Telefono,
        "Email": Email,
        "Nick": Nick,
        "Password": Password
    }

    var paramentroJason = {
        "v": getCookie("username")
    }
    //Hola
    ISSC311.IContratoJSUsuarios.validar(paramentroJason);
    if (EncasoCorrecto() == 1) {
        ISSC311.IContratoJSUsuarios.InsertarUsuario(ObjetoJason, OnRequestComplete, onError);
        //ISSC311.IContratoJSUsuarios.Update2(ObjetoJason, OnRequestComplete, onError);
    }

    else {
        alert("Tu sesión no se encuentra activa :v");
    }
}


function OnRequestComplete(response, state) {
    if (response = 1)
        alert('Bienvenido');
    else
        alert('Usuario y/o Contraseña incorrectos');
}

function onError() {
    alert('Ocurrió un error');
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


function EncasoCorrecto(response, state) {

    if (response == 1) {
        return 1;
    }

    else {
        return 0;
    }

}
