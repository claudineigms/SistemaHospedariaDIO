namespace projetoHospedagemHotel.models
{
    public class Suite
    {  
        public Suite(string nome, int capacidade, double valorDiaria){
            this.TipoSuite = nome;
            this.Capacidade = capacidade;
            this.ValorDiaria = valorDiaria;
            FuncoesDados.adicionarsuite(this);
        }
        
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public double ValorDiaria{ get; set; }

        public bool atualizarCapacidade(int capacidade){
           if (capacidade <= 0){
                Console.WriteLine("Favor cadastrar um valor maior que 0");
                return false;
            }
            this.Capacidade = capacidade;
            //FuncoesDados.SalvarSuites();
            return true;
        }

        public bool atualizarValorDiaria(double valor){
           if (valor <= 0){
                Console.WriteLine("Favor cadastrar um valor maior que 0");
                return false;
            }
            this.ValorDiaria = valor;
            //FuncoesDados.SalvarSuites();
            return true;
        }
    }
}