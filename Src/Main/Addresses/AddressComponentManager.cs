using System;

namespace USC.GISResearchLab.Common.Addresses
{
    //public enum AddressComponents { Unknown, Number, Predirectional, Name, Suffix, Postdirectional, SuiteNumber, SuiteType, StreetAddress, Zip, City, State, Country, SoundexName };
    public enum CertainyLevel { Unknown, Street, Zip, City, State, Country };

    [Flags]
    public enum AddressComponents
    {
        Unknown = 2,
        Number = 4,
        NumberFractional = 8,
        PreDirectional = 16,
        PreQualifier = 32,
        PreType = 524288,
        PreArticle = 1048576,
        StreetName = 64,
        SoundexName = 128,
        PostArticle = 2097152,
        PostQualifier = 256,
        Suffix = 512,
        PostDirectional = 1024,
        SuiteType = 2048,
        SuiteNumber = 4096,
        City = 8192,
        State = 16384,
        Zip = 32768,
        ZipPlus4 = 65536,
        Country = 131072,
        All = 262144,
    }

    public enum PlaceTypes
    {
        unknown,
        zip,
        place,
        consolidatedCity,
        subMcd,
        countySub,
        county,
        country,
    };

    public enum StreetNumberRangeOrderType
    {
        Unknown,
        HiLow,
        LowHi,
        SingleNumber,
    };

    public enum StreetNumberRangeType
    {
        Unknown,
        Numeric,
        AlphaNumeric,
        Alpha,
        None,
    };

    public enum StreetNumberRangeNumericSubType
    {
        Unknown,
        Normal,
        Dashed,
        AlphaNumeric,
        None,
    };

    public enum StreetNumberRangeParity
    {
        Unknown,
        Even,
        Odd,
        Both,
        None
    };

    public enum StreetSide
    {
        Unknown,
        Left,
        Right,
        Both,
        None
    };

    public class AddressComponentManager
    {
        public const string ATTRIBUTE_NAME_STREETADDRESS = "streetaddress";
        public const string ATTRIBUTE_NAME_NUMBER = "number";
        public const string ATTRIBUTE_NAME_PREDIRECTIONAL = "predirectional";
        public const string ATTRIBUTE_NAME_NAME = "name";
        public const string ATTRIBUTE_NAME_SOUNDEXNAME = "soundexname";
        public const string ATTRIBUTE_NAME_SUFFIX = "suffix";
        public const string ATTRIBUTE_NAME_POSTDIRECTIONAL = "postdirectional";
        public const string ATTRIBUTE_NAME_SUITETYPE = "suitetype";
        public const string ATTRIBUTE_NAME_SUITENUMBER = "suitenumber";
        public const string ATTRIBUTE_NAME_CITY = "city";
        public const string ATTRIBUTE_NAME_STATE = "state";
        public const string ATTRIBUTE_NAME_COUNTRY = "country";
        public const string ATTRIBUTE_NAME_ZIP = "zip";
        public const string ATTRIBUTE_NAME_UNKNOWN = "unknown";

        public static AddressComponents GetAddressComponentByName(string name)
        {
            AddressComponents ret = AddressComponents.Unknown;

            if (!String.IsNullOrEmpty(name))
            {
                name = name.Trim();

                if (String.Compare(name, "number", true) == 0 || String.Compare(name, AddressComponents.Number.ToString(), true) == 0)
                {
                    ret = AddressComponents.Number;
                }
                else if (String.Compare(name, "pre", true) == 0 || String.Compare(name, AddressComponents.PreDirectional.ToString(), true) == 0)
                {
                    ret = AddressComponents.PreDirectional;
                }
                else if (String.Compare(name, "prequalifier", true) == 0 || String.Compare(name, AddressComponents.PreQualifier.ToString(), true) == 0)
                {
                    ret = AddressComponents.PreQualifier;
                }
                else if (String.Compare(name, "name", true) == 0 || String.Compare(name, AddressComponents.StreetName.ToString(), true) == 0)
                {
                    ret = AddressComponents.StreetName;
                }
                else if (String.Compare(name, "suffix", true) == 0 || String.Compare(name, AddressComponents.Suffix.ToString(), true) == 0)
                {
                    ret = AddressComponents.Suffix;
                }
                else if (String.Compare(name, "post", true) == 0 || String.Compare(name, AddressComponents.PostDirectional.ToString(), true) == 0)
                {
                    ret = AddressComponents.PostDirectional;
                }
                else if (String.Compare(name, "postqualifier", true) == 0 || String.Compare(name, AddressComponents.PostQualifier.ToString(), true) == 0)
                {
                    ret = AddressComponents.PostQualifier;
                }
                else if (String.Compare(name, "suitetype", true) == 0 || String.Compare(name, AddressComponents.SuiteType.ToString(), true) == 0)
                {
                    ret = AddressComponents.SuiteType;
                }
                else if (String.Compare(name, "suitenumber", true) == 0 || String.Compare(name, AddressComponents.SuiteNumber.ToString(), true) == 0)
                {
                    ret = AddressComponents.SuiteNumber;
                }
                else if (String.Compare(name, "city", true) == 0 || String.Compare(name, AddressComponents.City.ToString(), true) == 0)
                {
                    ret = AddressComponents.City;
                }
                else if (String.Compare(name, "state", true) == 0 || String.Compare(name, AddressComponents.State.ToString(), true) == 0)
                {
                    ret = AddressComponents.State;
                }
                else if (String.Compare(name, "zip", true) == 0 || String.Compare(name, AddressComponents.Zip.ToString(), true) == 0)
                {
                    ret = AddressComponents.Zip;
                }
            }

            return ret;
        }

        public static string GetAddressComponentName(AddressComponents addressComponent)
        {
            string ret = "";

            switch (addressComponent)
            {
                case AddressComponents.City:
                    ret = ATTRIBUTE_NAME_CITY;
                    break;
                case AddressComponents.Country:
                    ret = ATTRIBUTE_NAME_COUNTRY;
                    break;
                case AddressComponents.StreetName:
                    ret = ATTRIBUTE_NAME_NAME;
                    break;
                case AddressComponents.Number:
                    ret = ATTRIBUTE_NAME_NUMBER;
                    break;
                case AddressComponents.PostDirectional:
                    ret = ATTRIBUTE_NAME_POSTDIRECTIONAL;
                    break;
                case AddressComponents.PreDirectional:
                    ret = ATTRIBUTE_NAME_PREDIRECTIONAL;
                    break;
                case AddressComponents.SoundexName:
                    ret = ATTRIBUTE_NAME_SOUNDEXNAME;
                    break;
                case AddressComponents.State:
                    ret = ATTRIBUTE_NAME_STATE;
                    break;
                case AddressComponents.Suffix:
                    ret = ATTRIBUTE_NAME_SUFFIX;
                    break;
                case AddressComponents.SuiteNumber:
                    ret = ATTRIBUTE_NAME_SUITENUMBER;
                    break;
                case AddressComponents.SuiteType:
                    ret = ATTRIBUTE_NAME_SUITETYPE;
                    break;
                case AddressComponents.Unknown:
                    ret = ATTRIBUTE_NAME_UNKNOWN;
                    break;
                case AddressComponents.Zip:
                    ret = ATTRIBUTE_NAME_ZIP;
                    break;
                default:
                    throw new Exception("Unexpected AddressComponents:" + addressComponent);
            }


            return ret;
        }
    }
}
