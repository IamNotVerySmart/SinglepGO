// See https://aka.ms/new-console-template for more information
using SinglepGO;

Board board = new Board();
board.generateBoard();
while (board.isGameOn)
{
    board.movePlayerPosition();
    board.moveEnemyPosition();
    board.generateBoard();
    board.checkPositions();
}