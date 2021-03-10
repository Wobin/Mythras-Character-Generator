using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Models
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string PlayerName { get; set; }
        public string Culture { get; set; }
        public string Gender { get; set; }
        public string Frame { get; set; }
        public string Homeland { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string  Career { get; set; }
        public string Handedness { get; set; }
        public string Weight { get; set; }
        public string  SocialClass { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; }
        public Characteristics Characteristics { get; set; } = new();
        public RaceTemplate Race { get; set; } = Constants.Human;
        public int ActionPoints { get; set; } = 2;
        public int ActionPointsCurrent { get; set; }
        public DicePool DamageModifier { get {
                return (Characteristics.Strength.Value + Characteristics.Size.Value) switch
                {
                    <= 5   => new("Damage Modifier") { PenaltyDice = new() { Die.d8 } },
                    <= 10  => new("Damage Modifier") { PenaltyDice = new() { Die.d6 } },
                    <= 15  => new("Damage Modifier") { PenaltyDice = new() { Die.d4 } },
                    <= 20  => new("Damage Modifier") { PenaltyDice = new() { Die.d2 } },
                    <= 25  => new("Damage Modifier") {                                 },
                    <= 30  => new("Damage Modifier") { Dice = new() { Die.d2 } },
                    <= 35  => new("Damage Modifier") { Dice = new() { Die.d4 } },
                    <= 40  => new("Damage Modifier") { Dice = new() { Die.d6 } },
                    <= 45  => new("Damage Modifier") { Dice = new() { Die.d8 } },
                    <= 50  => new("Damage Modifier") { Dice = new() { Die.d10 } },
                    <= 60  => new("Damage Modifier") { Dice = new() { Die.d12 } },
                    <= 70  => new("Damage Modifier") { Dice = new() { Die.d6, Die.d6 } },
                    <= 80  => new("Damage Modifier") { Dice = new() { Die.d8, Die.d6 } },
                    <= 90  => new("Damage Modifier") { Dice = new() { Die.d8, Die.d8 } },
                    <= 100 => new("Damage Modifier") { Dice = new() { Die.d10, Die.d8 } },
                    <= 110 => new("Damage Modifier") { Dice = new() { Die.d10, Die.d10 } },
                    <= 120 => new("Damage Modifier") { Dice = new() { Die.d10, Die.d10, Die.d2 } },
                         _ => new("Damage Modifier") { Dice = new() { Die.d10, Die.d10, Die.d4 } }, // TODO No idea how to extend this, there's no obvious progression
                };
            }  }
        public string DamageModifierCurrent { get; set; }
        public int ExperienceModifier { get {
                return Characteristics.Charisma.Value switch
                {
                    <= 6  => -1,
                    <= 12 => 0,
                    <= 18 => 1,
                    _ => ((Characteristics.Charisma.Value - 18) / 6) + 2 
                };
            } }
        public int HealingRate { get {
                return Characteristics.Constitution.Value switch
                {
                    <= 6  => -1,
                    <= 12 =>  0,
                    <= 18 =>  1,
                    _ => ((Characteristics.Constitution.Value - 18) / 6 ) + 2
                };
            }  }
        public Dictionary<Constants.BodyParts, int> MaxHitPoints { get {
                return (Characteristics.Constitution.Value + Characteristics.Size.Value) switch
                {
                    <= 5 => new()
                    {
                        { Constants.BodyParts.LeftLeg, 1 },
                        { Constants.BodyParts.RightLeg, 1 },
                        { Constants.BodyParts.Abdomen, 2 },
                        { Constants.BodyParts.Chest, 3 },
                        { Constants.BodyParts.LeftArm, 1 },
                        { Constants.BodyParts.RightArm, 1 },
                        { Constants.BodyParts.Head, 1 },
                    },
                    <= 10 => new()
                    {
                        { Constants.BodyParts.LeftLeg, 2 },
                        { Constants.BodyParts.RightLeg, 2 },
                        { Constants.BodyParts.Abdomen, 3 },
                        { Constants.BodyParts.Chest, 4 },
                        { Constants.BodyParts.LeftArm, 1 },
                        { Constants.BodyParts.RightArm, 1 },
                        { Constants.BodyParts.Head, 2 },
                    },
                    <= 15 => new()
                    {
                        { Constants.BodyParts.LeftLeg, 3 },
                        { Constants.BodyParts.RightLeg, 3 },
                        { Constants.BodyParts.Abdomen, 4 },
                        { Constants.BodyParts.Chest, 5 },
                        { Constants.BodyParts.LeftArm, 2 },
                        { Constants.BodyParts.RightArm, 2 },
                        { Constants.BodyParts.Head, 3 },
                    },
                    <= 20 => new()
                    {
                        { Constants.BodyParts.LeftLeg, 4 },
                        { Constants.BodyParts.RightLeg, 4 },
                        { Constants.BodyParts.Abdomen, 5 },
                        { Constants.BodyParts.Chest, 5 },
                        { Constants.BodyParts.LeftArm, 3 },
                        { Constants.BodyParts.RightArm, 3 },
                        { Constants.BodyParts.Head, 2 },
                    },
                    <= 25 => new()
                    {
                        { Constants.BodyParts.LeftLeg, 5 },
                        { Constants.BodyParts.RightLeg, 5 },
                        { Constants.BodyParts.Abdomen, 6 },
                        { Constants.BodyParts.Chest, 7 },
                        { Constants.BodyParts.LeftArm, 4 },
                        { Constants.BodyParts.RightArm, 4 },
                        { Constants.BodyParts.Head, 5 },
                    },
                    <= 30 => new()
                    {
                        { Constants.BodyParts.LeftLeg, 6 },
                        { Constants.BodyParts.RightLeg, 6 },
                        { Constants.BodyParts.Abdomen, 7 },
                        { Constants.BodyParts.Chest, 8 },
                        { Constants.BodyParts.LeftArm, 5 },
                        { Constants.BodyParts.RightArm, 5 },
                        { Constants.BodyParts.Head, 6 },
                    },
                    <= 35 => new()
                    {
                        { Constants.BodyParts.LeftLeg, 7 },
                        { Constants.BodyParts.RightLeg, 7 },
                        { Constants.BodyParts.Abdomen, 8 },
                        { Constants.BodyParts.Chest, 9 },
                        { Constants.BodyParts.LeftArm, 6 },
                        { Constants.BodyParts.RightArm, 6 },
                        { Constants.BodyParts.Head, 7 },
                    },
                    <= 40 => new()
                    {
                        { Constants.BodyParts.LeftLeg, 8 },
                        { Constants.BodyParts.RightLeg, 8 },
                        { Constants.BodyParts.Abdomen, 9 },
                        { Constants.BodyParts.Chest, 10 },
                        { Constants.BodyParts.LeftArm, 7 },
                        { Constants.BodyParts.RightArm, 7 },
                        { Constants.BodyParts.Head, 8 },
                    },
                    _ => new()
                    {
                        { Constants.BodyParts.LeftLeg, 8 +  (((Characteristics.Constitution.Value + Characteristics.Size.Value - 40) / 5) + 1) },
                        { Constants.BodyParts.RightLeg, 8 + (((Characteristics.Constitution.Value + Characteristics.Size.Value - 40) / 5) + 1) },
                        { Constants.BodyParts.Abdomen, 9 +  (((Characteristics.Constitution.Value + Characteristics.Size.Value - 40) / 5) + 1) },
                        { Constants.BodyParts.Chest, 10 +   (((Characteristics.Constitution.Value + Characteristics.Size.Value - 40) / 5) + 1) },
                        { Constants.BodyParts.LeftArm, 7 +  (((Characteristics.Constitution.Value + Characteristics.Size.Value - 40) / 5) + 1) },
                        { Constants.BodyParts.RightArm, 7 + (((Characteristics.Constitution.Value + Characteristics.Size.Value - 40) / 5) + 1) },
                        { Constants.BodyParts.Head, 8 +     (((Characteristics.Constitution.Value + Characteristics.Size.Value - 40) / 5) + 1) },
                    },
                };
            }  }
        public int BaseInitiativeBonus { get { return (Characteristics.Dexterity.Value + Characteristics.Intelligence.Value) / 2; } }
        public int MaxLuckPoints { get {
                return Characteristics.Power.Value switch
                {
                    <=6  => 1,
                    <=12 => 2,
                    <=18 => 3,
                    _ => ((Characteristics.Power.Value - 18 ) / 6) + 4
                }; } }
        public int MaxMagicPoints { get { return Characteristics.Power.Value; } }
        public int MovementRate { get { return Race.BaseMovementRate; } }
    }
}
