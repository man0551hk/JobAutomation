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
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "DefSample.Job".ToLower()))
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("CLOSEBUFFERS");
                sb.AppendLine();
                sb.AppendLine("SET_DETECTOR 1");
                sb.AppendLine();
                sb.AppendLine("STOP");
                sb.AppendLine();
                sb.AppendLine("CLEAR");
                sb.AppendLine();
                sb.AppendLine("REM 'RECALL_OPTIONS \"{sourceSDF}\"");
                sb.AppendLine();
                sb.AppendLine("SET_OPTIONS \"{jobOptionFile}\",\"{targetFile}\"");
                sb.AppendLine();
                sb.AppendLine("ASK_CONFIRM \"Update SDF ok !\"");
                sb.AppendLine();
                sb.AppendLine("RECALL_OPTIONS \"{sourceSDF}\"");
                sb.AppendLine();
                sb.AppendLine("DESCRIBE_SAMPLE \"{description}\"");
                sb.AppendLine();
                sb.AppendLine("SET_PRESET_LIVE {counting}");
                sb.AppendLine();
                sb.AppendLine("'ASK_CONFIRM \"Check Preset Live of {counting} sec & sample desc\"");
                sb.AppendLine();
                sb.AppendLine("START");
                sb.AppendLine();
                sb.AppendLine("WAIT 2");
                sb.AppendLine();
                sb.AppendLine("WAIT");
                sb.AppendLine();
                sb.AppendLine("SAVE \"{spectraFile}\"");
                sb.AppendLine();
                sb.AppendLine("WAIT 5");
                sb.AppendLine();
                sb.AppendLine("ANALYZE");
                sb.AppendLine();
                sb.AppendLine("WAIT 5");
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "DefSample.Job", sb.ToString());
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
            Directory.CreateDirectory(path + @"\JobOptionFiles");
            Directory.CreateDirectory(path + @"\JobFiles");
            Directory.CreateDirectory(path + @"\Spectra");
            

        }

        public static void GenerateToFile(int sampleNo)
        { 
            string path = AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.toggleProfileDetail.operationName;

            try
            {
                SampleDetail thisDetail = GlobalFunc.toggleProfileDetail.sampleDetailList[sampleNo];
                string optionsfileName = GlobalFunc.toggleProfileDetail.operationName + "_options_" + thisDetail.index.ToString("000") + ".txt";
                string sdfFileName = GlobalFunc.toggleProfileDetail.operationName + "_" + thisDetail.index.ToString("000") + ".SDF";
                string spcFileName = GlobalFunc.toggleProfileDetail.operationName + "_" + thisDetail.index.ToString("000") + ".SPC";
                string jobFileName = GlobalFunc.toggleProfileDetail.operationName + "_" + thisDetail.index.ToString("000") + ".JOB";

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
                File.WriteAllText(path + @"\JobOptionFiles\" + optionsfileName, sb.ToString());

                //GenerateDefaultJobTemplate();
                //GenerateDefaultOptionsTemplate();
                string jobFileStr = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "JobSample.txt");
                jobFileStr = jobFileStr.Replace("{sourceSDF}",  GlobalFunc.toggleProfileDetail.sampleDefinitionFile);
                jobFileStr = jobFileStr.Replace("{jobOptionFile}", path + @"\JobOptionFiles\" + optionsfileName);
                jobFileStr = jobFileStr.Replace("{spectraFile}", path + @"\Spectra\" +spcFileName);
                jobFileStr = jobFileStr.Replace("{targetFile}", sdfFileName);
                jobFileStr = jobFileStr.Replace("{counting}", thisDetail.countingTime.ToString());
                jobFileStr = jobFileStr.Replace("{description}", thisDetail.sampleDescription == "" ? GlobalFunc.toggleProfileDetail.operationName + "_" + thisDetail.index.ToString("000") : thisDetail.sampleDescription);


                File.WriteAllText(path + @"\JobFiles\" + jobFileName, jobFileStr);
                jobFileList.Add(path + @"\JobFiles\" + jobFileName);
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
