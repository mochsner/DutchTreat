var x = 0;
var s = "";

alert("hello pluralsight");


var theForm = document.getElementById("theForm");
theForm.hidden = true;

var button = document.getElementById("buyButton");
button.addEventListener("click", function () {
    alert("Buying item");
});

var productInfo = document.getElementsByClassName("product-props");
var listItems = productInfo.item[0].children;


