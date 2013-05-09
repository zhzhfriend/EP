$(document).ready(function () {
    //var button = $('#button1');
    $('.uploadbutton').each(function (index, item) {
        new AjaxUpload(item, {
            action: '/upload/Index',
            name: 'myfile',
            responseType: 'json',
            onSubmit: function (file, ext) {
                var button = $(this._button);
                button.text('正在上传');
                this.disable();
                interval = window.setInterval(function () {
                    var text = button.text();
                    if (text.length < 13) {
                        button.text(text + '.');
                    } else {
                        button.text('正在上传');
                    }
                }, 200);
            },
            onComplete: function (file, response) {
                var button = $(this._button);
                button.text('上传');
                window.clearInterval(interval);
                this.enable();
                if (response.Success) {
                    var img = $('#images_' + button.attr('data'));
                    $('<li><img src="' + response.FileName + '" width="75"/><p class="delImg">删除</p></li>').appendTo(img);

                    bindImageEvent();
                }
                else {
                    alert('上传失败，失败原因：' + response.ErrMsg);
                }
            }
        });
    });
});

function bindImageEvent() {
    $('img').click(function () {
        window.open(this.src);
    });
    $('.delImg').click(function (item) {
        $(this.parentNode).remove();
    });
}