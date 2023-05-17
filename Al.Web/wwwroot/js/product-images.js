const mainImage = document.querySelector(".main-img img");
const subImages = document.querySelectorAll(".others-img div");
const boxSubs = document.querySelector(".others-img").children;

console.log(mainImage);
console.log(subImages);

subImages.forEach(ChoseImages);

function ChoseImages (element, index) {

    element.addEventListener('click', function () {
        var url = element.style.backgroundImage.replace('url("', "");
        url = url.replace('")', "");
        url = url.replace("/thumb", "/normal");

        SetImageForMainImage(url);
        UnactiveAllSubImages();
        SelectSubImage(index);
    })
}

function SetImageForMainImage (url) {
    mainImage.src = url;
}

function UnactiveAllSubImages () {
    subImages.forEach(sub => {
        sub.classList.remove("active");
    });
}

function SelectSubImage (index) {
    boxSubs[index].classList.add("active");
}