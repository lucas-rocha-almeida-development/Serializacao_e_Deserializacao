using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;


namespace Serializacao_e_Deserializacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //objeto da class que será serealizada
            Cachorro meuCachorro = new Cachorro("Lobinho","Husky-Siberiano","Branco&Preto");
            Cachorro meuCachorroDesserializado;

            DataContractSerializer serializador = new DataContractSerializer(typeof(Cachorro));
            //Serealização 
            XmlWriterSettings xmlConfig = new XmlWriterSettings {Indent=true };//mantenha o codigo organizado
            StringBuilder construtorDeString = new StringBuilder();//escreva em formato de string
            XmlWriter escrevaNoFormatoXml = XmlWriter.Create(construtorDeString, xmlConfig);
            serializador.WriteObject(escrevaNoFormatoXml, meuCachorro);//escreva um objeto cachorro e transforme em XML
            escrevaNoFormatoXml.Flush();//FINALIZAÇÃO DA ESCRITA XML ( CONVERSÃO ENCERRADA)
            string objetoserializadoSrt = construtorDeString.ToString();

            //salvando o conteudo do objeto em um xml
            string caminhodomeuArquivoXml = "Cachorro.xml";
            FileStream meuArquivoXml = File.Create(caminhodomeuArquivoXml);
            meuArquivoXml.Close();
            File.WriteAllText(caminhodomeuArquivoXml, objetoserializadoSrt);

            //Desserializar //PEGAR O ARQUIVO XML E TRANSFORMA EM UM OBJETO (INVERSO)

            string conteudoDoObjSerializado = File.ReadAllText(caminhodomeuArquivoXml);//
            StringReader LeitorDeString = new StringReader(conteudoDoObjSerializado);//leia o conteudo do arquivo.xml
            XmlReader LeitorDeXml = XmlReader.Create(LeitorDeString);
            meuCachorroDesserializado = (Cachorro)serializador.ReadObject(LeitorDeXml);

            escrevaNoFormatoXml.Close();
            LeitorDeXml.Close();
        }
    }
}
