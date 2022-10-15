namespace projetoHospedagemHotel.models{
    public static class moduloSuite{
        public static void FuncoesSuite(){
            Console.WriteLine("Insira a função desejada:\n" +
                                "1 - Cadastrar Suite\n" +
                                "2 - Alterar capacidade\n" +
                                "3 - Alterar valor\n" +
                                "4 - Remover Suite\n" +
                                "5 - Voltar");
            string valor = Console.ReadLine();
            Console.Clear();

            switch (valor)
            { 
                case "1": //Cadastra uma Suite
                    Console.Write("Insira o nome da Suite\nNome:");
                    string nome = Console.ReadLine();
                    if (nome == "")
                    { funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                        break;
                    }
                    Console.Write("Insira a capacidade da Suíte\nCapacidade:");
                    if (!int.TryParse(Console.ReadLine(), out int capacidade))
                    { funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                        break;
                    }
                    Console.Write("Insira o valor da diária da Suíte\nValor:");
                    valor = Console.ReadLine().Replace(",", ".");
                    if (!double.TryParse(valor, out double valorSuite))
                    { funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                        break;
                    }

                    try
                    {
                        new Suite(nome, capacidade, Math.Round(valorSuite, 2));
                    } catch(Exception e){
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, e.Message);
                    }
                    Console.Clear();
                    break;

                case "2": //Altera a capacidade
                    try { funcoesMenuPrincipal.ListarSuites("Informe A suite que deseja remover:"); }catch { break;}

                    if (int.TryParse(Console.ReadLine(), out int suiteaalterarcapacidade))
                    {
                        Console.Write("Insira a nova capacidade da Suíte\nCapacidade:");
                        if (!int.TryParse(Console.ReadLine(), out int novacapacidade))
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                            break;
                        }
                        try
                        {
                            FuncoesDados.ListaSuites[suiteaalterarcapacidade - 1].atualizarCapacidade(novacapacidade);
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Capacidade alterada com sucesso!");
                        }
                        catch (Exception e)
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, e.Message);
                        }
                    }
                    else
                    {
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                    }
                    break;

                case "3": //Altera o valor
                    try { funcoesMenuPrincipal.ListarSuites("Informe A suite que deseja remover:"); }catch { break; }

                    if (int.TryParse(Console.ReadLine(), out int suiteaalterarvalor))
                    {
                        Console.Write("Insira o valor da diária da Suíte\nValor:");
                        valor = Console.ReadLine().Replace(",", ".");
                        if (!double.TryParse(valor, out double novovalorSuite))
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                            break;
                        }

                        try
                        {
                            FuncoesDados.ListaSuites[suiteaalterarvalor - 1].atualizarValorDiaria(novovalorSuite);
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Valor atualizado com sucesso!");
                        }
                        catch(Exception e)
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, e.Message);
                        }
                    }
                    else
                    {
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                    }
                    break;
                
                case "4": //Remove a Suite
                    try { funcoesMenuPrincipal.ListarSuites("Informe A suite que deseja remover:"); }catch { break; }

                    if (int.TryParse(Console.ReadLine(), out int suitearemover))
                    {
                        try
                        {
                            FuncoesDados.removersuite(FuncoesDados.ListaSuites[suitearemover - 1]);
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Suite removida com sucesso!");
                        }
                        catch
                        {
                            funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Suite Inválida");
                        }
                    }
                    else
                    {
                        funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Erro! Digite um valor Válido");
                    }
                    break;

                case "5":
                    break;

                default:
                    funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "A função informada não é válida!");
                    break;
            }

        }
    }
}