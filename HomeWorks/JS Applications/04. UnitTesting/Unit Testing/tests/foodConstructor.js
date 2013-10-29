/// <reference path="../game/scripts/snake.js" />

module("Food.init");

test("When food game object is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var size = 1;
    var fColor = "#0000ff";
    var sColor = "#00ff00";
    var food = new snakeGame.Food(position, size, fColor, sColor);

    equal(position, food.position, "Position is set");
    equal(size, food.size, "Size is set");
    equal(fColor, food.fcolor, "Fill color is set");
    equal(sColor, food.scolor, "Stroke color is set");
});

module("Food.changePosition");

test("When food game object is moved by X, should set the correct values", function () {
    var start = {
        x: 150,
        y: 150
    };
    var size = 1;
    var fColor = "#0000ff";
    var sColor = "#00ff00";
    var newFood = new snakeGame.Food(start, size, fColor, sColor);

    var newPosition = {
        x: 50,
        y: 50
    };
    newFood.changePosition(newPosition);
    equal(newPosition.x, newFood.position.x, "Position is changed");
});

test("When food game object is moved by Y, should set the correct values", function () {
    var start = {
        x: 150,
        y: 150
    };
    var size = 1;
    var fColor = "#0000ff";
    var sColor = "#00ff00";
    var newFood = new snakeGame.Food(start, size, fColor, sColor);

    var newPosition = {
        x: 50,
        y: 50
    };
    newFood.changePosition(newPosition);
    equal(newPosition.y, newFood.position.y, "Position is changed");
});