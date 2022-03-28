async function AjaxApiRequest(type, url, data = null) {
    const response = await $.ajax({
        type: type,
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    });

    return response;
}