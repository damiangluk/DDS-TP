var data = [];
var rowsError = "";
var provincias;
var municipios;
var departamentos;
var provinciasResult;
var municipiosResult;
var departamentosResult;

validarArchivo = () => {
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

    var reader = new FileReader();

    reader.onload = async (e) => {
        var contents = e.target.result;
        var rows = contents.split('\n');

        var msj = document.getElementById('msg');

        if (rows.length < 2 || rows[1] == "") {
            msj.innerHTML = 'El archivo no contiene informacion';
            return;
        }

        msj.innerHTML = '';
        var tabla = crearTabla();

        cargarParametros(rows);
        await consultarAPI(["provincias", "departamentos", "municipios"], [provincias, departamentos, municipios]);
        cargarInformacion(rows, tabla);

        var tableContainer = document.getElementById('tableContainer');
        tableContainer.innerHTML = '';
        tableContainer.appendChild(tabla);
    };

    reader.readAsText(file, 'latin1');
}


crearTabla = () => {
    var tabla = document.createElement('table');
    tabla.classList.add('table', 'table-bordered', 'table-striped');

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

cargarParametros = (rows) => {
    provincias = { provincias: [] };
    municipios = { municipios: [] };
    departamentos = { departamentos: [] };

    for (var i = 1; i < rows.length; i++) {
        var columnsRow = rows[i].split(',');
        if (columnsRow[0] == "")
            break;
        columnsRow[4] = columnsRow[4].replace(/\r$/, '');
        if (columnsRow[3] == "DEPARTAMENTO" && !departamentos.departamentos.some(d => d.nombre === columnsRow[4])) {
            departamentos.departamentos.push({
                nombre: columnsRow[4],
                campos: "id,nombre",
                max: 1,
                exacto: true
            })
        } else if (columnsRow[3] == "MUNICIPIO" && !municipios.municipios.some(m => m.nombre === columnsRow[4])) {
            municipios.municipios.push({
                nombre: columnsRow[4],
                campos: "id,nombre",
                max: 1,
                exacto: true
            })
        } else if (columnsRow[3] == "PROVINCIA" && !provincias.provincias.some(p => p.nombre === columnsRow[4])) {
            provincias.provincias.push({
                nombre: columnsRow[4],
                campos: "id,nombre",
                max: 1,
                exacto: true
            })
        }
    }
}

cargarInformacion = (rows, tabla) => {
    for (var i = 1; i < rows.length; i++) {
        var columns = rows[i].split(',');
        if (columns[0] == "")
            break;

        if (!validarFila(columns)) {
            rowsError += columns[4] + ",";
            continue;
        }

        data.push({
            tipoOrganismo: tipoOrganismo,
            entidad: entidad,
            encargado: encargado
        });

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
        msj.innerHTML = 'No se encontraron las siguiente localizaciones: ' + rowsError.slice(0, -1);
    }
}

validarFila = (columns) => {
    var nombreLoc = columns[4].trim();
    var tipoLoc = columns[3]
    if (tipoLoc === "PROVINCIA" && provinciasResult.some(p => p.nombre === nombreLoc))
        return true;
    else if (tipoLoc === "DEPARTAMENTO" && departamentosResult.some(d => d.nombre === nombreLoc))
        return true;
    else if (tipoLoc === "MUNICIPIO" && municipiosResult.some(m => m.nombre === nombreLoc))
        return true;
    return false;
}

consultarAPI = async (urls, datas) => {
    /*const requestOptions = (data) => {
        return {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }
    };

    var requests = urls.map((url, index) => fetch("https://apis.datos.gob.ar/georef/api/" + url, requestOptions(datas[index])));

    try {
        var responses = await Promise.all(requests);
        var provinciasResponse = await responses[0].json();
        var departamentosResponse = await responses[1].json();
        var municipiosResponse = await responses[2].json();

        provinciasResult = provinciasResponse.resultados.map(res => res.cantidad > 0 ? res.provincias[0] : null).filter(r => r != null);
        departamentosResult = departamentosResponse.resultados.map(res => res.cantidad > 0 ? res.departamentos[0] : null).filter(r => r != null);
        municipiosResult = municipiosResponse.resultados.map(res => res.cantidad > 0 ? res.municipios[0] : null).filter(r => r != null);

        console.log(provinciasResult);
        console.log(departamentosResult);
        console.log(municipiosResult);
    } catch (error) {
        console.error('Error:', error);
    }*/
    $.ajax({
        url: '/Organismos/ConsultarAPI',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify([{ param: provincias.provincias }, { param: municipios.municipios }, { param: departamentos.departamentos }]),
        success: function (response) {
            console.log(response);
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}
/*
PROVINCIAS
POST https://apis.datos.gob.ar/georef/api/provincias
HEADER 'Content-Type: application/json'
{
    "provincias": [
        {
            "nombre": "cordoba",
            "campos": "nombre"
        },
        {
            "nombre": "chaco",
            "campos": "nombre"
        },
        {
            "nombre": "san luis",
            "campos": "nombre"
        }
    ]
}

MUNICIPIOS
POST "https://apis.datos.gob.ar/georef/api/municipios"
HEADER 'Content-Type: application/json'
{
    "municipios": [
        {
            "nombre": "belgrano",
            "max": 1,
            "campos": "id, nombre"
        },
        {
            "nombre": "martin",
            "max": 1,
            "provincia": "la pampa",
            "aplanar": true
        }
    ]
}

DEPARTAMENTOS
POST "https://apis.datos.gob.ar/georef/api/departamentos"
HEADER 'Content-Type: application/json'
{
  "departamentos": [
    {
      "id": "string",
      "nombre": "string",
      "provincia": "Santa Fe",
      "interseccion": "provincia:82,departamento:82084,municipio:820196",
      "orden": "id",
      "aplanar": true,
      "campos": "estandar",
      "max": 10,
      "inicio": 10,
      "exacto": true
    }
  ]
}
*/