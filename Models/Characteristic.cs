using System;

namespace MythrasCharacterGenerator.Models
{
    public class Characteristic
    {        
        public Constants.Characteristics _type { get; init; }
        public int Value { get; set; }
        public Characteristic() { }

        public Characteristic(Constants.Characteristics characteristic)
        {
            _type = characteristic;
        }

        public override bool Equals(object obj)
        {
            return obj is Constants.Characteristics characteristic &&
                   _type == characteristic;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_type);
        }
    }
}