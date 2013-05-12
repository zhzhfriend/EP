$(document).ready(function () {
    $('#addClothesSize').click(function () {
        var html = '<tr><td>';
        html = html + $('.clothesSizeDropDown').html();
        html = html + '</td><td><input type="text" name="size" class="input-mini"></td></tr>';
        $(html).appendTo($('#clothSizeTable'));
    });
});