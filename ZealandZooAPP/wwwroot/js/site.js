function changeBackgroundImage() {
    if (window.location.pathname.includes("index")) {
        // Get a reference to the body element
        var body = document.getElementsByTagName('body')[0];

        // Set the background image
        body.style.backgroundImage = "url('../assets/wallhaven-z8mr5y.png')";
    }
}


// Call the method when the page is loaded
window.onload = changeBackgroundImage;