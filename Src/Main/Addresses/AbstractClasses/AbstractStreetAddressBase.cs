using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using USC.GISResearchLab.Common.Core.Addresses.Interfaces;
using USC.GISResearchLab.Common.Utils.Numbers;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Common.Addresses.AbstractClasses
{

    public enum AddressLocationTypes
    {
        Unknown,
        StreetAddress,
        PostOfficeBox,
        RuralRoute,
        StarRoute,
        HighwayContractRoute,
        Intersection,
        NamedPlace,
        RelativeDirection,
        USPSZIP,
        City,
        State,
        Unmatchable
    }

    public enum ZIPCodeType
    {
        Unknown,
        Residential,
        POBox
    }

    public abstract class AbstractStreetAddressBase : IStreetAddressBase, ICloneable
    {

        #region Properties

        [JsonConverter(typeof(StringEnumConverter))]
        public AddressFormatType AddressFormatType { get; set; }

        [JsonIgnore]
        public double Version { get; set; }
        [JsonIgnore]
        public bool Valid { get; set; }
        [JsonIgnore]
        public string Error { get; set; }
        [JsonIgnore]
        public bool ExceptionOccurred { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public Exception Exception { get; set; }



        [JsonIgnore]
        public StreetSide StreetSide { get; set; }
        [JsonIgnore]
        public StreetNumberRangeParity StreetNumberRangeParity { get; set; }

        [JsonIgnore]
        public string TransactionId { get; set; }
        [JsonIgnore]
        public TimeSpan TimeTaken { get; set; }
        [JsonIgnore]
        public int NumTracts2000 { get; set; }
        [JsonIgnore]
        public int NumTracts2010 { get; set; }



        [JsonIgnore]
        public string Id { get; set; }
        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public string Phone { get; set; }

        [JsonIgnore]
        public string FullName { get; set; }

        public string Number { get; set; }
        public string NumberFractional { get; set; }
        public string PreDirectional { get; set; }
        public string PreQualifier { get; set; }
        public string PreType { get; set; }
        public string PreArticle { get; set; }
        public string StreetName { get; set; }
        public string PostArticle { get; set; }
        public string PostQualifier { get; set; }
        public string PostDirectional { get; set; }
        public string Suffix { get; set; }
        public string SuiteType { get; set; }
        public string SuiteNumber { get; set; }

        [JsonIgnore]
        public string CityAlternate { get; set; }

        public string City { get; set; }
        [JsonIgnore]
        public string CityCode { get; set; }
        public string MinorCivilDivision { get; set; }
        [JsonIgnore]
        public string MinorCivilDivisionCode { get; set; }
        public string ConsolidatedCity { get; set; }
        [JsonIgnore]
        public string ConsolidatedCityCode { get; set; }
        public string CountySubregion { get; set; }
        [JsonIgnore]
        public string CountySubregionCode { get; set; }
        public string County { get; set; }

        public string State { get; set; }
        [JsonIgnore]
        public string StateCode { get; set; }



        [JsonIgnore]
        public string MetropolitanDivisionCode { get; set; }
        [JsonIgnore]
        public string MajorStatisticalAreaCode { get; set; }
        [JsonIgnore]
        public string CentralBusinessStatisticalAreaCode { get; set; }
        [JsonIgnore]
        public string CentralBusinessStatisticalMicroAreaCode { get; set; }
        [JsonIgnore]
        public string OtherInformation { get; set; }

        public string ZIP { get; set; }
        public string ZIPPlus1 { get; set; }
        public string ZIPPlus2 { get; set; }
        public string ZIPPlus3 { get; set; }
        public string ZIPPlus4 { get; set; }
        public string ZIPPlus5 { get; set; }

        [JsonIgnore]
        public string CountyCode { get; set; }
        public string Country { get; set; }
        [JsonIgnore]
        public string CountryCode { get; set; }

        [JsonIgnore]
        public ZIPCodeType ZIPCodeType { get; set; }
        [JsonIgnore]
        public string ZIPAlternate { get; set; }
        [JsonIgnore]
        public string ZIPPlus1Alternate { get; set; }
        [JsonIgnore]
        public string ZIPPlus2Alternate { get; set; }
        [JsonIgnore]
        public string ZIPPlus3Alternate { get; set; }
        [JsonIgnore]
        public string ZIPPlus4Alternate { get; set; }
        [JsonIgnore]
        public string ZIPPlus5Alternate { get; set; }


        [JsonIgnore]
        public string AliasFullName { get; set; }
        [JsonIgnore]
        public string AliasPreDirectional { get; set; }
        [JsonIgnore]
        public string AliasPreType { get; set; }
        [JsonIgnore]
        public string AliasName { get; set; }
        [JsonIgnore]
        public string AliasPreArticle { get; set; }
        [JsonIgnore]
        public string AliasPostArticle { get; set; }
        [JsonIgnore]
        public string AliasPreQualifier { get; set; }
        [JsonIgnore]
        public string AliasPostQualifier { get; set; }
        [JsonIgnore]
        public string AliasPostDirectional { get; set; }
        [JsonIgnore]
        public string AliasSuffix { get; set; }
        [JsonIgnore]
        public string AliasSuiteType { get; set; }
        [JsonIgnore]
        public string AliasSuiteNumber { get; set; }
        //[JsonIgnore]
        //public string CensusYear { get; set; }
        //[JsonIgnore]
        //public string CensusTract { get; set; }
        //[JsonIgnore]
        //public string CensusBlock { get; set; }
        //[JsonIgnore]
        //public string CensusBlockGroup { get; set; }
        //[JsonIgnore]
        //public string CensusNAACCRCertCode { get; set; }
        //[JsonIgnore]
        //public string CensusNAACCRCertType { get; set; }
        //[JsonIgnore]
        //public string CensusCountyFips { get; set; }
        //[JsonIgnore]
        //public string CensusPlaceFips { get; set; }
        //[JsonIgnore]
        //public string CensusMSAFips { get; set; }
        //[JsonIgnore]
        //public string CensusMCDFips { get; set; }
        //[JsonIgnore]
        //public string CensusCBSAFips { get; set; }
        //[JsonIgnore]
        //public string CensusCBSAMicro { get; set; }
        //[JsonIgnore]
        //public string CensusMetDivFips { get; set; }
        //[JsonIgnore]
        //public string CensusStateFips { get; set; }

        private bool _NameIsNumberComputed;
        [JsonIgnore]
        public bool NameIsNumberComputed
        {
            get
            {
                return _NameIsNumberComputed;
            }
            set
            {
                _NameIsNumberComputed = value;
            }
        }

        private bool _NameIsNumber;
        [JsonIgnore]
        public bool NameIsNumber
        {
            get
            {
                if (!_NameIsNumberComputed)
                {
                    if (!String.IsNullOrEmpty(StreetName))
                    {
                        _NameIsNumber = NumberUtils.IsInt(StreetName);
                    }

                    _NameIsNumberComputed = true;
                }

                return _NameIsNumber;
            }
        }

        private bool _NameIsNumericAbbreviationComputed;
        [JsonIgnore]
        public bool NameIsNumericAbbreviationComputed
        {
            get
            {
                return _NameIsNumericAbbreviationComputed;
            }
            set
            {
                _NameIsNumericAbbreviationComputed = value;
            }
        }

        private bool _NameIsNumericAbbreviation;
        [JsonIgnore]
        public bool NameIsNumericAbbreviation
        {
            get
            {
                if (!NameIsNumericAbbreviationComputed)
                {
                    if (!String.IsNullOrEmpty(StreetName))
                    {
                        _NameIsNumericAbbreviation = NumberUtils.IsNumericAbbreviation(StreetName);
                    }

                    NameIsNumericAbbreviationComputed = true;
                }

                return _NameIsNumericAbbreviation;
            }
        }

        [JsonIgnore]
        public bool NameIsNumberWordsComputed { get; set; }

        private bool _NameIsNumberWords;
        [JsonIgnore]
        public bool NameIsNumberWords
        {
            get
            {
                if (!NameIsNumberWordsComputed)
                {
                    if (!String.IsNullOrEmpty(StreetName))
                    {
                        _NameIsNumberWords = NumberUtils.IsNumberWords(StreetName);
                    }
                    NameIsNumberWordsComputed = true;
                }

                return _NameIsNumberWords;
            }
        }

        [JsonIgnore]
        public string Source { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AddressLocationTypes AddressLocationType
        {
            get
            {
                AddressLocationTypes ret = AddressLocationTypes.Unknown;

                if (HasAddress)
                {
                    ret = AddressLocationTypes.StreetAddress;
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

        [JsonIgnore]
        public bool HasCity
        {
            get
            {
                return !String.IsNullOrEmpty(City);
            }
        }

        [JsonIgnore]
        public bool HasZip
        {
            get
            {
                return !String.IsNullOrEmpty(ZIP);
            }
        }

        [JsonIgnore]
        public bool HasZipPlus4
        {
            get
            {
                return !String.IsNullOrEmpty(ZIPPlus4);
            }
        }

        [JsonIgnore]
        public bool HasState
        {
            get
            {
                return !String.IsNullOrEmpty(State);
            }
        }

        [JsonIgnore]
        public bool HasAddress
        {
            get
            {
                return !String.IsNullOrEmpty(StreetName);
            }
        }

        #endregion

        #region Constructors
        public AbstractStreetAddressBase()
        { }

        public AbstractStreetAddressBase(string pre, string name, string post, string suffix)
            : this(pre, name, post, suffix, null, null, null, null, null, null)
        { }


        public AbstractStreetAddressBase(string pre, string name, string post, string suffix, string suite, string suitenumber)
            : this(pre, name, post, suffix, suite, suitenumber, null, null, null, null)
        { }

        public AbstractStreetAddressBase(string pre, string name, string suffix, string post, string city, string state, string zip)
            : this(pre, name, post, suffix, null, null, city, null, null, null)
        { }

        public AbstractStreetAddressBase(string pre, string name, string suffix, string post, string city, string state, string zip, string country)
            : this(pre, name, post, suffix, null, null, city, state, zip, country)
        { }

        public AbstractStreetAddressBase(string pre, string name, string suffix, string post, string suite, string suiteNumber, string city, string state, string zip)
            : this(pre, name, post, suffix, suite, suiteNumber, city, state, zip, null)
        { }

        public AbstractStreetAddressBase(string pre, string name, string suffix, string post, string suite, string suiteNumber, string city, string state, string zip, string country)
        {
            //PreDirectional = "";
            //PreQualifier = "";
            //PreArticle = "";
            //StreetName = "";
            //PostDirectional = "";
            //PostQualifier = "";
            //PostArticle = "";
            //Suffix = "";
            //SuiteType = "";
            //SuiteNumber = "";
            //City = "";
            //State = "";
            //ZIP = "";
            //ZIPPlus1 = "";
            //ZIPPlus2 = "";
            //ZIPPlus3 = "";
            //ZIPPlus4 = "";
            //ZIPPlus5 = "";
            //MinorCivilDivision = "";
            //CountySubregion = "";
            //County = "";
            //Country = "";
            //Source = "";

            PreDirectional = (!String.IsNullOrEmpty(pre)) ? pre.Trim() : null;
            StreetName = (!String.IsNullOrEmpty(name)) ? name.Trim() : null;
            Suffix = (!String.IsNullOrEmpty(suffix)) ? suffix.Trim() : null;
            PostDirectional = (!String.IsNullOrEmpty(post)) ? post.Trim() : null;
            SuiteType = (!String.IsNullOrEmpty(suite)) ? suite.Trim() : null;
            SuiteNumber = (!String.IsNullOrEmpty(suiteNumber)) ? suiteNumber.Trim() : null;
            City = (!String.IsNullOrEmpty(city)) ? city.Trim() : null;
            State = (!String.IsNullOrEmpty(state)) ? state.Trim() : null;
            ZIP = (!String.IsNullOrEmpty(zip)) ? zip.Trim() : null;
            Country = (!String.IsNullOrEmpty(country)) ? country.Trim() : null;

            //AliasFullName = "";
            //AliasPreDirectional = "";
            //AliasPreType = "";
            //AliasName = "";
            //AliasPreArticle = "";
            //AliasPostArticle = "";
            //AliasPreQualifier = "";
            //AliasPostQualifier = "";
            //AliasPostDirectional = "";
            //AliasSuffix = "";
            //AliasSuiteType = "";
            //AliasSuiteNumber = "";
        }

        #endregion




        public virtual List<AddressComponents> Difference(StreetAddress b)
        {
            List<AddressComponents> ret = new List<AddressComponents>();

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

        public virtual bool HasStreetAddressComponent(AddressComponents component)
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

        public virtual string GetStreetAddressComponent(AddressComponents component)
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

        public override string ToString()
        {
            string ret = "";
            //ret += StringUtils.ValueAndBlankOrNoBlank(AddressId);
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
            StreetAddress ret = new StreetAddress();
            ret.AddressId = ((StreetAddress)this).AddressId;
            ret.City = ((StreetAddress)this).City;
            ret.CityAlternate = ((StreetAddress)this).CityAlternate;
            ret.CityCode = ((StreetAddress)this).CityCode;
            ret.ConsolidatedCity = ((StreetAddress)this).ConsolidatedCity;
            ret.ConsolidatedCityCode = ((StreetAddress)this).ConsolidatedCityCode;
            ret.Country = ((StreetAddress)this).Country;
            ret.CountryCode = ((StreetAddress)this).CountryCode;
            ret.County = ((StreetAddress)this).County;
            ret.CountyCode = ((StreetAddress)this).CountyCode;
            ret.CountySubregion = ((StreetAddress)this).CountySubregion;
            ret.CountySubregionCode = ((StreetAddress)this).CountySubregionCode;
            ret.FullName = ((StreetAddress)this).FullName;
            ret.HasHighwayContractRoute = ((StreetAddress)this).HasHighwayContractRoute;
            ret.HasHighwayContractRouteBox = ((StreetAddress)this).HasHighwayContractRouteBox;
            ret.HasPostOfficeBox = ((StreetAddress)this).HasPostOfficeBox;
            ret.HasRuralRoute = ((StreetAddress)this).HasRuralRoute;
            ret.HasRuralRouteBox = ((StreetAddress)this).HasRuralRouteBox;
            ret.HasStarRoute = ((StreetAddress)this).HasStarRoute;
            ret.HasStarRouteBox = ((StreetAddress)this).HasStarRouteBox;
            ret.HighwayContractRouteBoxNumber = ((StreetAddress)this).HighwayContractRouteBoxNumber;
            ret.HighwayContractRouteBoxType = ((StreetAddress)this).HighwayContractRouteBoxType;
            ret.HighwayContractRouteNumber = ((StreetAddress)this).HighwayContractRouteNumber;
            ret.HighwayContractRouteType = ((StreetAddress)this).HighwayContractRouteType;
            ret.IsParsed = ((StreetAddress)this).IsParsed;
            ret.MinorCivilDivision = ((StreetAddress)this).MinorCivilDivision;
            ret.MinorCivilDivisionCode = ((StreetAddress)this).MinorCivilDivisionCode;
            ret.StreetName = ((StreetAddress)this).StreetName;
            ret.NameIsNumberWordsComputed = ((StreetAddress)this).NameIsNumberWordsComputed;
            ret.NameIsNumericAbbreviationComputed = ((StreetAddress)this).NameIsNumericAbbreviationComputed;
            //ret.NonParsedOriginalValue = ((StreetAddress)this).NonParsedOriginalValue;
            ret.Number = ((StreetAddress)this).Number;
            ret.NumberFractional = ((StreetAddress)this).NumberFractional;
            ret.PostDirectional = ((StreetAddress)this).PostDirectional;
            ret.PostOfficeBoxNumber = ((StreetAddress)this).PostOfficeBoxNumber;
            ret.PostOfficeBoxType = ((StreetAddress)this).PostOfficeBoxType;
            ret.PostQualifier = ((StreetAddress)this).PostQualifier;
            ret.PreDirectional = ((StreetAddress)this).PreDirectional;
            ret.PreQualifier = ((StreetAddress)this).PreQualifier;
            ret.PreType = ((StreetAddress)this).PreType;
            ret.RuralRouteBoxNumber = ((StreetAddress)this).RuralRouteBoxNumber;
            ret.RuralRouteBoxType = ((StreetAddress)this).RuralRouteBoxType;
            ret.RuralRouteNumber = ((StreetAddress)this).RuralRouteNumber;
            ret.RuralRouteType = ((StreetAddress)this).RuralRouteType;
            ret.SoundexableAttributes = ((StreetAddress)this).SoundexableAttributes;
            ret.Source = ((StreetAddress)this).Source;
            ret.StarRouteBoxNumber = ((StreetAddress)this).StarRouteBoxNumber;
            ret.StarRouteBoxType = ((StreetAddress)this).StarRouteBoxType;
            ret.StarRouteNumber = ((StreetAddress)this).StarRouteNumber;
            ret.StarRouteType = ((StreetAddress)this).StarRouteType;
            ret.State = ((StreetAddress)this).State;
            ret.StateCode = ((StreetAddress)this).StateCode;
            ret.Suffix = ((StreetAddress)this).Suffix;
            ret.SuiteType = ((StreetAddress)this).SuiteType;
            ret.SuiteNumber = ((StreetAddress)this).SuiteNumber;
            ret.ZIP = ((StreetAddress)this).ZIP;
            ret.ZIPPlus1 = ((StreetAddress)this).ZIPPlus1;
            ret.ZIPPlus2 = ((StreetAddress)this).ZIPPlus2;
            ret.ZIPPlus3 = ((StreetAddress)this).ZIPPlus3;
            ret.ZIPPlus4 = ((StreetAddress)this).ZIPPlus4;
            ret.ZIPPlus5 = ((StreetAddress)this).ZIPPlus5;

            ret.ZIPAlternate = ((StreetAddress)this).ZIPAlternate;
            ret.ZIPPlus1Alternate = ((StreetAddress)this).ZIPPlus1Alternate;
            ret.ZIPPlus2Alternate = ((StreetAddress)this).ZIPPlus2Alternate;
            ret.ZIPPlus3Alternate = ((StreetAddress)this).ZIPPlus3Alternate;
            ret.ZIPPlus4Alternate = ((StreetAddress)this).ZIPPlus4Alternate;
            ret.ZIPPlus5Alternate = ((StreetAddress)this).ZIPPlus5Alternate;

            return ret;
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
            if (String.Compare(this.PreDirectional, s.PreDirectional, true) == 0 &&
                String.Compare(this.PreQualifier, s.PreQualifier, true) == 0 &&
                String.Compare(this.PreArticle, s.PreArticle, true) == 0 &&
                String.Compare(this.StreetName, s.StreetName, true) == 0 &&
                String.Compare(this.Suffix, s.Suffix, true) == 0 &&
                String.Compare(this.PostArticle, s.PostArticle, true) == 0 &&
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
                String.Compare(this.ZIP, s.ZIP, true) == 0)
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

    }
}