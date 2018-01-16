using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPoker
{
    public class Card
    {
        // from http://edcharbeneau.com/csharp-functional-workshop-instructions/#chapter0
        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }

        public CardValue Value { get; }
        public CardSuit Suit { get; }

        public override string ToString() => $"{Value} of {Suit}";

    }
}
