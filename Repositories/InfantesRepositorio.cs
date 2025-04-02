using ProrgamaNiños.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProrgamaNiños.Repositories
{
    public class InfantesRepositorio
    {
        ProgramaNinosContext context = new();
        public IEnumerable<Vmcumplenhoy> GetMenoresCumplenHoy()
        {
            return context.Vmcumplenhoy;
        }
        public IEnumerable<Vmcatorceaños> GetCatorceAños()
        {
            return context.Vmcatorceaños;
        }

        public IEnumerable<Vmmenoresde15> GetVigentes()
        {
            return context.Vmmenoresde15;
        }
        public IEnumerable<Vwestadisticaciudades> GetEstadisticas()
        {
            return context.Vwestadisticaciudades;
        }
        public IEnumerable<Vwcumplemes> GetMenoresCumplenEsteMes()
        {
            return context.Vwcumplemes;
        }
        public void Insertar(Infantes n)
        {
            context.Infantes.Add(n);
            context.SaveChanges();
        }

        public bool validar(Infantes n, out string? error)
        {
            List<string> errores = new List<string>();
            // dos niños no se pueden llamar igual si no viven en el mismo domicilio
            // que la fecha de nacimiento no sea mañana
            if (string.IsNullOrWhiteSpace(n.Nombre))
            {
                errores.Add("El nombre del infante no puede esta vacio");
            }
            if (string.IsNullOrWhiteSpace(n.Domicilio))
            {
                errores.Add("El domicilio del infante no puede esta vacio");

            }
            if (n.FechaNacimiento==null)
            {
                errores.Add("La fecha de nacimiento no puede estar vacia");
            }
            if (context.Infantes.Select(x=>x.Nombre.ToLower()).Contains(n.Nombre.ToLower()) && context.Infantes.Select(x=>x.Domicilio.ToLower()).Contains(n.Domicilio.ToLower()) && n.Domicilio!= "desconocido")
            {
                errores.Add("No se puede agregar dos infantes con el mismo nombre y el mismo domicilio");
            }
            error = string.Join(Environment.NewLine, errores);
            return errores.Count != 0;
        }
    }
}
