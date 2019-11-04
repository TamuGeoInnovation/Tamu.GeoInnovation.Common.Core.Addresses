using System;
using System.Collections.Generic;
using USC.GISResearchLab.Common.Addresses.AbstractClasses;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.Addresses
{

    public enum AddressFormatType { USPSPublication28, USCensusTiger, LACounty }

    public class StreetAddress : AbstractStreetAddress
    {

        #region Static Objects

        public static double LatestVersion = 2.95;

        #endregion

        #region Properties


        #endregion

        #region Constructors
        public StreetAddress()
            : this(null, null, null, null, null, null, null, null, null, null, null)
        { }

        //public StreetAddress(string number, string pre, string name, string suffix, string post)
        //    : this(number, pre, name, suffix, post, null, null, null, null, null, null)
        //{ }

        public StreetAddress(string number, string preDirectional, string name, string suffix, string postDirectional, string city, string state, string zip)
            : this(number, preDirectional, name, suffix, postDirectional, null, null, city, state, zip, null)
        { }

        public StreetAddress(string number, string preDirectional, string name, string suffix, string postDirectional, string city, string state, string zip, string country)
            : this(number, preDirectional, name, suffix, postDirectional, null, null, city, state, zip, country)
        { }

        public StreetAddress(string number, string preDirectional, string name, string suffix, string postDirectional, string suite, string suiteNumber, string city, string state, string zip)
            : this(number, preDirectional, name, suffix, postDirectional, suite, suiteNumber, city, state, zip, null)
        { }

        public StreetAddress(string number, string preDirectional, string name, string suffix, string postDirectional, string suite, string suiteNumber, string city, string state, string zip, string country)
            : this(number, preDirectional, null, null, name, suffix, null, postDirectional, suite, suiteNumber, city, state, zip, null)
        { }

        public StreetAddress(string number, string preDirectional, string preQualifier, string preType, string name, string suffix, string postQualifier, string postDirectional, string suite, string suiteNumber, string city, string state, string zip, string country)
            : this(number, null, preDirectional, preQualifier, preType, null, name, suffix, null, postQualifier, postDirectional, suite, suiteNumber, city, state, zip, null)
        {
        }

        public StreetAddress(string number, string numberFractional, string preDirectional, string preQualifier, string preType, string preArticle, string name, string suffix, string postArticle, string postQualifier, string postDirectional, string suite, string suiteNumber, string city, string state, string zip, string country)
        {
            AddressId = "";
            Number = "";
            NumberFractional = "";
            PreDirectional = "";
            PreType = "";
            PreQualifier = "";
            PreArticle = "";
            StreetName = "";
            PostArticle = "";
            PostDirectional = "";
            PostQualifier = "";
            Suffix = "";
            SuiteType = "";
            SuiteNumber = "";
            City = "";
            State = "";
            ZIP = "";
            ZIPPlus1 = "";
            ZIPPlus2 = "";
            ZIPPlus3 = "";
            ZIPPlus4 = "";
            ZIPPlus5 = "";
            MinorCivilDivision = "";
            CountySubregion = "";
            County = "";
            Country = "";
            Source = "";
            PostOfficeBoxType = "";
            PostOfficeBoxNumber = "";
            RuralRouteType = "";
            RuralRouteNumber = "";
            RuralRouteBoxType = "";
            RuralRouteBoxNumber = "";
            SoundexableAttributes = new List<AddressComponents>();

            Number = (!String.IsNullOrEmpty(number)) ? number.Trim() : "";
            NumberFractional = (!String.IsNullOrEmpty(numberFractional)) ? numberFractional.Trim() : "";
            PreDirectional = (!String.IsNullOrEmpty(preDirectional)) ? preDirectional.Trim() : "";
            PreType = (!String.IsNullOrEmpty(preType)) ? preType.Trim() : "";
            PreQualifier = (!String.IsNullOrEmpty(preQualifier)) ? preQualifier.Trim() : "";
            PreArticle = (!String.IsNullOrEmpty(preArticle)) ? preArticle.Trim() : "";
            StreetName = (!String.IsNullOrEmpty(name)) ? name.Trim() : "";
            Suffix = (!String.IsNullOrEmpty(suffix)) ? suffix.Trim() : "";
            PostArticle = (!String.IsNullOrEmpty(postDirectional)) ? postDirectional.Trim() : "";
            PostDirectional = (!String.IsNullOrEmpty(postArticle)) ? postArticle.Trim() : "";
            PostQualifier = (!String.IsNullOrEmpty(postQualifier)) ? postQualifier.Trim() : "";
            SuiteType = (!String.IsNullOrEmpty(suite)) ? suite.Trim() : "";
            SuiteNumber = (!String.IsNullOrEmpty(suiteNumber)) ? suiteNumber.Trim() : "";
            City = (!String.IsNullOrEmpty(city)) ? city.Trim() : "";
            State = (!String.IsNullOrEmpty(state)) ? state.Trim() : "";
            ZIP = (!String.IsNullOrEmpty(zip)) ? zip.Trim() : "";
            Country = (!String.IsNullOrEmpty(country)) ? country.Trim() : "";
            IsParsed = true;
        }

        #endregion

        public string GetStreetAddressPortionAsString()
        {
            string ret = "";
            ret += StringUtils.ValueAndBlankOrNoBlank(Number);
            ret += StringUtils.ValueAndBlankOrNoBlank(NumberFractional);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreDirectional);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreQualifier);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreType);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreArticle);
            ret += StringUtils.ValueAndBlankOrNoBlank(StreetName);
            ret += StringUtils.ValueAndBlankOrNoBlank(PostArticle);
            ret += StringUtils.ValueAndBlankOrNoBlank(Suffix);
            ret += StringUtils.ValueAndBlankOrNoBlank(PostQualifier);
            ret += StringUtils.ValueAndBlankOrNoBlank(PostDirectional);
            ret += StringUtils.ValueAndBlankOrNoBlank(SuiteType);
            ret += StringUtils.ValueAndBlankOrNoBlank(SuiteNumber);

            return ret;
        }

        public override string ToString()
        {
            string ret = "";
            //ret += StringUtils.ValueAndBlankOrNoBlank(AddressId);
            ret += StringUtils.ValueAndBlankOrNoBlank(Number);
            ret += StringUtils.ValueAndBlankOrNoBlank(NumberFractional);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreDirectional);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreQualifier);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreType);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreArticle);
            ret += StringUtils.ValueAndBlankOrNoBlank(StreetName);
            ret += StringUtils.ValueAndBlankOrNoBlank(PostArticle);
            ret += StringUtils.ValueAndBlankOrNoBlank(Suffix);
            ret += StringUtils.ValueAndBlankOrNoBlank(PostQualifier);
            ret += StringUtils.ValueAndBlankOrNoBlank(PostDirectional);
            ret += StringUtils.ValueAndBlankOrNoBlank(City);

            if (!String.IsNullOrEmpty(ConsolidatedCity))
            {
                ret += StringUtils.ValueAndBlankOrNoBlank(ConsolidatedCity);
            }

            if (!String.IsNullOrEmpty(CountySubregion))
            {
                ret += StringUtils.ValueAndBlankOrNoBlank(CountySubregion);
            }

            if (!String.IsNullOrEmpty(County))
            {
                ret += StringUtils.ValueAndBlankOrNoBlank(County);
            }

            ret += StringUtils.ValueAndBlankOrNoBlank(State);
            ret += StringUtils.ValueOrNoBlank(ZIP);

            if (!String.IsNullOrEmpty(ZIPPlus4))
            {
                ret += "-" + StringUtils.ValueAndBlankOrNoBlank(ZIPPlus4);
            }
            else if (!String.IsNullOrEmpty(ZIPPlus3))
            {
                ret += "-" + StringUtils.ValueAndBlankOrNoBlank(ZIPPlus3);
            }
            else if (!String.IsNullOrEmpty(ZIPPlus2))
            {
                ret += "-" + StringUtils.ValueAndBlankOrNoBlank(ZIPPlus2);
            }
            else if (!String.IsNullOrEmpty(ZIPPlus1))
            {
                ret += "-" + StringUtils.ValueAndBlankOrNoBlank(ZIPPlus1);
            }

            ret += StringUtils.ValueOrNoBlank(Country);
            return ret;
        }

        public string AsStringVerbose(string separator)
        {
            return AsStringVerbose(separator, LatestVersion);
        }

        public string AsStringVerbose(string separator, double version)
        {
            string ret = null;
            if (version < 2.7)
            {
                ret = AsStringVerbose_Pre_V02_7(separator, version);
            }
            else
            {
                if (version >= 2.7 && version < 2.94)
                {
                    ret = AsStringVerbose_V02_7(separator, version);
                }
                else if (version >= 2.94)
                {
                    ret = AsStringVerbose_V02_94(separator, version);
                }
                else
                {
                    throw new Exception("Unsupported or unimplemented version number: " + version);
                }
            }
            return ret;
        }

        public string AsStringVerbose_Pre_V02_7(string separator, double version)
        {
            string ret = "";
            ret += Number + separator;
            ret += PreDirectional + separator;
            ret += StreetName + separator;
            ret += Suffix + separator;
            ret += PostDirectional + separator;
            ret += SuiteType + separator;
            ret += SuiteNumber + separator;
            ret += PostOfficeBoxType + separator;
            ret += PostOfficeBoxNumber + separator;
            ret += City + separator;
            ret += State + separator;
            ret += ZIP + separator;

            if (!String.IsNullOrEmpty(ZIPPlus4))
            {
                ret += ZIPPlus4 + separator;
            }
            else if (!String.IsNullOrEmpty(ZIPPlus3))
            {
                ret += ZIPPlus3 + separator;
            }
            else if (!String.IsNullOrEmpty(ZIPPlus2))
            {
                ret += ZIPPlus2 + separator;
            }
            else if (!String.IsNullOrEmpty(ZIPPlus1))
            {
                ret += ZIPPlus1 + separator;
            }

            return ret;
        }

        // added in 
        // Parsed attributes -- NumberFractional, ZipPlus1
        public string AsStringVerbose_V02_7(string separator, double version)
        {
            string ret = "";
            ret += Number + separator;
            ret += NumberFractional + separator;
            ret += PreDirectional + separator;
            ret += StreetName + separator;
            ret += Suffix + separator;
            ret += PostDirectional + separator;
            ret += SuiteType + separator;
            ret += SuiteNumber + separator;
            ret += PostOfficeBoxType + separator;
            ret += PostOfficeBoxNumber + separator;
            ret += City + separator;

            if (!String.IsNullOrEmpty(ConsolidatedCity))
            {
                ret += ConsolidatedCity + separator;
            }

            if (!String.IsNullOrEmpty(CountySubregion))
            {
                ret += CountySubregion + separator;
            }

            if (!String.IsNullOrEmpty(County))
            {
                ret += County + separator;
            }

            ret += State + separator;
            ret += ZIP + separator;

            if (!String.IsNullOrEmpty(ZIPPlus4))
            {
                ret += ZIPPlus4 + separator;
            }
            else if (!String.IsNullOrEmpty(ZIPPlus3))
            {
                ret += ZIPPlus3 + separator;
            }
            else if (!String.IsNullOrEmpty(ZIPPlus2))
            {
                ret += ZIPPlus2 + separator;
            }
            else if (!String.IsNullOrEmpty(ZIPPlus1))
            {
                ret += ZIPPlus1 + separator;
            }



            ret += ZIPPlus5;

            return ret;
        }


        // added in 
        // Parsed attributes -- PreType, PreQualifier, PreArticle, PostArticle, PostQualifier
        public string AsStringVerbose_V02_94(string separator, double version)
        {
            string ret = "";
            ret += Number + separator;
            ret += NumberFractional + separator;
            ret += PreDirectional + separator;
            ret += PreQualifier + separator;
            ret += PreType + separator;
            ret += PreArticle + separator;
            ret += StreetName + separator;
            ret += PostArticle + separator;
            ret += Suffix + separator;
            ret += PostQualifier + separator;
            ret += PostDirectional + separator;
            ret += SuiteType + separator;
            ret += SuiteNumber + separator;
            ret += PostOfficeBoxType + separator;
            ret += PostOfficeBoxNumber + separator;
            ret += City + separator;

            if (!String.IsNullOrEmpty(ConsolidatedCity))
            {
                ret += ConsolidatedCity + separator;
            }

            if (!String.IsNullOrEmpty(CountySubregion))
            {
                ret += CountySubregion + separator;
            }

            if (!String.IsNullOrEmpty(County))
            {
                ret += County + separator;
            }

            ret += State + separator;
            ret += ZIP + separator;
            ret += ZIPPlus4 + separator;
            ret += ZIPPlus3 + separator;
            ret += ZIPPlus2 + separator;
            ret += ZIPPlus1 + separator;
            ret += ZIPPlus5;

            return ret;
        }

        // added in 
        // Parsed attributes -- qualifiers
        public string ToCSV(string separator, double version)
        {
            string ret = "";
            ret += Number + separator;
            ret += NumberFractional + separator;
            ret += PreDirectional + separator;
            ret += PreQualifier + separator;
            ret += StreetName + separator;
            ret += PostQualifier + separator;
            ret += Suffix + separator;
            ret += PostDirectional + separator;
            ret += SuiteType + separator;
            ret += SuiteNumber + separator;
            ret += PostOfficeBoxType + separator;
            ret += PostOfficeBoxNumber + separator;
            ret += City + separator;
            ret += ConsolidatedCity + separator;
            ret += MinorCivilDivision + separator;
            ret += CountySubregion + separator;
            ret += County + separator;
            ret += State + separator;
            ret += ZIP + separator;
            ret += ZIPPlus4 + separator;


            return ret;
        }
    }
}