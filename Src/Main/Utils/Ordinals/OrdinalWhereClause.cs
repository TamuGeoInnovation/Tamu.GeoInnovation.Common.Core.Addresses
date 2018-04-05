
using System.Collections.Generic;

namespace Tamu.GeoInnovation.Common.Core.Addresses.Utils.Ordinals
{
    public class OrdinalWhereClause
    {
        public string WhereClause { get; set; }
        //public string OrdParam1 { get; set; }
        //public string OrdParam2 { get; set; }
        //public string OrdParam3 { get; set; }
        public List<KeyValuePair<string, string>> OrdParams { get; set; }

        public OrdinalWhereClause()
        {
            WhereClause = "";
            OrdParams = new List<KeyValuePair<string, string>> { };

        }
        public OrdinalWhereClause(string whereClause, List<KeyValuePair<string, string>> ordParams)
        {
            WhereClause = whereClause;
            OrdParams = ordParams;
        }
        //Other properties, methods, events...
    }
}
