using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame
{
    class PlayWar
    {
        public CardDeck Deck = new CardDeck();
        public CardDeck playerHand = new CardDeck();
        public CardDeck computerHand = new CardDeck();
        private List<Card> warSpoils = new List<Card>();

        public void NewGame()
        {
            Deck.InitializeNewDeck();
            DealDeck();

            while(playerHand.deck.Count > 0 && computerHand.deck.Count > 0)
            {
                DisplayCounts();
                TakeTurn();
            }
        }
        public void DealDeck()
        {
            Card card;

            while (Deck.deck.Count >= 2)
            {
                card = Deck.DrawCard();
                playerHand.AddCard(card);
                Deck.RemoveCard(card);
                card = Deck.DrawCard();
                computerHand.AddCard(card);
                Deck.RemoveCard(card);
            }
            
        }

        private void DisplayCounts()
        {
            Console.WriteLine("Deck Counts:");
            Console.WriteLine($"Your Deck:{playerHand.deck.Count}, Computer Deck: {computerHand.deck.Count}");
        }

        private void TakeTurn()
        {
            Card player, computer;
            string whoIsHigher;
            player = playerHand.deck[0];
            computer = computerHand.deck[0];

            Console.WriteLine($"You drew the {player.Name}. Computer drew the {computer.Name}");
            whoIsHigher = CompareValues(player.Value, computer.Value);

            playerHand.RemoveCard(player);
            computerHand.RemoveCard(computer);
            warSpoils.Add(player);
            warSpoils.Add(computer);

            if (whoIsHigher == "player")
            {
                playerHand.AddCard(warSpoils);
            }
            else if(whoIsHigher == "computer")
            {
                computerHand.AddCard(warSpoils);
            }
            else
            {
                Console.WriteLine("It's War!");
                War();
            }

        }

        private string CompareValues(int playerVal, int computerVal)
        {
            if(playerVal > computerVal)
            {
                return "player";
            }
            else if (playerVal < computerVal)
            {
                return "computer";
            }
            else
            {

                return "war";
            }

        }

        private void War()
        {
            Card playerWarCard = playerHand.deck[1];
            Card computerWarCard = computerHand.deck[1];
            Card playerWarSpoils = playerHand.deck[0];
            Card computerWarSpoils = computerHand.deck[0];
            
            playerHand.RemoveCard(playerWarCard);
            playerHand.RemoveCard(playerWarSpoils);
            computerHand.RemoveCard(computerWarCard);
            computerHand.RemoveCard(computerWarSpoils);

            warSpoils.Add(playerWarCard);
            warSpoils.Add(playerWarSpoils);
            warSpoils.Add(computerWarCard);
            warSpoils.Add(computerWarSpoils);
           
            string whoWon =  CompareValues(playerWarCard.Value, computerWarCard.Value);
            if(whoWon == "player")
            {

            }
            else if (whoWon == "computer")
            {

            }
            else
            {
                Console.WriteLine("WarAGAIN");
                War();
            }

        }

    }
}
