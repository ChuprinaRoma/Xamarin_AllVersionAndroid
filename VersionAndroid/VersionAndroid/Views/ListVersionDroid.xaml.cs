using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;
using VersionAndroid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;

namespace VersionAndroid.Views
{
    public partial class ListVersionDroid : ContentPage
    {
        private ListAndroidVersionViewModel listAndroidVersionView = null;

        public ListVersionDroid(string nameOC)
        {
            InitializeComponent();
            SetStyle();
            listAndroidVersionView = new ListAndroidVersionViewModel(nameOC);
            BindingContext         = listAndroidVersionView;
        }

        private void SetStyle()
        {
            this.Resources.Add(StyleSheet.FromAssemblyResource
                (IntrospectionExtensions.GetTypeInfo(typeof(ListVersionDroid)).Assembly,
            "VersionAndroid.Style.ListDroidversion.css"));
        }

        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Android android = ((Models.Android)e.Item);
            Navigation.PushModalAsync(new VersionDroid(android));
        }
    }
}
