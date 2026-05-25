$(document).ready(function () {
    var conteo = $("#conteo").val();
    if (conteo > 0) {
        var table = $('#tablaListadoRequisicionLicitacion').DataTable({
            scrollY: "450px",
            scrollCollapse: true,
            scrollX: true,
            sort: false,
            initComplete: function (settings, json) {
                setTimeout(function () { $("#tablaListadoRequisicionLicitacion").DataTable().draw(); }, 200);
            }
        }).draw();
    }
    else {
        var table = $('#tablaListadoRequisicionLicitacion').DataTable({

        });
    }

});
