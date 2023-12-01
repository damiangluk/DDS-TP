var urlbase = "https://localhost:44320"

getAllComunidades = () => {
    var url = urlbase + `/Comunidades/get-all`;
    return new Promise((resolve, reject) => {

        $.ajax({
            url: url,
            type: 'POST',
            data: null, //JSON.stringify(select.toString()),
            contentType: null,//'application/json',
            success: function (response) {
                document.getElementById("comunidades-container").innerHTML = response;
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });


    });
}

window.onload = getAllComunidades;


changeRol = (id) => {
    var url = urlbase + `/Comunidades/cambiar-rol`;
    var select = document.getElementById(`select-form-${id}`);
    var participacion = document.querySelector(`input[name="Participacion-${id}"]`).value;
    var json = {
        rol: parseInt(select.value),
        participacion: parseInt(participacion)
    }
    return new Promise((resolve, reject) => {

        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(json),
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