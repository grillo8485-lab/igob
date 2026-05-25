$(document).ready(function () {
    $('#ListadoLicitacion').DataTable({
        order: [[1, "asc"]],
        searching: false,
        ordering: false,
        paging: false,
        sortable: false,
        bInfo: false,
        drawCallback: function () {
            $('.dataTables_empty').css('display', 'none')
        }
    });

    $('#ConsularListado').on('click', function (event) {
        event.preventDefault();
        if (evaluar()) {
            location.href = `/ListadoLicitaciones/index?id=${$('#IdTipoLicitacion').val().trim()}&id2=${$('#IdEjercicioFiscal').val().trim()}&id3=${$('#IdUsuario').val().trim()}&id4=${$('#IdTipoRequisicion').val().trim()}`
        } else {
            mensajeGenerico("Aviso", "Falta selecionar campos", "")
        }
    })
    $("input[name='id']").on('click', function () {
        let ConSer = false;
        let AdqBin = false;
        let segundaVuelta = false;
        let primeraVuelta = false;
        let countSegundaVuelta = 0;
        $("input[name='id']:checked").each(function () {

            
            if ($(this).attr('dataTypeLicitacion').trim() == "1") {


                if ($(this).attr('datatype').trim() == "Contratación de Servicios") {
                    ConSer = true;
                }
                if ($(this).attr('datatype').trim() == "Adquisición de Bienes") {
                    AdqBin = true;
                }
                primeraVuelta = true;
            }
            else {
                segundaVuelta = true;
                countSegundaVuelta++;
            }
        })
        
        if (AdqBin && ConSer) {
            mensajeGenerico("Aviso", "No se puede unir un bien con un servicio", "")
            $(this).prop('checked',false)
        }
        if (primeraVuelta && segundaVuelta) {
            mensajeGenerico("Aviso", "No se puede unir licitación de primera con segunda vuelta", "")
            $(this).prop('checked', false)
        }
        if (countSegundaVuelta>1) {
            mensajeGenerico("Aviso", "No se puede unir más de 2 licitación de segunda vuelta", "")
            $(this).prop('checked', false)
        }
    })
    $("#btnGenLicitacion").on('click', function () {

        if (evaluar()) {
            if (evaluarchecks()) {
                bootbox.confirm({
                    title: "<div class='col-12 text-center'>Generar licitación<div>",
                    message: "¿Desea generar una licitación?",
                    size: 'small',
                    callback: function (res) {
                        if (res) {
                            let data = $(`input[name='id']:checked,#IdLicitacion,#IdEjercicioFiscal,#IdTipoLicitacion`).serialize()//Id = IdLicitacion, IdEjercicioFiscal, Listado IdRequisiciones
                            location.href = '/ListadoLicitaciones/Listadolicitaciones?' + data
                        }
                    }
                }).find('.modal-dialog').addClass("modal-dialog-centered");
            } else {
                mensajeGenerico("Aviso", "Falta selecionar requisiones", "")
            }

        } else {
            mensajeGenerico("Aviso", "Falta selecionar campos", "")
        }
    })
    function evaluar() {
        return ($('#IdTipoLicitacion').val().trim() == "" || $('#IdEjercicioFiscal').val().trim() == "" || $('#IdUsuario').val().trim() == "" || $('#IdTipoRequisicion').val().trim() == "") ? false : true;
    }
    function evaluarchecks() {
        return ($("input[name='id']:checked").length > 0) ? true : false;
    }
    $(function () {
        var errorLicitacion = $('#errorLicitacion').val();
        if (errorLicitacion != "") {
            mensajeGenerico("Aviso", errorLicitacion,"")
        }
    });
})