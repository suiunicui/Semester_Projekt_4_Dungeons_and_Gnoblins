namespace GameEngineLibrary.Actors
{
    public abstract class Actor
    {
        public uint HP { get; set; }
        public uint AC { get; set; }

        public abstract uint Attack(Actor target);
    }
}
