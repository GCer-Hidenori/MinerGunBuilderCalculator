using System.Collections.Generic;
using System.Linq;

namespace MinerGunBuilderCalculator.Ships
{
    public class Ship
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public ShipParameter Parameter { get; private set; }

        public Ship(string id, string name, decimal fireRate, decimal projectileSpeed)
        {
            Id = id;
            Name = name;
            Parameter = new ShipParameter(fireRate, projectileSpeed);
        }
    }

    public static class ShipCatalog
    {
        private static Dictionary<string, Ship> Catalog = new Dictionary<string, Ship>()
        {
            { "000", new Ship("000", "Rider-used", 1, 1) },
            { "001", new Ship("001", "Rider", 1.5m, 1) },
            { "002", new Ship("002", "Transporter", 1.4m, 1) },
            { "003", new Ship("003", "Rocket", 2.7m, 1) },
            { "004", new Ship("004", "Alien Seeker", 4.9m, 2) },
            { "005", new Ship("005", "Bus", 2, 1) },
            { "006", new Ship("006", "Fighter", 3.5m, 2) },
            { "007", new Ship("007", "Family cruiser", 5.5m, 2) },
            { "008", new Ship("008", "Pirate Blade", 4, 3) },
            { "009", new Ship("009", "Widow", 5.5m, 3) },
            { "010", new Ship("010", "Backsword", 6.2m, 3) },
            { "011", new Ship("011", "Container ship", 1, 2) },
            { "012", new Ship("012", "Prototype", 5.1m, 3) },
            { "013", new Ship("013", "Particle Launcher", 3.2m, 2) },
            { "014", new Ship("014", "Scout", 1.6m, 1) },
            { "015", new Ship("015", "Eco Seeker", 4.9m, 2) },
            { "016", new Ship("016", "Spaceshuttle", 2.8m, 2) },
            { "017", new Ship("017", "Army Launcher", 2.2m, 2) },
            { "018", new Ship("018", "Explorer", 4.3m, 1.3m) },
            { "019", new Ship("019", "Luxus-Class", 3.9m, 2) },
            { "020", new Ship("020", "Endprice", 1, 1) },
            { "021", new Ship("021", "Eco Destroyer", 3.7m, 2.2m) },
            { "022", new Ship("022", "Alien Destroyer", 1.8m, 2) },
            { "023", new Ship("023", "Rocket Carrier", 1, 1) },
            { "024", new Ship("024", "Mothership", 4, 2) },
            { "025", new Ship("025", "Death Star", 5.5m, 3.7m) },
            { "026", new Ship("026", "Cargo Ship", 1, 1) },
            { "027", new Ship("027", "Archmage", 3.1m, 3) },
            { "028", new Ship("028", "Eco Death", 3, 4) },
            { "029", new Ship("029", "Radio Seeker", 12.7m, 3) },
            { "030", new Ship("030", "Extractor", 11.1m, 3) },
            { "031", new Ship("031", "Transmitter", 9.9m, 4) }
        };

        public static Ship GetShipById(string id)
        {
            return Catalog.GetValueOrDefault(id);
        }

        public static Ship GetShipByName(string name)
        {
            return Catalog.Values.FirstOrDefault(s => s.Name == name);
        }
    }
}