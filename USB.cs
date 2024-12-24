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

    adifContent += $"<CALL:{_callsign.Length}>{_callsign}\n";
    adifContent += $"<BAND:{_frequency.ToString().Length}>{_frequency}\n";
    adifContent += $"<MODE:{_mode.Length}>{_mode}\n";
    adifContent += $"<STATE:{_state.Length}>{_state}\n";
    adifContent += $"<RST_SENT:{_rstTx.ToString().Length}>{_rstTx}\n";
    adifContent += $"<RST_RCVD:{_rstRx.ToString().Length}>{_rstRx}\n";
    adifContent += $"<QSO_DATE:8>{_date}\n";
    adifContent += $"<QSO_DATE_OFF:8>{_date}\n";
    adifContent += $"<TIME:{_time.Length}>{_time}\n";
    adifContent += $"<EOR>\n";

    return adifContent;
}

}