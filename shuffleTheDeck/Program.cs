//Joanthan Paul
//RCET 2265
// Fall 2026
//https://github.com/jmpaul484/shuffleTheDeck.git
namespace shuffleTheDeck
{
    internal class Program
    {
        /* TODO
         [] Create a 2D array to track the cards drawn
         [] Create a method to display the board
         [] Create a method to draw a card
         [] Create a method to clear the board
         [] Create a method to check if the board is full
         [] Create a method to check if the card has already been drawn
        */
        static bool[,] cardTracker = new bool[15, 5];
        static int cardCount = 0;

        static void Main(string[] args)
        {
            string userInput = "";
            do
            {
                DrawCard();
                DisplayBoard();
                Console.WriteLine("Press any key to continue or q to quit");
                userInput = Console.ReadLine();
                if (userInput == "c" || userInput == "C" || cardCount >= 75)
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

        static void DisplayBoard()
        {
            string cardNumber;
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
            int rows = cardTracker.GetLength(0);
            int cols = cardTracker.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                Console.Write("|");
                for (int col = 0; col < cols; col++)
                {
                    if (cardTracker[row, col])
                    {
                        cardNumber = ((rows * col) + row + 1).ToString();
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

        static void DrawCard()
        {
            Random Card = new Random();
            int rowCard, colCard;
            Console.WriteLine("Press any key to draw a card or c to clear the board");
            do
            {
                rowCard = Card.Next(15);
                colCard = Card.Next(5);

            } while (cardTracker[rowCard, colCard] && cardCount < 75);
            cardCount++;
            Console.WriteLine($"Cards drawn: {cardCount}");
            cardTracker[rowCard, colCard] = true;
        }
    }
}