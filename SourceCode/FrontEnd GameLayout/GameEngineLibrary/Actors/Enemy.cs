namespace GameEngineLibrary.Actors
{
    public class Enemy : Actor
    {
        public uint Damage { get; set; }

        public Enemy(uint healthPoint, uint armorClass, uint baseDamage)
        {
            HP = healthPoint;
            AC = armorClass;
            Damage = baseDamage;
        }

        public override uint Attack(Actor target)
        {
            throw new NotImplementedException();
        }
    }
}
