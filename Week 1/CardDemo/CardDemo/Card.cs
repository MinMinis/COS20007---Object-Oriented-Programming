using System;
namespace CardDemo
{
    public class Card
    {
        private string rank;
        private string suit;
        private bool faceUp;

        public Card(string aRank, string aSuit)
        {
            rank = aRank;
            suit = aSuit;
            faceUp = false;
        }

        public void Flip()
        {
            faceUp = !faceUp;
        }

        public void PrintDetails()
        {
            if (faceUp)
            {
                Console.WriteLine("{0} {1}", rank, suit);
            }
            else
            {
                Console.WriteLine("*****");
            }
        }
    }
}
