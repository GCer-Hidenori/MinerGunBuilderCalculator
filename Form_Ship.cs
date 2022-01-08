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
    public partial class Form_Ship : Form
    {
        public static Form_Ship Current;
        public ShipLayoutManager shipLayoutManager = null;
        FireController fireController = null;
        public ShipParameter shipParamater = null;
        public string save_file_name = null;
        internal Profile profile = null;
        Form_SkillTree form_skillTree = null;
        public Form_Ship()
        {
            InitializeComponent();
        }

        public ShipLayoutManager GetShipLayoutManager()
        {
            return shipLayoutManager;
        }

        private void Form_Ship_Load(object sender, EventArgs e)
        {
            fireController = new(this);
            shipLayoutManager.AddShipLayoutChangeObserver(fireController);
            shipLayoutManager.Draw();
        }

        public void WriteCalculateResult(decimal average_damage_per_sec, decimal? min_damage, decimal average_damage, decimal max_damage, decimal projectile_speed, decimal projectile_eject_per_sec)
        {
            Label_average_damage.Text = String.Format("{0:#,0.00}", Decimal.Round(average_damage,2,MidpointRounding.AwayFromZero));
            Label_average_damage_per_sec.Text = String.Format("{0:#,0.00}",Decimal.Round(average_damage_per_sec,2,MidpointRounding.AwayFromZero));
            Label_highest_projectile_damage.Text = String.Format("{0:#,0.00}", max_damage);
            Label_lowest_projectile_damage.Text = String.Format("{0:#,0.00}", min_damage ?? 0);
            Label_Projectile_Max_Speed.Text = String.Format("{0:#,0.00}", projectile_speed);
            Label_projectile_ejected_per_sec.Text = String.Format("{0:#,0.00}", projectile_eject_per_sec);

        }

        public void AddPictureBox(PictureBox pb)
        {
            panel_pb_parent.Controls.Add(pb);
        }
        
        public void SetShipParameteLabelText(decimal base_damage, decimal fire_rate, decimal projectile_speed,decimal projectile_lifetime)
        {
            TextBox_BaseDamage.Text = base_damage.ToString();
            TextBox_FireRate.Text = fire_rate.ToString();
            TextBox_Projectile_Speed.Text = projectile_speed.ToString();
            TextBox_Projectile_Lifetime.Text = projectile_lifetime.ToString();
        }
        private void TextBox_Projectile_Speed_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (TextBox)sender;
            
            if (!Decimal.TryParse(textbox.Text, out decimal value))
            {
                errorProvider1.SetError(TextBox_BaseDamage, "Projectile Speed must be number.");
                e.Cancel = true;
            }
            shipParamater.projectile_speed = value;
        }

        private void TextBox_BaseDamage_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (TextBox)sender;
            
            if (!Decimal.TryParse(textbox.Text, out decimal value))
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
            
            if (!Decimal.TryParse(textbox.Text, out decimal value))
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

        private void Form_Ship_Enter(object sender, EventArgs e)
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
            
            if (!int.TryParse(textbox.Text, out int value))
            {
                errorProvider1.SetError(TextBox_Highet_Tier_in_World_Map, "Firerate must be number.");
                e.Cancel = true;
            }
            profile.Highest_Reached_Tier_in_World_Map = value;

        }

        private void TextBox_Projectile_Lifetime_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TextBox_Projectile_Lifetime, "");
            shipLayoutManager.NotifyShipLayoutChange2Observer();
        }

        private void TextBox_Projectile_Lifetime_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (TextBox)sender;
            
            if (!Decimal.TryParse(textbox.Text, out decimal value))
            {
                errorProvider1.SetError(TextBox_Projectile_Lifetime, "Projectile lifetime must be number.");
                e.Cancel = true;
            }
            shipParamater.projectile_lifetime = value;
        }

        private void Button_Start_Detailed_Calc_Click(object sender, EventArgs e)
        {
            if(fireController != null)
            {
                fireController.MakeGraphs((Form_Parent)this.ParentForm,shipLayoutManager.skillTree);
            }
            
            //var graphForm = new Form_Graph();
        }

        private void Button_SkillTree_Click(object sender, EventArgs e)
        {
            if(form_skillTree == null || form_skillTree.IsDisposed == true)
            {
                form_skillTree = new Form_SkillTree
                {
                    MdiParent = this.MdiParent
                };
                form_skillTree.skillTree = shipLayoutManager.skillTree;
                //form_skillTree.skillTree.form_SkillTree = form_skillTree;
                form_skillTree.Show();
                form_skillTree.DrawSkills();
            }

        }

        // Close skilltree form before ship form closed
        private void Form_Ship_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(form_skillTree != null && form_skillTree.IsDisposed == false)
            {
                form_skillTree.Close();
            }
        }
    }
}
