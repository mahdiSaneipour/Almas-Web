form = document.querySelector("#send-from");
page = document.querySelector("#page-id");

function ClickOnPage(pageId) {
    console.log(page)
    page.value = pageId;
    form.submit();
}