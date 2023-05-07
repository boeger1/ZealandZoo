// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Check if the current page is the about page
function changeBackgroundImage() {
    if (window.location.pathname.includes("Calender")) {
        // Get a reference to the body element
        var body = document.getElementsByTagName('body')[0];

        // Set the background image
        body.style.backgroundImage = "url('../assets/img/beer-drink-wallpaper.jpg')";
    }

    if (window.location.pathname.includes("EventPage")) {
        // Get a reference to the body element
        var body = document.getElementsByTagName('body')[0];

        // Set the background image
        body.style.backgroundImage = "url('../Images/Festival.PNG')";

    }
}


// Call the method when the page is loaded
window.onload = changeBackgroundImage;
