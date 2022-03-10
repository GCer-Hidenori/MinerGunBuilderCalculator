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
    public partial class Form_Graph : Form
    {
        public Form_Graph()
        {
            InitializeComponent();
        }
        public void ClearGraphs()
        {
            //remember 1st row's controls
            List<Control> not_first_row_controls = new();
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                var cellposition = tableLayoutPanel1.GetPositionFromControl(control);
                if (cellposition.Row != 0) not_first_row_controls.Add(control);
            }
            foreach(Control control in not_first_row_controls)
            {
                tableLayoutPanel1.Controls.Remove(control);
            }

            /*
            for(int i = tableLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                Control control = tableLayoutPanel1.Controls[i];
                if(!first_row_controls.Contains(control))
                {
                    tableLayoutPanel1
                }
            }

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if(!first_row_controls.Contains(control))
                {
                    tableLayoutPanel1.Controls.Remove(control);
                }
            }
            */
            tableLayoutPanel1.RowCount = 1;
            /*
            while (tableLayoutPanel1.RowCount > 1)
            {
                for(int col = 0 ; col < tableLayoutPanel1.ColumnCount;col++)
                {
                    このあたりから。列ループとは違う？ずれてくるし
                }
            }
            */
            /*
            while(tableLayoutPanel1.Controls.Count > 0){
                tableLayoutPanel1.Controls.RemoveAt(0);
            }
            tableLayoutPanel1.RowCount = 1;
            */
        }
        private (Label label,ScottPlot.FormsPlot formsPlot) CreateSingleHistgram(string ejector_name,List<decimal> projectile_damages,int fire_time_sec,Statistics.Stats stats_projectile_damage,decimal ejected_count,decimal ejected_count_per_sec)
        {
            var formsPlot_projectile_damage = new ScottPlot.FormsPlot
            {
                Height = 300,
                Width = 398,

                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill
            };
            var plt_projectile_damage = formsPlot_projectile_damage.Plot;
            double[] damages = new double[projectile_damages.Count];
            for (var i = 0; i < projectile_damages.Count; i++) damages[i] = (double)projectile_damages[i];

            //double scale_min = (double)stats.min;
            //double scale_max = (double)stats.max;

            //if (scale_min == scale_max) scale_max *= 10;
            //if (scale_max - scale_min < 10)scale_max = scale_min + 10;

            //(double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(damages, min: (double)scale_min, max: (double)scale_max, binSize: 1);
            (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(damages,20);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();

            // display the histogram counts as a bar plot
            plt_projectile_damage.AddBar(values: counts, positions: leftEdges);
            //bar.BarWidth = 1;

            // customize the plot style
            plt_projectile_damage.Title($"Ejector #{ejector_name} damage histogram for {fire_time_sec}second");
            plt_projectile_damage.YAxis.Label("Count (#)");
            plt_projectile_damage.XAxis.Label("Damage");
            plt_projectile_damage.SetAxisLimits(yMin: 0);

            //tableLayoutPanel1.Controls.Add(formsPlot_projectile_damage);

            var label = new Label()
            {
                Dock = DockStyle.Fill,
                Text = $"Lowest projectile damage:{stats_projectile_damage.min_damage:#,0.00}\r\nAverage projectile damage:{Decimal.Round(stats_projectile_damage.average_damage,2,MidpointRounding.AwayFromZero):#,0.00}\r\nMean projectile damage:{stats_projectile_damage.mean_damage:#,0.00}\r\nHighest projectile damage:{stats_projectile_damage.max_damage:#,0.00}" +
                $"\r\nTotal projectile damage:{Decimal.Round(stats_projectile_damage.total_damage,2,MidpointRounding.AwayFromZero)}\r\nAverage projectile damage/sec:{Decimal.Round(stats_projectile_damage.average_damage_per_sec,2,MidpointRounding.AwayFromZero):#,0.00}" +
                $"\r\nProjectile ejected count:{ejected_count}\r\nProjectile ejected count/sec:{Decimal.Round(ejected_count_per_sec,2,MidpointRounding.AwayFromZero):#,0.00}"


            };

            return (label,formsPlot_projectile_damage);
        }
        public void AddHistogram(string ejector_name,List<decimal> projectile_damages,List<decimal> projectile_effective_damages,int fire_time_sec, Statistics.Stats stats_projectile_damage,Statistics.Stats stats_projectile_effective_damage)
        {
            decimal ejected_count = projectile_damages.Count;
            decimal ejected_count_per_sec = ejected_count / fire_time_sec;
            var histgram_projectile_damage = CreateSingleHistgram(ejector_name,projectile_damages,fire_time_sec,stats_projectile_damage,ejected_count,ejected_count_per_sec);
            var histgram_projectile_effective_damage = CreateSingleHistgram(ejector_name,projectile_effective_damages,fire_time_sec,stats_projectile_effective_damage,ejected_count,ejected_count_per_sec);

            //if(tableLayoutPanel1.Controls.Count != 0)
            //{
                tableLayoutPanel1.RowCount += 1;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200));
            //}
            tableLayoutPanel1.Controls.Add(histgram_projectile_damage.formsPlot);
            tableLayoutPanel1.Controls.Add(histgram_projectile_damage.label);
            tableLayoutPanel1.Controls.Add(histgram_projectile_effective_damage.formsPlot);
            tableLayoutPanel1.Controls.Add(histgram_projectile_effective_damage.label);

            histgram_projectile_damage.formsPlot.Refresh();
            histgram_projectile_effective_damage.formsPlot.Refresh();
        }
    }
}
