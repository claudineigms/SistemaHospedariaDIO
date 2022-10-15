namespace projetoHospedagemHotel.models
{
    public class Reserva
    {
        public Reserva(Suite suite, Pessoa responsavel, int diarias){
            _Hospedes = new List<Pessoa>();
            Hospedes = new List<Pessoa>();
            Hospedes.Add(responsavel);
            this.Suite = suite;
            DiasReservados = diarias;
            FuncoesDados.adicionarreserva(this);
        }

        private List<Pessoa> _Hospedes;
        private Suite _Suite;
        private int _DiasReservados;

        public List<Pessoa> Hospedes{ get{return _Hospedes;} set{_Hospedes = value;} }
        public Suite Suite {
            get{
                return _Suite;
            }set{
                if (this.Suite == value){
                    throw new ArgumentException("Esta suíte ja está selecionada!");
                }
                if (Hospedes.Count() > value.Capacidade){
                    this.Hospedes = new List<Pessoa> { Hospedes[0] };
                }
                _Suite = value;
            }
        }
        public int DiasReservados{ 
            get
            {
                return _DiasReservados;
            }
            set
            {
                if (value < 0)
                {throw new ArgumentException("O valor deve ser igual ou maior que 0");
                }
                else { _DiasReservados = value; }
            }
        }
        public bool finalizado = false;

        public bool CadastrarHospede(Pessoa hospede){
            if (Suite == null){
                throw new ArgumentException("Não é possível Cadastrar um hóspede sem inserir uma Suíte");
            }else if(Hospedes.Contains(hospede)){
                throw new Exception("Esta pessoa já está cadastrada na lista!");
            }else if (this.Hospedes.Count() >= this.Suite.Capacidade){
                throw new NotSupportedException("Não é possível inserir uma pessoa pois o limite ultrapassa o tamanho");
            }else{
                Hospedes.Add(hospede);
                return true;
            }
        }

        public bool RemoverHospede(Pessoa hospede){
            if(this.Hospedes.Count() <= 0){
                throw new MissingMemberException("Não há hóspedes na lista!");
            }
            else{
                this.Hospedes.Remove(hospede);
                return true;
            }
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
                throw new Exception("Verificar o valor de dias reservado cadastrado");
            }else if(Suite == null){
                throw new Exception("É necessário que se cadastre uma suíte");
            }
            Valor = this.DiasReservados * this.Suite.ValorDiaria;

            return ((this.DiasReservados >= 10) ? (Valor *= 0.9) :(Valor));
        }
    }
}