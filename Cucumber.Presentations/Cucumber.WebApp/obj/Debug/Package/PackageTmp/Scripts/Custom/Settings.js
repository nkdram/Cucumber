var Settings =
(function ($) {
    var settings = {
        init: function () {
            $(document).ready(function () {
                //Load selected Values
                settings.loadDefault();
                $('.dropdown-item').click(function () {
                    $('#countryselect').text($(this).text());
                    settings.getCurrentDetails($(this).text(), function (curr) {
                        $('#CurrencyDetails').text(curr.name);
                    });
                });
                $('#submit_btn').click(function () {
                    var currenySettings = {
                        "currency": $('#CurrencyDetails').text(),
                        "maindenomination": $('#MainCurreny').val(),
                        "fracdenomination": $('#FractionalCurrency').val()
                    }
                    localStorage.setItem('currencysetting', JSON.stringify(currenySettings));
                    $('#message-area').html("<div class='alert alert-danger'><strong>Current Details</strong> Saved</div>");
                })
            });
        },
        getCurrentDetails: function (country, callback) {
            $.ajax({
                url: "https://restcountries.eu/rest/v2/name/" + country + "?fullText=true"
            }).done(function (data) {
                console.log(data);
                callback(data[0].currencies[0]);
            });
        },
        loadDefault: function () {
            var currencyDetails = JSON.parse(localStorage.getItem('currencysetting'));
            if (currencyDetails) {
                $('#CurrencyDetails').text(currencyDetails["currency"]);
                $('#MainCurreny').val(currencyDetails["maindenomination"]);
                $('#FractionalCurrency').val(currencyDetails["fracdenomination"]);
            }
        }
    }
    return settings;
})(window.jQuery);