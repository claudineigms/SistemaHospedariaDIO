namespace projetoHospedagemHotel.models
{
    public class Reserva
    {
        public Reserva(Suite suite, Pessoa responsavel){
            Hospedes = new List<Pessoa>(1);
            Hospedes.Add(responsavel);
            this.Suite = suite;
            DiasReservados = 0;
            FuncoesDados.adicionarreserva(this);
        }

        public List<Pessoa> Hospedes{ get; set; }
        private Suite _Suite;
        public Suite Suite {
            get
            {
                return _Suite;
            }
            set
            {
                _Suite = value;
            }
        }
        public int DiasReservados { get; set; }

        public bool CadastrarHospede(Pessoa hospede){
            if (Suite == null){
                Console.WriteLine("Não é possível Cadastrar um hóspede sem inserir uma Suíte");
                return false;
            }else if (this.Hospedes.Count() <= Suite.Capacidade){
                Console.WriteLine("Não é possível inserir uma pessoa pois o limite ultrapassa o tamanho");
                return false;
            }else{
                Hospedes.Add(hospede);
                return true;
            }
        }

        public bool CadastrarDias(int dias){
            if (dias <= 0){
                Console.WriteLine("Favor cadastrar um valor maior que 0");
                return false;
            }
            this.DiasReservados = dias;
            return true;
        }

        public int RetornarCapacidade(){
            int valor = Suite.Capacidade;
            return valor;
        }

        public int QuantidadeHospedes()
        {

            int contador = 0;
            try
            {
                contador = Hospedes.Count();
            }
            catch (Exception)
            {
                contador = 0;
            }
            return contador;
        }

        /// <summary>
        /// Caso a reserva possua o número igual ou maior que 10 diárias é concedido a taxa de 10% de desconto) 
        /// </summary>
        public double ValorReserva(){
            double Valor = 0.00f;
            if (this.DiasReservados <= 0){
                Console.WriteLine("Verificar o valor de dias reservado cadastrado");
            }else if(Suite != null){
                Console.WriteLine("É necessário que se cadastre uma suíte");
            }
            Valor = this.DiasReservados * this.Suite.ValorDiaria;

            return ((this.DiasReservados >= 10) ? (Valor *= 0.9) :(Valor));
        }
    }
}