var count = 0;
var duration = 3000;
var imagesCount = 10;

function GetNewPosition() {
    var windowHeight = $(window).height();
    var divImageHeight = $('#divPersonImage').height();
    var desiredBottom = 100;
    var newPosition = windowHeight - (divImageHeight + desiredBottom);

    return newPosition;
}
function PlayGame() {
    console.log('PlayGame call')
    count++;
    if (count > imagesCount) { 
        swal({
            title: "End game",
            text: " Your total score is " + $("#spanPoints").html(),
            type: "success"
        });
        $("#btnPlayGame").html("Reply Game");
        count = 0;
        return;
    }

    if (count == 1) {
        $("#spanPoints").html('0');
    }

    var newPosition = GetNewPosition();
    $.ajax({
        url: 'Home/GetNewPerson',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
        
            if (data.result) {
                $("#imgPerson").attr('src', data.value.Image);
                $("#imgPerson").attr('imageid', data.value.Id); 
                $('#divPersonImage').show();
                $("#divPersonImage").animate({
                    marginTop: newPosition
                }, {
                        duration: duration,
                        complete: function () {
                            $("#divPersonImage").fadeOut(1, function () {
                                $("#divPersonImage").css('margin-top', 0);
                                if (count < imagesCount) {
                                    $("#btnPlayGame").trigger('click')
                                }
                                else {
                                    swal({
                                        title: "End game",
                                        text: "",
                                        type:  "success"  
                                    });  
                                }
                            });
                        }
                    });
            }
        },
        error: function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
};

function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");

    var lastBoxHtml = $(ev.target).html();
    var selectedImageID = $("#" + data).attr('imageid');
    var selectedBoxCorner = $(ev.target).attr('boxid');

    var newimage = $("#" + data).clone();
    $(newimage).attr('id', '');

    $(ev.target).html(newimage);

    $(newimage).fadeOut('slow', function () {
        $(ev.target).html(lastBoxHtml);
    });

    $("#divPersonImage").stop();
    $("#divPersonImage").css('margin-top', 0);
    $("#divPersonImage").hide();

    $.ajax({
        url: 'Home/CalculatePointGame',
        type: 'GET',
        data: { boxId: selectedBoxCorner, imgId: selectedImageID },
        dataType: 'json',
        success: function (data) {
            console.log(data)
            if (data.result) {
                var point =
                    parseInt($("#spanPoints").html()) + parseInt(data.value);
                $("#spanPoints").html(point);
                $("#btnPlayGame").trigger('click');
            }
        },
        error: function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
}
