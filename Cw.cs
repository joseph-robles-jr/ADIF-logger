class Cw : Qso
{
    protected override void setRx()
    {
        Console.Write("what is the other station's 3 digit RST (i.e 599) : ");
        string input = Console.ReadLine();
        int firstTwoChars = int.Parse(input.Length >= 2 ? input.Substring(0, 3) : input); //takes first to characters. If it is shorter than 2, take the whole input.
        _rstRx = firstTwoChars;
    }

    protected override void setTx()
    {
        Console.Write("what is the your station's 3 digit RST (i.e 599) : ");
        string input = Console.ReadLine();
        int firstTwoChars = int.Parse(input.Length >= 2 ? input.Substring(0, 3) : input); //takes first to characters. If it is shorter than 2, take the whole input.
        _rstTx = firstTwoChars;
    }
}