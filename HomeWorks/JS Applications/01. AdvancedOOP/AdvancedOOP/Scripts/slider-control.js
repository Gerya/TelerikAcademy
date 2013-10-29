var ImageSlider = {
    init: function (selector, thumbnail) {
        this.selector = selector;
        this.thumbnail = thumbnail;
    },
    create: function () {
        var position;
        var ul = document.createElement("ul");

        for (var i = 0; i < this.thumbnail.imgArr.length; i++) {
            var li = document.createElement("li");
            li.style.backgroundImage = "url(" + thumbnail.imgArr[i].url + ")";
            li.id = i;
            ul.appendChild(li);
        }

        var sliderPosition = document.querySelector(this.selector);
        var priview = document.createElement("div");
        priview.id = "priview";
        priview.style.backgroundImage = "url(" + thumbnail.imgArr[4].largeUrl + ")";
        var thumb = document.createElement("div");
        thumb.id = "thumbnail";
        var leftButton = document.createElement("div");
        leftButton.id = "leftButton";
        var anchor = document.createElement("a");
        anchor.title = "left";
        anchor.href = "#";
        leftButton.appendChild(anchor);
        var rightButton = document.createElement("div");
        rightButton.id = "rightButton";
        anchor = document.createElement("a");
        anchor.title = "right;"
        anchor.href = "#";
        rightButton.appendChild(anchor);
        thumb.appendChild(leftButton);
        thumb.appendChild(rightButton);
        var imgDiv = document.createElement("div");
        imgDiv.id = "imagesDiv";
        imgDiv.appendChild(ul);
        thumb.appendChild(imgDiv);
        sliderPosition.appendChild(priview);
        sliderPosition.appendChild(thumb);

        leftButton.onclick = function () {
            var container = document.querySelector("#imagesDiv");
            var position = (ul.offsetLeft - 200 - container.offsetLeft);

            if (position >= -400) {
                ul.style.left = position + "px";
            }
        };

        rightButton.onclick = function () {
            var container = document.querySelector("#imagesDiv");
            var position = (ul.offsetLeft - container.offsetLeft) + 200;

            if (position <= 0) {
                ul.style.left = position + "px";
            }
        };

        ul.onclick = function (ev) {
            var handleId = ev.target;
            var number = handleId.id * 1;
            priview.style.backgroundImage = "url(" + thumbnail.imgArr[number].largeUrl + ")";
        };

    }
};

var Thumbnail = {
    init: function () {
        var arr = new Array();
        this.imgArr = arr;

    },
    addImage: function (image) {
        this.imgArr.push(image)
        return this.imgArr;
    },
};

var Image = {
    init: function (title, url, largeUrl) {
        this.title = title;
        this.url = url;
        this.largeUrl = largeUrl;
    }
};