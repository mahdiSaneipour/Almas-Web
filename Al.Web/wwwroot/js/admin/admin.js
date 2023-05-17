const menu = document.querySelector(".menu-border");
const menuButton = document.querySelector(".admin-menu");
const main = document.querySelector("main .main");
const closedMenu = document.querySelector(".closed-menu");

menuButton.addEventListener("click", function() {
    ActionMenu()
})

closedMenu.addEventListener("click", function() {
    ActionMenu();
})

function ActionMenu() {
    menu.classList.toggle("close-menu");
    main.classList.toggle("full-main");
    closedMenu.classList.toggle("open");
}