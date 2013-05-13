$(document).ready(function () {
    $('#btnAddClothesPartType').click(function () {
        var data = { 'name': $('#name').val(), 'partId': $('#clothPartId').val() };
        $.post($('#btnAddClothesPartType').attr('href'), data, function (data) {
            $('#nav_' + $('#clothPartId').val() + ' li:last').before('<li data="' + data.Id + '" class="btn btn-success">' + data.Name + '<button data="' + data.Id + '" class="close">&times;</button></li>');
            $('#myModal').modal('hide');
            $('#name').val('');
            $('#clothPartId').val('');
            initAllRemoveButtons();
        }).fail(function () { alert('添加失败'); });
        return false;
    });
    $('button[data-target="#myModal"]').click(function () {
        $('#clothPartId').val($(this).attr('data'));
    });

    initAllRemoveButtons();

    $("ul").sortable();

    $('.sortbtn').click(function () {
        var items = Array();
        $('ul#nav_' + $(this).attr('data') + '').children().each(function (index, item) {
            items.push($(item).attr('typeId'));
        });
        $.post('/Main/order', { 'partId': $(this).attr('data'), 'items': items.join(',') }, function (data) {
            alert('保存成功');
        }).fail(function () { alert('保存失败'); });
        return false;
    });
});

function initAllRemoveButtons() {

    $('button.close').click(function () {
        $('body').data('id', $(this).attr('data'));
        $.post('/Main/DeleteClothesPartType', { id: $(this).attr('data') }, function (data) {
            if (data == true)
                $('button[data="' + $('body').data('id') + '"]').parent().remove();
            else
                alert('删除失败');
        }).fail(function () { alert('删除失败'); });
        return false;
    });
}