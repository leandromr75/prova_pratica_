using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piloto
{
    public class Pilotos
    {
        public Pilotos(string hora, string piloto, string n_volta, string t_volta, string v_media_volta)
        {
            Hora = hora;
            Piloto = piloto;
            N_Volta = n_volta;
            T_Volta = t_volta;
            V_Media_Volta = v_media_volta;
        }

        public string Hora { get; set; }
        public string Piloto { get; set; }
        public string N_Volta { get; set; }
        public string T_Volta { get; set; }
        public string V_Media_Volta { get; set; }
    }

   
}
