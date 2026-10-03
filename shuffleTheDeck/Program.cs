namespace shuffleTheDeck
{
    internal class Program
    {
        /* TODO
          [x] display drawn balls
          [x] draw a random ball
          [x] if ball already drawn just draw another
          [x] don't draw when all balls already drawn
          [x] let user start a new game any time
          [x] let user quit at any time
          [ ] 
         */
        static bool[,] ballTracker = new bool[15, 5];
        static int ballCount = 0;

        static void Main(string[] args)
        {
            string userInput = "";
            do
            {
                DrawBall();
                DisplayBoard();
                Console.WriteLine("Press any key to continue or q to quit");
                userInput = Console.ReadLine();
                if (userInput == "c" || userInput == "C" || ballCount >= 75)
                {
                    Array.Clear(ballTracker, 0, ballTracker.Length);
                    ballCount = 0;
                    Console.WriteLine("");
                    Console.WriteLine("You have cleared the board. A new game has started.");
                }
            } while (userInput != "q" && userInput != "Q");

            Console.WriteLine("Game Over. Press any key to exit.");
            Console.Beep();
            //pause
            Console.ReadLine();
        }

        static void DisplayBoard()
        {
            string ballNumber;
            string[] header = { "B", "I", "N", "G", "O" };
            string seperator = "_";

            foreach (string letter in header)
            {
                Console.Write(letter.PadLeft(3));
                seperator += "___";
            }
            Console.WriteLine();
            Console.WriteLine(seperator);

            // header

            // iterate through array
            int rows = ballTracker.GetLength(0);
            int cols = ballTracker.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                Console.Write("|");
                for (int col = 0; col < cols; col++)
                {
                    if (ballTracker[row, col])
                    {
                        ballNumber = ((rows * col) + row + 1).ToString();
                    }
                    else
                    {
                        ballNumber = "";
                    }
                    Console.Write(ballNumber.PadLeft(2) + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void DrawBall()
        {
            Random Ball = new Random();
            int rowBall, colBall;
            Console.WriteLine("Press any key to draw a ball or c to clear the board");
            do
            {
                rowBall = Ball.Next(15);
                colBall = Ball.Next(5);

            } while (ballTracker[rowBall, colBall] && ballCount < 75);
            ballCount++;
            Console.WriteLine($"Balls drawn: {ballCount}");
            ballTracker[rowBall, colBall] = true;
        }
    }
}