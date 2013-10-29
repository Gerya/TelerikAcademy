function opentIt(obj) {

    obj.style.backgroundImage = "url(Images/bucket.jpg)";
}
function allowDrop(ev) {
    var bucket = document.getElementById("bucket");
    bucket.style.backgroundImage = "url(Images/openCan.png)";
    ev.preventDefault();
}
function drag(ev) {
    ev.dataTransfer.setData("dragged-id", ev.target.id);
}
function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("dragged-id");
    var element = document.getElementById(data);
    element.parentNode.removeChild(element);
    bucket.style.backgroundImage = "";
    updateGameState();
}