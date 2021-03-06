using System.Collections.Generic;

namespace MythrasCharacterGenerator.Models
{
    public class DicePool
    {
        public List<Dice> Dice { get; set; }
        public List<Dice> PenaltyDice { get; set; }
        public int Flat { get; set; }
    }
}