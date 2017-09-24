//SweetAlert2 for delete confirmation
function commentDelete(id, url) {
    swal({
        type: 'error',
        text: 'Are you sure you want to delete this comment?',
        allowOutsideClick: true,
        showCancelButton: true,
        confirmButtonText: 'Delete',
        confirmButtonColor: '#e74c3c',
        confirmButtonClass: null,
        showLoaderOnConfirm: true,
        preConfirm: function (data) {
            return $.post(url, {
                __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
            },
            function (response) {
                swal({
                    type: 'success',
                    title: 'Comment successfully deleted!',
                })
                $("div[data-id='" + id + "']").remove();
            });
        },
    });
}

function toggleCommentEdit(id) {
    $('#editForm-' + id).toggle();
    $('#comment-body-' + id).toggle();
}

