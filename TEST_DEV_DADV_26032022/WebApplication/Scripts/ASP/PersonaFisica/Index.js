$tableData = null;

$(document).ready(function () {
    $tableData = $("#tblPersonaFisica").DataTable({ scrollX: true });
    Get();
    SubmitPost();
    SubmitPut();
    EditClickEvent();
    DeleteClickEvent();
});


async function Get()
{
    const personas = await AjaxApiRequest("GET", urlGet, null);
    BuildTable(personas);
}

function BuildTable(personas)
{
    if ($tableData != null) {
        $tableData.destroy();
    }

    if (personas.length > 0) {
        const habilitar = "<button class='put btn btn-primary'><i class='fa fa-solid fa-pencil'></i></button> <button class='enable btn btn-primary'><i class='fa fa-solid fa-check'></i></button>";
        const deshabilitar = "<button class='put btn btn-primary'><i class='fa fa-solid fa-pencil'></i></button> <button class='delete btn btn-danger'><i class='fa fa-solid fa-trash'></i></button>";

        $tableData = $("#tblPersonaFisica").DataTable({
            data: personas,
            scrollX: true,
            columns: [
                { "data": function (data, type, row) { return data.Activo ? deshabilitar : habilitar; }, "searchable": false },
                { "data": "IdPersonaFisica" },
                { "data": "BirthDay" },
                { "data": "Nombre" },
                { "data": "ApellidoPaterno" },
                { "data": "ApellidoMaterno" },
                { "data": "RFC" },
                { "data": "CreatedDate" },
                { "data": "UpdatedDate"}
            ]
        });
    }
    else {        
        $tableData = $("#tblPersonaFisica").DataTable({ scrollX: true });
    }
}

function Clear() {
    ClearCreatePersonaFisica();
}

function SubmitPost() {
    $("#frmPost").submit(async function (event) {
        Post(event);
    });
}

async function Post(event) {
    const persona = BuildCreatePersonaFisicaData(event);
    const response = await AjaxApiRequest("POST", urlPost, JSON.stringify(persona));

    if (response) {
        Get();
        $("#btnCancelarCrear").trigger("click");
        alert("¡Registro creado exitosamente!");
    }
    else {
        alert("¡Registro no creado, intentar más tarde!");
    }
}

function BuildCreatePersonaFisicaData(event)
{
    event.preventDefault();
    const newPersona = {};
    const persona = GetCreatePersonaFisica();

    newPersona.Nombre = persona.Nombre;        
    newPersona.ApellidoPaterno = persona.ApellidoPaterno;
    newPersona.ApellidoMaterno = persona.ApellidoMaterno;
    newPersona.RFC = persona.RFC;
    newPersona.FechaNacimiento = persona.FechaNacimiento;
    newPersona.UsuarioAgrega = parseInt(persona.UsuarioAgrega);

    return newPersona;
}

function EditClickEvent()
{
    $('#tblPersonaFisica tbody').on('click', '.put', function () {
        ClearEditPersonaFisica();
        var persona = $tableData.row($(this).parents('tr')).data();
        LoadEditModal(persona);
    });
}

function DeleteClickEvent() {
    $('#tblPersonaFisica tbody').on('click', '.delete', async function () {       
        var persona = $tableData.row($(this).parents('tr')).data();
        Delete(persona);
    });
}

async function Delete(persona) {
    const obj = "{id:" + parseInt(persona.IdPersonaFisica) + "}";  

    if (confirm("Desea desactivar a: " + persona.Nombre + " " + persona.ApellidoPaterno)) {

        const response = await AjaxApiRequest("POST", urlDelete, obj);
        if (response) {
            Get();
            alert("Se desabilito correctamente");
        }
        else {
            alert("No se desabilito intente mas tarde");
        }
    }
}

function LoadEditModal(persona) {
    SetEditPersonaFisica(persona);
    $("#btnModalEdit").trigger("click");
}

function SubmitPut() {
    $("#frmPut").submit(async function (event) {
        Put(event);
    });
}


async function Put(event) {
    const persona = BuildEditPersonaFisicaData(event);
    const response = await AjaxApiRequest("POST", urlPut, JSON.stringify(persona));

    if (response) {
        Get();
        $("#btnCancelarEditar").trigger("click");
        alert("¡Registro Actualizado exitosamente!");
    }
    else {
        alert("¡Registro no Actualizado, intentar más tarde!");
    }
}

function BuildEditPersonaFisicaData(event) {
    event.preventDefault();
    const newPersona = {};
    const persona = GetEditPersonaFisica();

    newPersona.IdPersonaFisica = parseInt(persona.IdPersonaFisica);
    newPersona.Nombre = persona.Nombre;
    newPersona.ApellidoPaterno = persona.ApellidoPaterno;
    newPersona.ApellidoMaterno = persona.ApellidoMaterno;
    newPersona.RFC = persona.RFC;
    newPersona.FechaNacimiento = persona.FechaNacimiento;
    newPersona.UsuarioAgrega = parseInt(persona.UsuarioAgrega);

    return newPersona;
}



