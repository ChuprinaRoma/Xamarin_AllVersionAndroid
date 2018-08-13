using Prism.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity;
using VersionAndroid.Servise;
using Xamarin.Forms;

namespace VersionAndroid.ViewModels
{
    class ListAndroidVersionViewModel
    {
        public ObservableCollection<Models.Android> Androids { get; set; }
        public ManagerAndroid managerAndroid = null;
        public UnityContainer unityContainer = null;
        public ICommand UpdateCommand { get; set; }

        public ListAndroidVersionViewModel(string nameOC)
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterInstance<ManagerAndroid>(new ManagerAndroid(nameOC));
            managerAndroid = unityContainer.Resolve<ManagerAndroid>();
            UpdateCommand = new Command(UpdateData);
            Task.Run(() => managerAndroid.Work());
            Androids       = managerAndroid.androids;
        }
        
        private void UpdateData()
        {
            Task.Run(() => managerAndroid.Work());
        }
    }
}
