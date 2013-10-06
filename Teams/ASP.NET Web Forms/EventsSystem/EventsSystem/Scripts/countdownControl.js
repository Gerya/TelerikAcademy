function animateCountdown(endDate, id) {
    var target_date = new Date(endDate).getTime();

    var days, hours, minutes, seconds;

    var countdownContainer = $("p[data-controlid='" + id + "']")[0];

    fillTimerContainer(target_date, countdownContainer);

    setInterval(function () {
        fillTimerContainer(target_date, countdownContainer);
    }, 1000);
}

function fillTimerContainer(target_date, countdownContainer) {
    var current_date = new Date().getTime();
    var seconds_left = (target_date - current_date) / 1000;

    days = parseInt(seconds_left / 86400);
    seconds_left = seconds_left % 86400;

    hours = parseInt(seconds_left / 3600);
    seconds_left = seconds_left % 3600;

    minutes = parseInt(seconds_left / 60);
    seconds = parseInt(seconds_left % 60);


    countdownContainer.innerHTML = days + "d, " + hours + "h, "
    + minutes + "m, " + seconds + "s";
}