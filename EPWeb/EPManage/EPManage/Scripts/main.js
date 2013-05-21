function bindRemoveIcon() {
    $('.itemclose').click(function (item) {
        $('input[name="' + $(this).parent().attr('data') + '"]').click()
        $('input[value="' + $(this).parent().attr('data') + '"]').click()
    });
}
$(document).ready(function () {
    bindRemoveIcon();
    $('input[type="checkbox"]').click(function (item) {
        var name = $(this).attr('name');
        if ($(this)[0].checked) {
            $('#searchParameters').append('<li data="' + name + '" class="btn btn-success">' + name + '<button class="close itemclose">&times;</button></li>');
            bindRemoveIcon();
        }
        else {
            $('#searchParameters li').each(function (index, item) {
                if ($(item).html().indexOf(name) > -1)
                    $(item).remove();
            });
        }
    });
    $('.dropdown-select').multiselect({
        header: false,
        minWidth: '130',
        'class': 'a',
        selectedList: 4,
        'noneSelectedText': 'None'
    });

    $(".dropdown-select").on("multiselectclick", function (event, ui) {
        if (ui.value != '0') {
            if (ui.checked) {
                $('#searchParameters').append('<li data="' + ui.value + '" class="btn btn-success">' + ui.value + '<button class="close itemclose">&times;</button></li>');
                bindRemoveIcon();
            }
            else {
                $('#searchParameters li').each(function (index, item) {
                    if ($(item).html().indexOf(ui.value) > -1)
                        $(item).remove();
                });
            }
        }
    });

    $('#search').click(function () {
        searchClothes(function () {
            return { 'tags': getUserSelectedItems(), 'clothesTypeId': $('#clothesTypeId').val() };
        });
        return false;
    });

    $('#imgSearch').click(function () {
        searchClothes(function () {
            return data = { "NO": $('#txtSearchNO').val(), 'clothesTypeId': $('#clothesTypeId').val() };
        });
        return false;
    });

    $('#search').click();
});

function searchClothes(getDataParamsFunc) {
    $('#container').html('<div class="alert alert-info">正在加载数据</div>');
    var data = getDataParamsFunc();
    $.post($('#search').attr('href'), data, function (data) {
        $('#container').empty();
        $('#container').append(data);
    }).fail(function () {
        $('#container').html('<div class="alert alert-error">加载数据失败</div>');
    });
    return false;
}

function getUserSelectedItems() {
    var items = Array();
    $('#searchParameters li').each(function (index, item) {
        items.push($(item).attr('data'));
    });
    return items.join(',');
}