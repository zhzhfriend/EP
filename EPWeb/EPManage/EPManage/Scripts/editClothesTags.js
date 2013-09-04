$('#btnEditClothesTags').click(function () {
    if (getUserSelectedItems().length == 0) {
        alert('您尚未选择特征信息');
    }
    else if (!validSelectItems()) {
        return false;
    }
    else {
        $.post('/Clothes/EditClothesTags', { tags: getUserSelectedItems(), id: $('#clothesId').val() }).success(function (data) {
            if (data == true) {
                alert('保存成功');
                $('#clseBtnEditClothesTags').click();
            }
            else
                alert('保存失败');
        }).fail(function () { alert('保存失败'); });
        return false;
    }
});

function getUserSelectedItems() {
    var items = Array();
    $('input[type="checkbox"]:checked').each(function (index, item) {
        items.push($(item).attr('partId') + '-' + $(item).attr('name'));
    });
    return items.join(',');
}

function validSelectItems() {
    var r = true;
    $('ul.nav').each(function (index, item) {
        if ($(item).attr('multiple') == undefined)
            if ($(item).find('input[type="checkbox"]:checked').length > 1) {
                alert('一个属性只可选择一个值');
                r = false;
            }
    })
    return r;
};