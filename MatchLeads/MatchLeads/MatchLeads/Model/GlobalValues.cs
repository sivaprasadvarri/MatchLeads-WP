using MatchLeads.Model.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchLeads.Model
{
    static class GlobalValues
    {
        // OAuth response variables
        public static string serviceInstanceUrl { get; set; }
        public static string accessToken { get; set; }

        //Login Response Variables
        public static userProfile globalUserProfile { get; set; }
        public static List<MMeventDetails> globalEventDetails { get; set; }
        public static string lastRecordId { get; set; }


        //Variables
        public static string BlCountry;
        public static string BlCountryIndex;
        public static string BlState;
    }
}
