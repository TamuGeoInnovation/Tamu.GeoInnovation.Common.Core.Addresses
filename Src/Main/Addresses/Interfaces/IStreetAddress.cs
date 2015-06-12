using USC.GISResearchLab.Common.Addresses;

namespace USC.GISResearchLab.Common.Core.Addresses.Interfaces
{
    public interface IStreetAddress : IStreetAddressBase
    {
        #region Properties

        bool IsParsed { get; set; }
        bool HasPostOfficeBox { get; set; }
        string PostOfficeBoxType { get; set; }
        string PostOfficeBoxNumber { get; set; }
        bool HasPostOfficeBoxNumber { get; }

        bool HasRuralRoute { get; set; }
        string RuralRouteType { get; set; }
        string RuralRouteNumber { get; set; }
        bool HasRuralRouteNumber { get; }
        string RuralRouteBoxType { get; set; }
        string RuralRouteBoxNumber { get; set; }
        bool HasRuralRouteBoxNumber { get; }
        bool HasRuralRouteBox { get; set; }
        bool HasStarRoute { get; set; }
        string StarRouteType { get; set; }
        string StarRouteNumber { get; set; }
        bool HasStarRouteNumber { get; }
        string StarRouteBoxType { get; set; }
        string StarRouteBoxNumber { get; set; }
        bool HasStarRouteBoxNumber { get; }
        bool HasStarRouteBox { get; set; }
        bool HasHighwayContractRoute { get; set; }
        string HighwayContractRouteType { get; set; }
        string HighwayContractRouteNumber { get; set; }
        bool HasHighwayContractRouteNumber { get; }
        string HighwayContractRouteBoxType { get; set; }
        string HighwayContractRouteBoxNumber { get; set; }
        bool HasHighwayContractRouteBoxNumber { get; }
        bool HasHighwayContractRouteBox { get; set; }

       

        string AddressId { get; set; }
       

        string Number { get; set; }
        string NumberFractional { get; set; }
       
        //string NonParsedOriginalValue { get; set; }
        string NonParsedStreetAddress { get; set; }
        StreetAddress NonParsedOriginalStreetAddress { get; set; }

        bool HasCity { get; }
        bool HasZip { get; }
        bool HasZipPlus4 { get; }
        bool HasState { get; }
        bool HasAddress { get; }

        string CensusTract { get; set; }
        string CensusBlock { get; set; }
        string CensusBlockGroup { get; set; }

        #endregion
    }
}
