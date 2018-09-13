$('[data-attr="submit"]').on('click', function () {
    $.ajax(
        {
            url: "/Student/Index",
            type: "POST",
            data: $('#StudentSearch').serialize(),
            success: function (response) {
                
                $('#PartialView').hide()
                $('#PartialResultView').html("")
                $('#PartialResultView').html(response)

            },
            error: function (err) {
                
            }
        });
});