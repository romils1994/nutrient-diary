Webcam.set({
    width: 320,
    height: 240,
    image_format: 'jpeg',
    jpeg_quality: 100
});
Webcam.attach('#my_camera');

$(document).ready(function () {
    $("#submitImage,#Base64Image").hide();
});

function takeSnapshot() {
    // take snapshot and get image data
    Webcam.snap(function (dataUri) {
        // display results in page
        if (!document.getElementById('imageprev'))
            document.getElementById('results').innerHTML = '<img id="imageprev" src="' + dataUri + '"/>';
        else
            document.getElementById("imageprev").src = dataUri;
    });
    var base64Image = document.getElementById("imageprev").src;
    document.getElementById("Base64Image").value = base64Image;
    $("#submitImage").show();
}