// wwwroot/js/autocomplete.js
$(document).ready(function () {
    // 當輸入框的內容發生改變時觸發
    $('#dishNameInput').on('input', function () {
        // 獲取輸入的內容
        var input = $(this).val();

        // 發送 AJAX 請求
        $.ajax({
            type: 'GET',
            url: '/Menu/SearchDishes',
            data: { term: input },
            success: function (data) {
                // 清空建議列表
                $('#suggestions').empty();

                // 將 AJAX 返回的菜品名稱添加到建議列表中
                data.forEach(function (item) {
                    $('#suggestions').append('<div>' + item + '</div>');
                });

                // 當用戶點擊建議列表中的項目時，將該項目填充到輸入框中
                $('#suggestions div').on('click', function () {
                    $('#dishNameInput').val($(this).text());
                    $('#suggestions').empty();
                });
            }
        });
    });
});
