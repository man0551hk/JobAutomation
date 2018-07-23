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

    public class ProfileDetail
    {
        public string operationName { set; get; }
        public string CreateDate { set; get; }
        public string dataFolder { set; get; }
        public string prefix { set; get; }
        public int sampleNo { set; get; }
        public string sampleDefinitionFile { set; get; }
        public bool commonSDF { set; get; }
        public string calibrationFile { set; get; }
        public bool commonCalibrationFile { set; get; }
        public string qtyUnit { set; get; }
        public bool commonQtyUnit { set; get; }
        public double qty { set; get; }
        public bool commonQty { set; get; }
        public int countingTime { set; get; }
        public bool commonCountingTime { set; get; }
        public string activityUnit { set; get; }
        public bool commonActivityUnit { set; get; }
        public string libraryFile { set; get; }
        public bool commonLibrary { set; get; }
        public bool decayCorrection { set; get; }
        public bool commonDecayCorrection { set; get; }
        public string decayCorrectionDate { set; get; }
        public bool commonDecayDate { set; get; }

        public List<SampleDetail> sampleDetailList { set; get; }
    }


    public class SampleDetail
    {
        public int index { set; get; }
       
        public string sampleDescription { set; get; }

        public string sampleDefinationFilePath { set; get; }

        public string calibrationFilePath { set; get; }

        public bool decayCorrection { set; get; }

        public string decayCorrectionDate { set; get; }

        public double sampleQuantity { set; get; }

        public string units { set; get; }

        public string activityUnits { set; get; }

        public int countingTime { set; get; }
        
        public string libraryFile { set; get; }

        //public string jobTemplatePath { set; get; }
        //CollectionStart
        //CollectionEnd
        //Weight
        //LiveTime
        //RealTime
        //Multiplier
        //Divisor
        //SpectrumFilePath
        //ABSLength
        //RandomError
        //SystematicError
        //RandomSummingFactor
    }
}
