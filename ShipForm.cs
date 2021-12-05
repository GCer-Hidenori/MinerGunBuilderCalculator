using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerGunBuilderCalculator
{
    public partial class ShipForm : Form
    {
        public static ShipForm Current;
        public ShipLayoutManager shipLayoutManager = null;
        FireController fireController = null;
        public ShipParameter shipParamater = null;
        public string save_file_name = null;
        internal Profile profile = null;
        public ShipForm()
        {
            InitializeComponent();
        }

        public ShipLayoutManager GetShipLayoutManager()
        {
            return shipLayoutManager;
        }

        private void ShipForm_Load(object sender, EventArgs e)
        {
            fireController = new(this);
            shipLayoutManager.AddShipLayoutChangeObserver(fireController);
            shipLayoutManager.Draw();
        }

        public void WriteCalculateResult(decimal average_damage_per_sec, decimal? min_damage, decimal average_damage, decimal max_damage, decimal projectile_speed, decimal projectile_eject_per_sec)
        {
            Label_average_damage.Text = String.Format("{0:#,0.00}", average_damage);
            Label_average_damage_per_sec.Text = String.Format("{0:#,0.00}", average_damage_per_sec);
            Label_highest_projectile_damage.Text = String.Format("{0:#,0.00}", max_damage);
            Label_lowest_projectile_damage.Text = String.Format("{0:#,0.00}", min_damage);
            Label_Projectile_Max_Speed.Text = String.Format("{0:#,0.00}", projectile_speed);
            Label_projectile_ejected_per_sec.Text = String.Format("{0:#,0.00}", projectile_eject_per_sec);

        }

        public void AddMessage(string msessage)
        {
            TextBox_Message.Text += msessage;
        }
        
        public void AddPictureBox(PictureBox pb)
        {
            panel_pb_parent.Controls.Add(pb);
        }
        
        public void SetShipParameteLabelText(decimal base_damage, decimal fire_rate, decimal projectile_speed)
        {
            TextBox_BaseDamage.Text = base_damage.ToString();
            TextBox_FireRate.Text = fire_rate.ToString();
            TextBox_Projectile_Speed.Text = projectile_speed.ToString();
        }
        private void TextBox_Projectile_Speed_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (TextBox)sender;
            decimal value;
            if (!Decimal.TryParse(textbox.Text, out value))
            {
                errorProvider1.SetError(TextBox_BaseDamage, "Projectile Speed must be number.");
                e.Cancel = true;
            }
            shipParamater.projectile_speed = value;
        }

        private void TextBox_BaseDamage_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (TextBox)sender;
            decimal value;
            if (!Decimal.TryParse(textbox.Text, out value))
            {
                errorProvider1.SetError(TextBox_BaseDamage, "Base damage must be number.");
                e.Cancel = true;
            }
            shipParamater.base_damage = value;
        }

        private void TextBox_BaseDamage_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TextBox_BaseDamage, "");
            shipLayoutManager.NotifyShipLayoutChange2Observer();
        }
        private void TextBox_Projectile_Speed_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TextBox_Projectile_Speed, "");
            shipLayoutManager.NotifyShipLayoutChange2Observer();
        }

        private void TextBox_FireRate_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (TextBox)sender;
            decimal value;
            if (!Decimal.TryParse(textbox.Text, out value))
            {
                errorProvider1.SetError(TextBox_FireRate, "Firerate must be number.");
                e.Cancel = true;
            }
            shipParamater.fire_rate = value;
        }

        private void TextBox_FireRate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TextBox_FireRate, "");
            shipLayoutManager.NotifyShipLayoutChange2Observer();
        }

        private void ShipForm_Enter(object sender, EventArgs e)
        {
            Current = this;
        }

        private void TextBox_Highet_Tier_in_World_Map_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TextBox_Highet_Tier_in_World_Map, "");
            shipLayoutManager.NotifyShipLayoutChange2Observer();
        }

        private void TextBox_Highet_Tier_in_World_Map_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (TextBox)sender;
            int value;
            if (!int.TryParse(textbox.Text, out value))
            {
                errorProvider1.SetError(TextBox_Highet_Tier_in_World_Map, "Firerate must be number.");
                e.Cancel = true;
            }
            profile.Highest_Reached_Tier_in_World_Map = value;

        }
    }
}
