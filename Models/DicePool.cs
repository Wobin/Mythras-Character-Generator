using System;
using System.Collections.Generic;

using System.Linq;

namespace MythrasCharacterGenerator.Models
{
    public class DicePool
    {
        public DicePool(string title = null)
        {
            Title = title;
        }
        public string Title { get; set; }
        public List<Die> Dice { get; set; } = new();
        public List<Die> PenaltyDice { get; set; } = new();
        public int Flat { get; set; }
        public int Low => (PenaltyDice.Any() ? PenaltyDice : Dice).Count();
        public int High => (PenaltyDice.Any() ? PenaltyDice : Dice).Sum(s => (int)s) + Flat;

        public override string ToString()
        {
            
            var groupedDice = Dice.Distinct().Select(s => Dice.OfDieType(s)).OrderBy(s => s.FirstOrDefault());
            var groupedPDice = PenaltyDice.Distinct().Select(s => PenaltyDice.OfDieType(s)).OrderBy(s => s.FirstOrDefault());
            var PlusDice = String.Join(" + ",groupedDice.Select(die => $"{die.Count()}{die.FirstOrDefault()}"));
            var MinusDice = String.Join(" + ", groupedPDice.Select(die => $"{die.Count()}{die.FirstOrDefault()}"));
            return $"{PlusDice}{(PenaltyDice.Any() ? " [-" + MinusDice + "]" : String.Empty)}{(Flat != 0 ? " " + Flat.ToString("+ #;- #;0") : String.Empty)}";
        }

        
        public string GetRange =>  $"{(PenaltyDice.Any() ?"-":"")}{Low}-{High}";
        
    }

    public static class Extensions
    {
        public static IEnumerable<Die> OfDieType(this List<Die> diceList, Die dieType)
        {
            return diceList.Where(s => s.Equals(dieType));
        }
    }
}