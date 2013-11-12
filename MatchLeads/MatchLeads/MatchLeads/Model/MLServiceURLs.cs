using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchLeads.Model
{
    class MLServiceURLs
    {
        public static string ML_OAuthUrl = "https://test.salesforce.com/services/oauth2/token?grant_type=password&client_id=3MVG9GiqKapCZBwHzyHJ_RnuesB4SLhNhSBC2Z6JIKEf1j1sSRhMHoxf6h0U4nxZqJafm89IR74G3PQCDzrZy&client_secret=835319979606089662&username=phani3@globalnest.com&password=globalnest@281EpumSfpx8QbnNC2Vyzdt74Zj";
        public static string ML_RegisterUrl = "/services/apexrest/SignUpForGnemsdc?userName={0}&passWord={1}&userType={2}";
        public static string ML_LoginUrl = "/services/apexrest/MMUserLogin?userName={0}&passWord={1}&isMM=TRUE";
        public static string ML_ForgotPasswordUrl = "/services/apexrest/FORGOTPASSWORD?Username={0}";
        public static string ML_ReSetPasswordUrl = "/services/apexrest/RESETPASSWORD?Username={0}&OldPassword={1}&newPassword={2}";
    }
}
