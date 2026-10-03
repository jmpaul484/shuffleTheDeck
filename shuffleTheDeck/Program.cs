//Jonathan Paul
//RCET 2265
// Fall 2026
//https://github.com/jmpaul484/shuffleTheDeck.git
namespace shuffleTheDeck
{
    internal class Program
    {
        /* TODO
         [X] Create a 2D array to track the cards drawn
         [X] Create a method to display the board
         [X] Create a method to draw a card
         [X] Create a method to clear the board
         [X] Create a method to check if the board is full
         [X] Create a method to check if the card has already been drawn
        */
        static bool[,] cardTracker = new bool[13, 4];
        static int cardCount = 0;
        // single Random instance to avoid reseeding issues
        static Random rng = new Random();

        static void Main(string[] args)
        {
            // ensure console can render Unicode suit characters
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            string userInput = "";
            do
            {
                DrawCard();
                DisplayBoard();
                Console.WriteLine("Press any key to continue or q to quit");
                userInput = Console.ReadLine();
                if (userInput == "c" || userInput == "C" || cardCount >= 52)
                {
                    Array.Clear(cardTracker, 0, cardTracker.Length);
                    cardCount = 0;
                    Console.WriteLine("");
                    Console.WriteLine("You have cleared the board. A new game has started.");
                }
            } while (userInput != "q" && userInput != "Q");

            Console.WriteLine("Game Over. Press any key to exit.");
            Console.Beep();
            //pause
            Console.ReadLine();
        }
        // method to display the board
        static void DisplayBoard()
        {
            // header
            string cardNumber;
            // use Unicode escapes for suit symbols to avoid source encoding issues
            string[] header = { "\u2660 ", "\u2663 ", "\u2665 ", "\u2666 " };
            string seperator = "_";
            
            foreach (string letter in header)
            {
                Console.Write(letter.PadLeft(3));
                seperator += "___";
            }
            Console.WriteLine();
            Console.WriteLine(seperator);
            // iterate through array
            int rows = cardTracker.GetLength(0);
            int cols = cardTracker.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                Console.Write("|");
                for (int col = 0; col < cols; col++)
                {
                    if (cardTracker[row, col])
                    {
                        int rank = row + 1;
                        string rankStr;
                        if (rank == 1)
                            rankStr = "A";
                        else if (rank == 11)
                            rankStr = "J";
                        else if (rank == 12)
                            rankStr = "Q";
                        else if (rank == 13)
                            rankStr = "K";
                        else
                            rankStr = rank.ToString();

                        cardNumber = rankStr;
                    }
                    else
                    {
                        cardNumber = "";
                    }
                    Console.Write(cardNumber.PadLeft(2) + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        // method to draw a card, make sure to check if the card has already been drawn and if the board is full
        static void DrawCard()
        {
            if (cardCount >= 52)
            {
                Console.WriteLine("All 52 cards have been drawn. Clear the board to start a new game.");
                return;
            }

            int rowCard, colCard;
            Console.WriteLine("Press any key to draw a card or c to clear the board");
            do
            {
                rowCard = rng.Next(13);
                colCard = rng.Next(4);

            } while (cardTracker[rowCard, colCard]);
            cardCount++;
            Console.WriteLine($"Cards drawn: {cardCount}");
            cardTracker[rowCard, colCard] = true;
        }
    }
}