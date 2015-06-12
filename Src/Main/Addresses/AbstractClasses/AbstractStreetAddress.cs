using System;
using System.Collections.Generic;
using USC.GISResearchLab.Common.Core.Addresses.Interfaces;
using USC.GISResearchLab.Common.Utils.Strings;
using System.Text;

namespace USC.GISResearchLab.Common.Addresses.AbstractClasses
{


    public abstract class AbstractStreetAddress : AbstractStreetAddressBase, IStreetAddress, ICloneable
    {

        #region Properties

        public List<AddressComponents> SoundexableAttributes { get; set; }
        public bool IsParsed { get; set; }
        public bool HasPostOfficeBox { get; set; }
        public string PostOfficeBoxType { get; set; }
        public string PostOfficeBoxNumber { get; set; }
        public bool HasPostOfficeBoxNumber
        {
            get { return !String.IsNullOrEmpty(PostOfficeBoxNumber); }
        }

        public bool HasRuralRoute { get; set; }
        public string RuralRouteType { get; set; }
        public string RuralRouteNumber { get; set; }

        public bool HasRuralRouteNumber
        {
            get { return !String.IsNullOrEmpty(RuralRouteNumber); }
        }

        public string RuralRouteBoxType { get; set; }
        public string RuralRouteBoxNumber { get; set; }

        public bool HasRuralRouteBoxNumber
        {
            get { return !String.IsNullOrEmpty(RuralRouteBoxNumber); }
        }

        public bool HasRuralRouteBox { get; set; }
        public bool HasStarRoute { get; set; }
        public string StarRouteType { get; set; }
        public string StarRouteNumber { get; set; }
        public bool HasStarRouteNumber
        {
            get { return !String.IsNullOrEmpty(StarRouteNumber); }
        }

        public string StarRouteBoxType { get; set; }
        public string StarRouteBoxNumber { get; set; }
        public bool HasStarRouteBoxNumber
        {
            get { return !String.IsNullOrEmpty(StarRouteBoxNumber); }
        }

        public bool HasStarRouteBox { get; set; }
        public bool HasHighwayContractRoute { get; set; }
        public string HighwayContractRouteType { get; set; }
        public string HighwayContractRouteNumber { get; set; }

        public bool HasHighwayContractRouteNumber
        {
            get { return !String.IsNullOrEmpty(HighwayContractRouteNumber); }
        }

        public string HighwayContractRouteBoxType { get; set; }
        public string HighwayContractRouteBoxNumber { get; set; }
        public bool HasHighwayContractRouteBoxNumber
        {
            get { return !String.IsNullOrEmpty(HighwayContractRouteBoxNumber); }
        }

        public bool HasHighwayContractRouteBox { get; set; }


        public string AddressId { get; set; }



        public string Number { get; set; }
        public string NumberWithMultiRanges { get; set; }
        public string NumberFractional { get; set; }

        //public string NonParsedOriginalValue { get; set; }
        public string NonParsedStreetAddress { get; set; }

        private StreetAddress _NonParsedOriginalStreetAddress;
        public StreetAddress NonParsedOriginalStreetAddress
        {
            get
            {
                if (_NonParsedOriginalStreetAddress == null)
                {
                    _NonParsedOriginalStreetAddress = new StreetAddress();
                }
                return _NonParsedOriginalStreetAddress;
            }

            set
            {
                _NonParsedOriginalStreetAddress = value;
            }
        }

        public new AddressLocationTypes AddressLocationType
        {
            get
            {
                AddressLocationTypes ret = AddressLocationTypes.Unknown;

                if (HasAddress)
                {
                    ret = AddressLocationTypes.StreetAddress;
                }
                else if (HasPostOfficeBox)
                {
                    ret = AddressLocationTypes.PostOfficeBox;
                }
                else if (HasRuralRoute)
                {
                    ret = AddressLocationTypes.RuralRoute;
                }
                else if (HasStarRoute)
                {
                    ret = AddressLocationTypes.StarRoute;
                }
                else if (HasHighwayContractRoute)
                {
                    ret = AddressLocationTypes.HighwayContractRoute;
                }
                else if (HasZip)
                {
                    ret = AddressLocationTypes.USPSZIP;
                }
                else if (HasCity)
                {
                    ret = AddressLocationTypes.City;
                }
                else if (HasState)
                {
                    ret = AddressLocationTypes.State;
                }
                return ret;
            }

        }

        #endregion

        #region Constructors
        public AbstractStreetAddress()
        { }

        public AbstractStreetAddress(string number, string pre, string name, string post, string suffix)
            : this(number, pre, name, post, suffix, null, null, null, null, null, null)
        { }


        public AbstractStreetAddress(string number, string pre, string name, string post, string suffix, string suite, string suitenumber)
            : this(number, pre, name, post, suffix, suite, suitenumber, null, null, null, null)
        { }

        public AbstractStreetAddress(string number, string pre, string name, string suffix, string post, string city, string state, string zip)
            : this(number, pre, name, post, suffix, null, null, city, null, null, null)
        { }

        public AbstractStreetAddress(string number, string pre, string name, string suffix, string post, string city, string state, string zip, string country)
            : this(number, pre, name, post, suffix, null, null, city, state, zip, country)
        { }

        public AbstractStreetAddress(string number, string pre, string name, string suffix, string post, string suite, string suiteNumber, string city, string state, string zip)
            : this(number, pre, name, post, suffix, suite, suiteNumber, city, state, zip, null)
        { }

        public AbstractStreetAddress(string number, string pre, string name, string suffix, string post, string suite, string suiteNumber, string city, string state, string zip, string country)
            : base(pre, name, post, suffix, suite, suiteNumber, city, state, zip, country)
        {
            //NonParsedOriginalValue = "";
            AddressId = "";
            Number = "";
            NumberFractional = "";

            PostOfficeBoxType = "";
            PostOfficeBoxNumber = "";
            RuralRouteType = "";
            RuralRouteNumber = "";
            RuralRouteBoxType = "";
            RuralRouteBoxNumber = "";
            SoundexableAttributes = new List<AddressComponents>();

            Number = (!String.IsNullOrEmpty(number)) ? number.Trim() : "";
            IsParsed = true;
        }

        #endregion

        public string GetDeliveryLine()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(StringUtils.ValueAndBlankOrNoBlank(Number));
            sb.Append(StringUtils.ValueAndBlankOrNoBlank(NumberFractional));
            sb.Append(StringUtils.ValueAndBlankOrNoBlank(PreDirectional));
            sb.Append(StringUtils.ValueAndBlankOrNoBlank(PreQualifier));
            sb.Append(StringUtils.ValueAndBlankOrNoBlank(PreArticle));
            sb.Append(StringUtils.ValueAndBlankOrNoBlank(PreType));
            sb.Append(StringUtils.ValueAndBlankOrNoBlank(StreetName));
            sb.Append(StringUtils.ValueAndBlankOrNoBlank(PostArticle));
            sb.Append(StringUtils.ValueAndBlankOrNoBlank(Suffix));
            sb.Append(StringUtils.ValueAndBlankOrNoBlank(PostQualifier));
            sb.Append(StringUtils.ValueAndBlankOrNoBlank(PostDirectional));
            
            if (!String.IsNullOrEmpty(SuiteNumber) || !String.IsNullOrEmpty(SuiteType))
            {
                sb.Append(", ");
                sb.Append(StringUtils.ValueAndBlankOrNoBlank(SuiteNumber));
                sb.Append(StringUtils.ValueAndBlankOrNoBlank(SuiteType));
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            string ret = "";
            //ret += StringUtils.ValueAndBlankOrNoBlank(AddressId);
            ret += StringUtils.ValueAndBlankOrNoBlank(Number);
            ret += StringUtils.ValueAndBlankOrNoBlank(NumberFractional);
            ret += StringUtils.ValueAndBlankOrNoBlank(PreDirectional);
            ret += StringUtils.ValueAndBlankOrNoBlank(StreetName);
            ret += StringUtils.ValueAndBlankOrNoBlank(Suffix);
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

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return Clone();
        }

        public virtual StreetAddress Clone()
        {
            return (StreetAddress)MemberwiseClone();
        }

        #endregion

        public override bool Equals(Object obj)
        {
            //check if obj isn't null, if it is return false 
            if (obj == null)
            {
                return false;
            }

            StreetAddress s = obj as StreetAddress;

            //if obj can't be casted as StreetAddress, return false 
            if (s == null)
            {
                return false;
            }

            //compare the values 
            if (String.Compare(this.Number, s.Number, true) == 0 &&
                String.Compare(this.NumberFractional, s.NumberFractional, true) == 0 &&
                String.Compare(this.PreDirectional, s.PreDirectional, true) == 0 &&
                String.Compare(this.PreQualifier, s.PreQualifier, true) == 0 &&
                String.Compare(this.PreType, s.PreType, true) == 0 &&
                String.Compare(this.StreetName, s.StreetName, true) == 0 &&
                String.Compare(this.Suffix, s.Suffix, true) == 0 &&
                String.Compare(this.PostDirectional, s.PostDirectional, true) == 0 &&
                String.Compare(this.PostQualifier, s.PostQualifier, true) == 0 &&
                String.Compare(this.SuiteType, s.SuiteType, true) == 0 &&
                String.Compare(this.SuiteNumber, s.SuiteNumber, true) == 0 &&
                String.Compare(this.City, s.City, true) == 0 &&
                String.Compare(this.ConsolidatedCity, s.ConsolidatedCity, true) == 0 &&
                String.Compare(this.MinorCivilDivision, s.MinorCivilDivision, true) == 0 &&
                String.Compare(this.CountySubregion, s.CountySubregion, true) == 0 &&
                String.Compare(this.County, s.County, true) == 0 &&
                String.Compare(this.Country, s.Country, true) == 0 &&
                String.Compare(this.State, s.State, true) == 0 &&
                String.Compare(this.ZIP, s.ZIP, true) == 0 &&
                String.Compare(this.ZIPPlus4, s.ZIPPlus4, true) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        

        public override List<AddressComponents> Difference(StreetAddress b)
        {
            List<AddressComponents> ret = new List<AddressComponents>();

            if (String.Compare(this.Number, b.Number, true) != 0)
            {
                ret.Add(AddressComponents.Number);
            }

            if (String.Compare(this.NumberFractional, b.NumberFractional, true) != 0)
            {
                ret.Add(AddressComponents.NumberFractional);
            }

            if (String.Compare(this.PreDirectional, b.PreDirectional, true) != 0)
            {
                ret.Add(AddressComponents.PreDirectional);
            }

            if (String.Compare(this.PreQualifier, b.PreQualifier, true) != 0)
            {
                ret.Add(AddressComponents.PreQualifier);
            }

            if (String.Compare(this.PreType, b.PreType, true) != 0)
            {
                ret.Add(AddressComponents.PreType);
            }

            if (String.Compare(this.PreArticle, b.PreArticle, true) != 0)
            {
                ret.Add(AddressComponents.PreArticle);
            }

            if (String.Compare(this.StreetName, b.StreetName, true) != 0)
            {
                ret.Add(AddressComponents.StreetName);
            }

            if (String.Compare(this.Suffix, b.Suffix, true) != 0)
            {
                ret.Add(AddressComponents.Suffix);
            }

            if (String.Compare(this.PostDirectional, b.PostDirectional, true) != 0)
            {
                ret.Add(AddressComponents.PostDirectional);
            }

            if (String.Compare(this.PostQualifier, b.PostQualifier, true) != 0)
            {
                ret.Add(AddressComponents.PostQualifier);
            }

            if (String.Compare(this.PostArticle, b.PostArticle, true) != 0)
            {
                ret.Add(AddressComponents.PostArticle);
            }

            if (String.Compare(this.SuiteType, b.SuiteType, true) != 0)
            {
                ret.Add(AddressComponents.SuiteType);
            }

            if (String.Compare(this.SuiteNumber, b.SuiteNumber, true) != 0)
            {
                ret.Add(AddressComponents.SuiteNumber);
            }

            if (String.Compare(this.City, b.City, true) != 0)
            {
                ret.Add(AddressComponents.City);
            }

            if (String.Compare(this.Country, b.Country, true) != 0)
            {
                ret.Add(AddressComponents.Country);
            }

            if (String.Compare(this.State, b.State, true) != 0)
            {
                ret.Add(AddressComponents.State);
            }

            if (String.Compare(this.ZIP, b.ZIP, true) != 0)
            {
                ret.Add(AddressComponents.Zip);
            }

            if (String.Compare(this.ZIPPlus4, b.ZIPPlus4, true) != 0)
            {
                ret.Add(AddressComponents.ZipPlus4);
            }

            return ret;
        }

        public override bool HasStreetAddressComponent(AddressComponents component)
        {
            bool ret = false;

            switch (component)
            {
                case AddressComponents.City:
                    if (!String.IsNullOrEmpty(City))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.Country:
                    if (!String.IsNullOrEmpty(Country))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.StreetName:
                    if (!String.IsNullOrEmpty(StreetName))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.Number:
                    if (!String.IsNullOrEmpty(Number))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.NumberFractional:
                    if (!String.IsNullOrEmpty(NumberFractional))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.PostArticle:
                    if (!String.IsNullOrEmpty(PostArticle))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.PostDirectional:
                    if (!String.IsNullOrEmpty(PostDirectional))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.PostQualifier:
                    if (!String.IsNullOrEmpty(PostQualifier))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.PreArticle:
                    if (!String.IsNullOrEmpty(PreArticle))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.PreDirectional:
                    if (!String.IsNullOrEmpty(PreDirectional))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.PreQualifier:
                    if (!String.IsNullOrEmpty(PreQualifier))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.PreType:
                    if (!String.IsNullOrEmpty(PreType))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.State:
                    if (!String.IsNullOrEmpty(State))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.Suffix:
                    if (!String.IsNullOrEmpty(Suffix))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.SuiteNumber:
                    if (!String.IsNullOrEmpty(SuiteNumber))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.SuiteType:
                    if (!String.IsNullOrEmpty(SuiteType))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.Zip:
                    if (!String.IsNullOrEmpty(ZIP))
                    {
                        ret = true;
                    }
                    break;
                case AddressComponents.ZipPlus4:
                    if (!String.IsNullOrEmpty(ZIPPlus4))
                    {
                        ret = true;
                    }
                    break;

                default:
                    throw new Exception("Unexpected or unimplemented AddressComponents: " + component);
            }

            return ret;
        }

        public override string GetStreetAddressComponent(AddressComponents component)
        {
            string ret = "";

            switch (component)
            {
                case AddressComponents.City:
                    ret = City;
                    break;
                case AddressComponents.Country:
                    ret = Country;
                    break;
                case AddressComponents.StreetName:
                    ret = StreetName;
                    break;
                case AddressComponents.Number:
                    ret = Number;
                    break;
                case AddressComponents.NumberFractional:
                    ret = NumberFractional;
                    break;
                case AddressComponents.PostArticle:
                    ret = PostArticle;
                    break;
                case AddressComponents.PostDirectional:
                    ret = PostDirectional;
                    break;
                case AddressComponents.PostQualifier:
                    ret = PostQualifier;
                    break;
                case AddressComponents.PreArticle:
                    ret = PreArticle;
                    break;
                case AddressComponents.PreDirectional:
                    ret = PreDirectional;
                    break;
                case AddressComponents.PreQualifier:
                    ret = PreQualifier;
                    break;
                case AddressComponents.PreType:
                    ret = PreType;
                    break;
                case AddressComponents.State:
                    ret = State;
                    break;
                case AddressComponents.Suffix:
                    ret = Suffix;
                    break;
                case AddressComponents.SuiteNumber:
                    ret = SuiteNumber;
                    break;
                case AddressComponents.SuiteType:
                    ret = SuiteType;
                    break;
                case AddressComponents.Zip:
                    ret = ZIP;
                    break;
                case AddressComponents.ZipPlus4:
                    ret = ZIPPlus4;
                    break;

                default:
                    throw new Exception("Unexpected or unimplemented AddressComponents: " + component);
            }

            return ret;
        }
    }
}