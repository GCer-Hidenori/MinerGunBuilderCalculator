using MinerGunBuilderCalculator.Ships;
using System.Text;
using System.Windows.Forms;

namespace MinerGunBuilderCalculator
{
    public partial class Form_ShipExport : Form
    {
        public Form_ShipExport(ShipLayoutManager shipLayoutManager, string shipName)
        {
            InitializeComponent();

            CreateExportString(shipLayoutManager, shipName);
        }

        private void CreateExportString(ShipLayoutManager shipLayoutManager, string shipName)
        {
            Ship exportShip = ShipCatalog.GetShipByName(shipName);
            if(exportShip == null)
            {
                txtExportString.Text = "Unsupported Ship!";
                return;
            }
            StringBuilder exportString = new StringBuilder().Append(exportShip.Id);

            for(int y = 0; y<11; y++)
            {
                for (int x = 0; x < 11; x++)
                {
                    var tile = shipLayoutManager.thing_layout[x, y];
                    exportString.Append(tile.Id);
                    if (tile.IsRotatable)
                    {
                        switch (tile.direction)
                        {
                            case Thing.Direction.RIGHT:
                                exportString.Append('1');
                                break;
                            case Thing.Direction.DOWN:
                                exportString.Append('2');
                                break;
                            case Thing.Direction.LEFT:
                                exportString.Append('3');
                                break;
                            default:
                                exportString.Append('0');
                                break;
                        }
                    } else
                    {
                        exportString.Append('0');
                    }
                }
            }

            txtExportString.Text = exportString.ToString();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}