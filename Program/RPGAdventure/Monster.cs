namespace RPGAdventure
{

    public class Monster : Enemy
    {
        public string[] MonsNames { get; set; }

        public Monster() : base("", 0, 0, 0, 0, 0)
        {
            Random random = new();
            int maxhealth = random.Next(50, 100);
            int attack = random.Next(10, 20);
            int defense = random.Next(0, 10);
            int gold = random.Next(10, 30);
            int exp = random.Next(10, 30);
            MaxHealth = maxhealth;
            Health = MaxHealth;
            Attack = attack;
            Defense = defense;
            Gold = gold;
            Expgain = exp;

            MonsNames = new string[]
            {
                "Vicious Minotaur",
                "Venomous Hydra",
                "Lurking Kraken",
                "Dreadful Behemoth",
                "Sinister Chimera",
                "Malevolent Basilisk",
                "Terrifying Leviathan",
                "Monstrous Harpy",
                "Pestilent Manticore",
                "Eerie Banshee",
                "Maleficent Gorgon",
                "Diabolical Wendigo",
                "Fearsome Cyclops",
                "Brutish Ogre",
            };

            int index = random.Next(0, MonsNames.Length);
            Name = MonsNames[index];
        }
    }
}
