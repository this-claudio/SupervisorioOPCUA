using System;
using System.Collections.Generic;
using System.Text;

namespace Supervisorio.Model
{
    public class GrupoMaquinas
    {
        public List<Machine> Machines { get; set; }
    }
    public class Machine
    {
        public string sNome { get; set; }
        public string sEnderecoIP { get; set; }
        public string sPorta { get; set; }
        public string sUser { get; set; }
        public string sPassword { get; set; }
        public string sEstadoConexao { get; set; }

        public List<Grupo> Grupos { get; set; }

        public override string ToString()
        {
            return sNome.ToString();
        }
    }

    public class Grupo
    {
        public string sNomeGrupo { get; set; }
        public List<Sinal> Sinais { get; set; }

        public override string ToString()
        {
            return sNomeGrupo.ToString();
        }
    }

    public class Sinal
    {
        public string sTipo { get; set; }
        public string sNomeSinal { get; set; }
        public string sEndereco { get; set; }
        public int nMin { get; set; }
        public int nMax { get; set; }
        public string sUnidade { get; set; }
        public object oValue { get; set; }

        public override string ToString()
        {
            return sNomeSinal.ToString();
        }
    }
}
