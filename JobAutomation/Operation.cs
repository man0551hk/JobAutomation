using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace JobAutomation
{
    public static class Operation
    {
        public static List<string> jobFileList = new List<string>();

        public static void GenerateDefaultJobTemplate()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "JobSample.txt"))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("WAIT 2");
                sb.AppendLine("SET_DETECTOR 1");
                sb.AppendLine("STOP");
                sb.AppendLine("CLEAR");
                sb.AppendLine("SEND_MESSAGE \"set_output_high\"");
                sb.AppendLine("WAIT 60");
                sb.AppendLine("SEND_MESSAGE \"set_output_low\"");
                sb.AppendLine("WAIT_CHANGER");
                //sb.AppendLine("SET_DETECTOR 0");
                
                sb.AppendLine("SET_PRESET_CLEAR");
                sb.AppendLine("SET_PRESET_REAL {counting}");
                sb.AppendLine("SET_PRESET_LIVE {counting}");

                //C:\User\ASC2\ASC2_DEF.Sdf
                sb.AppendLine("Recall_Options \"{sourceSDF}\"");

                sb.AppendLine("SET_OPTIONS \"{jobTextFile}\", \"{targetFile}\"");

                sb.AppendLine("Recall_Options \"{targetFile}\"");

                sb.AppendLine("Describe_Sample \"{description}\"");

                sb.AppendLine("Start");
                sb.AppendLine("Wait 2");
                sb.AppendLine("Wait");

                sb.AppendLine("Save \"$(AutoFile)\"");
                sb.AppendLine("Wait 2");
                sb.AppendLine("Analyze");

                sb.AppendLine("Wait 15");

                sb.AppendLine("Wait \"C:\\Program Files\\GammaVision\\Npp32.Exe\"");
                sb.AppendLine("Wait 2");

                sb.AppendLine("Wait \"C:\\Program Files\\ORTEC\\GammaVision Report Writer\\gvrpt32.exe\"");

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "JobSample.txt", sb.ToString());
            }
        }

        public static void PrepareDirectory()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.toggleProfileDetail.operationName;
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
            Directory.CreateDirectory(path + @"\JobTemplateFiles");
            Directory.CreateDirectory(path + @"\JobFiles");

        }

        public static void GenerateToFile(int sampleNo)
        { 
            string path = AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.toggleProfileDetail.operationName;

            try
            {
                SampleDetail thisDetail = GlobalFunc.toggleProfileDetail.sampleDetailList[sampleNo];
                string fileName = GlobalFunc.toggleProfileDetail.operationName + "_options_" + thisDetail.index.ToString("000") + ".txt";

                #region Generate Job File
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("CalibrationFilePath, \"" + thisDetail.calibrationFilePath + "\"");
                sb.AppendLine("LibraryFilePath, \"" + GlobalFunc.toggleProfileDetail.libraryFile + "\"");
                if (GlobalFunc.toggleProfileDetail.decayCorrection)
                {
                    sb.AppendLine("DecayToCollectionEnabled, 1");
                    sb.AppendLine("DecayToDate, \"" + thisDetail.decayCorrectionDate + "\"");
                }
                else 
                {
                    sb.AppendLine("DecayToCollectionEnabled, 0");
                }
                sb.AppendLine("SampleQuantity, " + thisDetail.sampleQuantity + "");
                sb.AppendLine("SampleQuantityUnits,  " + thisDetail.units + "");
                if (thisDetail.activityUnits == "uCi")
                {
                    sb.AppendLine("ActivityuCi, 1");
                }
                else
                {
                    sb.AppendLine("ActivityuCi, 0");
                }
                #endregion
                File.WriteAllText(path + @"\JobTemplateFiles\" + fileName, sb.ToString());

                GenerateDefaultJobTemplate();
                string jobFileStr = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "JobSample.txt");
                jobFileStr = jobFileStr.Replace("{sourceSDF}", GlobalFunc.setup.sdfFilePath);
                jobFileStr = jobFileStr.Replace("{jobTextFile}", path + @"\JobTemplateFiles\" + fileName);
                jobFileStr = jobFileStr.Replace("{targetFile}", path + @"\JobTemplateFiles\" +  fileName.Replace(".txt", ".sdf"));
                jobFileStr = jobFileStr.Replace("{counting}", thisDetail.countingTime.ToString());
                jobFileStr = jobFileStr.Replace("{description}", thisDetail.sampleDescription);

                File.WriteAllText(path + @"\JobFiles\" + fileName.Replace(".txt", ".job"), jobFileStr);
                jobFileList.Add(path + @"\JobFiles\" + fileName.Replace(".txt", ".job"));
            }
            catch
            { 
                    
            }
        }

        public static string masterPath = "";
        public static void GenerateMasterFile()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < jobFileList.Count; i++)
            {
                sb.AppendLine("Call \""+ jobFileList[i]+ "\"");
            }
            sb.AppendLine("QUIT");
            masterPath = AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.toggleProfileDetail.operationName + @"\" + GlobalFunc.toggleProfileDetail.operationName + "_master.job";
            File.WriteAllText(masterPath, sb.ToString());
        }

        public static void RunScript()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = GlobalFunc.setup.gammamVisionPath;
            //startInfo.Arguments = "-P DetL " + scriptFilePath + " -B";
            startInfo.Arguments = masterPath;
            Process.Start(startInfo);
        }
    }
}
