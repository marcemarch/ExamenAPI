using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteAPI.Models
{
    public class Plato : INotifyPropertyChanged
    {
        private int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id == value) return;
                _Id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        private int _Nombre;
        public int Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                if (_Nombre == value) return;
                _Nombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nombre)));
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
