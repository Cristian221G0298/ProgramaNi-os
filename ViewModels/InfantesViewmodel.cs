using CommunityToolkit.Mvvm.Input;
using LiveCharts;
using LiveCharts.Wpf;
using ProrgamaNiños.Models;
using ProrgamaNiños.Repositories;
using ProrgamaNiños.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProrgamaNiños.ViewModels
{
    public class InfantesViewmodel : INotifyPropertyChanged
    {
        public InfantesRepositorio Repos = new();
        public Infantes infante { get; set; }=new();
        InfantesView ViewInfantes = new();
        CumplenHoyView viewCumplenhoy = new();
        CumplenEsreMesView ViewCumplenEsreMes = new();
        MenoresDe15View ViewVigentes = new();
        VerCatorceView ViewCatorce = new();
        EstadisticasView ViewEstadisticas = new();
        public ObservableCollection<Vmcumplenhoy> CumpleañosDeHoy { get; set; } = new();
        public ObservableCollection<Vmmenoresde15> Vigentes { get; set; } = new();
        public ObservableCollection<Vwcumplemes> CumplenEsteMes { get; set; } = new();
        public ObservableCollection<Vmcatorceaños> CatorceAños { get; set; } = new();
        private string? error = "";
        private UserControl vista = null!;       
        public UserControl Vista
        {
            get
            {
                return vista;
            }
            set
            {
                vista = value;
                PropertyChanged?.Invoke(this, new(nameof(Vista)));
            }
        }
        public string? Error
        {
            get { return error; }
            set
            {
                error = value;
            }
        }
        public SeriesCollection Series { get; set; } = new();
        public ICommand VerAgregarCommand { get; set; }
        public ICommand VerCumpleañosDeHoyCommand { get; set; }
        public ICommand VerCumpleañosDeEsteMesCommand { get; set; }
        public ICommand VerVigentesCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        public ICommand VerCatorceCommand {  get; set; }
        public ICommand VerEstadisticasCommand {  get; set; }
        public ICommand EliminarNoVigentesCommand {  get; set; }
        public InfantesViewmodel()
        {
            VerAgregarCommand = new RelayCommand(VerAgregar);
            VerCumpleañosDeEsteMesCommand = new RelayCommand(VerCumplenMes);
            VerVigentesCommand = new RelayCommand(verVigentes);
            AgregarCommand = new RelayCommand(Agregar);
            CancelarCommand = new RelayCommand(Cancelar);
            VerCumpleañosDeHoyCommand = new RelayCommand(CumpleañosHoy);
            VerCatorceCommand = new RelayCommand(VerCatorce);
            VerEstadisticasCommand = new RelayCommand(VerEstadisticas);
            EliminarNoVigentesCommand = new RelayCommand(EliminarNoVigentes);
            verVigentes();
        }

        private void EliminarNoVigentes()
        {
            Repos.EliminarNoVigentes();
        }

        private void VerEstadisticas()
        {
            Vista = ViewEstadisticas;
            Series.Clear();
            foreach (var item in Repos.GetEstadisticas())
            {
                Series.Add(new PieSeries 
                { Title = item.Ciudad, 
                    DataLabels = true, 
                    LabelPoint = ChartPoint => $"{item.Ciudad}: {item.Count}",
                    FontSize = 20,
                    Values = new ChartValues<long> { item.Count} });
            }
        }

        private void VerCatorce()
        {
            Vista = ViewCatorce;
            Vigentes.Clear();
            if (Vigentes.Count == 0)
            {
                foreach (var ch in Repos.GetCatorceAños())
                {
                    CatorceAños.Add(ch);
                }
            }
        }

        private void verVigentes()
        {
            Vista = ViewVigentes;
            Vigentes.Clear();
            if (Vigentes.Count == 0)
            {
                foreach (var ch in Repos.GetVigentes())
                {
                    Vigentes.Add(ch);
                }
            }
        }

        private void VerCumplenMes()
        {
            Vista = ViewCumplenEsreMes;
            CumplenEsteMes.Clear();
            if (CumplenEsteMes.Count == 0)
            {
                foreach (Vwcumplemes ch in Repos.GetMenoresCumplenEsteMes())
                {
                    CumplenEsteMes.Add(ch);
                }
            }
        }

        private void CumpleañosHoy() 
        {
            Vista = viewCumplenhoy;
            CumpleañosDeHoy.Clear();
            if (CumpleañosDeHoy.Count==0)
            {
                foreach (Vmcumplenhoy ch in Repos.GetMenoresCumplenHoy())
                {
                    CumpleañosDeHoy.Add(ch);
                }
            }
        }
        private void Cancelar()
        {
            Vista = ViewVigentes;
        }

        public void VerAgregar()
        {
            infante = new();
            Actualizar(nameof(infante));
            Vista = ViewInfantes;
        }
        public void Agregar()
        {
            if (!Repos.validar(infante, out error))
            {
                Repos.Insertar(infante);
                verVigentes();
            }           
            Actualizar(nameof(error));
        }

        private void Actualizar(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
