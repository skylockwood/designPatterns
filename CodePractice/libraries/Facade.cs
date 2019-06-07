using System;

class Bank{
    public bool HasSuffienctFunds(Customer c, int amount){
        Console.WriteLine("Checking Bank of " + c.Name);
        return true;
    }
}

class Credit{
    public bool HasGoodCredit(Customer c){
        Console.WriteLine("Gathering Credit Report of " + c.Name);
        return true;
    }

}

class Loan{
    public bool HasNoBadLoans(Customer c){
        Console.WriteLine("Checking Loan History for " + c.Name);
        return true;
    }
}

class Customer{
    private string _name;

    public Customer(string name){
        this._name = name;
    }

    public string Name{
        get{
            return _name;
        }
    }
}

class Mortgage{
    private Bank _bank = new Bank();
    private Credit _credit = new Credit();
    private Loan _loan = new Loan();

    public bool IsElligable(Customer c, int amount){
        Console.WriteLine(c.Name + " is applying for a mortgage of $" + amount);
        bool elligable = true;

        if(!_bank.HasSuffienctFunds(c,amount/10)){
            elligable = false;
        }

        if(!_credit.HasGoodCredit(c)){
            elligable = false;
        }

        if(!_loan.HasNoBadLoans(c)){
            elligable = false;
        }
        return elligable;
    }
}