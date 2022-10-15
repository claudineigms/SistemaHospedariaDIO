using projetoHospedagemHotel.models;

namespace projetoHospedagemHotel.models
{
    public static class moduloPessoa
    {
        public static void FuncoesPessoas()
        {
            Console.WriteLine("Insira a função desejada:\n" +
                                "1 - Cadastrar Pessoa\n" +
                                "2 - Remover Pessoa\n" +
                                "3 - Voltar");
            string valor = Console.ReadLine();
            Console.Clear();

            switch (valor)
            {
                case "1": //Cadastra uma pessoa
                    Console.Write("Insira o nome da pessoa\nNome:");
                    string nome = Console.ReadLine();
                    if (nome == "")
                    {
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                        break;
                    }
                    Console.Write("Insira o sobrenome da pessoa\nSobrenome:");
                    string sobrenome = Console.ReadLine();
                    if (sobrenome == "")
                    {
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                        break;
                    }
                    new Pessoa(nome, sobrenome);
                    Console.Clear();
                    break;

                case "2": //Remove uma pessoa
                    try { funcoesMenuPrincipal.ListarClientes("Informe o cliente que deseja remover:"); }catch { break; };
                    if (int.TryParse(Console.ReadLine(), out int clientearemover))
                        {
                            try
                            {
                                FuncoesDados.removerpessoa(FuncoesDados.ListaPessoas[clientearemover - 1]);
                                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Pessoa removida com sucesso!");
                            }
                            catch
                            {
                                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Pessoa Inválida");
                            }
                        }
                        else
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                        }
                    break;

                case "3": //Volta ao Menu Principal
                    break;

                default:
                    funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "A função informada não é válida!");
                    break;
            }
        }
    }
}