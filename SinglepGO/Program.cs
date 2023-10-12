// See https://aka.ms/new-console-template for more information
using SinglepGO;

Board board = new Board();
Player player = new Player();
Enemy enemy = new Enemy();

while (board.isGameOn)
{
    board.generateBoard();
    board.checkWinConditions();
    if (board.isGameOn)
    {
        player.Move();
        enemy.moveEnemyPosition();
    }
}
/***********************************************************
 *
 *      Trzeba dodać jeszcze real-time poruszanie 
 *      oraz dać możliwość 2 ruchów z czekaniem na ruch gracza
 *      bo narazie nie da sie tego wygrać.
 *      Oraz zrobić aby przeciwnicy poruszali się w strone gracza.
 *
 *
 *
 **********************************************************/