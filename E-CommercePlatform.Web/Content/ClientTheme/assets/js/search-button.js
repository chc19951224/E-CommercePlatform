$(document).ready(function() {
    // 显示搜索框
    $('.search-switch').on('click', function() {
        $('.search-model-box').addClass('open');
    });

    // 隐藏搜索框
    $('.search-close-btn').on('click', function() {
        $('.search-model-box').removeClass('open');
    });
});
