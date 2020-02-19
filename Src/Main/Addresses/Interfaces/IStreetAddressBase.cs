using System;
using System.Collections.Generic;
using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.Addresses.AbstractClasses;

namespace USC.GISResearchLab.Common.Core.Addresses.Interfaces
{

    public interface IStreetAddressBase
    {
        #region Properties


        AddressFormatType AddressFormatType { get; set; }
        AddressLocationTypes AddressLocationType { get; }

        string Error { get; set; }
        bool ExceptionOccurred { get; set; }
        Exception Exception { get; set; }

        double Version { get; set; }

        int NumTracts2000 { get; set; }
        int NumTracts2010 { get; set; }

        string City { get; set; }
        string CityCode { get; set; }
        string MinorCivilDivision { get; set; }
        string MinorCivilDivisionCode { get; set; }
        string ConsolidatedCity { get; set; }
        string ConsolidatedCityCode { get; set; }
        string CountySubregion { get; set; }
        string CountySubregionCode { get; set; }
        string County { get; set; }
        string CountyCode { get; set; }
        string Country { get; set; }
        string CountryCode { get; set; }
        string State { get; set; }
        string StateCode { get; set; }



        string MetropolitanDivisionCode { get; set; }
        string MajorStatisticalAreaCode { get; set; }
        string CentralBusinessStatisticalAreaCode { get; set; }
        string CentralBusinessStatisticalMicroAreaCode { get; set; }


        string OtherInformation { get; set; }

        string Name { get; set; }
        string Phone { get; set; }

        string ZIP { get; set; }
        string ZIPPlus1 { get; set; }
        string ZIPPlus2 { get; set; }
        string ZIPPlus3 { get; set; }
        string ZIPPlus4 { get; set; }
        string ZIPPlus5 { get; set; }
        ZIPCodeType ZIPCodeType { get; set; }


        string PreArticle { get; set; }
        string PreDirectional { get; set; }
        string PreType { get; set; }
        string PreQualifier { get; set; }
        string PostArticle { get; set; }
        string PostQualifier { get; set; }
        string FullName { get; set; }
        string StreetName { get; set; }
        bool NameIsNumericAbbreviation { get; }
        bool NameIsNumberWords { get; }
        string PostDirectional { get; set; }
        string Suffix { get; set; }
        string SuiteType { get; set; }
        string SuiteNumber { get; set; }
        string Source { get; set; }

        string AliasFullName { get; set; }
        string AliasPreDirectional { get; set; }
        string AliasPreType { get; set; }
        string AliasName { get; set; }
        string AliasPreArticle { get; set; }
        string AliasPostArticle { get; set; }
        string AliasPreQualifier { get; set; }
        string AliasPostQualifier { get; set; }
        string AliasPostDirectional { get; set; }
        string AliasSuffix { get; set; }
        string AliasSuiteType { get; set; }
        string AliasSuiteNumber { get; set; }

        bool HasCity { get; }
        bool HasZip { get; }
        bool HasZipPlus4 { get; }
        bool HasState { get; }
        bool HasAddress { get; }

        StreetNumberRangeParity StreetNumberRangeParity { get; set; }
        StreetSide StreetSide { get; set; }

        #endregion

        List<AddressComponents> Difference(StreetAddress b);
        bool HasStreetAddressComponent(AddressComponents component);
        string GetStreetAddressComponent(AddressComponents component);
    }
}
