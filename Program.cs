using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerGunBuilderCalculator
{
    class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddEventLog(eventLogSettings =>
                {
                    //eventLogSettings.SourceName = "MinerBunBuilderCalculator";
                });

            });
            ILogger logger = loggerFactory.CreateLogger<Program>();

            //logger.LogInformation("Example log message");

            Application.Run(new Form_Parent(logger));
        }
    
    }
}
