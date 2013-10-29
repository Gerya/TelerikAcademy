(function () {
    'use strict';

    function addEventListener(selector, eventType, listener) {
        document.querySelector(selector).addEventListener(eventType, listener, false);
    }
    var checked;
    var i;
    var ulList = document.getElementById("todo-list");

    document.getElementById("add-item").addEventListener("click", addItems, false);

    document.getElementById("delete-item").addEventListener("click", deleteItems, false);

    document.getElementById("hide-item").addEventListener("click", hideItems, false);

    document.getElementById("show-item").addEventListener("click", showItems, false);

    function addItems() {
        var content = document.getElementById("inputText").value;
        if (content) {
            var liItem = document.createElement('li');
            var itemCheckbox = document.createElement('input');

            itemCheckbox.type = 'radio';
            itemCheckbox.name = 'selected';
            liItem.appendChild(itemCheckbox);
            liItem.appendChild(document.createTextNode(content));
            ulList.appendChild(liItem);
        }
    }

    function deleteItems() {
        checked = document.querySelector('input[name=selected]:checked');
        if (checked) {
            var parentLi = checked.parentNode;
            parentLi.parentNode.removeChild(parentLi);
        }
    }

    function hideItems() {
        checked = document.querySelector('input[name=selected]:checked');
        if (checked) {
            var parentLi = checked.parentNode;
            parentLi.className = 'hidden';
        }
    }

    function showItems() {
        var hidenItem = document.querySelectorAll(".hidden");
        var len = hidenItem.length;
        for (i = 0; i < len; i++) {
            hidenItem[i].className = "";
        }
    }
})();
