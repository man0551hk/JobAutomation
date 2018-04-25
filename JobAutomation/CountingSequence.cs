using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobAutomation
{
    public class Profile
    {
        public List<string> operationName { set; get; }
    }

    public class Analysis
    {
        public string operationName { set; get; }
        public string CreateDate { set; get; }
        public List<AnalysisSetting> analysisList { set; get; }
    }

    public class AnalysisSetting
    {
        public int index { set; get; }
        public string name { set; get; }
        public string sampleDescription { set; get; }
        public bool allowSampleDescription { set; get; }

        public string spectrumFilePath { set; get; }
        public bool allowSpectrumFilePath { set; get; }

        public string jobTemplatePath { set; get; }
        public bool allowJobTemplatePath { set; get; }

        public string sampleDefaultFilePath { set; get; }
        public bool allowSampleDefaultFilePath { set; get; }

        public string calibrationFilePath { set; get; }
        public bool allowCalibrationFilePath { set; get; }

        public string libraryFilePath { set; get; }
        public bool allowLibraryFilePath { set; get; }

        public string collectionStartDate { set; get; }
        public bool allowCollectionStartDate { set; get; }

        public string collectionStopDate { set; get; }
        public bool allowCollectionStopDate { set; get; }

        public bool decayCorrectionStopDateTime { set; get; }

        public string decayCorrectionDate { set; get; }
        public bool allowDecayCorrectionDate { set; get; }

        public int sampleQuantity { set; get; }
        public bool allowSampleQuantity { set; get; }

        public string units { set; get; }
        public bool allowUnits { set; get; }

        public string activityUnits { set; get; }
        public bool allowActivityUnits { set; get; }
        
        public int liveTimePreset { set; get; }
        public bool allowLiveTimePreset { set; get; }

        public int realTimePreset { set; get; }
        public bool allowRealTimePreset { set; get; }

        public int activityMultiper { set; get; }
        public bool allowActivityMultiper { set; get; }

        public int activityDivisor { set; get; }
        public bool allowActivityDivisor { set; get; }

        public int randomSummingFactor { set; get; }
        public bool allowRandomSummingFactor { set; get; }

        public int randomError { set; get; }
        public bool allowRandomError { set; get; }

        public int systematicError { set; get; }
        public bool allowSystematicError { set; get; }

        public int attenuationSize { set; get; }
        public bool allowAttenuationSize { set; get; }
    }
}
