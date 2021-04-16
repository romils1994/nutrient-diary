if (typeof Webcam !== 'undefined') {
    Webcam.set({
        width: 320,
        height: 240,
        image_format: 'jpeg',
        jpeg_quality: 100
    });
}
var foodDetails = {};
$(document).ready(function () {
    $("#submitImage,#Base64Image,#capture").hide();
    $("#camera_on").show();
    $(".nutrient-tabs a").click(function () {
        $(this).tab('show');
    });

    $(function updateNutrientInfo() {
        if ($("input[data-food-item]")) {
            $("input[data-food-item]").each(function (key, val) {
                var foodItem = $(this).data("food-item");
                var foodNutrient = new Array();
                $("table[data-fdc=" + foodItem + "] tbody").find('tr').each(function (key, val) {
                    var td = $(this).find('td');
                    foodNutrient[key] = td.eq(1).text();
                });
                foodDetails[foodItem] = foodNutrient;
            });
        }
    });
});

function turnOnCamera() {
    Webcam.attach('#my_camera');
    $("#camera_on").hide();
    $("#capture").show();
    $("#image-details").hide();
}

function takeSnapshot() {
    // take snapshot and get image data
    Webcam.snap(function (dataUri) {
        // display results in page
        if (!document.getElementById('imageprev'))
            document.getElementById('results').innerHTML = '<img id="imageprev" class="img-fluid margin-top-42" src="' + dataUri + '"/>';
        else
            document.getElementById("imageprev").src = dataUri;
    });
    var base64Image = document.getElementById("imageprev").src;
    document.getElementById("Base64Image").value = base64Image;
    document.getElementById("imageSelector").value = "";
    $("#defaultImage").hide();
    $("#submitImage").show();
    $("#image-details").hide();
}

function previewFile() {
    const file = document.querySelector('input[type=file]').files[0];
    const reader = new FileReader();

    reader.addEventListener("load", function () {
        // convert image file to base64 string
        if (!document.getElementById('imageprev'))
            document.getElementById('results').innerHTML = '<img id="imageprev" class="img-fluid margin-top-42" src="' + reader.result + '"/>';
        else
            document.getElementById("imageprev").src = reader.result;
        document.getElementById("Base64Image").value = reader.result;
    }, false);

    if (file) {
        reader.readAsDataURL(file);
    }
    $("#defaultImage").hide();
    $("#submitImage").show();
}

$("input[name=portion]").change(function updateNutrientInfo() {
    var foodItem = $(this).data("food-item");
    var portionSize = $(this).val();
    $("table[data-fdc=" + foodItem + "] tbody").find('tr').each(function (key, val) {
        var td = $(this).find('td');
        var initialAmount = foodDetails[foodItem][key];
        var updAmount = ((portionSize / 100) * initialAmount).toFixed(2);
        if (updAmount % 1 === 0) {
            updAmount = updAmount.toFixed(0);
        }
        td.eq(1).text(updAmount);
    });
});