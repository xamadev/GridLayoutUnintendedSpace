using C4S.Model;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace C4S.MobileApp.Data
{
    public class QueryResultFunktionMitKontakten : ObservableRangeCollection<Kontakt>, INotifyPropertyChanged
    {    
        public Funktion Funktion { get; set; }
        public ObservableRangeCollection<Kontakt> Kontakte { get; set; }

        private bool _expanded = false;
        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Expanded"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StateIcon"));
                    if (_expanded)
                    {
                        AddRange(Kontakte);
                    }
                    else
                    {
                        Clear();
                    }
                }
            }
        }
        public string StateIcon
        {
            get
            {
                if (Expanded)
                {
                    return "arrow_up.png";
                }
                else
                {
                    return "arrow_down.png";
                }
            }
        }
    }
}
