namespace MinerGunBuilderCalculator
{
    internal class Item : Thing
    {
        public Item(Thing[,] thing_layout) : base(thing_layout)
        {
            this.thing_layout = thing_layout;
        }

        public override string Id { get; set; } = "--";
        public override string Name { get; set; } = nameof(Item);
    }
}