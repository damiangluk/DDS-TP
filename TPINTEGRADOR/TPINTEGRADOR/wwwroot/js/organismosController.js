var rowsError = "";
var rows;
var provinciasResult;
var municipiosResult;
var departamentosResult;
var importButton = document.getElementById('importButton');
var textImport = document.getElementById('textButton');
var loadingImport = document.getElementById('loadingButton');

validarArchivo = async () => {
    var inputFile = document.getElementById('formFile');
    var file = inputFile.files[0];
    var allowedExtensions = /(\.csv)$/i;

    if (file == null) {
        alert('Por favor, cargue algun archivo.');
        return false;
    }

    if (!allowedExtensions.exec(file.name)) {
        alert('Por favor, selecciona un archivo CSV válido.');
        return false;
    }

    importButton.disabled = true
    textImport.style.display = 'none';
    loadingImport.style.display = 'flex';

    rowsError = "";

    await enviarArchivo(file);
    var msj = document.getElementById('msg');
    msj.innerHTML = '';
    var tabla = crearTabla();
    cargarInformacion(tabla);

    var tableContainer = document.getElementById('tableContainer');
    tableContainer.innerHTML = '';
    tableContainer.appendChild(tabla);

}

crearTabla = () => {
    var tabla = document.createElement('table');
    tabla.classList.add('table', 'table-bordered', 'table-striped', 'table-hover');

    var encabezado = document.createElement('tr');

    var tipoOrganismoHeader = document.createElement('th');
    tipoOrganismoHeader.textContent = 'Tipo de organismo';
    encabezado.appendChild(tipoOrganismoHeader);

    var entidadHeader = document.createElement('th');
    entidadHeader.textContent = 'Entidad';
    encabezado.appendChild(entidadHeader);

    var encargadoHeader = document.createElement('th');
    encargadoHeader.textContent = 'Encargado';
    encabezado.appendChild(encargadoHeader);

    var tipoLocalizacionHeader = document.createElement('th');
    tipoLocalizacionHeader.textContent = 'Tipo de localizacion';
    encabezado.appendChild(tipoLocalizacionHeader);

    var nombreLocalizacionHeader = document.createElement('th');
    nombreLocalizacionHeader.textContent = 'Nombre localizacion';
    encabezado.appendChild(nombreLocalizacionHeader);

    tabla.appendChild(encabezado);
    return tabla;
}

cargarInformacion = (tabla) => {
    for (var i = 0; i < rows.length; i++) {
        var columns = rows[i].split(',');

        var tipoOrganismo = columns[0].trim();
        var entidad = columns[1].trim();
        var encargado = columns[2].trim();
        var tipoLocalizacion = columns[3].trim();
        var nombreLocalizacion = columns[4].trim();

        var fila = document.createElement('tr');

        var tipoOrganismoTd = document.createElement('td');
        tipoOrganismoTd.textContent = tipoOrganismo;
        fila.appendChild(tipoOrganismoTd);

        var entidadTd = document.createElement('td');
        entidadTd.textContent = entidad;
        fila.appendChild(entidadTd);

        var encargadoTd = document.createElement('td');
        encargadoTd.textContent = encargado;
        fila.appendChild(encargadoTd);

        var tipoLocalizacionTd = document.createElement('td');
        tipoLocalizacionTd.textContent = tipoLocalizacion;
        fila.appendChild(tipoLocalizacionTd);

        var nombreLocalizacionTd = document.createElement('td');
        nombreLocalizacionTd.textContent = nombreLocalizacion;
        fila.appendChild(nombreLocalizacionTd);

        tabla.appendChild(fila);
    }

    if (rowsError !== "") {
        var msj = document.getElementById('msg');
        msj.innerHTML = rowsError;
    }
}

enviarArchivo = (file) => {

    var formData = new FormData();
    formData.append('archivoCSV', file);

    return new Promise((resolve, reject) => {

        $.ajax({
            url: '/Organismos/ValidarArchivo',
            type: 'POST',
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                var result = JSON.parse(response);
                if (result.validation) {
                    provinciasResult = result.content.provinciasResult;
                    departamentosResult = result.content.departamentosResult;
                    municipiosResult = result.content.municipiosResult;
                    rows = result.content.rowsValidated;
                    rowsError = result.content.rowsError;

                    importButton.disabled = false
                    textImport.style.display = 'flex';
                    loadingImport.style.display = 'none';

                    resolve();
                } else {
                    console.log("Ocurrio un error", result);
                    var msj = document.getElementById('msg');
                    msj.innerHTML = result.message;

                    importButton.disabled = false
                    textImport.style.display = 'flex';
                    loadingImport.style.display = 'none';

                    reject("Ocurrió un error en la consulta API");
                }
            },
            error: function (xhr, status, error) {
                console.error(error);
                importButton.disabled = false
                textImport.style.display = 'flex';
                loadingImport.style.display = 'none';
                reject("Ocurrió un error en la consulta API");
            }
        });
    });
}