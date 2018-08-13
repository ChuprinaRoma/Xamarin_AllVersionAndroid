using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace VersionAndroid.ViewModels
{
    public class VersionDroidViewModels : BindableBase
    {
        public INavigation Navigation { get; set; }
        public ICommand BackToPageCommand { get; set; }

        public VersionDroidViewModels(Models.Android android)
        {
            BackToPageCommand = new DelegateCommand(BackToPage);
            TitleFullName     = android.FullName;
            FullName          = "Полное имя: "  + android.FullName;
            Name              = "Имя версии: "  + android.Name;
            ReleaseDate       = "Дата выхода: " + android.ReleaseDate;
            Version           = "Версия: "      + android.Version;
            WhatsNew          = android.WhatsNew;
        }

        private string _FullName = null;
        public string FullName
        {
            get { return _FullName; }
            set
            {
                SetProperty(ref _FullName, value);
            }
        }

        private string _TitleFullName = null;
        public string TitleFullName
        {
            get { return _TitleFullName; }
            set
            {
                SetProperty(ref _TitleFullName, value);
            }
        }

        private string _Name = null;
        public string Name
        {
            get { return _Name; }
            set
            {
                SetProperty(ref _Name, value);
            }
        }

        private string _ReleaseDate = null;
        public string ReleaseDate
        {
            get { return _ReleaseDate; }
            set
            {
                SetProperty(ref _ReleaseDate, value);
            }
        }

        private string _Version = null;
        public string Version
        {
            get { return _Version; }
            set
            {
                SetProperty(ref _Version, value);
            }
        }

        private string[] _WhatsNew = null;
        public string[] WhatsNew
        {
            get { return _WhatsNew; }
            set
            {
                SetProperty(ref _WhatsNew, value);
            }
        }

        private void BackToPage()
        {
            Navigation.PopModalAsync();
        }
    }
}
