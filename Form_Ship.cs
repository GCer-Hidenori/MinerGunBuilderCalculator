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

        public void WriteCalculateResult(decimal average_damage_per_sec, decimal? min_damage, decimal average_damage, decimal max_damage, decimal projectile_speed, decimal projectile_eject_per_sec,decimal projectile_lifetime)
        {
            Label_average_damage.Text = String.Format("{0:#,0.00}", Decimal.Round(average_damage,2,MidpointRounding.AwayFromZero));
            Label_average_damage_per_sec.Text = String.Format("{0:#,0.00}",Decimal.Round(average_damage_per_sec,2,MidpointRounding.AwayFromZero));
            Label_highest_projectile_damage.Text = String.Format("{0:#,0.00}", max_damage);
            Label_lowest_projectile_damage.Text = String.Format("{0:#,0.00}", min_damage ?? 0);
            Label_Projectile_Max_Speed.Text = String.Format("{0:#,0.00}", projectile_speed);
            Label_projectile_ejected_per_sec.Text = string.Format("{0:#,0.00}", projectile_eject_per_sec);
            Label_Projectile_Lifetime.Text = string.Format("{0:#,0.00}", projectile_lifetime);
        }
        public void WriteCalculateResult_EffectiveDamage(decimal average_effective_damage_per_sec, decimal? min_effective_damage, decimal average_effective_damage, decimal max_effective_damage)
        {
            Label_average_effective_damage.Text = String.Format("{0:#,0.00}", Decimal.Round(average_effective_damage, 2, MidpointRounding.AwayFromZero));
            Label_average_effective_damage_per_sec.Text = String.Format("{0:#,0.00}", Decimal.Round(average_effective_damage_per_sec, 2, MidpointRounding.AwayFromZero));
            Label_highest_projectile_effective_damage.Text = String.Format("{0:#,0.00}", max_effective_damage);
            Label_lowest_projectile_effective_damage.Text = String.Format("{0:#,0.00}", min_effective_damage ?? 0);
        }
        public void WriteCalculateResult_area_pierce(decimal average_round_area_count, decimal average_rectangle_area_count, decimal average_pierce_count)
        {
            Label_average_round_area_count.Text = String.Format("{0:#,0.00}", Decimal.Round(average_round_area_count,2,MidpointRounding.AwayFromZero));
            Label_average_rectangle_area_count.Text = String.Format("{0:#,0.00}",Decimal.Round(average_rectangle_area_count,2,MidpointRounding.AwayFromZero));
            Label_average_pierce_count.Text = String.Format("{0:#,0.00}", Decimal.Round(average_pierce_count,2,MidpointRounding.AwayFromZero));
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
        public void SetProfileParameteLabelText(decimal highest_reached_tier_in_world_map, decimal highest_cleared_tier_in_world_map,decimal play_hour)
        {
            TextBox_Highest_Reached_Tier_in_World_Map.Text = highest_reached_tier_in_world_map.ToString();
            TextBox_Highest_Cleared_Tier_in_World_Map.Text = highest_cleared_tier_in_world_map.ToString();
            TextBox_Play_Hour.Text = play_hour.ToString();
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

        private void TextBox_Highest_Reached_Tier_in_World_Map_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TextBox_Highest_Reached_Tier_in_World_Map, "");
            shipLayoutManager.NotifyShipLayoutChange2Observer();
        }

        private void TextBox_Highest_Reached_Tier_in_World_Map_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (TextBox)sender;
            
            if (!int.TryParse(textbox.Text, out int value))
            {
                errorProvider1.SetError(TextBox_Highest_Reached_Tier_in_World_Map, "Tier must be number.");
                e.Cancel = true;
            }
            profile.Highest_Reached_Tier_in_World_Map = value;
        }
        private void TextBox_Highest_Cleared_Tier_in_World_Map_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TextBox_Highest_Cleared_Tier_in_World_Map, "");
            shipLayoutManager.NotifyShipLayoutChange2Observer();
        }

        private void TextBox_Highest_Cleared_Tier_in_World_Map_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (TextBox)sender;
            
            if (!int.TryParse(textbox.Text, out int value))
            {
                errorProvider1.SetError(TextBox_Highest_Cleared_Tier_in_World_Map, "Tier must be number.");
                e.Cancel = true;
            }
            profile.Highest_Cleared_Tier_in_World_Map = value;
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
        private void TextBox_Play_Hour_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TextBox_Play_Hour, "");
            shipLayoutManager.NotifyShipLayoutChange2Observer();
        }

        private void TextBox_Play_Hour_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (TextBox)sender;
            
            if (!Decimal.TryParse(textbox.Text, out decimal value))
            {
                errorProvider1.SetError(TextBox_Play_Hour, "Play hour must be number.");
                e.Cancel = true;
            }
            profile.Play_Hour = value;
        }

        private void Button_Start_Simulation_Click(object sender, EventArgs e)
        {
            if(fireController != null)
            {
                fireController.MakeGraphs((Form_Parent)this.ParentForm,shipLayoutManager.profile.skillList);
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
                form_skillTree.SkillList = shipLayoutManager.profile.skillList;
                form_skillTree.shipLayoutManager = shipLayoutManager;
                form_skillTree.Show();
                form_skillTree.DrawSkills();
            }
            form_skillTree.Focus();

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
