$(document).ready(function () {
    var table =  $('#requisicionConsultaTable').DataTable({
        scrollY: "450px",
        scrollCollapse: true,
        scrollX: true,
        sort: false,
        initComplete: function (settings, json) {
            setTimeout(function () { $("#requisicionConsultaTable").DataTable().draw(); }, 200);
        }
    }).draw();
});
function altaRequisicion() {
    var a = $("#idLista").val();
    location.href = '/Requisiciones/Index/' + a;
}