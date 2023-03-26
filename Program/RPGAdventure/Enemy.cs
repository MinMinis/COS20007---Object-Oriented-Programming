namespace RPGAdventure
{
    public enum EnemyType
    {
        Monster,
        Boss
    }
    public interface ISpecialAbilityUser
    {
       void UseSpecialAbility();
    }
    public abstract class EnemyWithSpecialAbility : Enemy, ISpecialAbilityUser
    {
        public abstract void UseSpecialAbility();
        public EnemyWithSpecialAbility(string name, int health, int maxhealth,int attack, int defense, int gold, int exp)
            : base(name, health, maxhealth,attack, defense, gold, exp)
        {
        }
    }
    public abstract class Enemy
    {
        public string Name { get; set; }
        public int Health
        {
            get;
            set;
        }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }
        public int Expgain { get; set; }
        public Enemy(string name, int health, int maxhealth, int attack, int defense, int gold, int exp)
        {
            Name = name;
            MaxHealth= maxhealth;
            Health = health;
            Attack = attack;
            Defense = defense;
            Gold = gold;
            Expgain = exp;
        }
        public void TakeDamage(int hurt)
        {
            Health -= hurt;
        }
        public bool IsDeath()
        {
            if (Health <= 0)
            {
                GUI.Congrat($"{Name} has been defeated");
                Health = 0;
                return true;
            }
            return false;
        }
        public string Enemyinfo()
        {
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            string info = $"\nInfo: {Name} | Health: {Health}/{MaxHealth}" +
                          $"\nAttack: {Attack} | Defense: {Defense}";

            return info;
        }
    }
}
