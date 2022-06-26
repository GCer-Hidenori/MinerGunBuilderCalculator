namespace MinerGunBuilderCalculator
{
    internal class Parts : Thing
    {
        public Parts(Thing[,] thing_layout) : base(thing_layout)
        {
        }

        public override string Id { get; set; } = "--";
        public override string Name { get; set; } = nameof(Parts);
    }
}