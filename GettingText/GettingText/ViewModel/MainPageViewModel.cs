using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace GettingText.ViewModel
{

    public class MainPageViewModel : INotifyPropertyChanged
    {

        public MainPageViewModel()
        {
            EraseCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });

            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);
                TheNote = string.Empty;
            });

            ClearCommand = new Command(() =>
            {
                AllNotes.Clear();
            });
        }

        public ObservableCollection<string> AllNotes { get; set; } = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;

        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
                //Uma linha só
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }

        public Command ClearCommand { get; }
    }
}
