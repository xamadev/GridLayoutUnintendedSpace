using C4S.MobileApp.Data;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using C4S.Model;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace C4S.MobileApp.ViewModels
{
    public class KontakteGroupViewModel : MvvmHelpers.BaseViewModel
    {

        public ObservableRangeCollection<QueryResultFunktionMitKontakten> FunktionenMitKontakten { get; set; }
            = new ObservableRangeCollection<QueryResultFunktionMitKontakten>();
        public Command LoadFunktionenMitKontaktenCommand { get; set; }
        public Command<QueryResultFunktionMitKontakten> KontaktSelectedCommand { get; set; }

        public Command MakePhoneCallCommand { get; set; }
        public Command SendEmailCommand { get; set; }

        public KontakteGroupViewModel()
        {

            Title = "Title";

            LoadFunktionenMitKontaktenCommand = new Command(async () => await ExecuteLoadFunktionenMitKontaktenCommand());
            KontaktSelectedCommand = new Command<QueryResultFunktionMitKontakten>((item) => ExecuteKontaktSelectedCommand(item));

            MakePhoneCallCommand = new Command<string>((phoneNumber) =>
            {
                PhoneDialer.Open(phoneNumber);
            });

            SendEmailCommand = new Command<string>((email) =>
            {
                Email.ComposeAsync("", "", email);
            });
        }
        public bool isExpanded = false;
        private void ExecuteKontaktSelectedCommand(QueryResultFunktionMitKontakten item)
        {
            //if (_oldHotel == item)
            //{
            //    // click twice on the same item will hide it  
            //    item.Expanded = !item.Expanded;
            //}
            //else
            //{
            //    if (_oldHotel != null)
            //    {
            //        // hide previous selected item  
            //        item.Expanded = false;
            //    }
            //    // show selected item  
            //    item.Expanded = true;
            //}
            //_oldHotel = item;

            item.Expanded = !item.Expanded;
        }
        async Task ExecuteLoadFunktionenMitKontaktenCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var funktionenMitKontakten = new ObservableRangeCollection<QueryResultFunktionMitKontakten>()
                {
                    new QueryResultFunktionMitKontakten()
                    {
                        Funktion = new Funktion()
                        {
                            Bezeichnung = "Funktion1"
                        },
                        Kontakte = new ObservableRangeCollection<Kontakt>()
                        {
                            new Kontakt()
                            {
                                Name = "Name1",
                                Vorname = "Vorname1",
                                Email = "1@2.3",
                                TelefonMobilNummer = "324234",
                                TelefonMobilOrt = "324",
                                TelefonOfficeOrt = "234",
                                TelefonOfficeNummer = "45457"
                            },
                            new Kontakt()
                            {
                                Name = "Name2",
                                Vorname = "Vorname2",
                                Email = "1@2.3",
                                TelefonMobilNummer = "324234",
                                TelefonMobilOrt = "324",
                                TelefonOfficeOrt = "234",
                                TelefonOfficeNummer = "45457"
                            }
                        },


                    },
                        new QueryResultFunktionMitKontakten()
                        {
                        Funktion = new Funktion()
                        {
                        Bezeichnung = "Funktion2"
                    },
                    Kontakte = new ObservableRangeCollection<Kontakt>()
                    {
                        new Kontakt()
                        {
                            Name = "Name3",
                            Vorname = "Vorname3",
                            Email = "1@2.3",
                            TelefonMobilNummer = "324234",
                            TelefonMobilOrt = "324",
                            TelefonOfficeOrt = "234",
                            TelefonOfficeNummer = "45457"
                        }
                        }
                    }

                };

                //Wenn nur eine Funktion vorhanden ist -> Kontakte ausklappen
                if (funktionenMitKontakten.Count == 1)
                    funktionenMitKontakten.FirstOrDefault().Expanded = true;

                MainThread.BeginInvokeOnMainThread(() => FunktionenMitKontakten.Clear());
                MainThread.BeginInvokeOnMainThread(() => FunktionenMitKontakten.AddRange(funktionenMitKontakten));
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex);
                throw ex;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
