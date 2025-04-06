using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClienteAPI.Models
{
    public class Plato : INotifyPropertyChanged
    {
        private int _Id;
        [JsonPropertyName("id")]
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

        private string _Nombre;
        [JsonPropertyName("nombre")]
        public string Nombre
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

        private double _Precio;
        [JsonPropertyName("precio")]
        public double Precio
        {
            get { return _Precio; }
            set
            {
                if (_Precio == value) return;
                _Precio = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Precio)));
            }
        }

        private string _Ingredientes;
        [JsonPropertyName("ingredientes")]
        public string Ingredientes
        {
            get { return _Ingredientes; }
            set
            {
                if (_Ingredientes == value) return;
                _Ingredientes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ingredientes)));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
