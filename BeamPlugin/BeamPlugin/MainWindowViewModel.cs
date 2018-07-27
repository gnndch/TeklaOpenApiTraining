using System.ComponentModel;
using Tekla.Structures.Dialog;

namespace BeamPlugin
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string beamClass = string.Empty;

        [StructuresDialog("beamClass", typeof(Tekla.Structures.Datatype.String))]
        public string BeamClass
        {
            get { return beamClass; }
            set { beamClass = value; OnPropertyChanged("BeamClass"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}