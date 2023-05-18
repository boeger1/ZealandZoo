function changeBackgroundImage() {
    if (window.location.pathname.includes("index")) {
        // Get a reference to the body element
        var body = document.getElementsByTagName("body")[0];

        // Set the background image
        body.style.backgroundImage = "url('../assets/wallhaven-z8mr5y.png')";
    }
}


// Call the method when the page is loaded
window.onload = changeBackgroundImage;

function checkClickFunc() {
    var checkbox = document.getElementById("is-free-checkbox");
    if (checkbox.checked == true) {
        document.getElementById("price-input").disabled = true;
        document.getElementById("price-input").value = 0;
    } else {
        document.getElementById("price-input").disabled = false;
    }
}