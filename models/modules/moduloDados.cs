using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace projetoHospedagemHotel.models
{
    public static class FuncoesDados
    {
        public static List<Pessoa> ListaPessoas = new List<Pessoa>();
        public static List<Suite> ListaSuites = new List<Suite>();
        public static List<Reserva> ListaReservas = new List<Reserva>();
        public static List<Reserva> ListaReservasFechadas = new List<Reserva>();

        public static void VerificarArquivos(){
            if (!File.Exists("files/pessoas.json")){
                File.Create("files/pessoas.json").Close();
            }
            if (!File.Exists("files/suites.json")){
                File.Create("files/suites.json").Close();
            }
            if (!File.Exists("files/reserva.json")){
                File.Create("files/reserva.json").Close();
            }
        }

        public static void LerArquivos()
        {
            VerificarArquivos();
            
            if (File.ReadAllText("files/pessoas.json") != "")
            {
                ListaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>(File.ReadAllText("files/pessoas.json"));
            }
            if (File.ReadAllText("files/suites.json") != "")
            {
                ListaSuites = JsonConvert.DeserializeObject<List<Suite>>(File.ReadAllText("files/suites.json"));
            }
            if (File.ReadAllText("files/reserva.json") != "")
            {
                ListaReservas = JsonConvert.DeserializeObject<List<Reserva>>(File.ReadAllText("files/reserva.json"));
            }
        }

        public static void salvardados(){
            FuncoesDados.salvarpessoas();
            FuncoesDados.SalvarSuites();
            FuncoesDados.salvarReserva();
        }

        public static void salvarpessoas(){
            string pessoas = JsonConvert.SerializeObject(ListaPessoas,Formatting.Indented);
            File.Delete("files/pessoas.json");
            File.WriteAllText("files/pessoas.json",pessoas);
        }

        public static void salvarReserva(){
            string reserva = JsonConvert.SerializeObject(ListaReservas,Formatting.Indented);
            Console.WriteLine(reserva);
            Console.ReadLine();
            File.Delete("files/reserva.json");
            File.WriteAllText("files/reserva.json",reserva);
        }

        public static void SalvarSuites(){
            string suites = JsonConvert.SerializeObject(ListaSuites,Formatting.Indented);
            File.Delete("files/suites.json");
            File.WriteAllText("files/suites.json",suites);
        }

        public static void adicionarpessoa(Pessoa p){
            ListaPessoas.Add(p);
            //salvarpessoas();
        }

        public static void removerpessoa(Pessoa p){
            ListaPessoas.Remove(p);
            //salvarpessoas();
        }

        public static void adicionarreservafechada(Reserva r){
            ListaReservas.Remove(r);
            ListaReservasFechadas.Add(r);
            //salvarReserva();
        }

        public static void adicionarreserva(Reserva r){
            ListaReservas.Add(r);
            //salvarReserva();
        }

        public static void removerreserva(Reserva r){
            ListaReservas.Remove(r);
            //salvarReserva();
        }

        public static void adicionarsuite(Suite s){
            ListaSuites.Add(s);
            //SalvarSuites();
        }

        public static void removersuite(Suite s){
            ListaSuites.Remove(s);
            //SalvarSuites();
        }
    }
}