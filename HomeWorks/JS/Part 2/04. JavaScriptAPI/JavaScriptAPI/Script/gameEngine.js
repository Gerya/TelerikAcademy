function displayHighscores() {
    var scoretable = document.getElementById('scoretable');
    if (scoretable.style.display == 'block') {
        scoretable.style.display = 'none';
    } else {
        scoretable.style.display = 'block';
    }
    loadPairs();
}

function closeNewScore() {
    newScore.style.display = 'none';
}

function updateGameState() {
    var garbageCount = (document.querySelectorAll('.trash')).length;
    var collected = document.getElementById('collected');
    collected.innerHTML = 'left:' + garbageCount;
    if (garbageCount == 0) {
        timerStop();
        var time = document.getElementById('time');
        time.innerHTML = document.timeform.timetextarea.value;
        document.getElementById('newScore').style.display = 'block';
    }

}

function startGame() {
    divs.Clear();
    divs.Create(20);
    updateGameState();
    timerReset();
    timerStart();
}