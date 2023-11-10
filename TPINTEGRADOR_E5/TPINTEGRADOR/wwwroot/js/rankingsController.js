filtrarRanking = () => {
    var url = "/RankingController/FiltrarRanking";
    var dataToSend = {
        ejemplo: "ejemplo de dato" // Dato de ejemplo que quieres enviar al controlador
    };

    return new Promise((resolve, reject) => {
        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(dataToSend), // Convertir el objeto a una cadena JSON
            contentType: 'application/json', // Especificar el tipo de contenido como JSON
            success: function (response) {
                console.log("Test", response);
                resolve(response); // Resolver la promesa con la respuesta del controlador
            },
            error: function (xhr, status, error) {
                console.error("Test", error);
                reject(error); // Rechazar la promesa en caso de error
            }
        });
    });
}

validateForm = () => {
    let username = document.getElementById("username").value;
    let password = document.getElementById("password").value;
    let isValid = true;

    let usernameError = document.getElementById("usernameError");
    let passwordError = document.getElementById("passwordError");

    if (username === "") {
        usernameError.innerHTML = "El campo nombre de usuario es requerido.";
        isValid = false;
    } else {
        usernameError.innerHTML = "";
    }

    if (password === "") {
        passwordError.innerHTML = "El campo contraseña es requerido.";
        isValid = false;
    } else {
        passwordError.innerHTML = "";
    }

    return isValid;
}