using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatchLeads.Model.DataContracts;
using System.Runtime.Serialization.Json;
using System.IO;

namespace MatchLeads.Model
{
    class ServiceResponseParsing
    {


        internal static void OAuthResponseParsing(string response)
        {
            JSON jsonObj = new JSON();
            Dictionary<string, object> dicOAuthResponse = jsonObj.Deserialize(response);

            //Get Service Instance Url for calling service
            if (dicOAuthResponse.ContainsKey("instance_url"))
            {
                GlobalValues.serviceInstanceUrl = (string)dicOAuthResponse["instance_url"];
            }

            //Get Access Token value
            if (dicOAuthResponse.ContainsKey("access_token"))
            {
                GlobalValues.accessToken = (string)dicOAuthResponse["access_token"];
            }


        }

        internal static string RegisterParsing(string response)
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(response));
            DataContractJsonSerializer dcJsonserializer = new DataContractJsonSerializer(typeof(string));
            string strRegStatus = (string)dcJsonserializer.ReadObject(stream);
            return strRegStatus;
        }

        internal static bool LoginResponseParsing(string response)
        {
            bool IsValidUser = false;
            JSON jSonObj = new JSON();


            Dictionary<string, Object> dicStep1 = jSonObj.Deserialize(response);

            #region Code for UserProfile
            if (dicStep1.Keys.Contains("userProfile"))
            {
                List<object> listUserProfile = (List<object>)dicStep1["userProfile"];
                foreach (var item in listUserProfile)
                {
                    Dictionary<string, object> dicUserPrifile = (Dictionary<string, object>)item;

                    if (dicUserPrifile.Keys.Contains("error"))
                    {
                        if (!string.IsNullOrEmpty(dicUserPrifile["error"].ToString()))
                        {
                            //Invalid User
                            break;
                        }
                    }
                    else if (!dicUserPrifile.Keys.Contains("error"))
                    {
                        //Valid User
                        IsValidUser = true;
                        userProfile userProfileObj = new userProfile();

                        if (dicUserPrifile.Keys.Contains("UserID"))
                        {
                            userProfileObj.UserID = dicUserPrifile["UserID"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("FirstName"))
                        {
                            userProfileObj.FirstName = dicUserPrifile["FirstName"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("LastName"))
                        {
                            userProfileObj.LastName = dicUserPrifile["LastName"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("Email"))
                        {
                            userProfileObj.Email = dicUserPrifile["Email"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("PhoneNo"))
                        {
                            userProfileObj.PhoneNo = dicUserPrifile["PhoneNo"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("ImageUrl"))
                        {
                            userProfileObj.ImageUrl = dicUserPrifile["ImageUrl"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("Company"))
                        {
                            userProfileObj.ImageUrl = dicUserPrifile["Company"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("City"))
                        {
                            userProfileObj.Company = dicUserPrifile["City"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("State"))
                        {
                            userProfileObj.State = dicUserPrifile["State"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("Country"))
                        {
                            userProfileObj.Country = dicUserPrifile["Country"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("attendeeID"))
                        {
                            userProfileObj.attendeeID = dicUserPrifile["attendeeID"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("dtime"))
                        {
                            userProfileObj.dtime = dicUserPrifile["dtime"].ToString();
                        }

                        if (dicUserPrifile.Keys.Contains("message"))
                        {
                            userProfileObj.message = dicUserPrifile["message"].ToString();
                        }

                        GlobalValues.globalUserProfile = userProfileObj;
                    }
                }

            }

            #endregion

            #region Code For Events
            if (dicStep1.Keys.Contains("MMeventDetails"))
            {
                List<object> eventslist = (List<object>)dicStep1["MMeventDetails"];
                List<MMeventDetails> Events = new List<MMeventDetails>();

                foreach (var item in eventslist)
                {
                    MMeventDetails eventObj = new MMeventDetails();

                    Dictionary<string, object> dicEvent = (Dictionary<string, object>)item;

                    if (dicEvent.Keys.Contains("UserRole"))
                    {
                        eventObj.UserRole = dicEvent["UserRole"].ToString();
                    }

                    if (dicEvent.Keys.Contains("Event_ID"))
                    {
                        eventObj.Event_ID = dicEvent["Event_ID"].ToString();
                    }

                    if (dicEvent.Keys.Contains("Event_Name"))
                    {
                        eventObj.Event_Name = dicEvent["Event_Name"].ToString();
                    }

                    if (dicEvent.Keys.Contains("Event_Description"))
                    {
                        eventObj.Event_Description = dicEvent["Event_Description"].ToString();
                    }

                    if (dicEvent.Keys.Contains("Event_Location"))
                    {
                        eventObj.Event_Location = dicEvent["Event_Location"].ToString();
                    }

                    if (dicEvent.Keys.Contains("EventLogoImageURL"))
                    {
                        eventObj.EventLogoImageURL = dicEvent["EventLogoImageURL"].ToString();
                    }

                    if (dicEvent.Keys.Contains("Event_StartDate"))
                    {
                        eventObj.Event_StartDate = dicEvent["Event_StartDate"].ToString();
                    }

                    if (dicEvent.Keys.Contains("Event_StartHour"))
                    {
                        eventObj.Event_StartHour = dicEvent["Event_StartHour"].ToString();
                    }

                    if (dicEvent.Keys.Contains("Event_Date"))
                    {
                        eventObj.Event_Date = dicEvent["Event_Date"].ToString();
                    }

                    if (dicEvent.Keys.Contains("Event_EndHour"))
                    {
                        eventObj.Event_EndHour = dicEvent["Event_EndHour"].ToString();
                    }

                    if (dicEvent.Keys.Contains("MMType"))
                    {
                        eventObj.MMType = dicEvent["MMType"].ToString();
                    }

                    if (dicEvent.Keys.Contains("Status"))
                    {
                        eventObj.Status = dicEvent["Status"].ToString();
                    }

                    if (dicEvent.Keys.Contains("TwitterHashTag"))
                    {
                        eventObj.TwitterHashTag = dicEvent["TwitterHashTag"].ToString();
                    }

                    if (dicEvent.Keys.Contains("MatchMakingStartDate"))
                    {
                        eventObj.MatchMakingStartDate = dicEvent["MatchMakingStartDate"].ToString();
                    }

                    if (dicEvent.Keys.Contains("MatchMakingStartDate"))
                    {
                        eventObj.MatchMakingStartDate = dicEvent["MatchMakingStartDate"].ToString();
                    }

                    if (dicEvent.Keys.Contains("MatchMakingStartTime"))
                    {
                        eventObj.MatchMakingStartTime = dicEvent["MatchMakingStartTime"].ToString();
                    }

                    if (dicEvent.Keys.Contains("MatchMakingEndDate"))
                    {
                        eventObj.MatchMakingEndDate = dicEvent["MatchMakingEndDate"].ToString();
                    }

                    if (dicEvent.Keys.Contains("MatchMakingEndTime"))
                    {
                        eventObj.MatchMakingEndTime = dicEvent["MatchMakingEndTime"].ToString();
                    }

                    if (dicEvent.Keys.Contains("HostingPhone"))
                    {
                        eventObj.HostingPhone = dicEvent["HostingPhone"].ToString();
                    }

                    if (dicEvent.Keys.Contains("HostingAddr1"))
                    {
                        eventObj.HostingAddr1 = dicEvent["HostingAddr1"].ToString();
                    }

                    if (dicEvent.Keys.Contains("HostingAddr2"))
                    {
                        eventObj.HostingAddr2 = dicEvent["HostingAddr2"].ToString();
                    }

                    if (dicEvent.Keys.Contains("HostingCity"))
                    {
                        eventObj.HostingCity = dicEvent["HostingCity"].ToString();
                    }

                    if (dicEvent.Keys.Contains("HostingState"))
                    {
                        eventObj.HostingState = dicEvent["HostingState"].ToString();
                    }

                    if (dicEvent.Keys.Contains("HostingCountry"))
                    {
                        eventObj.HostingCountry = dicEvent["HostingCountry"].ToString();
                    }

                    if (dicEvent.Keys.Contains("HostingZipcode"))
                    {
                        eventObj.HostingZipcode = dicEvent["HostingZipcode"].ToString();
                    }

                    Events.Add(eventObj);
                }

                //Store Events List in Global Values
                GlobalValues.globalEventDetails = Events;
            }

            #endregion

            return IsValidUser;
        }
    }

    public class ServiceResponse
    {
        public int Code { get; set; }
        public string message { get; set; }
        public string error { get; set; }
        public string Message { get; set; }
        public string StatusMsg { get; set; }

    }
}
