class FM : Qso
{
    protected string _mode = "FM";
    protected override void setRx()
    {

        _rstRx = 0;
    }

    protected override void setTx()
    {
        _rstTx = 0;
    }

    public override string exportAdi()
    {
        string adifContent = "";

        adifContent += $"<CALL:{_callsign.Length}>{_callsign}<BAND:{_frequency.ToString().Length}>{_frequency}<MODE:{_mode.Length}>{_mode}<RST_SENT:{_rstTx.ToString().Length}>{_rstTx}<RST_RCVD:{_rstRx.ToString().Length}>{_rstRx}<QTH:{_state.Length}>{_state}<TIME_ON:15>{_date}\n";

        return adifContent;
    }
}