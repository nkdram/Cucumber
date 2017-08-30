var Conversion =
(function ($) {
    var conversion = {
        init: function () {
            $(document).ready(function () {
                var currencyDetails = JSON.parse(localStorage.getItem('currencysetting'));
                console.log(currencyDetails);
                //Hide details
                $(".conversion-details").hide();
                
                conversion.numberOnly('#Number');

                //Checking for curreny details
                if (currencyDetails.maindenomination) {
                    $('#MainCurrency').val(currencyDetails.maindenomination);
                }
                else {
                    $('#message-area').html("<div class='alert alert-danger'><strong>Error!</strong>Set Main currency details</div>");
                }
                if (currencyDetails.fracdenomination) {
                    $('#FractionalCurrency').val(currencyDetails.fracdenomination);
                }
                else {
                    $('#message-area').html("<div class='alert alert-danger'><strong>Error!</strong>Set Fractional currency details</div>");
                }
            });
        },
        setMessage: function (html, id) {
            if (id === undefined)
                $('#message-area').html(html);
            else {
                $(id).html(html);
            }
        },
        ShowFailure: function () {
            Conversion.setMessage("<div class='alert alert-danger'><strong>Error!</strong>Some error occured during submission </div>");
            $(".conversion-details").hide();
        },
        ShowSuccess: function () {
            var currencyDetails = JSON.parse(localStorage.getItem('currencysetting'));
            Conversion.setMessage("<strong> " + $('#FullName').val() + " </strong> <badge> Currency Set:" + currencyDetails["currency"] + "</badge>", "#currency-info");
            //Hide details
            $(".conversion-details").show();
            $('#message-area').hide();
        },
        numberOnly: function (selector) {
            $(selector).keypress(function (event) {
                var $this = $(this);
                if ((event.which != 46 || $this.val().indexOf('.') != -1) &&
                   ((event.which < 48 || event.which > 57) &&
                   (event.which != 0 && event.which != 8))) {
                    event.preventDefault();
                }

                var text = $(this).val();
                if ((event.which == 46) && (text.indexOf('.') == -1)) {
                    setTimeout(function () {
                        if ($this.val().substring($this.val().indexOf('.')).length > 3) {
                            $this.val($this.val().substring(0, $this.val().indexOf('.') + 3));
                        }
                    }, 1);
                }

                if ((text.indexOf('.') != -1) &&
                    (text.substring(text.indexOf('.')).length > 2) &&
                    (event.which != 0 && event.which != 8) &&
                    ($(this)[0].selectionStart >= text.length - 2)) {
                    event.preventDefault();
                }
            });

            $(selector).bind("paste", function (e) {
                var text = e.originalEvent.clipboardData.getData('Text');
                if ($.isNumeric(text)) {
                    if ((text.substring(text.indexOf('.')).length > 3) && (text.indexOf('.') > -1)) {
                        e.preventDefault();
                        $(this).val(text.substring(0, text.indexOf('.') + 3));
                    }
                }
                else {
                    e.preventDefault();
                }
            });
        }
    }
    return conversion;
})(window.jQuery);