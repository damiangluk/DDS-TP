var urlbase = "https://localhost:44320"


getAllIncidentes = () => {
    var select = document.getElementById("select-estado").value;
    var url = urlbase + `/Incidentes/get-all`;
    return new Promise((resolve, reject) => {

        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(select.toString()),
            contentType: 'application/json',
            success: function (response) {
                document.getElementById("incidentes-container").innerHTML = response;
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });


    });
}