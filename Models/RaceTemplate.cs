using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Models
{
    public class RaceTemplate
    {
        public string RaceName { get; set; }
        public Dictionary<Constants.Characteristics, DicePool> DicePool { get; set; }
        public List<Constants.BodyParts> BodyParts { get; set; }
        public int BaseMovementRate { get; set; }
    }
}
