using System;
using USC.GISResearchLab.Common.Utils.Numbers;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.Addresses
{
    /// <summary>
    /// Summary description for Address.
    /// </summary>
    public class ValidateableStreetAddress : StreetAddress, ICloneable
    {
        #region Properties
        private int _FIPS;
        private bool _HasRequiredStreetParameters;
        private bool _IsLeft;
        private bool _IsRight;

        public int NumberInt
        {
            get
            {
                int ret = 0;
                if (NumberUtils.IsInt(Number))
                {
                    ret = StringUtils.ToInt(Number);
                }
                return ret;
            }
        }

        public int ZIPInt
        {
            get
            {
                int ret = 0;
                if (NumberUtils.IsInt(ZIP))
                {
                    ret = StringUtils.ToInt(ZIP);
                }
                return ret;
            }
        }

        public int FIPS
        {
            get { return _FIPS; }
            set { _FIPS = value; }
        }

        public bool HasRequiredStreetParameters
        {
            get { return _HasRequiredStreetParameters; }
            set { _HasRequiredStreetParameters = value; }
        }

        public bool HasValidNumber
        {
            get { return StringUtils.StringIsInt(Number); }
        }

        public bool HasName
        {
            get { return !StringUtils.IsEmpty(StreetName); }
        }

        public bool HasCity
        {
            get { return !StringUtils.IsEmpty(City); }
        }

        public bool HasState
        {
            get { return !StringUtils.IsEmpty(State); }
        }

        public bool HasCityState
        {
            get { return (HasCity && HasState); }
        }

        public bool HasZIP
        {
            get { return !StringUtils.IsEmpty(ZIP); }
        }

        public bool HasValidZIP
        {
            get { return (HasZIP && StringUtils.StringIsInt(ZIP) && ZIP.Length == 5); }
        }

        public int EvenOdd
        {
            get { return NumberInt % 2; }
        }

        public bool IsLeft
        {
            get { return _IsLeft; }
            set { _IsLeft = value; }
        }

        public bool IsRight
        {
            get { return _IsRight; }
            set { _IsRight = value; }
        }

        #endregion

        public ValidateableStreetAddress()
        {
        }

        public static ValidateableStreetAddress FromStreetAddress(StreetAddress streetAddress)
        {
            ValidateableStreetAddress ret = new ValidateableStreetAddress();
            ret.Number = streetAddress.Number;
            ret.NumberFractional = streetAddress.NumberFractional;
            ret.PreDirectional = streetAddress.PreDirectional;
            ret.StreetName = streetAddress.StreetName;
            ret.Suffix = streetAddress.Suffix;
            ret.PostDirectional = streetAddress.PostDirectional;
            ret.SuiteType = streetAddress.SuiteType;
            ret.SuiteNumber = streetAddress.SuiteNumber;
            ret.PostOfficeBoxNumber = streetAddress.PostOfficeBoxNumber;
            ret.PostOfficeBoxType = streetAddress.PostOfficeBoxType;
            ret.City = streetAddress.City;
            ret.State = streetAddress.State;
            ret.ZIP = streetAddress.ZIP;
            ret.ZIPPlus1 = streetAddress.ZIPPlus1;
            ret.ZIPPlus2 = streetAddress.ZIPPlus2;
            ret.ZIPPlus3 = streetAddress.ZIPPlus3;
            ret.ZIPPlus4 = streetAddress.ZIPPlus4;
            ret.ZIPPlus5 = streetAddress.ZIPPlus5;

            return ret;
        }

        public ValidateableStreetAddress(string number, string pre, string name, string suffix, string post, string suite,
                       string suiteNumber, string city, string state, string zip)
        {
            Number = number;
            PreDirectional = pre;
            StreetName = name;
            Suffix = suffix;
            PostDirectional = post;
            SuiteType = suite;
            SuiteNumber = suiteNumber;
            City = city;
            State = state;
            ZIP = zip;
        }

        #region ICloneable Members

        object ICloneable.Clone()
        {
            // simply delegate to our type-safe cousin
            return Clone();
        }

        #endregion

        public string ToConcatString(string streetNumber)
        {
            string number = StringUtils.ValueOrNoBlank(streetNumber, true);
            if (StringUtils.IsEmpty(number))
            {
                number = "0 ";
            }
            string pre = StringUtils.ValueOrNoBlank(PreDirectional, true);
            string name = StringUtils.ValueOrNoBlank(StreetName, true);
            string suffix = StringUtils.ValueOrNoBlank(Suffix, true);
            string post = StringUtils.ValueOrNoBlank(PostDirectional, true);

            string ret = number + pre + name + suffix + post;
            ret = ret.Trim();
            return ret;
        }

        public override string ToString()
        {
            string ret = "";
            ret += StringUtils.ValueAndBlankOrNoBlank(Number);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreDirectional);
            ret += StringUtils.ValueAndBlankOrNoBlank(StreetName);
            ret += StringUtils.ValueOrNoBlank(Suffix);
            ret += StringUtils.ValueAndBlankOrNoBlank(PostDirectional);
            ret = ret.Trim();
            if (!ret.Equals(""))
            {
                ret += ", ";
            }
            ret += StringUtils.ValueAndBlankOrNoBlank(City);
            ret += StringUtils.ValueAndBlankOrNoBlank(State);
            ret += StringUtils.ValueAndBlankOrNoBlank(ZIP);
            ret = ret.Trim();
            return ret;
        }

        public virtual new ValidateableStreetAddress Clone()
        {
            // Start with a flat, memberwise copy
            ValidateableStreetAddress x =
                MemberwiseClone() as ValidateableStreetAddress;

            // Then deep-copy everything that needs the 
            // special attention
            //x.somethingDeep = this.somethingDeep.Clone();

            //...

            return x;
        }

        public ValidateableStreetAddress CloneOtherSide()
        {
            ValidateableStreetAddress address2 = Clone();
            int nextNumber = NumberInt + 1;
            address2.Number = nextNumber.ToString();
            address2.IsLeft = !IsLeft;
            address2.IsRight = !IsRight;
            return address2;
        }
    }
}