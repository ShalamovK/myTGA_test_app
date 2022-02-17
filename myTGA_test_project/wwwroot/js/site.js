// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


window.showNotify = function(message, type, caption, time) {
    $.notify({
        title: caption,
        message: message
    },
        {
            type: type ? type : 'info',
            timer: time ? time : 2000,
            animate: {
                enter: 'animated slideInUp',
                exit: 'animated slideOutDown'
            },
            placement: { from: 'bottom', align: "center" },
            z_index: 1051
        }
    );
}