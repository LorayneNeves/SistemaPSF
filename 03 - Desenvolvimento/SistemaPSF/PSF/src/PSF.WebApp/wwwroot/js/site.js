
$(document).ready(function () {
    $('.delete-button').on('click', function (e) {
        e.preventDefault();

        var link = $(this);
        var usuarioId = link.attr('asp-route-usuarioId');

        $('#confirm-delete-button').attr('href', link.attr('href'));
        $('#confirm-delete-modal').modal('show');
    });
});
