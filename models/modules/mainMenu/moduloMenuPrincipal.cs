using projetoHospedagemHotel.models;

namespace projetoHospedagemHotel.models
{
    public static class moduloMenuPrincipal
    {
        public static bool menuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Seja bem vindo ao sistema de Hospedagem!");
            Console.WriteLine("Insira a função desejada:\n" +
                    "1 - PESSOA\n" +
                    "2 - SUÍTE\n" +
                    "3 - RESERVA\n" +
                    "4 - FINALIZAR SISTEMA");
            string valor = Console.ReadLine();
            Console.Clear();

            switch (valor)
            {
                case "1":
                    moduloPessoa.FuncoesPessoas();
                    return true;

                case "2":
                    moduloSuite.FuncoesSuite();
                    return true;

                case "3":
                    moduloReserva.FuncoesReserva();
                    return true;

                case "4":
                    funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Sistema finalizado com sucesso!");
                    return false;
                default:
                    funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Red, "A função informada não é válida!");
                    return true;
            }
        }
    }
}