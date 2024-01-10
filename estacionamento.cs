using System;
using System.Collections.Generic;

class Estacionamento
{
    private decimal precoInicial;
    private decimal precoPorHora;
    private List<string> veiculos;

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
        this.veiculos = new List<string>();
    }

    public void AdicionarVeiculo()
    {
        Console.Write("Digite a placa do veículo: ");
        string placa = Console.ReadLine();
        veiculos.Add(placa);
        Console.WriteLine("Veículo adicionado com sucesso!");
    }

    public void RemoverVeiculo()
    {
        Console.Write("Digite a placa do veículo a ser removido: ");
        string placa = Console.ReadLine();

        if (veiculos.Contains(placa))
        {
            Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
            int horasEstacionado = int.Parse(Console.ReadLine());

            decimal valorCobrado = CalcularValorCobrado(horasEstacionado);
            Console.WriteLine($"Veículo removido. Valor cobrado: {valorCobrado:C}");

            veiculos.Remove(placa);
        }
        else
        {
            Console.WriteLine("Veículo não encontrado no estacionamento.");
        }
    }

    public void ListarVeiculos()
    {
        if (veiculos.Count == 0)
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
        else
        {
            Console.WriteLine("Veículos estacionados:");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
        }
    }

    private decimal CalcularValorCobrado(int horasEstacionado)
    {
        return precoInicial + (precoPorHora * horasEstacionado);
    }
}

class Program
{
    static void Main()
    {
        Estacionamento estacionamento = new Estacionamento(5.0m, 2.0m);

        int opcao;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Cadastrar veículo");
            Console.WriteLine("2. Remover veículo");
            Console.WriteLine("3. Listar veículos");
            Console.WriteLine("4. Encerrar");

            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    estacionamento.AdicionarVeiculo();
                    break;
                case 2:
                    estacionamento.RemoverVeiculo();
                    break;
                case 3:
                    estacionamento.ListarVeiculos();
                    break;
                case 4:
                    Console.WriteLine("Encerrando o programa.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        } while (opcao != 4);
    }
}
