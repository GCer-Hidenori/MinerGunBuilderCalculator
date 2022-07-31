using Microsoft.Extensions.Logging;
using MinerGunBuilderCalculator.Ships;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MinerGunBuilderCalculator
{
    public class ImportData
    {
        public ShipParameter shipParameter;
        public Profile profile;
        public Thing[,] thing_layout;

        private const int maxX = 11;
        private const int maxY = 11;

        private static bool CheckSaveFormatVersion(string importString)
        {
            return importString.Length == 366;
        }

        public static SaveData Load(out string saveFileName, ILogger logger)
        {
            saveFileName = "Clipboard";
            SaveData saveData = new SaveData();

            Form_ShipImport fsi = new Form_ShipImport();
            var retVal = fsi.ShowDialog();

            if (retVal == DialogResult.Cancel)
            {
                return null;
            }
            else if (retVal == DialogResult.OK)
            {
                var importData = fsi.ImportContent;
                if (CheckSaveFormatVersion(importData))
                {
                    List<string> parts = Split(importData, 3).ToList();
                    Ship ship = ShipCatalog.GetShipById(parts.First());
                    saveFileName = ship.Name;
                    saveData.shipParameter = ship.Parameter;

                    saveData.profile = new Profile();
                    saveData.thing_layout = CreateThings(parts.Skip(1).ToList());

                }
                else
                {
                    saveFileName = null;
                    MessageBox.Show("Not supported save data format.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            
                return saveData;
            }
            return null;
        }

        private static Thing[,] CreateThings(List<string> parts)
        {
            int x = 0;
            int y = 0;
            Thing[,] thing_layout = new Thing[maxX, maxY];

            foreach (string part in parts)
            {
                Thing item = new Parts_Null(thing_layout);
                string partId = part.Substring(0, 2);
                string partDirection = part.Substring(2, 1);
                switch (partId)
                {
                    case "01":
                        item = new Parts_01_Wall(thing_layout);
                        break;
                    case "02":
                        item = new Parts_03_ProjectileGenerator(thing_layout);
                        break;
                    case "03":
                        item = new Parts_02_Ejector(thing_layout);
                        break;
                    case "04":
                        item = new Item_002_Guide_left(thing_layout);
                        break;
                    case "05":
                        item = new Item_001_Guide_right(thing_layout);
                        break;
                    case "06":
                        item = new Item_003_Add_1_damage(thing_layout);
                        break;
                    case "07":
                        item = new Item_008_Small_spread(thing_layout);
                        break;
                    case "08":
                        item = new Item_006_Large_spread(thing_layout);
                        break;
                    case "09":
                        item = new Item_005_Spread_left(thing_layout);
                        break;
                    case "10":
                        item = new Item_007_Spread_right(thing_layout);
                        break;
                    case "11":
                        item = new Item_010_Random_curve(thing_layout);
                        break;
                    case "12":
                        item = new Item_009_Curve_left(thing_layout);
                        break;
                    case "13":
                        item = new Item_011_Curve_right(thing_layout);
                        break;
                    case "14":
                        item = new Item_021_Split_2_way(thing_layout);
                        break;
                    case "15":
                        item = new Item_004_Speed_up(thing_layout);
                        break;
                    case "16":
                        item = new Item_032_Add_projectile(thing_layout);
                        break;
                    case "17":
                        item = new Item_022_Split_3_way(thing_layout);
                        break;
                    case "18":
                        item = new Item_025_Remaining_damage(thing_layout);
                        break;
                    case "19":
                        item = new Item_026_Pierce(thing_layout);
                        break;
                    case "20":
                        item = new Item_013_Criticalx2(thing_layout);
                        break;
                    case "21":
                        item = new Item_014_Criticalx10(thing_layout);
                        break;
                    case "22":
                        item = new Item_023_Random_2_way(thing_layout);
                        break;
                    case "23":
                        item = new Item_024_Random_3_way(thing_layout);
                        break;
                    case "24":
                        item = new Item_027_Round_area(thing_layout);
                        break;
                    case "25":
                        item = new Item_018_Random_bounce(thing_layout);
                        break;
                    case "26":
                        item = new Item_017_Return(thing_layout);
                        break;
                    case "27":
                        item = new Item_033_Fly_forward(thing_layout);
                        break;
                    case "28":
                        item = new Item_020_Double_lifetime(thing_layout);
                        break;
                    case "29":
                        item = new Item_035_Money_crossing(thing_layout);
                        break;
                    case "30":
                        item = new Item_036_Damage_crossing(thing_layout);
                        break;
                    case "31":
                        item = new Item_012_Slow_down(thing_layout);
                        break;
                    case "32":
                        item = new Item_029_Attraction(thing_layout);
                        break;
                    case "33":
                        item = new Item_030_Align_direction(thing_layout);
                        break;
                    case "34":
                        item = new Item_019_Richchet(thing_layout);
                        break;
                    case "35":
                        item = new Item_031_Align_to_ship(thing_layout);
                        break;
                    case "36":
                        item = new Item_016_Charge(thing_layout);
                        break;
                    case "37":
                        item = new Item_034_Fly_sideways(thing_layout);
                        break;
                    case "38":
                        item = new Item_028_Rectangle_area(thing_layout);
                        break;
                    case "39":
                        item = new Item_015_Random_critical(thing_layout);
                        break;
                }
                if (item.IsRotatable)
                {
                    switch (partDirection)
                    {
                        case "1":
                            item.direction = Thing.Direction.RIGHT;
                            break;
                        case "2":
                            item.direction = Thing.Direction.DOWN;
                            break;
                        case "3":
                            item.direction = Thing.Direction.LEFT;
                            break;
                        default:
                            item.direction = Thing.Direction.TOP;
                            break;
                    }
                }

                thing_layout[x, y] = item;

                x++;
                if (x >= 11)
                {
                    y++;
                    x = 0;
                }
            }

            return thing_layout;
        }

        private static Ship GetShip(string shipId)
        {
            return ShipCatalog.GetShipById(shipId);
        }


        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
