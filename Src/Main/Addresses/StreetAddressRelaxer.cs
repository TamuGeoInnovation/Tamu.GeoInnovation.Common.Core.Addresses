using System;
using System.Collections.Generic;

namespace USC.GISResearchLab.Common.Addresses
{
    public class StreetAddressRelaxer
    {

        #region Properties

        public List<AddressComponents> AllowedAddressComponents { get; set; }

        #endregion

        public StreetAddressRelaxer(List<AddressComponents> allowedAddressComponents)
        {
            AllowedAddressComponents = allowedAddressComponents;
        }

        public List<AddressComponents>[] SetupAddressComponents(StreetAddress address)
        {
            List<AddressComponents>[] ret = new List<AddressComponents>[3];

            // level 1 bag contains the pre and post directionals
            // level 2 bag contains the street type
            // level 3 bag contains the city and zip

            List<AddressComponents> level1Bag = new List<AddressComponents>();
            List<AddressComponents> level2Bag = new List<AddressComponents>();
            List<AddressComponents> level3Bag = new List<AddressComponents>();

            if (!String.IsNullOrEmpty(address.PreDirectional))
            {
                if (AllowedAddressComponents.Contains(AddressComponents.PreDirectional))
                {
                    level1Bag.Add(AddressComponents.PreDirectional);
                }
            }

            if (!String.IsNullOrEmpty(address.PostDirectional))
            {
                if (AllowedAddressComponents.Contains(AddressComponents.PostDirectional))
                {
                    level1Bag.Add(AddressComponents.PostDirectional);
                }
            }

            if (!String.IsNullOrEmpty(address.Suffix))
            {
                if (AllowedAddressComponents.Contains(AddressComponents.Suffix))
                {
                    level2Bag.Add(AddressComponents.Suffix);
                }
            }

            if (!String.IsNullOrEmpty(address.City))
            {
                if (AllowedAddressComponents.Contains(AddressComponents.City))
                {
                    level3Bag.Add(AddressComponents.City);
                }
            }

            if (!String.IsNullOrEmpty(address.ZIP))
            {
                if (AllowedAddressComponents.Contains(AddressComponents.Zip))
                {
                    level3Bag.Add(AddressComponents.Zip);
                }
            }

            ret[0] = level1Bag;
            ret[1] = level2Bag;
            ret[2] = level3Bag;

            return ret;
        }

        public List<RelaxableStreetAddress> GetAllRelaxedVersions(StreetAddress address)
        {
            List<RelaxableStreetAddress> ret = new List<RelaxableStreetAddress>();

            try
            {
                List<AddressComponents>[] bags = SetupAddressComponents(address);
                List<AddressComponents> level1Bag = (List<AddressComponents>)bags[0];
                List<AddressComponents> level2Bag = (List<AddressComponents>)bags[1];
                List<AddressComponents> level3Bag = (List<AddressComponents>)bags[2];


                // step 1 (all by themselves)
                // pre
                // post
                // suffix
                // city
                // zip
                if (level1Bag.Contains(AddressComponents.PreDirectional))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { AddressComponents.PreDirectional }));
                }

                if (level1Bag.Contains(AddressComponents.PostDirectional))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { AddressComponents.PostDirectional }));
                }

                if (level2Bag.Contains(AddressComponents.Suffix))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { AddressComponents.Suffix }));
                }

                if (level3Bag.Contains(AddressComponents.City))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { AddressComponents.City }));
                }

                if (level3Bag.Contains(AddressComponents.Zip))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { AddressComponents.Zip }));
                }

                // step 2 (level 1's in conjunction)
                // pre, post
                if (level1Bag.Contains(AddressComponents.PreDirectional) && level1Bag.Contains(AddressComponents.PostDirectional))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PreDirectional, 
                        AddressComponents.PostDirectional }));
                }

                // step 3 (level 1's in conjunction with level 2)
                // pre, suffix
                // post, suffix
                if (level1Bag.Contains(AddressComponents.PreDirectional) && level2Bag.Contains(AddressComponents.Suffix))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PreDirectional, 
                        AddressComponents.Suffix }));
                }

                if (level1Bag.Contains(AddressComponents.PostDirectional) && level2Bag.Contains(AddressComponents.Suffix))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PostDirectional, 
                        AddressComponents.Suffix }));
                }


                // step 4 (level 1's in conjunction with each other and level 2)
                // pre, post, suffix
                if (level1Bag.Contains(AddressComponents.PreDirectional) && level1Bag.Contains(AddressComponents.PostDirectional) && level2Bag.Contains(AddressComponents.Suffix))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PreDirectional, 
                        AddressComponents.PostDirectional, 
                        AddressComponents.Suffix }));
                }

                
                // step 5 (level 1's in conjunction with level 3)
                // pre, city
                // post, city
                // pre, zip
                // post, zip
                if (level1Bag.Contains(AddressComponents.PreDirectional) && level3Bag.Contains(AddressComponents.City))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PreDirectional, 
                        AddressComponents.City }));
                }

                if (level1Bag.Contains(AddressComponents.PostDirectional) && level3Bag.Contains(AddressComponents.City))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PostDirectional, 
                        AddressComponents.City }));
                }

                if (level1Bag.Contains(AddressComponents.PreDirectional) && level3Bag.Contains(AddressComponents.Zip))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PreDirectional, 
                        AddressComponents.Zip }));
                }

                if (level1Bag.Contains(AddressComponents.PostDirectional) && level3Bag.Contains(AddressComponents.Zip))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PostDirectional, 
                        AddressComponents.Zip }));
                }

                // step 6 (level 2 in conjunction with level 3)
                // suffix, city
                // suffix, zip
                if (level2Bag.Contains(AddressComponents.Suffix) && level3Bag.Contains(AddressComponents.City))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.Suffix, 
                        AddressComponents.City }));
                }

                if (level2Bag.Contains(AddressComponents.Suffix) && level3Bag.Contains(AddressComponents.Zip))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.Suffix, 
                        AddressComponents.Zip }));
                }


                // step 7 (level 1's in conjunction with level 2 and 3)
                // pre, suffix, city
                // post, suffix, city
                // pre, suffix, zip
                // post, suffix, zip
                if (level1Bag.Contains(AddressComponents.PreDirectional) && level2Bag.Contains(AddressComponents.Suffix) &&  level3Bag.Contains(AddressComponents.City))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PreDirectional, 
                        AddressComponents.Suffix, 
                        AddressComponents.City }));
                }

                if (level1Bag.Contains(AddressComponents.PostDirectional) && level2Bag.Contains(AddressComponents.Suffix) && level3Bag.Contains(AddressComponents.City))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PostDirectional, 
                        AddressComponents.Suffix, 
                        AddressComponents.City }));
                }

                if (level1Bag.Contains(AddressComponents.PreDirectional) && level2Bag.Contains(AddressComponents.Suffix) && level3Bag.Contains(AddressComponents.Zip))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PreDirectional, 
                        AddressComponents.Suffix, 
                        AddressComponents.Zip }));
                }

                if (level1Bag.Contains(AddressComponents.PostDirectional) && level2Bag.Contains(AddressComponents.Suffix) && level3Bag.Contains(AddressComponents.Zip))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PostDirectional, 
                        AddressComponents.Suffix, 
                        AddressComponents.Zip }));
                }

                // step 8 (level 1's in conjunction with each other, level 2, and 3)
                // pre, post, suffix, city
                // pre, post, suffix, zip
                if (level1Bag.Contains(AddressComponents.PreDirectional) && level1Bag.Contains(AddressComponents.PostDirectional) && level2Bag.Contains(AddressComponents.Suffix) && level3Bag.Contains(AddressComponents.City))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PreDirectional, 
                        AddressComponents.PostDirectional, 
                        AddressComponents.Suffix, 
                        AddressComponents.City }));
                }

                if (level1Bag.Contains(AddressComponents.PreDirectional) && level1Bag.Contains(AddressComponents.PostDirectional) && level2Bag.Contains(AddressComponents.Suffix) && level3Bag.Contains(AddressComponents.Zip))
                {
                    ret.Add(GetNextRelaxedAddress(address, new AddressComponents[] { 
                        AddressComponents.PreDirectional, 
                        AddressComponents.PostDirectional, 
                        AddressComponents.Suffix, 
                        AddressComponents.Zip }));
                }

            }
            catch (Exception e)
            {
                throw new Exception("Exception occurred in GetRelaxedVersions: " + e.Message, e);
            }

            return ret;
        }

        public RelaxableStreetAddress GetNextRelaxedAddress(StreetAddress address, AddressComponents[] AddressComponentArray)
        {

            RelaxableStreetAddress ret = RelaxableStreetAddress.FromStreetAddress(address);

            foreach (AddressComponents attribute in AddressComponentArray)
            {
                switch (attribute)
                {
                    case AddressComponents.City:
                        ret.City = null;
                        ret.RelaxedAttributes.Add(AddressComponents.City);
                        break;
                    case AddressComponents.Country:
                        ret.Country = null;
                        ret.RelaxedAttributes.Add(AddressComponents.Country);
                        break;
                    case AddressComponents.StreetName:
                        ret.StreetName = null;
                        ret.RelaxedAttributes.Add(AddressComponents.StreetName);
                        break;
                    case AddressComponents.Number:
                        ret.Number = null;
                        ret.RelaxedAttributes.Add(AddressComponents.Number);
                        break;
                    case AddressComponents.PostDirectional:
                        ret.PostDirectional = null;
                        ret.RelaxedAttributes.Add(AddressComponents.PostDirectional);
                        break;
                    case AddressComponents.PreDirectional:
                        ret.PreDirectional = null;
                        ret.RelaxedAttributes.Add(AddressComponents.PreDirectional);
                        break;
                    case AddressComponents.State:
                        ret.State = null;
                        ret.RelaxedAttributes.Add(AddressComponents.State);
                        break;
                    case AddressComponents.Suffix:
                        ret.Suffix = null;
                        ret.RelaxedAttributes.Add(AddressComponents.Suffix);
                        break;
                    case AddressComponents.SuiteNumber:
                        ret.SuiteType = null;
                        ret.RelaxedAttributes.Add(AddressComponents.SuiteNumber);
                        break;
                    case AddressComponents.SuiteType:
                        ret.SuiteType = null;
                        ret.RelaxedAttributes.Add(AddressComponents.SuiteType);
                        break;
                    case AddressComponents.Zip:
                        ret.ZIP = null;
                        ret.RelaxedAttributes.Add(AddressComponents.Zip);
                        break;
                    default:
                        throw new Exception("Unexpected AddressComponents type: " + attribute);

                }
            }

            return ret;
        }
    }
}