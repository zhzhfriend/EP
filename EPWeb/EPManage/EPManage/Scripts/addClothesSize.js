$(document).ready(function () {
    $('#addClothesSize').click(function () {
        var html = '<tr><td>';
        html = html + '<input type="text" name="name" class="input-mini"/>';
        html = html + '</td><td><input type="text" name="size" class="input-mini"/><button class="close tdCloseIcon">&times;</button></td></tr>';
        $(html).appendTo($('#clothSizeTable'));
        bindTdCloseIcon();
    });
});

function bindTdCloseIcon() {
    $('.tdCloseIcon').click(function () {
        $(this).parentsUntil('tbody').remove();
    });
    $('input[name="name"] :last').autocomplete({
        source: ['后中长', '胸围', '腰围', '臀围', '摆围', '内长'],
        minLength: 0
    }).autocomplete('search', '');
}