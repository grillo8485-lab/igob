$(document).ready(function () {
    $('#LicitacionesListadoInvitaciones').DataTable({
        scrollY: 440,
        scrollCollapse: true,
        sort: false
    });

    $('#LicitacionesListadoInvitaciones').on('click', '.data', function () {
        let licitacion = $(this).attr('dataLicitacion')
        //console.log(licitacion)
        location.href = `/AceptarInvitacion/Index/?IdLicitacion:${licitacion}`;
    })

    function showModalView(header, msm) {
        $('#modaldiv').html(modalview(header, msm))
        $('#alertaModal').modal('show')
    }
    function modalview(title, body) {
        return modal = `<div class="modal fade" id="alertaModal" tabindex="-1" role="dialog" aria-hidden="true">
                      <div class="modal-dialog" style="max-width:500px">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="modal-title"><strong>${title}</strong></h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                              <span aria-hidden="true">&times;</span>
                            </button>
                          </div>
                          <div class="modal-body" style="word-wrap:break-word">
                            <h6><strong>${body}</strong></h6>
                          </div>
                          <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                          </div>
                        </div>
                      </div>
                    </div>`
    }
})