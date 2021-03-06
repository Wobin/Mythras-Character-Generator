using MythrasCharacterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator
{
    public static class Constants
    {
        public enum Characteristics
        {
            Strength,
            Constitution,
            Size,
            Dexterity,
            Intelligence,
            Power,
            Charisma
        }

        public enum BodyParts
        {
            Head,
            LeftArm,
            RightArm,
            Abdomen,
            Chest,
            LeftLeg,
            RightLeg
        }

        public static RaceTemplate Human = new()
        {
            RaceName = "Human",
            DicePool = new()
            {
                { Characteristics.Strength, new() { Dice = new() { Dice.d6, Dice.d6, Dice.d6 } } },
                { Characteristics.Constitution, new() { Dice = new() { Dice.d6, Dice.d6, Dice.d6 } } },
                { Characteristics.Dexterity, new() { Dice = new() { Dice.d6, Dice.d6, Dice.d6 } } },
                { Characteristics.Power, new() { Dice = new() { Dice.d6, Dice.d6, Dice.d6 } } },
                { Characteristics.Charisma, new() { Dice = new() { Dice.d6, Dice.d6, Dice.d6 } } },
                { Characteristics.Size, new() { Dice = new() { Dice.d6, Dice.d6 }, Flat = 6 } },
                { Characteristics.Intelligence, new() { Dice = new() { Dice.d6, Dice.d6 }, Flat = 6 } },
            },
            BodyParts = new() { BodyParts.Head, BodyParts.Abdomen, BodyParts.Chest, BodyParts.LeftArm, BodyParts.RightArm, BodyParts.LeftLeg, BodyParts.RightLeg },
            BaseMovementRate = 6
        };
    }
}
