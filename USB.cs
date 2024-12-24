class USB : Qso
{
    private string _mode = "USB";
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

    public override string exportAdi()
{
    string adifContent = "";

    adifContent += $"<CALL:{_callsign.Length}>{_callsign}<BAND:{_frequency.ToString().Length}>{_frequency}<MODE:{_mode.Length}>{_mode}<RST_SENT:{_rstTx.ToString().Length}>{_rstTx}<RST_RCVD:{_rstRx.ToString().Length}>{_rstRx}<QTH:{_state.Length}>{_state}<TIME_ON:15>{_date}<EOR>\n";

    return adifContent;
}

}