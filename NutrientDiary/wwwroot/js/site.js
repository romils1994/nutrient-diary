if (typeof Webcam !== 'undefined') {
    Webcam.set({
        width: 320,
        height: 240,
        image_format: 'jpeg',
        jpeg_quality: 100
    });
    Webcam.attach('#my_camera');
}
$(document).ready(function () {
    $("#submitImage,#Base64Image").hide();
});

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
    $("#submitImage").show();
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
    $("#submitImage").show();
}