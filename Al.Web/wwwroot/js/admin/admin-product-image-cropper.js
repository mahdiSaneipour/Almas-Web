﻿var image = document.getElementById("image");
var file = document.getElementById("file");
var saveProfile = document.getElementById("save-profile");
var cropperBg = document.getElementsByClassName("cropper-bg")[0];
var userAvatar = document.getElementById("user-avatar");
var imageValues = document.getElementById("image-values");
var boxImages = document.getElementsByClassName("other-images")[0];

var images = [];

let cropper;

image.addEventListener("click", function () {
    file.click();
})

file.addEventListener("change", function (event) {

    var extFile = file.value.substr(file.value.lastIndexOf(".") + 1, file.value.length).toLowerCase();

    if (extFile == "jpg" || extFile == "jpeg" || extFile == "png") {


        image = document.getElementById("image")

        let file = event.target.files[0];
        let reader = new FileReader();

        reader.addEventListener("load", function () {

            /*previousProfile = image.getAttribute("src");*/

            image.src = reader.result;
        }, false)

        if (file) {
            reader.readAsDataURL(file);
        }

    } else {
        alert("فقط میتوانید عکس انتخاب کنید");
    }
})

image.addEventListener("load", function () {
    if (image.src != "data:image/png;base64,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") {
        cropper = new Cropper(image, {
            aspectRatio: 1 / 1
        });
    }
})

saveProfile.addEventListener("click", function () {

    cropper.getCroppedCanvas({

    }).toBlob(function (blob) {


        let avatarModel = new FormData();


        avatarModel.set("file", blob);

        var xhr = new XMLHttpRequest();

        xhr.responseType = 'json';
        xhr.open('POST', '/Api/Admin/UploadProductImage', true);
        xhr.send(avatarModel);

        xhr.onreadystatechange = async function () {

            if (this.readyState == 4 && this.status == 200) {
                
                images[images.length] = this.response.name;
                
                imageValues.value = images;


                OtherImages();
                

                cropper.destroy();
                image.src = "data:image/png;base64,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";

                image = null;
                file.value = null;
            }
        }
    })

})

function OtherImages() {
    boxImages.innerHTML = "";

    for (var x = 0; x < images.length; x++) {
        const divBox = document.createElement("div");
        divBox.classList.add("img-box");

        var imgValue = images[x];

        const img = document.createElement("img");
        img.src = "../../images/products/normal/" + imgValue;

        divBox.appendChild(img);

        const divDelete = document.createElement("div");
        divDelete.classList.add("back-delete");

        const a = document.createElement("a");

        a.addEventListener("click", function () {

            var xhr = new XMLHttpRequest();

            xhr.responseType = 'json';
            
            var url = "/Api/Admin/DeleteProductImage/" + imgValue;
            
            xhr.open('GET', url, true);
            xhr.send();

            xhr.onreadystatechange = async function () {

                if (this.readyState == 4 && this.status == 200) {
                    
                    images.splice(images.indexOf(imgValue),1);

                    OtherImages();
                }
            }
        });
        const i = document.createElement("i");
        i.classList.add("fa-solid");
        i.classList.add("fa-trash");

        a.appendChild(i);
        divDelete.appendChild(a);

        divBox.appendChild(divDelete);

        boxImages.appendChild(divBox);
    }
    imageValues.value = images;
}