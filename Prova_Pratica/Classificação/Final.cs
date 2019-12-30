using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificação
{
    public class Final
    {
        public Final(string posicao_chegada, string cod_piloto, string nome_piloto, string qtde_voltas_completadas,
            string t_total_prova, string melhor_volta, string v_media_corrida, string tempo_apos, string melhor_volta_corrida)
        {
            Posicao_Chegada = posicao_chegada;
            Cod_Piloto = cod_piloto;
            Nome_Piloto = nome_piloto;
            Qtde_Voltas_Completadas = qtde_voltas_completadas;
            T_Total_Prova = t_total_prova;
            Melhor_Volta = melhor_volta;
            V_Media_Corrida = v_media_corrida;
            Tempo_Apos = tempo_apos;
            Melhor_Volta_Corrida = melhor_volta_corrida;
        }
        public string Posicao_Chegada { get; set; }
        public string Cod_Piloto { get; set; }
        public string Nome_Piloto { get; set; }
        public string Qtde_Voltas_Completadas { get; set; }
        public string T_Total_Prova { get; set; }
        public string Melhor_Volta { get; set; }
        public string V_Media_Corrida { get; set; }
        public string Tempo_Apos { get; set; }
        public string Melhor_Volta_Corrida { get; set; }
    }
}
