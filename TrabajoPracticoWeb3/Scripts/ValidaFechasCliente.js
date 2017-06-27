$(function () {
    $.validator.methods.date = function (value, element) {
        Globalize.culture("en-AU");
        // you can alternatively pass the culture to parseDate instead of
        // setting the culture above, like so:
        // parseDate(value, null, "en-AU")
        return this.optional(element) || Globalize.parseDate(value) !== null;
    }
});

$(document).ready(function () {
    $.culture = Globalize.culture("en-GB");
    $.validator.methods.date = function (value, element) {
        //This is not ideal but Chrome passes dates through in ISO1901 format regardless of locale
        //and despite displaying in the specified format.

        return this.optional(element)
            || Globalize.parseDate(value, "dd/MM/yyyy", "en-GB")
            || Globalize.parseDate(value, "yyyy-mm-dd");
    }
});