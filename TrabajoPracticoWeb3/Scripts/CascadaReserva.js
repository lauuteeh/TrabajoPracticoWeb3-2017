 $(document).ready(function () {
        //Dropdownlist Selectedchange event
        $("#Version").change(function () {
            $("#Sede").empty();
            $("#Dia").empty();
            $("#Horario").empty();
            $.ajax({
                type: 'POST',
                url: '@Url.Action("GetStates")', // we are calling json method

                dataType: 'json',

                data: { id: $("#Version").val() },
                // here we are get value of selected country and passing same value as inputto json method GetStates.


                success: function (states) {
                    // states contains the JSON formatted list
                    // of states passed from the controller

                    $.each(states, function (i, state) {
                        $("#Sede").append('<option value="' + state.Value + '">' +
                            state.Text + '</option>');
                        // here we are adding option for States

                    });
                },
                error: function (ex) {
                    alert('Failed to retrieve states.' + ex);
                }
            });
            return false;
        })
    });
        $(document).ready(function () {
            //Dropdownlist Selectedchange event
            $("#Sede").change(function () {
                $("#Dia").empty();
                $("#Horario").empty();
                $.ajax({
                    type: 'POST',
                    url: '@Url.Action("GetCity")',
                    dataType: 'json',
                    data: { id: $("#Sede").val() },
                    success: function (citys) {
                        // states contains the JSON formatted list
                        // of states passed from the controller
                        $.each(citys, function (i, city) {
                            $("#Dia").append('<option value="'
                                + city.Value + '">'
                                + city.Text + '</option>');
                        });
                    },
                    error: function (ex) {
                        alert('Failed to retrieve states.' + ex);
                    }
                });
                return false;
            })
        });

        $(document).ready(function () {
            //Dropdownlist Selectedchange event
            $("#Dia").change(function () {
                $("#Horario").empty();
                $.ajax({
                    type: 'POST',
                    url: '@Url.Action("GetHorario")',
                    dataType: 'json',
                    data: { id: $("#Dia").val() },
                    success: function (citys) {
                        // states contains the JSON formatted list
                        // of states passed from the controller
                        $.each(citys, function (i, city) {
                            $("#Horario").append('<option value="'
                                + city.Value + '">'
                                + city.Text + '</option>');
                        });
                    },
                    error: function (ex) {
                        alert('Failed to retrieve states.' + ex);
                    }
                });
                return false;
            })
        });
