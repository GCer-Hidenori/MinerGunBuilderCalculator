using System.Text.Json.Serialization;

namespace MinerGunBuilderCalculator
{
    internal class Parts_01_Wall : Thing
    {
        [JsonIgnore]
        public override string Id { get; set; } = "01";

        [JsonIgnore]
        public override string Name { get; set; } = nameof(Parts_01_Wall);

        public Parts_01_Wall(Thing[,] thing_layout) : base(thing_layout)
        {
            IsRotatable = false;
        }
    }
}