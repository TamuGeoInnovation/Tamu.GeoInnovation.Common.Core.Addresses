using System;
using System.Collections.Generic;
using System.Text;
using USC.GISResearchLab.Common.Addresses;
using USC.GISResearchLab.Common.Core.TextEncodings.Soundex;
using USC.GISResearchLab.Common.Utils.Numbers;

namespace Tamu.GeoInnovation.Common.Core.Addresses.Utils.Ordinals
{
    public class OrdinalUtils
    {

        //Payton: If streetname is numeric this adds where clause to account for multiple variations of the name
        public static OrdinalWhereClause getOrdinalWhereClause(StreetAddress streetAddress, string streetSoundexFieldName)
        {
            OrdinalWhereClause ret = new OrdinalWhereClause();
            StringBuilder where = new StringBuilder();
            StringBuilder parms = new StringBuilder();


            if (!String.IsNullOrEmpty(streetAddress.PreType)) // Via De La Vialla
            {
                where.Append("			OR ");
                where.Append("			" + streetSoundexFieldName + "=@ordParam1 ");
            }
            else if (streetAddress.StreetName.ToUpper().StartsWith("SAINT")) // Saint, add in ST
            {
                where.Append("			OR ");
                where.Append("			" + streetSoundexFieldName + "=@ordParam1 ");
            }
            else if (streetAddress.NameIsNumericAbbreviation) // 1st street, add in first soundex, and 1 soundex
            {
                where.Append("			OR ");
                where.Append("			" + streetSoundexFieldName + "=@ordParam1 ");
                where.Append("			OR ");
                where.Append("			" + streetSoundexFieldName + "=@ordParam2 ");

            }
            else if (streetAddress.NameIsNumberWords) // first street, add in 1st soundex, and 1 soundex
            {
                where.Append("			OR ");
                where.Append("			" + streetSoundexFieldName + "=@ordParam2 ");
                where.Append("			OR ");
                where.Append("			" + streetSoundexFieldName + "=@ordParam3 ");
            }
            else if (streetAddress.NameIsNumber) // 1, add in 1st soundex, first soundex, and 1 soundex
            {

                where.Append("			OR ");
                where.Append("			" + streetSoundexFieldName + "=@ordParam1 ");
                where.Append("			OR ");
                where.Append("			" + streetSoundexFieldName + "=@ordParam2 ");
                where.Append("			OR ");
                where.Append("			" + streetSoundexFieldName + "=@ordParam3 ");
            }

            ret.WhereClause = where.ToString();

            if (!String.IsNullOrEmpty(streetAddress.PreType)) // Via De La Vialla
            {
                ret.OrdParams.Add(new KeyValuePair<string, string>("ordParam1", SoundexEncoder.ComputeEncodingNew(streetAddress.PreType + " " + streetAddress.StreetName)));
            }
            else if (streetAddress.StreetName.ToUpper().StartsWith("SAINT")) // Saint, add in ST
            {
                string newName = streetAddress.StreetName.ToUpper().Replace("SAINT", "ST");
                ret.OrdParams.Add(new KeyValuePair<string, string>("ordParam1", SoundexEncoder.ComputeEncodingNew(newName)));
            }
            else if (streetAddress.NameIsNumericAbbreviation) // 1st street, add in first soundex and 1 soundex
            {
                ret.OrdParams.Add(new KeyValuePair<string, string>("ordParam1", SoundexEncoder.ComputeEncodingNew(NumberUtils.IntegerToWords(streetAddress.StreetName, true))));

                int number = NumberUtils.GetNumberPartOfNumericAbbreviation(streetAddress.StreetName);
                ret.OrdParams.Add(new KeyValuePair<string, string>("ordParam2", SoundexEncoder.ComputeEncodingNew(number.ToString())));
            }
            else if (streetAddress.NameIsNumberWords) // first street, add in 1st soundex and 1 soundex
            {
                string numericAbbreivation = NumberUtils.WordsToNumericAbbreviation(streetAddress.StreetName);
                int number = NumberUtils.GetNumberPartOfNumericAbbreviation(numericAbbreivation);
                ret.OrdParams.Add(new KeyValuePair<string, string>("ordParam2", SoundexEncoder.ComputeEncodingNew(numericAbbreivation)));
                ret.OrdParams.Add(new KeyValuePair<string, string>("ordParam3", SoundexEncoder.ComputeEncodingNew(number.ToString())));
            }
            else if (streetAddress.NameIsNumber) // 1, add in 1st soundex, first soundex, and 1 soundex
            {
                string integerWords = NumberUtils.IntegerToWords(streetAddress.StreetName, true);
                string integerWordsSoundex = SoundexEncoder.ComputeEncodingNew(integerWords);

                ret.OrdParams.Add(new KeyValuePair<string, string>("ordParam1", integerWordsSoundex));

                int number = Convert.ToInt32(streetAddress.StreetName);
                string numericAbbreviation = NumberUtils.getNumericAbbreviationSuffixForNumber(number);
                string numericAbbreviationSoundex = SoundexEncoder.ComputeEncodingNew(streetAddress.StreetName + numericAbbreviation);

                ret.OrdParams.Add(new KeyValuePair<string, string>("ordParam2", numericAbbreviationSoundex));
                ret.OrdParams.Add(new KeyValuePair<string, string>("ordParam3", SoundexEncoder.ComputeEncodingNew(number.ToString())));
            }
            return ret;
        }
    }


}
