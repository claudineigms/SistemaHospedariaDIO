namespace projetoHospedagemHotel.models
{
    public static class moduloReserva
    {
        public static void FuncoesReserva()
        {

            Console.WriteLine("Insira o grupo desejada:\n" +
                    "1 - CADASTRAR RESERVA\n" +
                    "2 - SELECIONAR RESERVA\n" +
                    "3 - VOLTAR");
            string valor = Console.ReadLine();
            Console.Clear();

            switch (valor)
            {
                case "1": //INICIA UMA NOVA RESERVA 
                    funcoesMenuPrincipal.ListarSuites("Selecione a suite que deseja fazer a reserva:");
                    if (int.TryParse(Console.ReadLine(), out int suiteselecionada))
                    {
                        // try
                        // {
                            funcoesMenuPrincipal.ListarClientes("Selecione o responsável da suíte:");
                            if (int.TryParse(Console.ReadLine(), out int clienteSelecionado))
                            {
                                // try
                                // {
                                    new Reserva(FuncoesDados.ListaSuites[suiteselecionada - 1], FuncoesDados.ListaPessoas[clienteSelecionado - 1]);
                            Console.Write(FuncoesDados.ListaReservas[0].Hospedes[0].nomecompleto);
                            Console.ReadLine();
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Reserva Cadastrada com sucesso!");
                                // }
                                // catch
                                // {
                                //     funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Cliente Invalido");
                                // }
                            }
                            else
                            {
                                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                            }
                        // }
                        // catch
                        // {
                        //     funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Suite Inválida");
                        // }
                    }
                    else
                    {
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                    }
                    break;

                case "2"://LISTA AS RESERVAS CADASTRADAS PARA ABRIR OPÇÕES
                    funcoesMenuPrincipal.ListarReservas("Selecione a reserva desejada:");
                    if (int.TryParse(Console.ReadLine(), out int reservaselecionada))
                    {
                        try
                        {
                            FuncoesReservaSelecionada(FuncoesDados.ListaReservas[reservaselecionada - 1]);
                        }
                        catch
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Reserva Inválida");
                        }
                    }
                    else
                    {
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                    }
                    break;

                case "3":
                    break;//RETORNA
    
                default:
                    funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "A função informada não é válida!");
                    break;
            }
        }

        public static void FuncoesReservaSelecionada(Reserva reservaSelecionada)
        { 

        }
    }
}