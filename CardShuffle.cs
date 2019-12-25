using System;
using System.Collections.Generic;
using System.Linq;

namespace card_shuffle
{
    public static class CardShuffle
    {
        public static List<long> Directions(List<string> input, long deckCount, long times = 1)
        {
            var deck = new List<long>();
            long timesCount = 0;
            long count = 0;
            while (count < deckCount)
            {
                deck.Add(count);
                count++;
            }
            while (timesCount < times)
            {
                foreach(string direction in input)
                {
                    var directionArr = direction.Split(' ').ToList();
                    long.TryParse(directionArr[directionArr.Count - 1], out long num);
                    
                    if (direction.Contains("deal into new stack"))
                        deck = BasicShuffle(deck);
                    if (direction.Contains("deal with increment")) 
                        deck = ShuffleCount(deck, num);        
                    if (direction.Contains("cut"))
                        deck = Cut(deck, num);
                }
            }    
            return deck;
        }
        public static List<long> BasicShuffle(List<long> deck)
        {
            deck.Reverse();
            return deck;
        }
        public static List<long> ShuffleCount(List<long> deck, long count)
        {
            var newDeck = new long[deck.Count];
            var counter = 0;
            long index = 0;
            while (counter < deck.Count)
            {
                newDeck[index] = deck[counter];
                if (index + count > deck.Count - 1)
                {
                    var remainder = index + count - deck.Count;
                    index = remainder;
                }
                else 
                {
                    index += count;
                }
                counter++;
            }
            return newDeck.ToList();
        }
        public static List<long> Cut(List<long> deck, long count) 
        {
            var fromTop = true;
            if (count < 0)
            {
                fromTop = false;
                count = Math.Abs(count);
            }
            if (fromTop)
            {
                var slice = deck.GetRange(0, count);
                deck.RemoveRange(0, count);
                deck.AddRange(slice);
            }
            else 
            {
                var startingIndex = deck.Count - count;
                var slice = deck.GetRange(startingIndex, count);
                deck.RemoveRange(startingIndex, count);
                slice.ForEach(x => deck.Insert(slice.IndexOf(x), x));
            }
            return deck;
        }
       
    }
}