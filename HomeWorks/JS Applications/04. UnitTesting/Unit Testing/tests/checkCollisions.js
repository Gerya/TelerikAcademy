/// <reference path="../game/scripts/snake.js" />
module("SnakeGame.checkCollisions");

test("There should be collision with Food, and the snake should grow", function () {
    var context = document.getElementById("snake-canvas").getContext("2d");
    var game = new snakeGame.SnakeEngine(context, 300, 300);
    var collidePosition = {
        x: 2,
        y: 2
    };
    var oldsnakesize = game.snake.size;
    game.snake.position.x = collidePosition.x;
    game.snake.position.y = collidePosition.y;
    game.food.position.x = collidePosition.x;
    game.food.position.y = collidePosition.y;
    game.checkCollisions();
    var newsnakesize = game.snake.size;
    equal(newsnakesize, oldsnakesize + 1);
});

test("There should be collision with snake body, and the snake should die", function () {
    var context = document.getElementById("snake-canvas").getContext("2d");
    var game = new snakeGame.SnakeEngine(context, 300, 300);
    var collidePosition = {
        x: 120,
        y: 120
    };

    game.snake.pieces[0].x = collidePosition.x;
    game.snake.pieces[0].y = collidePosition.y;
    game.snake.pieces[1].x = collidePosition.x;
    game.snake.pieces[1].y = collidePosition.y;

    game.checkCollisions();
    ok(true, game.snake.isDead, "The snake is dead");
});

test("There should be collision with snake tail, and the snake should die", function () {
    var context = document.getElementById("snake-canvas").getContext("2d");
    var game = new snakeGame.SnakeEngine(context, 300, 300);
    var collidePosition = {
        x: 120,
        y: 120
    };

    game.snake.pieces[0].x = collidePosition.x;
    game.snake.pieces[0].y = collidePosition.y;
    game.snake.pieces[4].x = collidePosition.x;
    game.snake.pieces[4].y = collidePosition.y;

    game.checkCollisions();
    ok(true, game.snake.isDead, "The snake is dead");
});

test("There should be collision with screen, and the snake should move", function () {
    var context = document.getElementById("snake-canvas").getContext("2d");
    var game = new snakeGame.SnakeEngine(context, 300, 300);
    var collidePosition = {
        x: - 4,
        y: 300
    };
    game.snake.position = collidePosition;

    game.checkCollisions();
    ok(collidePosition.x, game.snake.position.x, "The snake is out of screen");
});