function bindRemoveIcon() {
    $('.close').click(function (item) {
        $(this.parentNode).remove();
    });
}
$(document).ready(function () {
    bindRemoveIcon();
    $('input[type="checkbox"]').click(function (item) {
        var name = $(this).attr('name');
        if ($(this)[0].checked) {
            $('#searchParameters').append('<li data="' + name + '" class="btn btn-success">' + name + '<button class="close">&times;</button></li>');
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
        minWidth: '100',
        'class': 'a',
        selectedList: 4,
        'noneSelectedText': 'None'
    });

    $(".dropdown-select").on("multiselectclick", function (event, ui) {
        if (ui.value != '0') {
            if (ui.checked) {
                $('#searchParameters').append('<li data="' + ui.value + '" class="btn btn-success">' + ui.value + '<button class="close">&times;</button></li>');
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
        $('#container').html('<div class="alert alert-info">正在加载数据</div>');
        $.post($('#search').attr('href'), { param: getUserSelectedItems() }, function (data) {
            $('#container').empty();
            $('#container').append(data);
        }).fail(function () {
            $('#container').html('<div class="alert alert-error">加载数据失败</div>');
        });
        return false;
    });

    $('#search').click();
});

function getUserSelectedItems() {
    var items = Array();
    $('#searchParameters li').each(function (index, item) {
        items.push($(item).attr('data'));
    });
    return items.join(',');
}