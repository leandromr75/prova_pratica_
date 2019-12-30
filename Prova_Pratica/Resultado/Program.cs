using Corrida_Log;
using Piloto;
using Classificação;
using Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resultado
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Gera os dados de LOG
                Log_Gerador l = new Log_Gerador();

                //Cria o arquivo de LOG
                bool s = l.Save(l.Log());

                if (s == true)
                {
                    Console.WriteLine("Arquivo de Log gerado com sucesso!");

                }
                else
                {
                    Console.WriteLine("Erro na geração do arquivo de LOG");
                }


                // Carrega arquivo de LOG gerado anteriormente e o adiciona à uma lista de objetos
                Carrega_Log c = new Carrega_Log();
                List<Pilotos> p;
                p = new List<Pilotos>();
                p = c.Retorna_Log();

                char pad = ' ';
                int ajuste = 14;

                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Carregando o arquivo de LOG da corrida de Kart");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------\n\n");


                Console.WriteLine("Hora                  Piloto                    Nº Volta      Tempo Volta        Velocidade Média da Volta");
                Console.WriteLine("__________________________________________________________________________________________________________\n");
                
                p.ForEach(delegate(Pilotos z)
                {
                    if (z.Piloto.Length > 14)
                    {
                        ajuste = 14 - ( z.Piloto.Length - 14);
                    }
                    if (z.Piloto.Length < 14)
                    {
                        ajuste = 14 + (14 - z.Piloto.Length);
                    }
                    if (z.Piloto.Length == 14)
                    {
                        ajuste = 14;
                    }
                    Console.WriteLine(String.Format("{0}        {1} {2}            {3}         {4}", z.Hora, z.Piloto, z.N_Volta.PadLeft(ajuste, pad), z.T_Volta.Substring(3, (z.T_Volta.Length - 3)) , z.V_Media_Volta.Replace(".", ",").PadRight(20,pad)));
                    ajuste = 14;
                });

                Console.WriteLine("\n\n");


                //Exibir 
                
                
                List<Final> u;
                u = new List<Final>();
                u = l.Gerar_Resultado();
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Resultado da corrida no momento em que o primeiro colocado atinge 4 voltas");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------\n\n");


                Console.WriteLine("Posição  Cód.Piloto   Nome Piloto            Qtde Voltas    Tempo Tot. Prova   Melhor Volta   Vel. Média  Tempo_após_vencedor  Melhor_Volta_Corrida");
                Console.WriteLine("___________________________________________________________________________________________________________________________________________________\n");
                u.ForEach(delegate(Final d)
                {
                    if (d.Nome_Piloto.Length > 14)
                    {
                        ajuste = 14 - (d.Nome_Piloto.Length - 14);
                    }
                    if (d.Nome_Piloto.Length < 14)
                    {
                        ajuste = 14 + (14 - d.Nome_Piloto.Length);
                    }
                    if (d.Nome_Piloto.Length == 14)
                    {
                        ajuste = 14;
                    }
                    Console.WriteLine(String.Format("{0}           {1}       {2}{3}           {4}     {5}   {6}         {7}             {8}",
                        d.Posicao_Chegada, d.Cod_Piloto, d.Nome_Piloto, d.Qtde_Voltas_Completadas.PadLeft(ajuste, pad), d.T_Total_Prova.Substring(3, (d.T_Total_Prova.Length - 3)), d.Melhor_Volta,
                        d.V_Media_Corrida,d.Tempo_Apos,d.Melhor_Volta_Corrida));
                    ajuste = 14;
                });

                Console.WriteLine("\n");



            }
            catch (Exception)
            {

                Console.WriteLine("Erro"); 
            }
            

            Console.ReadKey();
        }

    }
}
