
namespace GameEngineLibrary.Actors
{
    public class Player : Actor
    {
        public Player(uint healthPoint, uint armorClass)
        {
            HP = healthPoint;
            AC = armorClass;
        }

        public override uint Attack(Actor target)
        {
            throw new NotImplementedException();
        }
    }
}
