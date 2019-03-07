using C4S.MobileApp.ViewModels;
using C4S.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GridLayoutFehlerhafterSpace.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KontaktePage : ContentPage
	{
        KontakteGroupViewModel viewModel;
        public Command KontaktSelectedCommand { get; set; }

        public KontaktePage(KontakteGroupViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

            Title = "Funktionen";

            KontaktSelectedCommand = new Command<Kontakt>((kontakt) => ExecuteKontaktSelectedCommand(kontakt));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.FunktionenMitKontakten.Count == 0)
                viewModel.LoadFunktionenMitKontaktenCommand.Execute(null);
        }

        async void ExecuteKontaktSelectedCommand(Kontakt kontakt)
        {
            if (kontakt == null)
                return;

            //Manually deselect item.
            //PortfolioElementeListe.SelectedItem = null;

         
        }
    }
}