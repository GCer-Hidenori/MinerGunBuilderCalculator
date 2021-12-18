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
            while(tableLayoutPanel1.Controls.Count > 0){
                tableLayoutPanel1.Controls.RemoveAt(0);
            }
            tableLayoutPanel1.RowCount = 1;
        }
        public void AddHistogram(int ejector_number,List<decimal> decimal_damages,int fire_time_sec, Statistics.Stats stats)
        {
            var formsPlot = new ScottPlot.FormsPlot
            {
                Height = 300,
                Width = 500,

                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill
            };
            var plt = formsPlot.Plot;
            
            double[] damages = new double[ decimal_damages.Count];
            for (var i = 0; i < decimal_damages.Count; i++) damages[i] = (double)decimal_damages[i];

            double scale_min = (double)stats.min;
            double scale_max = (double)stats.max;
            /*
            foreach(double v in damages)
            {
                min = (min > v || min==null) ? v : min;
                max = (max < v || max==null) ? v : max;
            }
            */

            //decide min,max
            //if (scale_min == null) scale_min = 0;
            //if (scale_max == null) scale_max = 100;
            if (scale_min == scale_max) scale_max *= 10;
            if (scale_max - scale_min < 10)scale_max = scale_min + 10;

            (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(damages, min: (double)scale_min, max: (double)scale_max, binSize: 1);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();

            // display the histogram counts as a bar plot
            var bar = plt.AddBar(values: counts, positions: leftEdges);
            bar.BarWidth = 1;

            // customize the plot style
            plt.Title($"Ejector #{ejector_number} damage histogram for {fire_time_sec}second");
            plt.YAxis.Label("Count (#)");
            plt.XAxis.Label("Damage");
            plt.SetAxisLimits(yMin: 0);

            if(tableLayoutPanel1.RowCount <= tableLayoutPanel1.Controls.Count)
            {
                tableLayoutPanel1.RowCount += 1;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200));
            }
            tableLayoutPanel1.Controls.Add(formsPlot);

            var label = new Label()
            {
                Dock = DockStyle.Fill,
                Text = $"Average:{stats.average:#,0.00}\r\nMean:{stats.mean:#,0.00}\r\nLow:{stats.min:#,0.00}\r\nHigh:{stats.max:#,0.00}"
            };
            tableLayoutPanel1.Controls.Add(label);

            formsPlot.Refresh();

        }
    }
}
