module("Snake.init");

test("When snake is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var snake = new snakeGame.Snake(position, speed, direction);

  equal(position, snake.position, "Position is set");
  equal(speed, snake.speed, "Speed is set");
  equal(direction, snake.direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var snake = new snakeGame.Snake(position, speed, direction);

  ok(snake.pieces,"SnakePieces are created");
  equal(snake.pieces.length, 5,"Five SnakePieces are created");
  ok(snake.head, "HeadSnakePiece is created");
});

test("should set correct values",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      equal(piece.position, position)
      equal(piece.size, 15);
      equal(piece.speed, speed);
      equal(piece.direction, dir);
  });

module("Snake.Consume");

test("When object is Food, should grow", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);
  var size = snake.size;
  snake.consume(new snakeGame.Food());
  var actual = snake.size;
  var expected = size + 1;
  equal(actual, expected);
});

test("When object is SnakePiece, should die", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);

  var isDead = false;

  snake.addDieHandler(function() {
    isDead = true;
  });

  snake.consume(new snakeGame.SnakePiece());
  ok(isDead, "The snake is dead");
});

test("The snake must die, when it bites itself", function () {
    var position = {
        x: 1,
        y: 3
    }
    var snake = new snakeGame.Snake(position, 8, 0);
    snake.pieces[4].position.x = position.x;
    snake.pieces[4].position.y = position.y;

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(snake.pieces[4]);
    ok(isDead,  "The snake is self eaten");
});

test("When object is Obstacle, should die", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);

  var isDead = false;

  snake.addDieHandler(function() {
    isDead = true;
  });

  snake.consume(new snakeGame.Obstacle());
  ok(isDead, "The snake is dead");
});

module("SnakePiece.move");
test("When direction is 0, decrease x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      position.x - speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 1, decrease update y",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      position.y - speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 2, increase x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      position.x + speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 3, should increase x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      position.y + speed;
      deepEqual(piece.position, position);
  });

