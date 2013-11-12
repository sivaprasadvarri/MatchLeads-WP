using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MatchLeads.Model
{
    class DbHelper
    {
        private const string StaticdbConnectionString = "Data Source='appdata:/BLDb.sdf';File Mode=read only";

        internal static System.Collections.Generic.List<BlCountry> getCountryList()
        {
            List<BlCountry> countryList = new List<BlCountry>();

            using (StaticDbDataContext staticDataContext = new StaticDbDataContext(StaticdbConnectionString))
            {
                if (staticDataContext.DatabaseExists())
                {
                    IQueryable<BlCountry> queryData = from data in staticDataContext.CountryTable select data;
                    countryList = queryData.ToList();
                }
            }

            return countryList;
        }

        internal static List<BLStates> getStatesList(string strSelectCountry)
        {
            List<BLStates> stateList = new List<BLStates>();
            try
            {
                using (StaticDbDataContext staticDataContext = new StaticDbDataContext(StaticdbConnectionString))
                {
                    if (staticDataContext.DatabaseExists())
                    {
                        IQueryable<BlCountry> selectedCountryInfo = from data in staticDataContext.CountryTable where data.Name.ToLower() == strSelectCountry.ToLower() select data;

                        long countryID = -1;
                        var enumerator = selectedCountryInfo.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            var currnetElement = enumerator.Current;
                            countryID = currnetElement.Id;
                        }

                        if (countryID != -1)
                        {
                            IQueryable<BLStates> queryData = from data in staticDataContext.StateTable where data.CountryId == countryID select data;
                            stateList = queryData.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error occured on getStatesList() : " + ex.Message);
            }

            return stateList;
        }
        internal static List<BLStates> getStatesList(long countryID)
        {
            List<BLStates> stateList = new List<BLStates>();
            try
            {
                using (StaticDbDataContext staticDataContext = new StaticDbDataContext(StaticdbConnectionString))
                {
                    if (staticDataContext.DatabaseExists())
                    {
                        IQueryable<BLStates> queryData = from data in staticDataContext.StateTable where data.CountryId == countryID select data;
                        stateList = queryData.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error occured on getStatesList() : " + ex.Message);
            }

            return stateList;
        }

        internal static System.Collections.Generic.List<BLStates> getStatesList()
        {
            List<BLStates> stateList = new List<BLStates>();
            try
            {
                using (StaticDbDataContext staticDataContext = new StaticDbDataContext(StaticdbConnectionString))
                {
                    if (staticDataContext.DatabaseExists())
                    {
                        IQueryable<BLStates> queryData = from data in staticDataContext.StateTable select data;
                        stateList = queryData.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error occured on getStatesList() : " + ex.Message);
            }


            return stateList;
        }

    }
}
