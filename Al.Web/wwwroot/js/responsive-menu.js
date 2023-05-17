const menu = document.querySelectorAll('.res-main-li');
const menuButton = document.querySelector('.menu-button');
const boxMenu = document.querySelector('.menu-res');
const backMenu = document.querySelector('.back-menu');

menu.forEach(Menu);

function Menu (element, index) {
    element.addEventListener('click', function () {
        ToggleActive(element ,index)
    })
}

function ToggleActive (element, index) {
    CloseAllLi(index);
    element.classList.toggle('active-menu');
}

function CloseAllLi (index) {
    for(var i = 0; i < menu.length; i++) {
        if (i != index) {
            menu[i].classList.remove('active-menu');
        }
    }
}

menuButton.addEventListener ('click', ToggleMenu);

function ToggleMenu () {
    boxMenu.classList.toggle('active-res');
    backMenu.classList.toggle('active-back-menu');
}

backMenu.addEventListener('click', ToggleMenu)