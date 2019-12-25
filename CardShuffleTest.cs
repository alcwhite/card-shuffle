using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class CardShuffle
{
    List<string> input = File.ReadAllLines("../../../input.txt").ToList();
    [Fact]
    public void Part1_Puzzle() 
    {
        Assert.Equal(6326, card_shuffle.CardShuffle.Directions(input, 10007).IndexOf(2019));
    }
    [Fact]
    public void Part1_BasicShuffle() 
    {
        var testInput = new List<string>(){"deal into new stack"};
        var output = new List<long>(){9,8,7,6,5,4,3,2,1,0};
        Assert.Equal(output, card_shuffle.CardShuffle.Directions(testInput, 10));
    }
    [Fact]
    public void Part1_Cut_Positive() 
    {
        var testInput = new List<string>(){"cut 3"};
        var output = new List<long>(){3, 4, 5, 6, 7, 8, 9, 0, 1, 2};
        Assert.Equal(output, card_shuffle.CardShuffle.Directions(testInput, 10));
    }
    [Fact]
    public void Part1_Cut_Negative() 
    {
        var testInput = new List<string>(){"cut -4"};
        var output = new List<long>(){6, 7, 8, 9, 0, 1, 2, 3, 4, 5};
        Assert.Equal(output, card_shuffle.CardShuffle.Directions(testInput, 10));
    }
    [Fact]
    public void Part1_ShuffleCount() 
    {
        var testInput = new List<string>(){"deal with increment 3"};
        var output = new List<long>(){0, 7, 4, 1, 8, 5, 2, 9, 6, 3};
        Assert.Equal(output, card_shuffle.CardShuffle.Directions(testInput, 10));
    }
    [Fact]
    public void Part2_Puzzle() 
    {
        Assert.Equal(10, card_shuffle.CardShuffle.Directions(input, 119315717514047, 101741582076661)[2020]);
    }

}