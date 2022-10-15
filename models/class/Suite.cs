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

        private int _Capacidade;
        private double _ValorDiaria;

        public string TipoSuite { get; set; }
        public int Capacidade { get
            { return _Capacidade; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("A capacidade não poder ser igual ou inferior a 0");
                }
                else {
                    _Capacidade = value;
                }
            }
        }
        public double ValorDiaria{
            get { return _ValorDiaria; }
            set
            {
                if (value < 0){
                    throw new ArgumentException("O valor não pode ser inferior a 0");
                }else{
                    _ValorDiaria = value;
                }
            }
        }

        public bool atualizarCapacidade(int capacidade){
           if (capacidade <= 0){
                throw new ArgumentException("Favor cadastrar um valor maior que 0");
            }
            this.Capacidade = capacidade;
            //FuncoesDados.SalvarSuites();
            return true;
        }

        public bool atualizarValorDiaria(double valor){
           if (valor <= 0){
                throw new ArgumentException("Favor cadastrar um valor maior que 0");
            }
            this.ValorDiaria = valor;
            //FuncoesDados.SalvarSuites();
            return true;
        }
    }
}