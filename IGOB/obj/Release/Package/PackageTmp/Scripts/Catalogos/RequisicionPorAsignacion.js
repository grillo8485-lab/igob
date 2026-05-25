$(document).ready(function () {
    $('#btnAsignarRev').on('click', function () {
        if ($('#IdUsuarioRevisor').val() && $('#IdUsuarioAsignante').val() && $('#IdRequisicion').val()) {
            bootbox.confirm({
                title: "Asignar revisor",
                message: "¿Desea asignar revisor?",
                size: "small",
                callback: function (res) {
                    if (res) {
                        traerTokenCapturaGenerico({ title: "Introduce token", CallBack: validarTokenGenerico, CallBackPersonalizado: saveRequisicionAsignacionRevisor, b: undefined })
                    }
                }
            }).find('.modal-dialog').addClass("modal-dialog-centered");
        } else {
            mensajeGenerico("Aviso", "Selecciones Revisor", "")
        }
    })

    // Cache selectors for faster performance.
    var $window = $(window),
        $mainMenuBar = $('.mainMenuBar'),
        $mainMenuBarAnchor = $('.mainMenuBarAnchor');

    // Run this on scroll events.
    $window.scroll(function () {
        var window_top = $window.scrollTop();
        var div_top = $mainMenuBarAnchor.offset().top;
        var diff = (Math.abs((window_top - 9) - (div_top)));

        if (diff < 9) {
            return false;
        } else if (window_top > div_top) {
            // Make the div sticky.
            $mainMenuBar.addClass('stick');
            $mainMenuBarAnchor.height($mainMenuBar.height());
        }
        else {
            // Unstick the div.
            $mainMenuBar.removeClass('stick');
            $mainMenuBarAnchor.height(0);
        }
    });
})

function retornarPagina(a) {
    location.href = `/RequisicionConsulta/Index/${a}`;
}

function saveRequisicionAsignacionRevisor() {
    $.post(
        '/RequisicionAsignacion/asignarRevisor',
        {
            IdUsuarioRevisor: $('#IdUsuarioRevisor').val(),
            IdUsuarioAsignante: $('#IdUsuarioAsignante').val(),
            IdRequisicion: $('#IdRequisicion').val(),
            __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
        },
        "json"
    ).done(
        function (resp) {
            mensajeGenerico("Aviso", resp, "1")
        }
    )
}