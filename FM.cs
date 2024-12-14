class FM : Qso
{
    protected override void setRx()
    {

        _rstRx = 0;
    }

    protected override void setTx()
    {
        _rstTx = 0;
    }
}