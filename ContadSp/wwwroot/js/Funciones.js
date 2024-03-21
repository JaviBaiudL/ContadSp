window.Funciones = {
    showAlert: function (message) {
        alert(message);
    }

    
};
window.showSweetAlert = function (title, message, type) {
    Swal.fire({
        title: title,
        text: message,
        icon: type
    });
};

