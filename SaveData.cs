using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace MinerGunBuilderCalculator
{
    public class SaveData
    {
        public ShipParameter shipParameter;
        public Profile profile;
        public Thing[,] thing_layout;

        const int SAVE_FORMAT_VERSION = 3;
        const int SUPPRT_MIN_SAVE_FORMAT_VERSION = 1;
        // 1 initial version
        // 2 Profile class
        // 3 SkillTree class
        public int SaveFormatVersion = SAVE_FORMAT_VERSION;

        private static bool CheckSaveFormatVersion(string json_string)
        {
            JObject savedata = JObject.Parse(json_string);
            if (savedata.ContainsKey("SaveFormatVersion"))
            {
                //int saveformatversion;
                if(int.TryParse(savedata["SaveFormatVersion"].ToString(),out int saveformatversion))
                {
                    if(saveformatversion >= SUPPRT_MIN_SAVE_FORMAT_VERSION)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static SaveData Load(out string save_file_name, ILogger logger)
        {
            OpenFileDialog ofd = new();
            SaveData save_data = null;
            save_file_name = null;
            ofd.FileName = "";
            ofd.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

            ofd.Filter = "Ship file(*.json)|*.json|All files(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "Load";

            ofd.RestoreDirectory = true;

            ofd.CheckFileExists = true;

            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (var sr = new StreamReader(ofd.FileName, System.Text.Encoding.UTF8))
                {

                    var jsonData = sr.ReadToEnd();
                    if (CheckSaveFormatVersion(jsonData))
                    {
                        // deserialize
                        var setting = new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All,
                        };

                        try
                        {
                            save_data = JsonConvert.DeserializeObject<SaveData>(jsonData, setting);
                            for (var x = 0; x < save_data.thing_layout.GetLength(0); x++)
                            {
                                for (var y = 0; y < save_data.thing_layout.GetLength(1); y++)
                                {
                                    save_data.thing_layout[x, y].thing_layout = save_data.thing_layout;
                                }
                            }
                            save_file_name = ofd.FileName;
                        }
                        catch (Newtonsoft.Json.JsonSerializationException ex)
                        {
                            save_file_name = null;
                            logger.LogError(ex, $"load error" +
                                $"jsondata:" +
                                $"{jsonData}");


                            /*
                            logger.LogError($"Load error: " +
                                $"Message:" +
                                $"{ex.Message}" +
                                $"Trace:" +
                                $"{ex.StackTrace}" +
                                $"LinePosition:" +
                                $"{ex.LinePosition}", ex, jsonData);
                            */
                            MessageBox.Show("Load error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        save_file_name = null;
                        MessageBox.Show("Not supported save data format.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                return save_data;
            }
            return null;
        }
        public static string Save(Thing[,] thing_layout,ShipParameter shipParameter,Profile profile,bool isSaveAs, string save_file_name = null)
        {
            var saveData = new SaveData
            {
                thing_layout = thing_layout,
                shipParameter = shipParameter,
                profile = profile
            };

            var setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                
            };
            var jsonString = JsonConvert.SerializeObject(saveData,setting);
            
            if ((isSaveAs ==false && save_file_name!=null) || (  save_file_name != null && File.Exists(save_file_name)))
            {
                using (StreamWriter sw = new (save_file_name,false, Encoding.UTF8))
                {
                    sw.Write(jsonString);
                }
                return save_file_name;
            }
            else
            {
                SaveFileDialog sfd = new()
                {
                    FileName = "New ship.json",
                    InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory,
                    Filter = "Ship file(*.json)|*.json|All files(*.*)|*.*",
                    FilterIndex = 1,
                    Title = "Save",
                    RestoreDirectory = true,
                    OverwritePrompt = true,
                    CheckPathExists = true
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new(sfd.FileName, false, Encoding.UTF8))
                    {
                        sw.Write(jsonString);
                    }
                    return sfd.FileName;

                }
                else
                {
                    return null;
                }
            }
        }
    }
}
