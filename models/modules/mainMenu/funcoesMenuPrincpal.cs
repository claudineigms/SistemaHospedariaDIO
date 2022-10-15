namespace projetoHospedagemHotel.models
{
    public static class funcoesMenuPrincipal
    {
        
        public static void FuncaoInformacao(ConsoleColor cor, string texto)
        {
            Console.Clear();
            Console.ForegroundColor = cor;
            Console.WriteLine(texto);
            Console.ResetColor();
            Console.WriteLine("Pressione enter para continuar");
            Console.ReadLine();
            Console.Clear();
        }

        public static void ListarClientes(string texto)
        {
            if (FuncoesDados.ListaPessoas.Count() > 0)
            {
                Console.WriteLine(texto);
                int contador = 1;
                foreach (Pessoa hospede in FuncoesDados.ListaPessoas)
                {
                    Console.WriteLine($"{contador} - {hospede.nomecompleto}");
                    contador++;
                }
            }
            else
            {
                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Não há clientes listados!");
                throw new NullReferenceException();
            }
        }

        public static void ListarSuites(string texto)
        {
            if (FuncoesDados.ListaSuites.Count() > 0)
            {
                Console.WriteLine(texto);
                int contador = 1;
                foreach (Suite suite in FuncoesDados.ListaSuites)
                {
                    Console.WriteLine($"{contador} - {suite.TipoSuite} | Capacidade: {suite.Capacidade} | Valor da diária: {suite.ValorDiaria}");
                    contador++;
                }
            }
            else
            {
                funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Não há suites listadas!");
                throw new NullReferenceException();
            }
        }

        public static void ListarReservas(string texto)
        {
            {
                if (FuncoesDados.ListaReservas.Count() > 0)
                {
                    Console.WriteLine(texto);
                    int contador = 1;
                    foreach (Reserva reserva in FuncoesDados.ListaReservas)
                    {
                        string Hospedes = Convert.ToString(reserva.QuantidadeHospedes());
                        string Responsavel = "";
                        if (reserva.Hospedes.Count > 0)
                        { Responsavel = reserva.Hospedes[0].nomecompleto; }
                        Console.WriteLine($"{contador} - Suite: {reserva.Suite.TipoSuite} | Responsável: {Responsavel} | Capacidade: {reserva.Suite.Capacidade} | Hospedes: {Hospedes} | Diárias: {reserva.DiasReservados}");
                        contador++;
                    }
                }
                else
                {
                    funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "Não há suites listadas!");
                    throw new NullReferenceException();
                }
            }
        }
    }
}