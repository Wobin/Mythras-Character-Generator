using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Models
{
    public class Characteristics
    {
        /// <summary>
        /// Everyone is defined by seven characteristics which tell you something 
        /// about your character; how strong or fast they are; how clever or healthy.
        /// 
        /// Characteristics are at the core of every Mythras character and form the 
        /// basis for most of the other elements such as Attributes and Skills
        /// </summary>

        public Characteristic Strength { get; set; }        = new Characteristic(Constants.Characteristics.Strength);
        public Characteristic Constitution { get; set; }    = new Characteristic(Constants.Characteristics.Constitution);
        public Characteristic Size { get; set; }            = new Characteristic(Constants.Characteristics.Size);
        public Characteristic Dexterity { get; set; }       = new Characteristic(Constants.Characteristics.Dexterity);
        public Characteristic Intelligence { get; set; }    = new Characteristic(Constants.Characteristics.Intelligence);
        public Characteristic Power { get; set; }           = new Characteristic(Constants.Characteristics.Power);
        public Characteristic Charisma { get; set; }        = new Characteristic(Constants.Characteristics.Charisma);

    }
}
