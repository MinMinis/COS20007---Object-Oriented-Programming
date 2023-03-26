using System;

namespace RPGAdventure
{
    public class Boss : EnemyWithSpecialAbility
    {
        private string[] BossNames { get; set; }

        public Boss() : base("", 0, 0, 0, 0, 0)
        {
            Random random = new();
            int maxhealth = random.Next(50, 200);
            int attack = random.Next(20, 40);
            int defense = random.Next(10, 30);
            int gold = random.Next(10, 30);
            int exp = random.Next(10, 30);
            MaxHealth = maxhealth;
            Health = MaxHealth;
            Attack = attack;
            Defense = defense;
            Gold = gold;
            Expgain = exp;

            BossNames = new string[]
            {
                "Vengeful Wrathful Valtor",
                "Unstoppable Vicious Zephyrion",
                "Fallen Cursed Azazel",
                "Dragon Lord Mighty Drakonius",
                "Devourer Monstrous Morgathor",
                "Enchantress Deceptive Ravenna",
                "Unknow Boss ???????????????"
            };

            int index = random.Next(0, BossNames.Length);
            Name = BossNames[index];
        }

        public override void UseSpecialAbility()
        {
            // can add more types of attack
            GUI.Slowprint($"The boss uses its special ability!");
        }
    }
}
