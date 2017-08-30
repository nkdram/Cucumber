var Conversion =
(function ($) {
    var conversion = {
        init: function () {
            $(document).ready(function () {
                var currencyDetails = JSON.parse(localStorage.getItem('currencysetting'));
                console.log(currencyDetails);
                //Hide details
                $(".conversion-details").hide();

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
            else
            {
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
        }
    }
    return conversion;
})(window.jQuery);