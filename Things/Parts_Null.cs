namespace MinerGunBuilderCalculator
{
    internal class Parts_Null : Parts
    {
        public override string Id { get; set; } = "00";
        public override string Name { get; set; } = nameof(Parts_Null);

        public Parts_Null(Thing[,] thing_layout) : base(thing_layout)
        {
            IsRemovable = false;
            IsRotatable = false;
        }
    }
}