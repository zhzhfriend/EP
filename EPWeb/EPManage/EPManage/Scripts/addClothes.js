$(document).ready(function () {
    $('#btnAddClothes').click(function () {
        var data = {
            'SampleNO': $('#SampleNO').val(),
            'StyleNO': $('#StyleNO').val(),
            'StylePics': getImages('#images_StylePics'),
            'ClothesPics': getImages('#images_ClothesPics'),
            'ModelVersionPics': getImages('#images_ModelVersionPics'),
            'clothSize': getClothesSize(),
            'ProductedCount': $('#ProductedCount').val(),
            'SaledCount': $('#SaledCount').val(),
            'Comment': $('#Comment').val(),
            'TechnologyFile': $('#TechnologyFile').val(),
            'AccessoriesFile': $('#AccessoriesFile').val(),
            'SampleFile': $('#SampleFile').val(),
            'ClothesTags': getUserSelectedItems()
        };
        $.post($('#btnAddClothes').attr('href'), data, function (data) {
            alert('保存成功');
            $('#myModal').modal('toggle');
        }, 'json');
        return false;
    });
});

function getImages(id) {
    var images = '';
    $(id + ' img').each(function (index, item) {
        images = images + $(item).attr('src') + ',';
    });
    if (images.length > 0)
        images = images.substring(0, images.length - 1);
    return images;
}

function getClothesSize() {
    var names = Array();
    var values = Array();
    var r = '';
    $('#clothSizeTable select').each(function (index, item) { names.push($(item).val()); });
    $('#clothSizeTable input[type="text"]').each(function (index, item) { values.push($(item).val()); });
    for (var i = 0; i < names.length; i++) {
        r = r + names[i] + '=' + values[i] + ',';
    }
    if (r.length > 0)
        r = r.substring(0, r.length - 1);
    return r;
}