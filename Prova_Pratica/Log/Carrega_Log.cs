using System;
using Piloto;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public class Carrega_Log
    {
        public List<Pilotos> Retorna_Log()
        {
            // Criando uma lista para ser preenchida com objetos Pilotos
            List<Pilotos> p;           
            p = new List<Pilotos>();

            //Gravando o arquivo de LOG da corrida
            try
            {
                StreamReader stream = new StreamReader("Log_Corrida.csv");

                string linha = null;
                while ((linha = stream.ReadLine()) != null)
                {
                    string[] coluna = linha.Split(';');

                    p.Add(new Pilotos(coluna[0], coluna[1], coluna[2], coluna[3], coluna[4]));

                }

                stream.Close(); 
            }
            catch (Exception)
            {

                p.Add(new Pilotos("Erro na gravação do arquivo de LOG","","","",""));

            }
            
            return p;
        }
    }
}
