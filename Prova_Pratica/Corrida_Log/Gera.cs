using Piloto;
using Classificação;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrida_Log
{
    public class Log_Gerador
    {
        public List<Pilotos> Log()
        {
            // Criando uma lista para ser preenchida com objetos Pilotos
            List<Pilotos> p;
            p = new List<Pilotos>();
            
            try
            {
                p.Add(new Pilotos("23:49:08.277", "038 - F.MASSA", "1", "0:1:02.852", "44.275"));
                p.Add(new Pilotos("23:49:10.858", "033 - R.BARRICHELLO", "1", "0:1:04.352", "43,243"));
                p.Add(new Pilotos("23:49:11.075", "002 - K.RAIKKONEN", "1", "0:1:04.108", "43,408"));
                p.Add(new Pilotos("23:49:12.667", "023 - M.WEBBER", "1", "0:1:04.414", "43,202"));
                p.Add(new Pilotos("23:49:30.976", "015 - F.ALONSO", "1", "0:1:18.456", "35,47"));
                p.Add(new Pilotos("23:50:11.447", "038 - F.MASSA", "2", "0:1:03.170", "44,053"));
                p.Add(new Pilotos("23:50:14.860", "033 - R.BARRICHELLO", "2", "0:1:04.002", "43,48"));
                p.Add(new Pilotos("23:50:15.057", "002 - K.RAIKKONEN", "2", "0:1:03.982", "43,493"));
                p.Add(new Pilotos("23:50:17.472", "023 - M.WEBBER", "2", "0:1:04.805", "42,941"));
                p.Add(new Pilotos("23:50:37.987", "015 - F.ALONSO", "2", "0:1:07.011", "41,528"));
                p.Add(new Pilotos("23:51:14.216", "038 - F.MASSA", "3", "0:1:02.769", "44,334"));
                p.Add(new Pilotos("23:51:18.576", "033 - R.BARRICHELLO", "3", "0:1:03.716", "43,675"));
                p.Add(new Pilotos("23:51:19.044", "002 - K.RAIKKONEN", "3", "0:1:03.987", "43,49"));
                p.Add(new Pilotos("23:51:21.759", "023 - M.WEBBER", "3", "0:1:04.287", "43,287"));
                p.Add(new Pilotos("23:51:46.691", "015 - F.ALONSO", "3", "0:1:08.704", "40,504"));
                p.Add(new Pilotos("23:52:01.796", "011 - S.VETTEL", "1", "0:3:31.315", "13,169"));
                p.Add(new Pilotos("23:52:17.003", "038 - F.MASSA", "4", "0:1:02.787", "44,321"));
                p.Add(new Pilotos("23:52:22.586", "033 - R.BARRICHELLO", "4", "0:1:04.010", "43,474"));
                p.Add(new Pilotos("23:52:22.120", "002 - K.RAIKKONEN", "4", "0:1:03.076", "44,118"));
                p.Add(new Pilotos("23:52:25.975", "023 - M.WEBBER", "4", "0:1:04.216", "43,335"));
                p.Add(new Pilotos("23:53:06.741", "015 - F.ALONSO", "4", "0:1:20.050", "34,763"));
                p.Add(new Pilotos("23:53:39.660", "011 - S.VETTEL", "2" ,"0:1:37.864", "28,435"));
                p.Add(new Pilotos("23:54:57.757", "011 - S.VETTEL", "3", "0:1:18.097", "35,633"));


            }
            catch (Exception)
            {
                //Exibe mensagem de erro em caso de falha no preenchimento
                p.Add(new Pilotos("Erro na geração do LOG", "","","",""));

            }
            //Retorna Lista de objetos
            return p;
                
           
        }
        public bool Success { get; private set; }

        public bool Save(List<Pilotos> l)
        {
            try
            {
                // Código para gerar o arquivo de LOG da corrida
                using (StreamWriter writer = new StreamWriter("LOG_Corrida.csv"))
                {
                    l.ForEach(delegate(Pilotos p)
                    {
                        writer.WriteLine(p.Hora + " ; " + p.Piloto + " ; " + p.N_Volta + " ; " + p.T_Volta + " ; " + p.V_Media_Volta);
                    });


                }
                
                //Exibe mensagem de sucesso na criação do LOG
                Success = true;

            }
            catch (Exception)
            {

                Success = false;
            }
            
            
            return Success;
        }

        public List<Final> Gerar_Resultado()
        {

            List<Pilotos> k;
            k = new List<Pilotos>();
            k = Log();
            
            
            
            // Criando uma lista para ser preenchida com objetos Pilotos
            List<Final> f;
            f = new List<Final>();

            // Criando uma lista temporária
            List<Pilotos> temp;
            temp = new List<Pilotos>();

            try
            {
                string piloto_temp = "";
                int pos = 1;
                int qtde_v = 0;
                TimeSpan tempo_total = TimeSpan.Parse("00:00:00");
                TimeSpan melhor_v = TimeSpan.Parse("00:00:00");
                double vel_media = 0;
                TimeSpan tempo_apos = TimeSpan.Parse("00:000:0");
                TimeSpan melhor_volta_corrida = TimeSpan.Parse("00:00:00");
                string nome_melhor_volta = "";
                bool fim_corrida = false;

                //Percorre a lista de input do LOG
                k.ForEach(delegate(Pilotos n)
                {

                    if (Convert.ToInt32(n.N_Volta) < 4)
                    {
                        temp.Add(new Pilotos(n.Hora, n.Piloto, n.N_Volta, n.T_Volta, n.V_Media_Volta));
                        
                    }
                    if (Convert.ToInt32(n.N_Volta) == 4 && fim_corrida == false)
                    {
                        temp.Add(new Pilotos(n.Hora, n.Piloto, n.N_Volta, n.T_Volta, n.V_Media_Volta));

                        //Sort na lista
                        temp.Sort(delegate(Pilotos p1, Pilotos p2)
                        {
                            return p1.N_Volta.CompareTo(p2.N_Volta);
                        });

                        // primeiro piloto atingiu 4 voltas e com isso terminou a corrida
                        fim_corrida = true;

                        piloto_temp = n.Piloto;
                        melhor_v = TimeSpan.Parse(n.T_Volta);
                        melhor_volta_corrida = TimeSpan.Parse(n.T_Volta);
                        nome_melhor_volta = n.Piloto;

                        temp.ForEach(delegate(Pilotos w)
                        {
                            if (TimeSpan.Compare(melhor_volta_corrida, TimeSpan.Parse(w.T_Volta)) == 1)
                            {
                                melhor_volta_corrida = TimeSpan.Parse(w.T_Volta);
                                nome_melhor_volta = w.Piloto;
                            } //t1 is greater than t1  

                        });


                        temp.ForEach(delegate(Pilotos w) 
                        {
                            if (w.Piloto == piloto_temp)
                            {
                                
                                if (TimeSpan.Compare(melhor_v, TimeSpan.Parse(w.T_Volta)) == 1){

                                    melhor_v = TimeSpan.Parse(w.T_Volta);
                                } //t1 is greater than t2

                                 
                                
                                vel_media += double.Parse(w.V_Media_Volta.Replace(".",","));
                                //tempo_apos = "0:0:0";
                                tempo_total += TimeSpan.Parse(w.T_Volta);
                                qtde_v++;
                                pos = 1;
                                
                            }
                            
                        
                        });
                        if (nome_melhor_volta == piloto_temp)
                        {
                            double vm = Math.Round(vel_media / qtde_v, 3);
                            f.Add(new Final("1", piloto_temp.Substring(0, 3), piloto_temp.Substring(6, (piloto_temp.Length - 6)),
                            Convert.ToString(qtde_v), Convert.ToString(tempo_total),Convert.ToString( melhor_v).Substring(3, (Convert.ToString( melhor_v).Length - 3)),
                            Convert.ToString(vm), "Vencedor", Convert.ToString(melhor_volta_corrida).Substring(3,Convert.ToString( melhor_volta_corrida).Length - 3)));

                            tempo_apos = tempo_total;
                        }
                        else
                        {
                            double vm = Math.Round(vel_media / qtde_v, 3);
                            f.Add(new Final("1", piloto_temp.Substring(0, 3), piloto_temp.Substring(6, (piloto_temp.Length - 6)),
                            Convert.ToString(qtde_v), Convert.ToString(tempo_total), Convert.ToString(melhor_v).Substring(3, (Convert.ToString(melhor_v).Length - 3)),
                            Convert.ToString(vm), "Vencedor", ""));

                            tempo_apos = tempo_total;
                        }

                       
                        int contador = 2;
                        while (contador > 0)
                        {
                            
                            
                            temp.ForEach(delegate(Pilotos p)
                            {

                                
                                if (Convert.ToInt32(p.N_Volta) == contador)
                                {
                                    piloto_temp = p.Piloto;
                                    melhor_v = TimeSpan.Parse(p.T_Volta);
                                    vel_media = 0;
                                    //tempo_apos = TimeSpan.Parse("0:0:0");
                                    tempo_total = TimeSpan.Parse("0:0:0");
                                    qtde_v = 0;
                                    pos++;

                                    
                                    temp.ForEach(delegate(Pilotos w)
                                    {
                                        if (w.Piloto == piloto_temp)
                                        {

                                            if (TimeSpan.Compare(melhor_v, TimeSpan.Parse(w.T_Volta)) == 1)
                                            {

                                                melhor_v = TimeSpan.Parse(w.T_Volta);
                                            } //t1 is greater than t2



                                            vel_media += double.Parse(w.V_Media_Volta.Replace(".", ","));
                                            //tempo_apos = "0:0:0";
                                            tempo_total += TimeSpan.Parse(w.T_Volta);
                                            qtde_v++;
                                            
                                            //temp.Remove(new Pilotos(w.Hora, w.Piloto, w.N_Volta, w.T_Volta, w.V_Media_Volta));
                                            
                                        }


                                    });

                                    if (nome_melhor_volta == piloto_temp)
                                    {
                                        


                                        double vm = Math.Round(vel_media / qtde_v, 3);
                                        f.Add(new Final(Convert.ToString(pos), piloto_temp.Substring(0, 3), piloto_temp.Substring(6, (piloto_temp.Length - 6)),
                                        Convert.ToString(qtde_v), Convert.ToString(tempo_total), Convert.ToString(melhor_v).Substring(3, (Convert.ToString(melhor_v).Length - 3)),
                                        Convert.ToString(vm), Convert.ToString(tempo_apos - tempo_total).Substring(3, (Convert.ToString(tempo_total).Length - 3)), Convert.ToString(melhor_volta_corrida).Substring(3, Convert.ToString(melhor_volta_corrida).Length - 3)));

                                    }
                                    else
                                    {


                                        double vm = Math.Round(vel_media / qtde_v, 3);
                                        f.Add(new Final(Convert.ToString(pos), piloto_temp.Substring(0, 3), piloto_temp.Substring(6, (piloto_temp.Length - 6)),
                                        Convert.ToString(qtde_v), Convert.ToString(tempo_total), Convert.ToString(melhor_v).Substring(3, (Convert.ToString(melhor_v).Length - 3)),
                                        Convert.ToString(vm), Convert.ToString(tempo_apos - tempo_total).Substring(3, (Convert.ToString(tempo_total).Length - 3)), ""));

                                    }

                                    

                                }
                                else
                                {

                                    contador--;
                                    
                                    
                                }

                                
                                
                            });

                            

                            
                            return;
                                 
                        }



                        
                    }
                      
                    
                });

                
            }

            catch (Exception)
            {
                //Exibe mensagem de erro em caso de falha no preenchimento
                f.Add(new Final("Erro na geração do LOG", "", "", "", "", "", "", "", ""));

            }

                 
           
            return f;


        }
    }
}
