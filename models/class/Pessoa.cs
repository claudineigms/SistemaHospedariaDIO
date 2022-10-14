namespace projetoHospedagemHotel.models
{
    public class Pessoa
    {

        public Pessoa(string nome, string sobrenome){
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            FuncoesDados.adicionarpessoa(this);
        }
        
        public string Nome{ get; set; }
        public string Sobrenome{ get; set; }
        public string nomecompleto {
            get{
                return Nome + " " + Sobrenome;
            }
        }
    }
}