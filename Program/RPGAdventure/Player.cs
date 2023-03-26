namespace RPGAdventure
{
    public class Player
    {
        private string name = "", desc = "";
        private int exp, expMax, level = 1;
        private bool isdef;
        // Stats
        private int hp, hpMax , damage, damageMax, defence, gold = 100;
        // potion
        private int potion, heal_ammount;
        // weapon
        private int weapondmg;
        private string weapon;
        private void ExpCal()
        {
            expMax = level * 100;
        }
        private void Stats()
        {
            weapon = "Stick";
            weapondmg = 10;
            hpMax       = 10;
            hp          = hpMax;
            damageMax   = weapondmg + 2;
            damage      = damageMax / 2;
            defence     = 2;
            potion      = 1;
            heal_ammount = 10;
            exp = 0;
            expMax = 10;
            isdef = false;
        }

        public Player(string namein, string descrip)
        {
            Stats();
            name = namein;
            desc = descrip;
        }
        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        public int Health
        {
            get => hp;
            set => hp = value < 0 ? 0 : value > hpMax ? hpMax : value;
        }

        public int MaxHealth
        {
            get
            {
                return hpMax;
            }
            set
            {
                hpMax = value;
            }
        }
        public string Name
        {
            get { return $"{desc} {name}"; }
        }
        public string Nameplayer
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Descplayer
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
            }
        }
        public int Level
        {
            get 
            { 
                return level; 
            } 
            set
            {
                level = value;
            }
        }
        public int Defend
        {
            get
            {
                return defence;
            }
            set
            {
                defence = value;
            }
        }
        public int Potion
        {
            get
            {
                return potion;
            }
            set
            {
                potion = value;
            }
        }
        public int Gold
        {
            get
            {
                return gold;
            }
            set
            {
                gold = value;
            }
        }
        public int Damage
        {
            get
            { return damage;}
            set
            {
                damage = value;
            }
        }
        public int DamageMax
        {
            get
            {
                return damageMax;
            }
            set
            {
                damageMax = value;
            }
        }
        public string Weapon
        {
            get
            {
                return weapon;
            }
            set
            {
                weapon = value;
            }
        }
        public int WeaponDmg
        {
            get
            {
                return weapondmg;
            }
            set
            {
                weapondmg = value;
            }
        }
        public string Banner()
        {
            string input = $"\n\tRole: {desc}. Name: {name}" +
                           $"\n\tLevel: {level}. EXP: {exp}/{expMax}" +
                           $"\n\t{GUI.ProgressBar(exp, expMax, 10)}" +
                           $"\n\tCoin: {gold}";
            return input;
        }
        public override string ToString()
        {
            string input = $"\n\tRole: {desc}. Name: {name}" +
                           $"\n\tLevel: {level}. EXP: {exp}/{expMax}" +
                           $"\n\t{GUI.ProgressBar(exp, expMax, 10)}";
            return input;
        }
        public string AllInfo()
        {
            string input = $"\t---------------------------"+
                           $"\n\tRole: {desc}. Name: {name}" +
                           $"\n\tLevel: {level} | EXP: {exp}/{expMax}" +
                           $"\n\t{GUI.ProgressBar(exp, expMax, 10)}" +
                           $"\n\tCoin: {gold}" +
                           $"\n\tHealth: {hp}/{hpMax} | Potion: {potion} (Heal: {heal_ammount})" +
                           $"\n\tWeapon: {weapon} | Weapon damage: {weapondmg}" +
                           $"\n\tDamage: {damage} - {damageMax} | Armor: {defence}" +
                           $"\n\t---------------------------";
            return input;
        }
        public void Win(Enemy enemy)
        {
            exp += enemy.Expgain;
            GUI.Congrat($"{name} has gain {enemy.Expgain} EXP");
            gold += enemy.Gold;
            GUI.Congrat($"{name} has gain {enemy.Gold} gold");
            GUI.WaitEnter();
        }
        public void TakeDamage(int damage)
        {
            hp -= damage;
        }
        public void UseHeal()
        {
            if (potion > 0)
            {
                hp += heal_ammount;
                potion--;
                GUI.Slowprint($"You heal yourself and loose 1 potion.");
            }
            else
            {
                GUI.Slowprint("You don't have any potion to use");
            }
        }
        public bool IsDefending
        {
            get
            {
                return isdef;
            }
            set
            { isdef = value; }
        }
    }
}
