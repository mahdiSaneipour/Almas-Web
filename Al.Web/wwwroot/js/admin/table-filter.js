const form = document.querySelector("#form");
const select = document.querySelector(".select");
const selectChildren = document.querySelector(".select").children;
const selects = document.querySelectorAll(".select-items div");
const pageId = document.querySelector("#page-id");

selects.forEach((element, index) => {
    element.addEventListener("click", function () {

        ClickSelect(element);
    })
});

function ClickSelect(element) {
    if (element.parentNode.parentNode.id == "select-group") {

        document.querySelectorAll(".second-selector .select")[0].selectedIndex = 0;

    }

    form.submit();
}

function ClickPage(id) {

    pageId.value = id;

    form.submit();
}