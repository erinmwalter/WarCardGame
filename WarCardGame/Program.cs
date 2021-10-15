using System;

namespace WarCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            CardDeck newDeck = new CardDeck();
            Card card;

            newDeck.InitializeNewDeck();

            PlayWar newGame = new PlayWar();
            newGame.NewGame();
   
        }

    }
}
