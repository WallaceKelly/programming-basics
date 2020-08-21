// game state
var tictactoe = newGame();

// reset the game state
function newGame() {

    var cells = document.getElementById("board").getElementsByTagName("td");
    for (i = 0; i < cells.length; i++) {
        cells[i].innerHTML = "";
        cells[i].onclick = onCellClicked;
        cells[i].setAttribute("data-cellnumber", i);
    }
    
    return {
        player: "X",
        turns: 0,
        scores: { "X": 0, "O": 0 }
    };
}

// check for three-in-a-row, based on 
function isWin(score) {
    var winningScores = [7, 56, 73, 84, 146, 273, 292, 448];
    for (i = 0; i < winningScores.length; i++) {
        if ((winningScores[i] & score) === winningScores[i]) {
            return true;
        }
    }
    return false;
}

function reset(msg) {
    setTimeout(() => {
        alert(msg);
        tictactoe = newGame();
    }, 100);
}

// user clicks on a cell
function onCellClicked() {
    if (this.innerHTML.length === 0) {
        this.innerHTML = tictactoe.player;
        tictactoe.turns += 1;

        var cellnumber = this.getAttribute("data-cellnumber");
        tictactoe.scores[tictactoe.player] += Math.pow(2, cellnumber);

        if (isWin(tictactoe.scores[tictactoe.player])) {
            reset(tictactoe.player + " wins!");
        } else if (tictactoe.turns === 9) {
            reset("Draw!");
        } else {
            tictactoe.player = tictactoe.player === "X" ? "O" : "X";
        }
    }
}
