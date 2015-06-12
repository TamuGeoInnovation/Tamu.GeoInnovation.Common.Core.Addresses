using USC.GISResearchLab.Common.Threading.ProgressStates;

namespace USC.GISResearchLab.Geocoding.Core.Runners.Databases
{
    public class AddressCompletedProgressState : PercentCompletableProgressState
    {
        #region Properties
        private string _Street;
        private string _City;
        private string _State;
        private string _ZIP;
        private string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
	

        public string ZIP
        {
            get { return _ZIP; }
            set { _ZIP = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
	

        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }
	

        
        #endregion

        public AddressCompletedProgressState()
            :base(){}
    }
}
