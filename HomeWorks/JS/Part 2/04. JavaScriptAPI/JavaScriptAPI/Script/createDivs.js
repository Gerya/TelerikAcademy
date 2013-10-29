var divs = (function () {
    var pageVisibleSize = getPageSize();
    var maxWidth = pageVisibleSize.width - 150;
    var maxHeight = pageVisibleSize.height - 50;
    var contentDiv = document.getElementById("trashContainer");

    function getPageSize() {
        var size = { width: 0, height: 0 };

        if (window.innerWidth && window.innerHeight) {
            size.width = window.innerWidth;
            size.height = window.innerHeight;
        } else {
            size.width = document.documentElement.offsetWidth;
            size.height = document.documentElement.offsetHeight;
        }

        return size;
    }

    function clearPage() {
        contentDiv = document.getElementById("trashContainer");
            while (contentDiv.firstChild) {
                contentDiv.removeChild(contentDiv.firstChild);
            }
    }

    function createDivs(countDivs) {
        contentDiv = document.getElementById("trashContainer");
        var docFragment = document.createDocumentFragment();
        for (var i = 0; i < countDivs; i++) {
            var div = document.createElement("div");
            div.className = "trash";
            div.id = "div" + i;
            div.addEventListener('dragstart', drag, false);
            div.draggable = "true";
            div.textContent = "drag me";
            makeRandomPosition(div);
            docFragment.appendChild(div);
        }
        contentDiv.appendChild(docFragment);
    }
    
    function makeRandomPosition(div) {
        div.style.top = generateRandomNumber(150, maxHeight) + "px";
        div.style.left = generateRandomNumber(120, maxWidth) + "px";
    }

    function generateRandomNumber(start, end) {
        var number = Math.floor(Math.random() * (end - start + 1)) + start;
        return number;
    }
    return {
        Create: createDivs ,
        Clear: clearPage 
    };
})();