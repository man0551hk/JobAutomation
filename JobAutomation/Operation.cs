using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JobAutomation
{
    public static class Operation
    {
        public static void GenerateDefaultJobTemplate()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "JobSample.txt"))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Set_Detector 1");
                sb.AppendLine("Stop");
                sb.AppendLine("Clear");
                sb.AppendLine("REM Send_Message \"set_output_high\"");
                sb.AppendLine("Wait 5");
                sb.AppendLine("REM Send_Message \"set_output_low\"");
                sb.AppendLine("REM Wait 60");
                sb.AppendLine("");
                sb.AppendLine("REM Wait_Changer");
                sb.AppendLine("");
                sb.AppendLine("Run \"{updateSDFExeFilePath} {sampleDefaultFilePath}, {sampleDetailFile}\"");
                sb.AppendLine("Wait \"{updateSDFExeFilePath}\"");
                sb.AppendLine("Recall_Options \"{sampleDefaultFilePath}\"");
                sb.AppendLine("Describe_Sample \"{description}\"");
                sb.AppendLine("");
                sb.AppendLine("Start");
                sb.AppendLine("Wait 2");
                sb.AppendLine("Wait");
                sb.AppendLine("");
                sb.AppendLine("Save \"{spectrumFilePath}\"");
                sb.AppendLine("Wait 2");
                sb.AppendLine("Analyze");
                sb.AppendLine("Wait 5");
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


        public static void GenerateJoFile(int sampleNo)
        { 
            string path = AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.toggleProfileDetail.operationName;

            try
            {
                SampleDetail thisDetail = GlobalFunc.toggleProfileDetail.sampleDetailList[sampleNo];
                string fileName = GlobalFunc.toggleProfileDetail.operationName + "_sample_" + thisDetail.index.ToString("000") + ".jtp";
                
                #region GenerateSampleDetailFile
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SampleDescription: " + thisDetail.sampleDescription);
                sb.AppendLine("JobTemplatePath: " + "");
                sb.AppendLine("SDFPath: " + thisDetail.sampleDefinationFilePath);
                sb.AppendLine("CollectionStart: " + "");
                sb.AppendLine("CollectionEnd: " + "");
                sb.AppendLine("DecayDateTime:" + thisDetail.decayCorrectionDate);
                sb.AppendLine("Weight: " + "0");
                sb.AppendLine("QuantityUnits: " + thisDetail.units);
                sb.AppendLine("ActivityUnits: " + thisDetail.activityUnits);
                sb.AppendLine("LiveTime: " + "15");
                sb.AppendLine("RealTime: " + "15");
                sb.AppendLine("Multiplier: " + "");
                sb.AppendLine("Divisor:  " + "");
                sb.AppendLine("SpectrumFilePath: " + "");
                sb.AppendLine("CalFileName: " + thisDetail.calibrationFilePath);
                sb.AppendLine("LibFileName: " + GlobalFunc.toggleProfileDetail.libraryFile);
                sb.AppendLine("ABSConfigID: -1");
                sb.AppendLine("ABSTypeID: -1");
                sb.AppendLine("ABSMaterialID: -1");
                sb.AppendLine("ABSLength: " + "");
                sb.AppendLine("RandomError: " + "");
                sb.AppendLine("SystematicError: " + "");
                sb.AppendLine("RandomSummingFactor: " + "");
                File.WriteAllText(path + @"\JobTemplateFiles\" + fileName, sb.ToString());
                #endregion

                #region Generate Job File
                GenerateDefaultJobTemplate();
                string jobFile = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "JobSample.txt");
                jobFile = jobFile.Replace("{updateSDFExeFilePath}", GlobalFunc.setup.sdfFilePath);
                jobFile = jobFile.Replace("{sampleDefaultFilePath}", thisDetail.sampleDefinationFilePath);
                jobFile = jobFile.Replace("{sampleDetailFile}", fileName);
                jobFile = jobFile.Replace("{description}", thisDetail.sampleDescription);
                File.WriteAllText(path + @"\JobFiles\" + fileName.Replace(".jtp", ".job"), jobFile);
                #endregion
            }
            catch
            { 
                    
            }
        }
    }
}
