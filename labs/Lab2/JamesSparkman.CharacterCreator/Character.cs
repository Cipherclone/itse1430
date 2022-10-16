/*
ITSE 1430 
Fall 2022
James Sparkman
*/
namespace JamesSparkman.CharacterCreator
{
    /// <summary> Represents a Character. </summary>
    public class Character
    {
        public Character () : this ("","")
        {

        }

        public Character (string name) : this (name, "")
        {
        
        }

        public Character (string name, string profession) : base()
        {
            Name = name;
            Profession = profession;
        }
        
        /// <summary> Name of the given character. </summary>
        public string Name { get; set; }
        
        /// <summary> Profession of the given character. </summary>
        public string Profession { get; set;}

        /// <summary> Race of a given character. </summary>
        public string Race { get; set; } = "Unknown";

        /// <summary> Optional Biography of a given character. </summary>
        public string Biography { get; set; } = "No Biography Given";

        /// <summary> Strength of a given character, must be between 1-100 </summary>
        public int Strength { get; set; } = 1;

        /// <summary> Intelligence of a given character, must be between 1-100 </summary>
        public int Intelligence { get; set; } = 1;

        /// <summary> Agility of a given character, must be between 1-100 </summary>
        public int Agility { get; set; } = 1;

        /// <summary> Constitution of a given character, must be between 1-100 </summary>
        public int Constitution { get; set; } = 1;

        /// <summary> Charisma of a given character, must be between 1-100 </summary>
        public int Charisma { get; set; } = 1;

        /// <summary> Clones the existing character. </summary>
        /// <returns>A copy of the character.</returns>
        public Character Clone ()
        {
            var character = new Character ();
            CopyTo(character);
            
            return character;
        }

        /// <summary> Copy the character to another instance. </summary>
        /// <param name="character">Character to copy into.</param>
        public void CopyTo (Character character)
        {
            character.Name = Name;
            character.Profession = Profession;
            character.Race = Race;
            character.Biography = Biography;
            character.Strength = Strength;
            character.Intelligence = Intelligence;
            character.Agility = Agility;
            character.Constitution = Constitution;
            character.Charisma = Charisma;

        }
    }
}