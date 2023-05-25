validarArchivo = () => {
    var inputFile = document.getElementById('formFile');
    var file = inputFile.files[0];
    var allowedExtensions = /(\.csv)$/i;

    if (!allowedExtensions.exec(file.name)) {
        alert('Por favor, selecciona un archivo CSV válido.');
        return false;
    }

    var reader = new FileReader();

    reader.onload = (e) => {
        var contents = e.target.result;
        var rows = contents.split('\n'); // Divide el contenido en filas

        var data = [];

        // Itera sobre cada fila del archivo CSV
        for (var i = 1; i < rows.length; i++) {
            var columns = rows[i].split(',');
            if (columns[0] == "") break; 

            var tipoOrganismo = columns[0].trim(); // Obtiene el valor de la columna "tipo de organismo" sin espacios en blanco
            var entidad = columns[1].trim(); // Obtiene el valor de la columna "entidad" sin espacios en blanco
            var encargado = columns[2].trim(); // Obtiene el valor de la columna "encargado" sin espacios en blanco


            // Almacena los datos en la matriz
            data.push({
                tipoOrganismo: tipoOrganismo,
                entidad: entidad,
                encargado: encargado
            });
        }

        console.log('Datos leídos desde el archivo CSV:', data);
    };

    reader.readAsText(file);
}