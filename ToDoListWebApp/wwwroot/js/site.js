// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('offline', function (event) {
    $('#newtask').attr("disabled", "disabled");
    $('#newtask').css('pointer-events', 'none');
});
window.addEventListener(‘online’, function (event) {
    $('#newtask').removeAttr('disabled');
    $('#newtask').css('pointer-events', 'auto');
});
function myFunction() {
    alert("Hello World!");
}