
using System.Threading.Tasks.Dataflow;

new TicTacToe().Run();


class TicTacToe
{
    public void Run()
    {
        Board board = new();
        Player playerX = new(Pieces.X);
        Player playerO = new(Pieces.O);
        Player[] players = {playerX, playerO};
        string winner = "continue";
        int turnNumber = 0;

        while (turnNumber <9)
        {
            for (int i = 0; i < 2; i++)
            {
                turnNumber++;
                bool success = false;
                while(success == false)
                {
                    Console.Clear();
                    Board.DisplayBoard(board);
                    Console.Write($"{players[i].Piece}, ");
                    success = (board.Place(players[i].GetSquare(), players[i].Piece));
                }
                winner = CheckForWinner(board, players[i]);
                if (winner != "continue") break;

                if (turnNumber == 9) break;


            }
            if (winner != "continue") break;
        }
        Console.Clear();
        Board.DisplayBoard(board);
        if (winner == "continue") Console.WriteLine("IT'S A DRAW!!!");
        else Console.WriteLine($"{winner} WINS!!!");
    }
    private static string CheckForWinner(Board board, Player player)
    {
        Pieces topLeft = board.BoardState[0, 0];
        Pieces topRight = board.BoardState[0, 2];
        Pieces middle = board.BoardState[1, 1];
        Pieces bottomMiddle = board.BoardState[2, 1];

        if (topLeft == board.BoardState[0, 1] && topLeft == board.BoardState[0, 2] && topLeft != Pieces.Blank) return player.Piece.ToString();
        else if (topLeft == board.BoardState[1, 0] && topLeft == board.BoardState[2, 0] && topLeft != Pieces.Blank) return player.Piece.ToString();
        else if (topLeft == board.BoardState[1, 1] && topLeft == board.BoardState[2, 2] && topLeft != Pieces.Blank) return player.Piece.ToString();
        else if (topRight == board.BoardState[1, 2] && topRight == board.BoardState[2, 2] && topRight != Pieces.Blank) return player.Piece.ToString();
        else if (topRight == board.BoardState[1, 1] && topRight == board.BoardState[2, 0] && topRight != Pieces.Blank) return player.Piece.ToString();
        else if (topRight == board.BoardState[1, 0] && topRight == board.BoardState[2, 0] && topRight != Pieces.Blank) return player.Piece.ToString();
        else if (middle == board.BoardState[1, 0] && middle == board.BoardState[1, 2] && middle != Pieces.Blank) return player.Piece.ToString();
        else if (middle == board.BoardState[2, 1] && middle == board.BoardState[0, 1] && middle != Pieces.Blank) return player.Piece.ToString();
        else if (bottomMiddle == board.BoardState[2, 0] && bottomMiddle == board.BoardState[2, 2] && bottomMiddle != Pieces.Blank) return player.Piece.ToString();
        else return "continue";

    }
}

class Player
{
    private int[]? _square;
    public Pieces Piece { get; private set; }

    public Player(Pieces piece)
    {
        Piece = piece;
    }


    public int[] GetSquare()
    {

        int squareInt = AskForNumberInRange("Which square would you like to place in? ", 1, 9);
        _square = squareInt switch
        {
            1 => new int[2] { 2, 0 },
            2 => new int[2] { 2, 1 },
            3 => new int[2] { 2, 2 },
            4 => new int[2] { 1, 0 },
            5 => new int[2] { 1, 1 },
            6 => new int[2] { 1, 2 },
            7 => new int[2] { 0, 0 },
            8 => new int[2] { 0, 1 },
            9 => new int[2] { 0, 2 },

        };
        return _square;
    }
    int AskForNumber(string text)
    {
        Console.Write(text);
        return Convert.ToInt32(Console.ReadLine());
    }

    int AskForNumberInRange(string text, int min, int max)
    {
        int num;
        do
        {
            num = AskForNumber(text);

        }
        while (num > max || num < min);
        return num;

    }
}

class Board
{
    public Pieces[,] BoardState { get; private set; } = new Pieces[3, 3] { { Pieces.Blank, Pieces.Blank , Pieces.Blank },
                                                                           { Pieces.Blank, Pieces.Blank , Pieces.Blank },
                                                                           { Pieces.Blank, Pieces.Blank , Pieces.Blank } };

    public bool Place(int[] square, Pieces piece)
    {
        if (BoardState[square[0], square[1]] == Pieces.Blank)
        {
            BoardState[square[0], square[1]] = piece;
            return true;
        }
        else return false;
    }

    public static void DisplayBoard(Board board)
    {
        Console.WriteLine($" {BlankDetector(board.BoardState[0, 0])} | {BlankDetector(board.BoardState[0, 1])} | {BlankDetector(board.BoardState[0, 2])} \n---+---+--- \n {BlankDetector(board.BoardState[1, 0])} | {BlankDetector(board.BoardState[1, 1])} | {BlankDetector(board.BoardState[1, 2])} \n---+---+--- \n {BlankDetector(board.BoardState[2, 0])} | {BlankDetector(board.BoardState[2, 1])} | {BlankDetector(board.BoardState[2, 2])}");
    }

    private static string BlankDetector(Pieces piece)
    {
        if (piece == Pieces.Blank) return " ";
        else return piece.ToString();
    }
}




enum Pieces { X, O, Blank }