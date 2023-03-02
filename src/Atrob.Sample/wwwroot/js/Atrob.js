//fileRequired
jQuery.validator.addMethod("fileRequired", function (value, element, param) {
    if (element.files[0] != null) return element.files[0].size > 0;
    return false;
});
jQuery.validator.unobtrusive.adapters.addBool("fileRequired");

//fileNotEmpty
jQuery.validator.addMethod("fileNotEmpty", function (value, element, param) {
    if (element.files[0] != null) return element.files[0].size > 0;
    return true;
});
jQuery.validator.unobtrusive.adapters.addBool("fileNotEmpty");

//maxFileSize
jQuery.validator.addMethod('maxFileSize', function (value, element, param) {
    if (element.files[0] != null) {
        var maxFileSize = $(element).data('val-maxsize');
        var selectedFileSize = element.files[0].size;
        return maxFileSize >= selectedFileSize;
    }
    return true;
});
jQuery.validator.unobtrusive.adapters.addBool('maxFileSize');

//minFileSize
jQuery.validator.addMethod('minFileSize', function (value, element, param) {
    if (element.files[0] != null) {
        var minFileSize = $(element).data('val-minsize');
        var selectedFileSize = element.files[0].size;
        return minFileSize <= selectedFileSize;
    }
    return true;
});
jQuery.validator.unobtrusive.adapters.addBool('minFileSize');

//maxAndMinFileSize
jQuery.validator.addMethod('maxAndMinFileSize', function (value, element, param) {
    if (element.files[0] != null) {
        var maxFileSize = $(element).data('val-maxsize');
        var minFileSize = $(element).data('val-minsize');
        var selectedFileSize = element.files[0].size;
        return minFileSize <= selectedFileSize && maxFileSize >= selectedFileSize;
    }
    return true;
});
jQuery.validator.unobtrusive.adapters.addBool('maxAndMinFileSize');

//allowedExtensions
jQuery.validator.addMethod('allowedExtensions', function (value, element, param) {
    if (element.files[0] != null) {
        var whiteListExtensions = $(element).data('val-whitelistextensions').split(',');
        return whiteListExtensions.includes(element.files[0].type);
    }
    return true;
});
jQuery.validator.unobtrusive.adapters.addBool('allowedExtensions');

//notAllowedExtensions
jQuery.validator.addMethod('notAllowedExtensions', function (value, element, param) {
    if (element.files[0] != null) {
        var whiteListExtensions = $(element).data('val-blacklistextensions').split(',');
        return !whiteListExtensions.includes(element.files[0].type);
    }
    return true;
});
jQuery.validator.unobtrusive.adapters.addBool('notAllowedExtensions');

//divisibility
jQuery.validator.addMethod('divisibility', function (value, element, param) {
    var numbersDivisible = $(element).data('val-numbersdivisible').split(',');
    if (numbersDivisible.find((n) => parseInt(element.value) % n == 0) == undefined)
        return false;
    return true;
});
jQuery.validator.unobtrusive.adapters.addBool('divisibility');

//boolValidation
jQuery.validator.addMethod('boolValidation', function (value, element, param) {
    return $(element)[0].checked;
});
jQuery.validator.unobtrusive.adapters.addBool('boolValidation');


//maxDateTimeValidation
jQuery.validator.addMethod('maxDateTime', function (value, element, param) {
    var maxDateTime = new Date($(element).data('val-maxdatetimevalue'));
    var dateTime = new Date(element.value);
    return maxDateTime >= dateTime;
});
jQuery.validator.unobtrusive.adapters.addBool('maxDateTime');


//minDateTimeValidation
jQuery.validator.addMethod('minDateTime', function (value, element, param) {
    var minDateTime = new Date($(element).data('val-mindatetimevalue'));
    var dateTime = new Date(element.value);
    return minDateTime <= dateTime;
});
jQuery.validator.unobtrusive.adapters.addBool('minDateTime');

//maxDate
jQuery.validator.addMethod('maxDate', function (value, element, param) {
    var maxDate = new Date($(element).data('val-maxdatevalue'));
    var date = new Date(element.value);
    return maxDate.getDate() >= date.getDate();
});
jQuery.validator.unobtrusive.adapters.addBool('maxDate');


//minDate
jQuery.validator.addMethod('minDate', function (value, element, param) {
    var maxDate = new Date($(element).data('val-mindatevalue'));
    var date = new Date(element.value);
    return maxDate.getDate() <= date.getDate();
});
jQuery.validator.unobtrusive.adapters.addBool('minDate');