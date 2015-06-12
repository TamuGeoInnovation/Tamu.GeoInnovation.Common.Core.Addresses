using System;
using System.Collections.Generic;
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

        public double Version { get; set; }
        public bool Valid { get; set; }
        public string Error { get; set; }
        public bool ExceptionOccurred { get; set; }
        public Exception Exception { get; set; }

        public AddressFormatType AddressFormatType { get; set; }

        public StreetSide StreetSide { get; set; }
        public StreetNumberRangeParity StreetNumberRangeParity { get; set; }

        public string TransactionId { get; set; }
        public TimeSpan TimeTaken { get; set; }

        public int NumTracts2000 { get; set; }
        public int NumTracts2010 { get; set; }

        public string CityAlternate { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string MinorCivilDivision { get; set; }
        public string MinorCivilDivisionCode { get; set; }
        public string ConsolidatedCity { get; set; }
        public string ConsolidatedCityCode { get; set; }
        public string CountySubregion { get; set; }
        public string CountySubregionCode { get; set; }
        public string County { get; set; }
        public string CountyCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }

        public string MetropolitanDivisionCode { get; set; }
        public string MajorStatisticalAreaCode { get; set; }
        public string CentralBusinessStatisticalAreaCode { get; set; }
        public string CentralBusinessStatisticalMicroAreaCode { get; set; }

        public string OtherInformation { get; set; }

        public string ZIP { get; set; }
        public string ZIPPlus1 { get; set; }
        public string ZIPPlus2 { get; set; }
        public string ZIPPlus3 { get; set; }
        public string ZIPPlus4 { get; set; }
        public string ZIPPlus5 { get; set; }

        public ZIPCodeType ZIPCodeType { get; set; }

        public string ZIPAlternate { get; set; }
        public string ZIPPlus1Alternate { get; set; }
        public string ZIPPlus2Alternate { get; set; }
        public string ZIPPlus3Alternate { get; set; }
        public string ZIPPlus4Alternate { get; set; }
        public string ZIPPlus5Alternate { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public string FullName { get; set; }
        public string PreDirectional { get; set; }
        public string PreType { get; set; }
        public string StreetName { get; set; }
        public string PreArticle { get; set; }
        public string PostArticle { get; set; }
        public string PreQualifier { get; set; }
        public string PostQualifier { get; set; }
        public string PostDirectional { get; set; }
        public string Suffix { get; set; }
        public string SuiteType { get; set; }
        public string SuiteNumber { get; set; }


        public string AliasFullName { get; set; }
        public string AliasPreDirectional { get; set; }
        public string AliasPreType { get; set; }
        public string AliasName { get; set; }
        public string AliasPreArticle { get; set; }
        public string AliasPostArticle { get; set; }
        public string AliasPreQualifier { get; set; }
        public string AliasPostQualifier { get; set; }
        public string AliasPostDirectional { get; set; }
        public string AliasSuffix { get; set; }
        public string AliasSuiteType { get; set; }
        public string AliasSuiteNumber { get; set; }

        public string CensusYear { get; set; }
        public string CensusTract { get; set; }
        public string CensusBlock { get; set; }
        public string CensusBlockGroup { get; set; }
        public string CensusNAACCRCertCode { get; set; }
        public string CensusNAACCRCertType { get; set; }
        public string CensusCountyFips { get; set; }
        public string CensusPlaceFips { get; set; }
        public string CensusMSAFips { get; set; }
        public string CensusMCDFips { get; set; }
        public string CensusCBSAFips { get; set; }
        public string CensusCBSAMicro { get; set; }
        public string CensusMetDivFips { get; set; }
        public string CensusStateFips { get; set; }

        private bool _NameIsNumberComputed;
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


        public bool NameIsNumberWordsComputed { get; set; }

        private bool _NameIsNumberWords;
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


        public string Source { get; set; }

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

        public bool HasCity
        {
            get
            {
                return !String.IsNullOrEmpty(City);
            }
        }

        public bool HasZip
        {
            get
            {
                return !String.IsNullOrEmpty(ZIP);
            }
        }

        public bool HasZipPlus4
        {
            get
            {
                return !String.IsNullOrEmpty(ZIPPlus4);
            }
        }

        public bool HasState
        {
            get
            {
                return !String.IsNullOrEmpty(State);
            }
        }

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
            PreDirectional = "";
            PreQualifier = "";
            PreArticle = "";
            StreetName = "";
            PostDirectional = "";
            PostQualifier = "";
            PostArticle = "";
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

            PreDirectional = (!String.IsNullOrEmpty(pre)) ? pre.Trim() : "";
            StreetName = (!String.IsNullOrEmpty(name)) ? name.Trim() : "";
            Suffix = (!String.IsNullOrEmpty(suffix)) ? suffix.Trim() : "";
            PostDirectional = (!String.IsNullOrEmpty(post)) ? post.Trim() : "";
            SuiteType = (!String.IsNullOrEmpty(suite)) ? suite.Trim() : "";
            SuiteNumber = (!String.IsNullOrEmpty(suiteNumber)) ? suiteNumber.Trim() : "";
            City = (!String.IsNullOrEmpty(city)) ? city.Trim() : "";
            State = (!String.IsNullOrEmpty(state)) ? state.Trim() : "";
            ZIP = (!String.IsNullOrEmpty(zip)) ? zip.Trim() : "";
            Country = (!String.IsNullOrEmpty(country)) ? country.Trim() : "";

            AliasFullName = "";
            AliasPreDirectional = "";
            AliasPreType = "";
            AliasName = "";
            AliasPreArticle = "";
            AliasPostArticle = "";
            AliasPreQualifier = "";
            AliasPostQualifier = "";
            AliasPostDirectional = "";
            AliasSuffix = "";
            AliasSuiteType = "";
            AliasSuiteNumber = "";
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
            ret.CensusBlock = ((StreetAddress)this).CensusBlock;
            ret.CensusBlockGroup = ((StreetAddress)this).CensusBlockGroup;
            ret.CensusTract = ((StreetAddress)this).CensusTract;
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