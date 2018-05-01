var increment;

function RunGame() {
    increment = 0;
    GameBoard.start();
}

var GameBoard = {
    start: function () {
        this.interval = setInterval(UpdateInterval, 1000)
    }
}

function UpdateInterval() {
    $('#displayInterval').val(increment);
    increment++;
}