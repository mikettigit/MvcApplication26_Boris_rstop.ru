var $ = jQuery;
$(document).ready(function () {
    
    $("<style>")
   .prop("type", "text/css")
       .html(".err {border: 1px solid #eb4848 !important; box-shadow: 0 0 10px #f00 !important;}")
       .appendTo("head");

    $("#SendButton").click(function () {
        iserr = false;

        nameField = $("[name='your-name']");
        nameField.removeClass("err");

        nameChars = " -ёйцукенгшщзхъфывапролджэячсмитьбюЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";;
        nameString = nameField.val();
        if (nameString.length < 3) {
            nameField.addClass("err");
            iserr = true;
        }
        else {
            i = 0;
            while (ch = nameString.substr(i, 1)) {
                if (nameChars.indexOf(ch) == -1) {
                    nameField.addClass("err");
                    iserr = true;
                    break;
                }
                i++;
            }
        }


        phoneField = $("[name='your-phone']");
        phoneField.removeClass("err");

        phoneChars = " +-()1234567890";
        phoneString = phoneField.val();
        if (phoneString.length < 7) {
            phoneField.addClass("err");
            iserr = true;
        }
        else {
            i = 0;
            while (ch = phoneString.substr(i, 1)) {
                if (phoneChars.indexOf(ch) == -1) {
                    phoneField.addClass("err");
                    iserr = true;
                    break;
                }
                i++;
            }
        }

        if (iserr) {
            alert("Пожалуйста, заполните все поля корректно");
        } else {
            $.post('/Home/SendMessage',
            {
                name: nameString,
                phone: phoneString,
                message: $("[name='your-message']").val(),
                subject: "Письмо с сайта"
            },
            function (data) {
                alert(data.Message);
            }, "json");
        }

        return false;
    })

})