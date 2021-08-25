namespace StardropPoolMinigame.Render.Filters
{
    abstract class Animation : Filter
    {
        public Animation(string key) : base(key)
        {
            this.StartTransition(key);
        }

        public override string GetName()
        {
            return "generic-animation";
        }
    }
}
