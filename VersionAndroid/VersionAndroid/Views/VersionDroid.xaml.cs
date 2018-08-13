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
using Xamarin.Forms.Xaml;

namespace VersionAndroid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VersionDroid : ContentPage
	{
        private VersionDroidViewModels versionDroidViewModels = null;
        public VersionDroid (Models.Android android)
		{
			InitializeComponent ();
            SetStyle();
            versionDroidViewModels = new VersionDroidViewModels(android)
            { Navigation = this.Navigation };
            BindingContext = versionDroidViewModels;
        }

        private void SetStyle()
        {
            this.Resources.Add(StyleSheet.FromAssemblyResource
                (IntrospectionExtensions.GetTypeInfo(typeof(VersionDroid)).Assembly,
            "VersionAndroid.Style.DroidSimplePage.css"));
        }
    }
}