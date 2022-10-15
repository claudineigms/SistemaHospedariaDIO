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
                    try { funcoesMenuPrincipal.ListarSuites("Selecione a suite que deseja fazer a reserva:"); } catch { break; };
                    if (int.TryParse(Console.ReadLine(), out int suiteselecionada) && suiteselecionada > 0 && suiteselecionada <= FuncoesDados.ListaSuites.Count())
                    {
                        try { funcoesMenuPrincipal.ListarClientes("Selecione o responsável da suíte:"); }catch { break; }
                        if (int.TryParse(Console.ReadLine(), out int clienteSelecionado) && clienteSelecionado > 0 && clienteSelecionado <= FuncoesDados.ListaPessoas.Count())
                        {
                            Console.WriteLine("Informe o valor de dias a reservar:");
                            if (int.TryParse(Console.ReadLine(), out int DiasAReservar))
                            {
                                try
                                {
                                    new Reserva(FuncoesDados.ListaSuites[suiteselecionada - 1], FuncoesDados.ListaPessoas[clienteSelecionado - 1], DiasAReservar);

                                    funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Reserva Cadastrada com sucesso!");
                                }catch (ArgumentException e)
                                {
                                    funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, e.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                    }
                    break;

                case "2"://LISTA AS RESERVAS CADASTRADAS PARA ABRIR OPÇÕES
                    try { funcoesMenuPrincipal.ListarReservas("Selecione a reserva desejada:"); }catch { break; }
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
            Console.Clear();
            Console.WriteLine("Insira a função desejada:\n" +
                                "1 - ALTERAR SUITE\n" +
                                "2 - INSERIR HÓSPEDE\n" +
                                "3 - REMOVER HÓSPEDE\n" +
                                "4 - ALTERAR DIÁRIA\n" +
                                "5 - CALCULAR VALOR RESERVA\n" +
                                "6 - FECHAR RESERVA\n" +
                                "7 - EXCLUIR RESERVA\n" +
                                "8 - VOLTAR\n");
                        string valor = Console.ReadLine();
                        Console.Clear();
            
            switch (valor){
                case "1": //ALTERA A SUÍTE
                        try { funcoesMenuPrincipal.ListarSuites("Selecione a suite que deseja fazer a reserva:"); } catch { break; };
                        
                        if (int.TryParse(Console.ReadLine(), out int suiteselecionada) && suiteselecionada > 0 && suiteselecionada <= FuncoesDados.ListaSuites.Count())
                        {
                            try { reservaSelecionada.Suite = FuncoesDados.ListaSuites[suiteselecionada - 1];
                            } catch (Exception e){
                                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, e.Message);
                            }
                        }
                        else
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                        }
                    break;

                    case "2"://INSERE UMA PESSOA;
                        try { funcoesMenuPrincipal.ListarClientes("Selecione o novo hóspede:"); }catch { break; }
                        if (int.TryParse(Console.ReadLine(), out int clienteSelecionado) && clienteSelecionado > 0 && clienteSelecionado <= FuncoesDados.ListaPessoas.Count())
                        {
                            try { 
                                reservaSelecionada.CadastrarHospede(FuncoesDados.ListaPessoas[clienteSelecionado - 1]); 
                                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Hospede cadastrado com Sucesso!");
                            }catch(Exception e){
                                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, e.Message);
                            }
                        }
                        else
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                        }
                        break;

                    case "3"://REMOVER A PESSOA
                        if (reservaSelecionada.Hospedes.Count > 0){
                        Console.WriteLine("Selecione o hóspede que deseja remover:");
                        int contador = 1;
                        foreach (Pessoa Hospede in reservaSelecionada.Hospedes)
                        {
                            Console.WriteLine($"{contador} - {Hospede.nomecompleto}");
                            contador++;
                        }
                        if (int.TryParse(Console.ReadLine(), out int HospedeARemover))
                        {
                            try 
                            { 
                                reservaSelecionada.RemoverHospede(reservaSelecionada.Hospedes[HospedeARemover - 1]);
                                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Hospede removido com Sucesso!");
                            }
                            catch (Exception e){
                                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, e.Message);
                            }
                        }else
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                        }
                        }
                    break;

                    case "4"://ALTERA VALOR DIÁRIA
                        Console.WriteLine("Informe o novo valor de dias a reservar:");
                        if (int.TryParse(Console.ReadLine(), out int DiasAReservar))
                        {
                            try
                            {
                            reservaSelecionada.DiasReservados = DiasAReservar;
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Diária com sucesso!");
                            }
                            catch (ArgumentException e)
                            {
                                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, e.Message);
                            }
                        }else
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                        }
                    break;

                    case "5"://CALCULA VALOR DA RESERVA
                        Console.WriteLine($"O Valor da reserva foi de: R${reservaSelecionada.ValorReserva()}\n"+
                        "Pressione enter para voltar...");
                        if (reservaSelecionada.DiasReservados >= 10)
                        {
                        Console.WriteLine("Pela reserva possuir mais de 10 dias, foi concedido 10% de desconto");
                        }
                        Console.ReadLine();
                        Console.Clear();
                    break;

                    case "6": //FECHAR RESERVA
                        Console.WriteLine($"O Valor da reserva foi de: R${reservaSelecionada.ValorReserva()}");
                        if (reservaSelecionada.DiasReservados >= 10)
                        {
                            Console.WriteLine("Pela reserva possuir mais de 10 dias, foi concedido 10% de desconto");
                        }
                        Console.Write($"Você confirma o recebimento do valor e fechamento da reserva? [Y/N]:");
                        string resposta = Console.ReadLine();
                        if (resposta.ToLower() == "y" || resposta.ToLower() == "yes" || resposta.ToLower() == "s" || resposta.ToLower() == "sim")
                        {
                            reservaSelecionada.finalizado = true;
                            FuncoesDados.adicionarreservafechada(reservaSelecionada);
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Reserva fechada com Sucesso!");
                        }
                        else if (resposta.ToLower() == "n" || resposta.ToLower() == "no" || resposta.ToLower() == "não" || resposta.ToLower() == "nao")
                        {}else{
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Selecione uma opção válida!");
                        }
                    break;

                    case "7": //EXCLUI A RESERVA
                        FuncoesDados.removerreserva(reservaSelecionada);
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Reserva removida com sucesso!");
                    break;

                    case "8": //RETORNA
                    break;

                    default:
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "A função informada não é válida!");
                    break;

            }
        }
    }
}