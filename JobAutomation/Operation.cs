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

        //public static void GenerateDefaultJobTemplate()
        //{
        //    if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "DefSample.Job".ToLower()))
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        sb.AppendLine("CLOSEBUFFERS");
        //        sb.AppendLine();
        //        sb.AppendLine("SET_DETECTOR 1");
        //        sb.AppendLine();
        //        sb.AppendLine("STOP");
        //        sb.AppendLine();
        //        sb.AppendLine("CLEAR");
        //        sb.AppendLine();
        //        sb.AppendLine("REM 'RECALL_OPTIONS \"{sourceSDF}\"");
        //        sb.AppendLine();
        //        sb.AppendLine("SET_OPTIONS \"{jobOptionFile}\",\"{targetFile}\"");
        //        sb.AppendLine();
        //        sb.AppendLine("ASK_CONFIRM \"Update SDF ok !\"");
        //        sb.AppendLine();
        //        sb.AppendLine("RECALL_OPTIONS \"{sourceSDF}\"");
        //        sb.AppendLine();
        //        sb.AppendLine("DESCRIBE_SAMPLE \"{description}\"");
        //        sb.AppendLine();
        //        sb.AppendLine("SET_PRESET_LIVE {counting}");
        //        sb.AppendLine();
        //        sb.AppendLine("'ASK_CONFIRM \"Check Preset Live of {counting} sec & sample desc\"");
        //        sb.AppendLine();
        //        sb.AppendLine("START");
        //        sb.AppendLine();
        //        sb.AppendLine("WAIT 2");
        //        sb.AppendLine();
        //        sb.AppendLine("WAIT");
        //        sb.AppendLine();
        //        sb.AppendLine("SAVE \"{spectraFile}\"");
        //        sb.AppendLine();
        //        sb.AppendLine("WAIT 5");
        //        sb.AppendLine();
        //        sb.AppendLine("ANALYZE");
        //        sb.AppendLine();
        //        sb.AppendLine("WAIT 5");
        //        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "DefSample.Job", sb.ToString());
        //    }
        //}

        public static void GenerateDefaultOptionsTemplate()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "DefOptions.txt".ToLower()))
            {
                StringBuilder sb = new StringBuilder();
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "DefOptions.txt", sb.ToString());
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

                #region Generate Options File
                string optionFile = ReplaceOptionFile(thisDetail);
                File.WriteAllText(path + @"\JobOptionFiles\" + optionsfileName, optionFile);
                #endregion


                #region Generate Job File
                string jobFileStr = ReplaceJobFile(sampleNo + 1, GlobalFunc.toggleProfileDetail.sampleDetailList[sampleNo].sampleDefinationFilePath, path + @"\JobOptionFiles\" + optionsfileName,
                                            path + @"\Spectra\" + spcFileName, sdfFileName, thisDetail.countingTime.ToString(), 
                                            thisDetail.sampleDescription == "" ? GlobalFunc.toggleProfileDetail.operationName + "_" + thisDetail.index.ToString("000") : thisDetail.sampleDescription);
                File.WriteAllText(path + @"\JobFiles\" + jobFileName, jobFileStr);
                jobFileList.Add(path + @"\JobFiles\" + jobFileName);
                #endregion

            }
            catch(Exception ex)
            { 
                    
            }
        }

        public static string ReplaceOptionFile(SampleDetail thisDetail)
        {
            StringBuilder sb = new StringBuilder();
            string line;
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "DefOptions.txt"))
            {
                StreamReader file = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "DefOptions.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("LibraryFilePath"))
                    {
                        sb.AppendLine("LibraryFilePath, \"" + GlobalFunc.toggleProfileDetail.libraryFile + "\"");
                    }
                    else if (line.Contains("CalibrationFilePath"))
                    {
                        sb.AppendLine("CalibrationFilePath, \"" + thisDetail.calibrationFilePath + "\"");
                    }
                    else if (line.Contains("ActivityuCi"))
                    {
                        if (thisDetail.activityUnits != "uCi")
                        {
                            sb.AppendLine("ActivityuCi, 0");
                        }
                        else
                        {
                            sb.AppendLine("ActivityuCi, 1");
                        }
                    }
                    else if (line.Contains("ActivityUnits"))
                    {
                        sb.AppendLine("ActivityUnits, " + thisDetail.activityUnits);
                    }
                    else if (line.Contains("SampleQuantity"))
                    {
                        sb.AppendLine("SampleQuantity, " + thisDetail.sampleQuantity + "");
                    }
                    else if (line.Contains("SampleQuantityUnits"))
                    {
                        sb.AppendLine("SampleQuantityUnits,  " + thisDetail.units + "");
                    }
                    else if (line.Contains("DecayToCollectionEnabled"))
                    {
                        if (GlobalFunc.toggleProfileDetail.decayCorrection)
                        {
                            sb.AppendLine("DecayToCollectionEnabled, 1");
                        }
                        else
                        {
                            sb.AppendLine("DecayToCollectionEnabled, 0");
                        }
                    }
                    else if (line.Contains("DecayToDate"))
                    {
                        sb.AppendLine("DecayToDate, \"" + thisDetail.decayCorrectionDate + "\"");
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                }

                file.Close();
            }
            return sb.ToString();
        }

        public static string ReplaceJobFile(int index, string sourceSDF, string optionsFileName, string spcFileName, string sdfFileName, string countingTime, string description )
        {
            StringBuilder sb = new StringBuilder();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "DefSample.Job"))
            {
                string line;


                StreamReader file = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "DefSample.Job");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("RECALL_OPTIONS \"C:\\USER\\SAMPLE TYPES\\DefAscSdf.SDF\""))
                    {
                        sb.AppendLine("RECALL_OPTIONS \"" + sourceSDF  + "\"");
                    }
                    else if (line.Contains("SET_OPTIONS \"C:\\USER\\SAMPLE TYPES\\DefOptions.Txt\",\"ASCXXX.SDF\""))
                    {
                        sb.AppendLine("SET_OPTIONS \"" + optionsFileName + "\", \"" + sdfFileName + "\"");
                    }
                    else if (line.Contains("RECALL_OPTIONS \"C:\\USER\\SAMPLE TYPES\\ASCXXX.SDF\""))
                    {
                        sb.AppendLine("RECALL_OPTIONS \"" + sdfFileName + "\"");
                    }
                    else if (line.Contains("DESCRIBE_SAMPLE \"SAMPLEXXX\""))
                    {
                        sb.AppendLine("DESCRIBE_SAMPLE \"" + description + "\"");
                        if (GlobalFunc.setup.hardware == "DSPec50")
                        {
                            sb.AppendLine("Send_Message \"SET_ID " + index.ToString() + "\"");
                        }
                        else if (GlobalFunc.setup.hardware == "DigiBASE")
                        {
                            sb.AppendLine("Send_Message \"SET_LLD " + index.ToString() + "\"");
                        }
                    }
                    else if (line.Contains("SET_PRESET_LIVE 10"))
                    {
                        sb.AppendLine("SET_PRESET_LIVE " + countingTime);
                    }
                    else if (line.Contains("SAVE \"C:\\USER\\SPECTRA\\SAMPLEXXX.SPC\""))
                    {
                        sb.AppendLine("SAVE \"" + spcFileName + "\"");
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                }
            }
            return sb.ToString();
        }

        public static string masterPath = "";
        public static void GenerateMasterFile()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SET_SETTING \"Laboratory\",\"" + GlobalFunc.setup.laboratory+ "\"");
            sb.AppendLine("SET_SETTING \"Operator\",\"" + GlobalFunc.setup._operator + "\"");

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

        public static string SendCommand(string command)
        {
            string returnVal = "";
            try
            {
                if (!GlobalFunc.tc.axUCONN21.IsOpen)
                {
                    GlobalFunc.tc.axUCONN21.Open();
                }
                returnVal = GlobalFunc.tc.axUCONN21.Comm(command);

                if (GlobalFunc.tc.axUCONN21.IsOpen)
                {
                    GlobalFunc.tc.axUCONN21.Close();
                }
            }
            catch (Exception ex)
            {
               LogManager.WriteLog(ex.Message);
            }
            //CloseConnection(detectorIndex);
            return returnVal;
        }

    }
}
