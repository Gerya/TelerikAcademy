/// <reference path="../game/scripts/snake.js" />

module("MovingGameObject.init");

test("When moving game object is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var size = 1;
    var fColor = "#0000ff";
    var sColor = "#00ff00";
    var movingObj = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, direction);

    equal(position, movingObj.position, "Position is set");
    equal(speed, movingObj.speed, "Speed is set");
    equal(direction, movingObj.direction, "Direction is set");
    equal(size, movingObj.size, "Size is set");
    equal(fColor, movingObj.fcolor, "Fill color is set");
    equal(sColor, movingObj.scolor, "Stroke color is set");
});

module("MovingGameObject.move");

test("When direction is 0, decrease x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.move();
      position.x - speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 1, decrease update y",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.move();
      position.y - speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 2, increase x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.move();
      position.x + speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 3, should increase x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.move();
      position.y + speed;
      deepEqual(piece.position, position);
  });

module("MovingGameObject.changeDirection");

test("When direction is 0, change to 1",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.changeDirection(1);
      deepEqual(piece.direction, dir+1);
  });

test("When  direction is 2, change to 3",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.changeDirection(3);
      deepEqual(piece.direction, 3);
  });

test("When  direction is 3, change to 0",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 3;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.changeDirection(0);
      deepEqual(piece.direction, 0);
  });

test("When  direction is 0, do not change to 2",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.changeDirection(2);
      deepEqual(piece.direction, dir);
  });

test("When  direction is 1, do not change to 3",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.changeDirection(3);
      deepEqual(piece.direction, 1);
  });

test("When  direction is 2, do not change to 0",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.changeDirection(0);
      deepEqual(piece.direction, 2);
  });

test("When  direction is 3, do not change to 1",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 3;
      var fColor = "#0000ff";
      var sColor = "#00ff00";
      var piece = new snakeGame.MovingGameObject(position, size, fColor, sColor, speed, dir);
      piece.changeDirection(1);
      deepEqual(piece.direction, 3);
  });