function formatCurrency(value) {
    if (typeof (value) == 'number')
        return '₹' + value.toFixed(2) + '/-';
    else 
        return '₹' + value + '/-';
}

jQuery["postJSON"] = function (url, data, callback) {
    // shift arguments if data argument was omitted
    if (jQuery.isFunction(data)) {
        callback = data;
        data = undefined;
    }

    return jQuery.ajax({
        url: url,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: data,
        success: callback
    });
};