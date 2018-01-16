using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPoker
{
    public class Hand
    {
        // from http://edcharbeneau.com/csharp-functional-workshop-instructions/#chapter0
        private readonly List<Card> cards = new List<Card>();
        public IEnumerable<Card> Cards { get { return cards;} }
        public void Draw(Card card) => cards.Add(card);

        public Card HighCard() => Cards.Aggregate((result, nextCard) => result.Value > nextCard.Value ? result : nextCard);
        
        /* From this:
        public HandRank GetHandRank()
        {
            if (HasRoyalFlush()) return HandRank.RoyalFlush;
            if (HasFlush()) return HandRank.Flush;
            return HandRank.HighCard;
            
        }
            to This: */
        public HandRank GetHandRank() =>
            HasRoyalFlush() ? HandRank.RoyalFlush :
            HasFlush() ? HandRank.Flush :
            HasFullHouse() ? HandRank.FullHouse :
            HasFourOfAKind() ? HandRank.FourOfAKind :
            HasThreeOfAKind() ? HandRank.ThreeOfAKind :
            HasPair() ? HandRank.Pair :
            HandRank.HighCard;
            /*
            NOTE: The order of the above is important.
            */
        /* From this: 
        public bool HasFlush()
        {
            return Cards.All(c => Cards.First().Suit == c.Suit);
        }
            To this: */
        public bool HasFlush() => cards.All(c => cards.First().Suit == c.Suit);
        /* From this: 
        public bool HasRoyalFlush()
        {
            return HasFlush() && Cards.All(c => c.Value > CardValue.Nine);
        }
            To this: */
        public bool HasRoyalFlush() => HasFlush() && Cards.All(c => c.Value > CardValue.Nine);
        
        /* Newly Added  */
        // The ToPairs extension method maps a collection of cards, to a collection of pairs.
        private bool HasOfAKind(int num) => cards.ToKindAndQuantities().Any(c => c.Value == num);
        /* From this:
        public bool HasPair()
        {
            return false;
        }
            to this: */
        public bool HasPair() => HasOfAKind(2);
        public bool HasThreeOfAKind() => HasOfAKind(3);
        public bool HasFourOfAKind() => HasOfAKind(4);
        public bool HasFullHouse() => HasThreeOfAKind() && HasPair();
    }
}
