using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Account> accountList = new List<Account>();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccounts();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }
        }

        private static void Transfer()
        {
            Console.WriteLine();
            Console.WriteLine("TRANSFERIR");
            Console.WriteLine();
            Console.WriteLine("Digite o número da conta de origem: ");
            int originalAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino: ");
            int targetAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double transferValue = double.Parse(Console.ReadLine());

            accountList[originalAccount].Transfer(transferValue, accountList[targetAccount]);


        }

        private static void Deposit()
        {
            Console.WriteLine();
            Console.WriteLine("DEPOSITAR");
            Console.WriteLine();
            Console.WriteLine("Digite o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do depósito: ");
            double depositValue = double.Parse(Console.ReadLine());

            accountList[accountIndex].Deposit(depositValue);
        }

        private static void Withdraw()
        {
            Console.WriteLine();
            Console.WriteLine("SACAR");
            Console.WriteLine();
            Console.WriteLine("Digite o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do saque: ");
            double withdrawValue = double.Parse(Console.ReadLine());

            accountList[accountIndex].Withdraw(withdrawValue);
        }

        private static void ListAccounts()
        {
            Console.WriteLine();
            Console.WriteLine("LISTAR CONTAS");

            if (accountList.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < accountList.Count; i++)
            {
                Console.WriteLine();
                Account account = accountList[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static void InsertAccounts()
        {
            Console.WriteLine();
            Console.WriteLine("ABRIR CONTA");
            Console.WriteLine("Informe o Tipo de Conta (1-Pessoa Física, 2-Pessoa Jurídica):");
            int accountTypeInput = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Informe o Nome do Cliente:");
            string nameInput = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Informe o Saldo Inicial:");
            double balanceInput = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Informe o Valor de Crédito:");
            double creditInput = double.Parse(Console.ReadLine());

            Account newAccount = new Account(Name: nameInput, AccountType: (AccountType)accountTypeInput, Balance: balanceInput, Credit: creditInput);
            accountList.Add(newAccount);

        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Abrir Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
