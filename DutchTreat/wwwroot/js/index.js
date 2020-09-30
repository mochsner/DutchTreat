$(document).ready(function () {
    var x = 0;
    var s = "";

    alert("hello pluralsight");


    var theForm = $("theForm");
    theForm.hide();

    var button = $("#buyButton");
    button.on("click", function () {
        console.log("buying item");
    });

    let productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("You clicked on " + $(this).text());
    })

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function () {
        $popForm.slideToggle();
    });
});
