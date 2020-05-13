function GetModelsByBrand(idBrand, model) {
    $.ajax({
        type: "GET",
        dataType: "html",
        url: "/Car/GetModels/" + idBrand,
        success: function (data) {
            $("#" + model).html("");
            $("#model-select").html(data);
        },
        error: function () {
            alert("Error in ajax request.");
        }
    })
}