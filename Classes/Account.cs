using System;

namespace DIO.Bank
{
    public class Account
    {
        private string Name { get; set; }
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }

        public Account(string Name, AccountType AccountType, double Balance, double Credit)
        {
            this.Name = Name;
            this.AccountType = AccountType;
            this.Balance = Balance;
            this.Credit = Credit;
        }

        public bool Withdraw(double withdrawValue)
        {
            if ((this.Balance - withdrawValue) < (this.Credit * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Balance -= withdrawValue;
            Console.WriteLine("Saldo atual da conta de {0} é: R$ {1}", this.Name, this.Balance);

            return true;
        }

        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;
            Console.WriteLine("Saldo atual da conta de {0} é: R$ {1}", this.Name, this.Balance);
        }

        public void Transfer(double transferValue, Account targetAccount)
        {
            if (this.Withdraw(transferValue))
            {
                targetAccount.Deposit(transferValue);
            }
        }

        public override string ToString()
        {
            string rtrn = "";
            rtrn += "Tipo de Conta: " + this.AccountType + " | ";
            rtrn += "Nome do Titular: " + this.Name + " | ";
            rtrn += "Saldo em Conta: " + this.Balance + " | ";
            rtrn += "Crédito Disponível: " + this.Credit + " | ";
            return rtrn;

        }
    }
}