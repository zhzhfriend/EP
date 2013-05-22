$(document).ready(function () {
    $('#addClothesSize').click(function () {
        var html = '<tr><td>';
        html = html + $('.clothesSizeDropDown').html();
        html = html + '</td><td><input type="text" name="size" class="input-mini"/><button class="close tdCloseIcon">&times;</button></td></tr>';
        $(html).appendTo($('#clothSizeTable'));
        bindTdCloseIcon();
    });
});

function bindTdCloseIcon() {
    $('.tdCloseIcon').click(function () {
        $(this).parentsUntil('tbody').remove();
    });
}