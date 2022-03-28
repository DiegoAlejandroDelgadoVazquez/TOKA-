function GetCreatePersonaFisica() {
    var persona = {};          
    persona.Nombre = $("#txtNombre").val();
    persona.ApellidoPaterno = $("#txtApellidoPaterno").val();
    persona.ApellidoMaterno = $("#txtApellidoMaterno").val();
    persona.RFC = $("#txtRFC").val();
    persona.FechaNacimiento = $("#txtFechaNacimiento").val();
    persona.UsuarioAgrega = $("#txtUsuarioAgrega").val();

    return persona;
}

function ClearCreatePersonaFisica() {    
    $("#txtNombre").val("");
    $("#txtApellidoPaterno").val("");
    $("#txtApellidoMaterno").val("");
    $("#txtRFC").val("");
    $("#txtFechaNacimiento").val("");
    $("#txtUsuarioAgrega").val("");  
}

function GetEditPersonaFisica() {
    var persona = {};
    persona.IdPersonaFisica = $("#txtIdPersonaFisica").val();
    persona.Nombre = $("#txtNombreF").val();
    persona.ApellidoPaterno = $("#txtApellidoPaternoF").val();
    persona.ApellidoMaterno = $("#txtApellidoMaternoF").val();
    persona.RFC = $("#txtRFCF").val();
    persona.FechaNacimiento = $("#txtFechaNacimientoF").val();
    persona.UsuarioAgrega = $("#txtUsuarioAgregaF").val();

    return persona;
}

function ClearEditPersonaFisica() {

    $("#txtIdPersonaFisica").val("");
    $("#txtNombreF").val("");
    $("#txtApellidoPaternoF").val("");
    $("#txtApellidoMaternoF").val("");
    $("#txtRFCF").val("");
    $("#txtFechaNacimientoF").val("");
    $("#txtUsuarioAgregaF").val("");
}

function SetEditPersonaFisica(persona) {

    $("#txtIdPersonaFisica").val(persona.IdPersonaFisica);
    $("#txtNombreF").val(persona.Nombre);
    $("#txtApellidoPaternoF").val(persona.ApellidoPaterno);
    $("#txtApellidoMaternoF").val(persona.ApellidoMaterno);
    $("#txtRFCF").val(persona.RFC);
    $("#txtFechaNacimientoF").val(persona.BirthDay);
    $("#txtUsuarioAgregaF").val(persona.UsuarioAgrega);
}

