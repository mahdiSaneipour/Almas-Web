const conRight = document.querySelectorAll('.products-right');
const conLeft = document.querySelectorAll('.products-left');
const slides = document.querySelectorAll('.products');
const slide = document.querySelector('.product-box');


const slideWidth = slide.clientWidth + 12;

console.log(slideWidth)

let maxSlide = 5;

if (window.screen.width <= 360) {
    maxSlide = 2;
} 

if (window.screen.width <= 768) {
    maxSlide = 3
}

var slideTimer = [];

slides.forEach(Slides);
function Slides (element, index) {

    const slide = document.querySelectorAll('.slide-products')[index];
    const count = document.querySelector('.slide-products').children.length;

    slideTimer[index] = setInterval(NextSlide, 3000, slide, count, index)

    conRight[index].addEventListener('click', function () {
        NextSlide(slide, count, index);
    });

    conLeft[index].addEventListener('click', function () {
        PrevSlide(slide, count, index);
    });
}

function NextSlide (element, count, index) {

    element.scrollLeft += -slideWidth;

    if (((count - maxSlide) * -slideWidth) + 20 >= element.scrollLeft) {
        element.scrollLeft = 0;
    }

    ResetIntervals(element, count, index);
}

function PrevSlide (element, count, index) {

    element.scrollLeft += slideWidth;

    if (element.scrollLeft >= 0) {
        element.scrollLeft = (count - maxSlide) * -slideWidth;
    }

    ResetIntervals(element, count, index);
}

function ResetIntervals (slide, count, index) {
    clearInterval(slideTimer[index])
    slideTimer[index] = setInterval(NextSlide, 3000, slide, count, index);
}