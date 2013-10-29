(function (me, undefined) {
    //@const
    var CTX = document.getElementById("gameBoard").getContext("2d");
    var DX = 5;
    var DY = 5;

    var ball;
    var minWith;
    var maxWith;
    var maxHeight;
    var intervalIds = [];
    var radius;

    function startGame() {
        if (intervalIds.length > 0) {
            stopGame();
        }
        ball = createBall();
        minWith = 1 + ball.radius;
        maxWith = 499 - ball.radius;
        maxHeight = 599 - ball.radius;
        CTX.fillStyle = ball.color;
        radius = ball.radius;
        var id = setInterval(draw, 10);
        intervalIds.push(id);
    }

    function stopGame() {
        CTX.clearRect(0, 0, 500, 600);

        for (var i = 0; i < intervalIds.length; i++) {
            clearInterval(intervalIds[i]);
        }
        intervalIds.length = 0;
    }

    function fastGame() {
        if (intervalIds.length == 0) {
            return;
        }
        var id = setInterval(draw, 10);
        intervalIds.push(id);
    }

    function draw() {
        CTX.clearRect(0, 0, 500, 600);
        drawCircle(ball.centerX, ball.centrY, ball.radius);
        // Boundary Logic
        if (ball.centrY > maxHeight) {
            DY = -DY;
        }
        if (ball.centerX > maxWith) {
            DX = -DX;
        }
        if (ball.centrY < minWith) {
            DY = -1 * DY;
        }
        if (ball.centerX < minWith) {
            DX = -1 * DX;
        }
        ball.centerX += DX;
        ball.centrY += DY;
    }

    function createBall() {
        var radiusRandom = generateRandomNumber(7, 20);
        var x = generateRandomNumber(radiusRandom + 1, 499 - radiusRandom);
        var y = generateRandomNumber(radiusRandom + 1, 600 - radiusRandom);
        var colorRandom = generateRandomColor();
        var ball = {
            centerX: x,
            centrY: y,
            radius: radiusRandom,
            color: colorRandom,
        };
        return ball;
    }

    function drawCircle(x, y) {
        CTX.beginPath();
        CTX.arc(x, y, radius, radius, 0, 2 * Math.PI, false);
        CTX.closePath();
        CTX.fill();
    }

    function generateRandomNumber(start, end) {
        var number = Math.floor(Math.random() * (end - start + 1)) + start;
        return number;
    }

    function generateRandomColor() {
        var red = (Math.random() * 256) | 0;
        var green = (Math.random() * 256) | 0;
        var blue = (Math.random() * 256) | 0;

        return "rgb(" + red + "," + green + "," + blue + ")";
    }

    me.startGame = startGame;
    me.stopGame = stopGame;
    me.fastGame = fastGame;
}(window.balls = window.balls || {}));