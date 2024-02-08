window.location.href = "https://challenge.longshotsystems.co.uk/go";

let numberOne = document.getElementById("number-box-0");
let numberTwo = document.getElementById("number-box-1");
let numberThree = document.getElementById("number-box-2");
let numberFour = document.getElementById("number-box-3");
let numberFive = document.getElementById("number-box-4");
let numberSix = document.getElementById("number-box-5");
let numberSeven = document.getElementById("number-box-6");
let numberEight = document.getElementById("number-box-7");

let myName = "Erik Boonprakong-Kitching";
let numberString =
    numberOne.innerHTML.trim() +
    numberTwo.innerHTML.trim() +
    numberThree.innerHTML.trim() +
    numberFour.innerHTML.trim() +
    numberFive.innerHTML.trim() +
    numberSix.innerHTML.trim() +
    numberSeven.innerHTML.trim() +
    numberEight.innerHTML.trim();

console.log(numberString + "\n" + myName);

let numberBox = document.getElementById("answer");
numberEight.addEventListener("load", function () {
    console.log("Hey");
});
numberBox.value = numberString;

let nameBox = document.getElementById("name");
nameBox.value = myName;

submit();
