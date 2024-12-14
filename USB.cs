class USB : Qso
{
    protected override void setRx()
    {
        Console.Write("what is the other station's RST (i.e 59) : ");
        string input = Console.ReadLine();

        int firstTwoChars = int.Parse(input.Length >= 2 ? input.Substring(0, 2) : input); //takes first to characters. If it is shorter than 2, take the whole input.
        _rstRx = firstTwoChars;

    }

    protected override void setTx()
    {
        Console.Write("what is the your station's RST (i.e 59) : ");
        string input = Console.ReadLine();
        int firstTwoChars = int.Parse(input.Length >= 2 ? input.Substring(0, 2) : input); //takes first to characters. If it is shorter than 2, take the whole input.
        _rstTx = firstTwoChars;

    }
}