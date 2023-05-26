var data = [];
var rowsError = "";
var provincias;
var municipios;
var departamentos;

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

    reader.onload = (e) => {
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
        consultarAPI("provincias", provincias);
        consultarAPI("municipios", municipios);
        consultarAPI("departamentos", departamentos);
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
    tipoOrganismoHeader.textContent = 'Tipo Organismo';
    encabezado.appendChild(tipoOrganismoHeader);

    var entidadHeader = document.createElement('th');
    entidadHeader.textContent = 'Entidad';
    encabezado.appendChild(entidadHeader);

    var encargadoHeader = document.createElement('th');
    encargadoHeader.textContent = 'Encargado';
    encabezado.appendChild(encargadoHeader);

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
        var nombre = columnsRow[4].replace(/\r$/, '');
        if (columnsRow[3] == "DEPARTAMENTO" && !departamentos.departamentos.some(d => d.nombre === nombre)) {
            departamentos.departamentos.push({
                nombre: nombre,
                max: 1,
                exacto: true
            })
        } else if (columnsRow[3] == "MUNICIPIO" && !municipios.municipios.some(m => m.nombre === nombre)) {
            municipios.municipios.push({
                nombre: nombre,
                max: 1,
                exacto: true
            })
        } else if (columnsRow[3] == "PROVINCIA" && !provincias.provincias.some(p => p.nombre === nombre)) {
            provincias.provincias.push({
                nombre: nombre,
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

        if (!validarFila(rows[i])) rowsError += i;

        data.push({
            tipoOrganismo: tipoOrganismo,
            entidad: entidad,
            encargado: encargado
        });

        var tipoOrganismo = columns[0].trim();
        var entidad = columns[1].trim();
        var encargado = columns[2].trim();

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

        tabla.appendChild(fila);
    }
}

validarFila = (row) => {
    return true;
}

consultarAPI = (url, data) => {
    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };

    fetch("https://apis.datos.gob.ar/georef/api/" + url, requestOptions)
        .then(response => response.json())
        .then(result => {
            // Aquí puedes procesar la respuesta de la API
            console.log(result);
        })
        .catch(error => {
            // Manejo de errores
            console.error('Error:', error);
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