const group = document.querySelectorAll("#group-select ~ .select-items div");
const sGroup = document.querySelector("#group-select");

const sSubGroup = document.querySelector("#sub-group-select");
const iSubGroup = document.querySelector(".input-selected-sub-group");

group.forEach((element, index) => {
    element.addEventListener("click", function () {
        SetSubGroup(sGroup.options[index].value);
    })
});

function SetSubGroup(groupId) {
    var xhr = new XMLHttpRequest();

    xhr.responseType = 'json';

    var url = "../../Api/Admin/GetSubGroupsByParentId/" + groupId;

    xhr.open('GET', url, true);
    xhr.send();

    xhr.onreadystatechange = async function () {

        if (this.readyState == 4 && this.status == 200) {
            sSubGroup.innerHTML = null;

            iSubGroup.value = this.response[0].value;

            this.response.forEach(element => {
                const option = document.createElement("option");
                option.innerHTML = element.groupName;
                option.value = element.groupId;
                sSubGroup.appendChild(option)
            });

            sSubGroup.nextElementSibling.remove();
            sSubGroup.nextElementSibling.remove();

            CreateCustom();
        }

    }
}

var CreateCustom = function () {
    var custom = document.querySelector(".custom-select.sub-group-select");
    var selectedD = custom.querySelectorAll("#selected-value")[0].value;
    var selectItem = custom.querySelector("select");

    var a = document.createElement("DIV");
    a.setAttribute("class", "select-selected");
    a.innerHTML = selectItem.options[selectItem.selectedIndex].innerHTML;

    for (var o = 0; o < selectItem.length; o++) {
        console.log(selectItem.options[o].value)
        if (selectItem.options[o].value == selectedD) {
            a.innerHTML = selectItem.options[o].innerHTML;
            selectItem.selectedIndex = o;
            break;
        }
    }

    custom.appendChild(a);

    var boxItems = document.createElement("DIV");
    boxItems.setAttribute("class", "select-items select-hide");

    for(var j = 0; j < selectItem.length; j++) {
        var item = document.createElement("DIV");
        item.innerHTML = selectItem.options[j].innerHTML;

        if (selectItem.options[j].value == selectedD) {
            item.setAttribute("class", "same-as-selected");
        }

        item.addEventListener("click", function () {
            var select = this.parentNode.parentNode.querySelectorAll("select")[0];
            var selectedValue = this.parentNode.parentNode.querySelectorAll("#selected-value")[0];

            var chose = this.parentNode.previousSibling;
            for(var s = 0; s < select.length; s++) {
                if(select.options[s].innerHTML == this.innerHTML) {
                    select.selectedIndex = s;
                    selectedValue.value = select.options[s].value;
                    chose.innerHTML = this.innerHTML;
                    var selected = this.parentNode.querySelectorAll(".same-as-selected");

                    for(var k = 0; k < selected.length; k++) {
                        selected[k].removeAttribute("class")
                    }
                    
                    this.setAttribute("class", "same-as-selected");
                    break;
                }
            }
            chose.click();
        });
        boxItems.appendChild(item);
    }

    custom.appendChild(boxItems);

    a.addEventListener("click", function(e) {
        e.stopPropagation();
        closeAllSelector(this);

        this.nextSibling.classList.toggle("select-hide");
        this.classList.toggle("select-arrow-active");
    });

    document.addEventListener("click", closeAllSelector);

    function closeAllSelector(element) {
    x = document.getElementsByClassName("select-items");
    y = document.getElementsByClassName("select-selected");

    var arrNo = [];

    for(var i = 0; i < y.length; i++) {
        if(element == y[i]) {
        arrNo.push(i);
        } else {
        y[i].classList.remove("select-arrow-active");
        }
    }
    for(var i = 0; i < x.length; i++) {
        if (arrNo.indexOf(i)) {
        x[i].classList.add("select-hide");
        }
    }
    }
}