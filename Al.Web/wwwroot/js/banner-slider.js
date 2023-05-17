const baner = document.querySelector('.images-box');
const baners = document.querySelector('.images-box').children;
const img = document.querySelector('.images-box');
const next = document.querySelector(".control-right");
const prev = document.querySelector(".control-left");

let imgWidth = img.clientWidth;

next.addEventListener('click', function () {
    NextFunction();
})

prev.addEventListener('click', function() {
    PrevFunction();
})

function NextFunction () {
    baner.scrollLeft += -imgWidth
    
    if ((--baners.length * -imgWidth) == baner.scrollLeft) {
        baner.scrollLeft = 0;
    }

    RestartBannerSlide();

}

function PrevFunction () {

    baner.scrollLeft += imgWidth

    if ( 0 == baner.scrollLeft) {
        baner.scrollLeft = (--baners.length * -imgWidth);
    }

    RestartBannerSlide();
}

var bannerTimer = setInterval(NextFunction, 3000);

function RestartBannerSlide () {
    clearInterval(bannerTimer)
    bannerTimer = setInterval(NextFunction, 3000);
}