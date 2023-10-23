using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Serializacao_e_Deserializacao
{
    [DataContract]
    internal class Cachorro
    {
        [DataMember] //membros da classe
        public string Nome {  get; set; }
        [DataMember]
        public string Raca { get; set; }
        [DataMember]

        private string Cor;

        public Cachorro(string pnome, string praca, string pcor)
        {
            this.Nome = pnome;
            this.Raca = praca;
            this.Cor = pcor;
        }

        //construtor padrão
        public Cachorro()
        {

        }
    }
}
