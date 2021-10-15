using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame
{
    class CardDeck
    {
        public List<Card> deck = new List<Card>();

        //adds all 52 cards to a deck of cards to make a new deck
        public void InitializeNewDeck()
        {
            for(int i = 0; i < 52; i++)
            {
                Card card = new Card(); //getting a new card object each pass

                card.Suit = AssignSuit(i);
                card.Color = AssignColor(i);
                card.Value = i % 13;
                card.Type = AssignType(i);
                card.Name = $"{card.Type} of {card.Suit}";

                deck.Add(card);
            }

        }

        //method associated with method to build the deck
        //assigns suit to card
        private string AssignSuit(int i)
        {
            if (i <= 12)
            {
                return "Hearts";
            }
            else if (i > 12 && i <= 25)
            {
                return "Diamonds";
            }
            else if (i > 25 && i <= 38)
            {
                return "Spades";
            }
            else
            {
                return "Clubs";
            }
        }

        //method to assign color to card, used within initialize method
        private bool AssignColor(int i)
        {
            if (i <= 25)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //method to assign a type to card
        private string AssignType(int i)
        {
            if (i == 12 || i == 25 || i == 38 || i == 51)
            {
                return "Ace";
            }
            else if (i == 11 || i == 24 || i == 37 || i == 50)
            {
                return "King";
            }
            else if (i == 10 || i == 23 || i == 36 || i == 49)
            {
                return "Queen";
            }
            else if (i == 9 || i == 22 || i == 35 || i == 48)
            {
                return "Jack";
            }
            else
            {
                return $"{(i % 13) + 2}" ;
            }

        }

        //gets random number and returns card at that number
        //as the drawn  card
        public Card DrawCard()
        {
            Random rand = new Random();
            int cardNum = rand.Next(0, deck.Count);
            return deck[cardNum];
        }

        //adds a card to the deck
        public void AddCard(Card card)
        {
            deck.Add(card);
        }

        //removes a card from the deck
        public void RemoveCard(Card card)
        {
            deck.Remove(card);
        }

        public void PrintHand()
        {
            foreach (Card card in deck)
            {
                Console.WriteLine(card.Name);
            }
        }

        public void AddCard(List<Card> spoils)
        {
            foreach (Card card in spoils)
            {
                deck.Add(card);
            }

            spoils.Clear();
        }

    }
}
