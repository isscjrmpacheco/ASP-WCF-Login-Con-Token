jQuery(document).ready(function () {//Aqui recolectamos los datos en el evento click
    $('#btnUpdateUser').click(function () {
        var Nombre = $('#txtNombre').val();
        var Ap1 = $('#txtApellido1').val();
        var Ap2 = $('#txtApellido2').val();
        var Edad = $('#txtEdad').val();
        var Sexo = $('#txtSexo').val();
        var Email = $('#txtEmail').val();
        var Username = $('#txtUsername').val();
        var Passsword = $('#txtPasssword').val();
        var IdActualizar = $('#txtIdPersona').val();
        var IdUser = $('#txtIdUser').val();

        //Antes del siguiente paso, se creo la funcion CreateUser()
        CreateUser(Nombre, Ap1, Ap2, Edad, Sexo, Email, Username, Passsword, IdActualizar, IdUser)
        debugger;



    });
});

function CreateUser(Nombre, Ap1, Ap2, Edad, Sexo, Email, Username, Passsword, IdActualizar, IdUser) {
    debugger;
    var ObjetoJason = {
        "Nombre": Nombre,//Se tienen que llamar igual que el objeto de la calse de .NET
        "Ap1": Ap1,
        "Ap2": Ap2,
        "Edad": Edad,
        "Sexo": Sexo,
        "Email": Email,
        "Nick": Username,
        "Password": Passsword,
        "IdPersona": IdActualizar,
        "IdUsuario": IdUser

    }
    ISSC311.IContratoJSUsuarios.validar(getCookie("username"), EncasoCorrecto, onError);
    if (EncasoCorrecto()==1) {
        ISSC311.IContratoJSUsuarios.Update2(ObjetoJason, OnRequestComplete, onError);
    }

    else {
        alert("Tu sesión no se encuentra activa :v");
    }
    
    
}


function validar(ObjetoJason2, OnRequestComplete2, onError2) {

}

function OnRequestComplete2(response, state) {
    if (response=1) {

    }
    alert('Datos Actualizados!');

}
function EncasoCorrecto(response, state) {
        
    if (response==1) {
        return 1;
    }

    else {
        return 0;
    }
   
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
