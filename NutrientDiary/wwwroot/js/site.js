Webcam.set({
    width: 320,
    height: 240,
    image_format: 'jpeg',
    jpeg_quality: 100
});
Webcam.attach('#my_camera');

$(document).ready(function () {
    $("#submitImage").hide();
});

function take_snapshot() {
    // take snapshot and get image data
    Webcam.snap(function (dataUri) {
        // display results in page
        document.getElementById('results').innerHTML =
            '<img src="' + dataUri + '"/>';
    });
    document.getElementById("Base64Image").value = dataUri.replace(/^data:image\/[a-z]+;base64,/, "");
    $("#submitImage").show();
}