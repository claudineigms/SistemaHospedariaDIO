using projetoHospedagemHotel.models;

//FuncoesDados.LerArquivos();

Pessoa testepessoa = new Pessoa("Claudinei", "Gomes");
Suite testesuite = new Suite("Master", 1, 100.00f);
Reserva testereserva = new Reserva(testesuite, testepessoa, 10);
while(moduloMenuPrincipal.menuPrincipal()){
}

//FuncoesDados.salvardados();
funcoesMenuPrincipal.FuncaoInformacao(ConsoleColor.Green, "Sistema finalizado com sucesso!");