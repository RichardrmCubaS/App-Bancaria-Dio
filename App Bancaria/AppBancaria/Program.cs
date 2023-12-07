using System;
using System.Collections.Generic;

namespace AppBancaria
{
	class Program
	{
		static List<Conta> listContas = new List<Conta>();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.Clear();
			Console.WriteLine("******************************************");
			Console.WriteLine("* Obrigado por utilizar nossos serviços. *");
			Console.WriteLine("******************************************");
			Console.ReadLine();
		}

		private static void Depositar()
		{
			Console.Clear();
			Console.WriteLine("-------------------------------------------");
			Console.Write("- Digite seu número da conta => ");
			int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------------------------");

			Console.Write("Digite o valor a ser depositado => ");
			double valorDeposito = double.Parse(Console.ReadLine());
			Console.WriteLine("-------------------------------------------");

            listContas[indiceConta].Depositar(valorDeposito);
			Console.WriteLine("     Presione  uma tecla para Continuar    ");
			Console.WriteLine("-------------------------------------------");
			Console.ReadLine();
		}

		private static void Sacar()
		{
			Console.Clear();
			Console.WriteLine("===========================================");
			Console.Write("Digite seu número da conta => ");
			int indiceConta = int.Parse(Console.ReadLine());
			Console.WriteLine("===========================================");

			Console.Write("Digite o valor a ser sacado => ");
			double valorSaque = double.Parse(Console.ReadLine());
			Console.WriteLine("===========================================");

            listContas[indiceConta].Sacar(valorSaque);
			Console.WriteLine("     Presione  uma tecla para Continuar    ");
			Console.WriteLine("-------------------------------------------");
			Console.ReadLine();
		}

		private static void Transferir()
		{
			
			Console.Clear();
			Console.WriteLine("*******************************************");
			Console.Write("Digite o número da conta de origem => ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());
			Console.WriteLine("*******************************************");

            Console.Write("Digite o número da conta de destino=> ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.WriteLine("*******************************************");
			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());
            Console.WriteLine("*******************************************");

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
			Console.WriteLine("     Presione  uma tecla para Continuar    ");
			Console.WriteLine("-------------------------------------------");
			Console.ReadLine();

		}

		private static void InserirConta()
		{
			Console.Clear();
			Console.WriteLine("-------------------------------------------");
			Console.WriteLine("            Inserir nova conta             ");
			Console.WriteLine("-------------------------------------------");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica => ");
			int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------------------------");

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();
			Console.WriteLine("-------------------------------------------");

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());
			Console.WriteLine("-------------------------------------------");

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());
			Console.WriteLine("-------------------------------------------");

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome);

			listContas.Add(novaConta);
			Console.WriteLine("     Presione  uma tecla para Continuar    ");
			Console.WriteLine("-------------------------------------------");
			Console.ReadLine();
			return;
		}

		private static void ListarContas()
		{
			Console.Clear();

			Console.WriteLine("===========================================");
			Console.WriteLine("              Listar contas                ");
			Console.WriteLine("===========================================");
			if (listContas.Count == 0)
			{
				Console.WriteLine("===========================================");
				Console.WriteLine("         Nenhuma conta cadastrada.         ");
				Console.WriteLine("     Presione  uma tecla para Continuar    ");
				Console.WriteLine("===========================================");
				Console.ReadLine();
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.WriteLine("");
				Console.Write("#{0} - ", i);
				Console.WriteLine("===================================================================");
				Console.WriteLine(conta);
				Console.WriteLine("===================================================================");
			}
			Console.WriteLine("     Presione  uma tecla para Continuar    ");
			Console.WriteLine("===========================================");
			Console.ReadLine();
		}

		private static string ObterOpcaoUsuario()
		{
			Console.Clear();
			Console.WriteLine();
			
			Console.WriteLine("*******************************************");
			Console.WriteLine("                 APP BANCARIA              ");
			Console.WriteLine("          Escolha a opção desejada:        ");
			Console.WriteLine("*******************************************");
			Console.WriteLine("           1- Listar contas                ");
			Console.WriteLine("           2- Inserir nova conta           ");
			Console.WriteLine("           3- Transferir Dinheiro          ");
			Console.WriteLine("           4- Sacar Dinheiro               ");
			Console.WriteLine("           5- Depositar Dinheiro           ");
            Console.WriteLine("           C- Limpar Tela                  ");
			Console.WriteLine("           X- Sair do App                  ");
			Console.WriteLine();
			Console.WriteLine("*******************************************");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
