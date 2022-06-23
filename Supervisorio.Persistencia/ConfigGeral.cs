using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Supervisorio.Model;

namespace Supervisorio.Persistencia
{
    public class ConfigGeralPersistence
    {

        public GrupoMaquinas GetParametros()
        {
            GrupoMaquinas ConfigParametros = new GrupoMaquinas();
            ConfigParametros = null;
            using (StreamReader oFile = new StreamReader("./ConfigGeral.xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(GrupoMaquinas));
                ConfigParametros = (GrupoMaquinas)xml.Deserialize(oFile);
            }

            return ConfigParametros;
        }

        public List<Sinal> GetSinalByEndereco(Machine oDados, string sEndereco)
        {
            var result = new List<Sinal>();
            foreach (Grupo Grupo in oDados.Grupos)
            {
                if (Grupo != null)
                    foreach (Sinal Sinal in Grupo.Sinais)
                    {
                        if (Sinal != null)
                        {
                            if (Sinal.sEndereco == sEndereco) result.Add(Sinal);
                        }
                    }
            }
            return result;

        }
        
    }
}
