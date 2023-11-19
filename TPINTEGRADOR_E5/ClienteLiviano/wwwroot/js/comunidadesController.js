var urlbase = "https://localhost:44320"


getAllComunidades = () => {
    var url = urlbase + `/Comunidades/get-all`;
    return new Promise((resolve, reject) => {

        $.ajax({
            url: url,
            type: 'POST',
            data: null, //JSON.stringify(select.toString()),
            contentType: 'application/json',
            success: function (response) {
                document.getElementById("comunidades-container").innerHTML = response;
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });


    });
}

changeRol = (prop) => {
    var select = document.getElementById("select-form");
    var url = urlbase + `/Comunidades/cambiar-rol`;
    var json = new {
         rol: select.value,
        participacion: document.querySelector('input[name="Participacion"]').value

    }
    return new Promise((resolve, reject) => {

        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(select.toString()),
            contentType: 'application/json',
            success: function (response) {
                location.reload();
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });


    });
}