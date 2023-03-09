// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let popup = document.getElementById("popup");
function openpopup() {
    popup.classList.add("open-popup");
}
function closepopup() {
    popup.classList.remove("open-popup");
}
function toggleDropdown() {
    var hiddenAnchor = document.getElementById("hiddenAnchor");
    if (hiddenAnchor.style.display === "none") {
        hiddenAnchor.style.display = "block";
    } else {
        hiddenAnchor.style.display = "none";
    }
}

