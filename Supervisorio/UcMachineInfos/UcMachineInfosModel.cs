using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UcMachineInfosModel
{
    public class GrupoSinais
    {
        
        public string sGrupoName { get; set;}
        public List<Panel> oSinaisComponentesVisuais { get; set; }

        public GrupoSinais(string sName)
        {
            this.sGrupoName = sName;
            this.oSinaisComponentesVisuais = new List<Panel>();
        }

        public void AddComponente(Panel oComponente)
        {
            this.oSinaisComponentesVisuais.Add(oComponente);
        }
    }

    
   
}
