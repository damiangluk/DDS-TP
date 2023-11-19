var urlbase = "https://localhost:44320"

getAllRankings = () => {
    var url = urlbase + `/Rankings/get-all`;

    var fechaInicio = document.querySelector('input[name="fechaInicio"]').value;
    var fechaFin = document.querySelector('input[name="fechaFin"]').value;
    var select = document.querySelector('select[name="tipoRanking"]').value;

    if (fechaInicio == '' || fechaFin == '') {
        let newDate = new Date();
        fechaFin = newDate;
        fechaInicio = newDate;
    }

    var json = {
        fechaInicio,
        fechaFin,
        tipoRanking: parseInt(select)
    }

    return new Promise((resolve, reject) => {

        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(json),
            contentType: "application/json",
            success: function (response) {
                document.getElementById("accordion").innerHTML = response;
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });


    });
}

chargeSelect = () => {
    var url = urlbase + `/Rankings/charge-select`;

    return new Promise((resolve, reject) => {

        $.ajax({
            url: url,
            type: 'POST',
            data: null,
            contentType: null,
            success: function (response) {
                document.getElementById("select-rankings").innerHTML = response;
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });


    });
}

window.onload = chargeSelect;