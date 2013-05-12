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

    $('#search').click(function () {
        $('#container').empty();
        $('#container').append('<div>正在加载数据</div>');
        $.post('Main/Search', { param: getUserSelectedItems() }, function (data) {
            $('#container').empty();
            $('#container').append(data);
        });
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