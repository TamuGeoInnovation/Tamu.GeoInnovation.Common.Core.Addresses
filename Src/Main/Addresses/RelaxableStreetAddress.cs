using System;
using System.Collections.Generic;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.Addresses
{
    public class RelaxableStreetAddress : ValidateableStreetAddress, ICloneable
    {

        #region Properties
        public List<AddressComponents> RelaxedAttributes { get; set; }

        #endregion

        public RelaxableStreetAddress()
        {
            RelaxedAttributes = new List<AddressComponents>();
        }

        public RelaxableStreetAddress(string number, string pre, string name, string suffix, string post, string suite, string suiteNumber, string city, string state, string zip)
            : base(number, pre, name, suffix, post, suite, suiteNumber, city, state, zip)
        {
            RelaxedAttributes = new List<AddressComponents>();
        }

        public static new RelaxableStreetAddress FromStreetAddress(StreetAddress streetAddress)
        {
            RelaxableStreetAddress ret = new RelaxableStreetAddress();
            ret.Number = streetAddress.Number;
            ret.NumberFractional = streetAddress.NumberFractional;
            ret.PreDirectional = streetAddress.PreDirectional;
            ret.PreType = streetAddress.PreType;
            ret.PreQualifier = streetAddress.PreQualifier;
            ret.StreetName = streetAddress.StreetName;
            ret.Suffix = streetAddress.Suffix;
            ret.PostDirectional = streetAddress.PostDirectional;
            ret.PostQualifier = streetAddress.PostQualifier;
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

            ret.Id = streetAddress.Id;
            ret.Phone = streetAddress.Phone;
            ret.Name = streetAddress.Name;


            // set the full name
            if (!String.IsNullOrEmpty(streetAddress.FullName))
            {
                ret.FullName = streetAddress.FullName;
            }
            else if (!String.IsNullOrEmpty(streetAddress.NonParsedStreetAddress))
            {
                ret.FullName = streetAddress.NonParsedStreetAddress;
            }
            else if (streetAddress.NonParsedOriginalStreetAddress != null)
            {
                if (!String.IsNullOrEmpty(streetAddress.NonParsedOriginalStreetAddress.NonParsedStreetAddress))
                {
                    ret.FullName = streetAddress.NonParsedStreetAddress;
                }
                else if (!String.IsNullOrEmpty(streetAddress.NonParsedOriginalStreetAddress.FullName))
                {
                    ret.FullName = streetAddress.FullName;
                }
            }

            // set the non-parsed address
            if (!String.IsNullOrEmpty(streetAddress.NonParsedStreetAddress))
            {
                ret.NonParsedStreetAddress = streetAddress.NonParsedStreetAddress;
            }
            else if (streetAddress.NonParsedOriginalStreetAddress != null)
            {
                if (!String.IsNullOrEmpty(streetAddress.NonParsedOriginalStreetAddress.NonParsedStreetAddress))
                {
                    ret.NonParsedStreetAddress = streetAddress.NonParsedOriginalStreetAddress.NonParsedStreetAddress;
                }
            }

            ret.SoundexableAttributes = streetAddress.SoundexableAttributes;

            return ret;
        }

        public override string ToString()
        {
            string ret = "";
            ret += StringUtils.ValueAndBlankOrNoBlank(AddressId);
            ret += StringUtils.ValueAndBlankOrNoBlank(Number);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreDirectional);
            ret += StringUtils.ValueAndBlankOrNoBlank(StreetName);
            ret += StringUtils.ValueAndBlankOrNoBlank(Suffix);
            ret += StringUtils.ValueAndBlankOrNoBlank(PostDirectional);
            ret += StringUtils.ValueAndBlankOrNoBlank(City);
            ret += StringUtils.ValueAndBlankOrNoBlank(State);
            ret += StringUtils.ValueOrNoBlank(ZIP);
            return ret;
        }



    }
}