// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function copyToClipboard() {
    //select the element with the id "copyMe", must be a text box
    const textToCopy = document.getElementById("cronExpression");
    const expression = textToCopy.value;
    //copy the text to the clipboard
    navigator.clipboard.writeText(expression)
        .then(_ => alert(`successfully copied "${expression}" expression`));
}