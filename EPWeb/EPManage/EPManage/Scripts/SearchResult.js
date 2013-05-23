$(document).ready(function () {
    bindDetailIcon();
});

function bindDetailIcon() {
    $('.detailIcon').click(function () {
        $.post('/Clothes/Pics', { id: $(this).attr('data'), type: $(this).attr('data-type') }, function (data) {
            $('#viewPicsModalBody').html(data);
            $('#viewPicsModal').modal();
        }).fail(function (data) { alert('加载失败'); });
    });
}