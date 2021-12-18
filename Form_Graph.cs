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
            //int i;
            while(tableLayoutPanel1.Controls.Count > 0){
                tableLayoutPanel1.Controls.RemoveAt(0);
            }
            //while(tableLayoutPanel1.RowCount > 1)
            //{
                tableLayoutPanel1.RowCount = 1;
            //}
        }
        public void AddHistogram(int ejector_number,List<decimal> decimal_damages,int fire_time_sec)
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

            double? min = null;
            double? max = null;
            foreach(double v in damages)
            {
                min = (min > v || min==null) ? v : min;
                max = (max < v || max==null) ? v : max;
            }

            //decide min,max
            if (min == null) min = 0;
            if (max == null) max = 100;
            if (min == max) max *= 10;
            if (max - min < 10)max = min + 10;

            (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(damages, min: (double)min, max: (double)max, binSize: 1);
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
            formsPlot.Refresh();

        }
    }
}
