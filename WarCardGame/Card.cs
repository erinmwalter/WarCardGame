using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame
{
    class Card
    {
        //card property methods
        public string Suit { get; set; } //diamond,heart,spade,club
        public int Value { get; set; } //0-12
        public bool Color { get; set; } //red-true, black-false
        public string Type { get; set; } //AKQJ etc
        public string Name { get; set; } //"8 of hearts" or "queen of diamonds" etc

        //2 constructors, one default one overloaded
        //not sure if i need either based on the current design of how the object is used.
        public Card()
        {
            Suit = "none";
            Value = -1;
            Type = "none";
            Color = false;
            Name = "none of none";
        }
        public Card(string suit, int value, string type, bool red)
        {
            Suit = suit;
            Value = value;
            Type = type;
            Color = red;
            Name = $"{type} of {suit}";
        }

    }
}
