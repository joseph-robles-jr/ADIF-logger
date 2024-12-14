abstract class Qso
{

    protected Dictionary<string, string[]> _stateCodes = new Dictionary<string, string[]>
{
    { "Alabama", new string[] { "AL", "al", "Al", "aL", "Alabama", "alabama" } },
    { "Alaska", new string[] { "AK", "ak", "Ak", "aK", "Alaska", "alaska" } },
    { "Arizona", new string[] { "AZ", "az", "Az", "aZ", "Arizona", "arizona" } },
    { "Arkansas", new string[] { "AR", "ar", "Ar", "aR", "Arkansas", "arkansas" } },
    { "California", new string[] { "CA", "ca", "Ca", "cA", "California", "california" } },
    { "Colorado", new string[] { "CO", "co", "Co", "cO", "Colorado", "colorado" } },
    { "Connecticut", new string[] { "CT", "ct", "Ct", "cT", "Connecticut", "connecticut" } },
    { "Delaware", new string[] { "DE", "de", "De", "dE", "Delaware", "delaware" } },
    { "Florida", new string[] { "FL", "fl", "Fl", "fL", "Florida", "florida" } },
    { "Georgia", new string[] { "GA", "ga", "Ga", "gA", "Georgia", "georgia" } },
    { "Hawaii", new string[] { "HI", "hi", "Hi", "hI", "Hawaii", "hawaii" } },
    { "Idaho", new string[] { "ID", "id", "Id", "iD", "Idaho", "idaho" } },
    { "Illinois", new string[] { "IL", "il", "Il", "iL", "Illinois", "illinois" } },
    { "Indiana", new string[] { "IN", "in", "In", "iN", "Indiana", "indiana" } },
    { "Iowa", new string[] { "IA", "ia", "Ia", "iA", "Iowa", "iowa" } },
    { "Kansas", new string[] { "KS", "ks", "Ks", "kS", "Kansas", "kansas" } },
    { "Kentucky", new string[] { "KY", "ky", "Ky", "kY", "Kentucky", "kentucky" } },
    { "Louisiana", new string[] { "LA", "la", "La", "lA", "Louisiana", "louisiana" } },
    { "Maine", new string[] { "ME", "me", "Me", "mE", "Maine", "maine" } },
    { "Maryland", new string[] { "MD", "md", "Md", "mD", "Maryland", "maryland" } },
    { "Massachusetts", new string[] { "MA", "ma", "Ma", "mA", "Massachusetts", "massachusetts" } },
    { "Michigan", new string[] { "MI", "mi", "Mi", "mI", "Michigan", "michigan" } },
    { "Minnesota", new string[] { "MN", "mn", "Mn", "mN", "Minnesota", "minnesota" } },
    { "Mississippi", new string[] { "MS", "ms", "Ms", "mS", "Mississippi", "mississippi" } },
    { "Missouri", new string[] { "MO", "mo", "Mo", "mO", "Missouri", "missouri" } },
    { "Montana", new string[] { "MT", "mt", "Mt", "mT", "Montana", "montana" } },
    { "Nebraska", new string[] { "NE", "ne", "Ne", "nE", "Nebraska", "nebraska" } },
    { "Nevada", new string[] { "NV", "nv", "Nv", "nV", "Nevada", "nevada" } },
    { "New Hampshire", new string[] { "NH", "nh", "Nh", "nH", "New Hampshire", "new hampshire" } },
    { "New Jersey", new string[] { "NJ", "nj", "Nj", "nJ", "New Jersey", "new jersey" } },
    { "New Mexico", new string[] { "NM", "nm", "Nm", "nM", "New Mexico", "new mexico" } },
    { "New York", new string[] { "NY", "ny", "Ny", "nY", "New York", "new york" } },
    { "North Carolina", new string[] { "NC", "nc", "Nc", "nC", "North Carolina", "north carolina" } },
    { "North Dakota", new string[] { "ND", "nd", "Nd", "nD", "North Dakota", "north dakota" } },
    { "Ohio", new string[] { "OH", "oh", "Oh", "oH", "Ohio", "ohio" } },
    { "Oklahoma", new string[] { "OK", "ok", "Ok", "oK", "Oklahoma", "oklahoma" } },
    { "Oregon", new string[] { "OR", "or", "Or", "oR", "Oregon", "oregon" } },
    { "Pennsylvania", new string[] { "PA", "pa", "Pa", "pA", "Pennsylvania", "pennsylvania" } },
    { "Rhode Island", new string[] { "RI", "ri", "Ri", "rI", "Rhode Island", "rhode island" } },
    { "South Carolina", new string[] { "SC", "sc", "Sc", "sC", "South Carolina", "south carolina" } },
    { "South Dakota", new string[] { "SD", "sd", "Sd", "sD", "South Dakota", "south dakota" } },
    { "Tennessee", new string[] { "TN", "tn", "Tn", "tN", "Tennessee", "tennessee" } },
    { "Texas", new string[] { "TX", "tx", "Tx", "tX", "Texas", "texas" } },
    { "Utah", new string[] { "UT", "ut", "Ut", "uT", "Utah", "utah" } },
    { "Vermont", new string[] { "VT", "vt", "Vt", "vT", "Vermont", "vermont" } },
    { "Virginia", new string[] { "VA", "va", "Va", "vA", "Virginia", "virginia" } },
    { "Washington", new string[] { "WA", "wa", "Wa", "wA", "Washington", "washington" } },
    { "West Virginia", new string[] { "WV", "wv", "Wv", "wV", "West Virginia", "west virginia" } },
    { "Wisconsin", new string[] { "WI", "wi", "Wi", "wI", "Wisconsin", "wisconsin" } },
    { "Wyoming", new string[] { "WY", "wy", "Wy", "wY", "Wyoming", "wyoming" } },
    { "DX", new string[] { "DX", "dx", "Dx", "dX", "Dx", "dx", "Dx", "dX" } } // Special case for DX
};



    protected float _frequency;
    protected int _rstRx;
    protected int _rstTx;
    protected string _state = ""; // 2 digit state abrv. (i.e. TX, AZ, ID)
    protected string _callsign; //callsign of rx station

    protected string _date; //set with getDateTime()

    protected abstract void setRx();
    protected abstract void setTx();

    protected void setFreq() //get the frequency and assign it to _frequesncy
    {
        Console.Write("Enter the frequency (i.e. 28.445): ");
        _frequency = float.Parse(Console.ReadLine());
    }

    protected void setState()
    {

        while (_state == "")
        {
            Console.Write("Enter the State of the Recived Station (i.e. AZ, DX) : ");
            string rawInput = Console.ReadLine();
            string firstTwoChars = rawInput.Length >= 2 ? rawInput.Substring(0, 2) : rawInput;

            foreach (KeyValuePair<string, string[]> entry in _stateCodes)
            {
                foreach (string item in entry.Value)
                {
                    if (item == firstTwoChars)
                    {
                        _state = entry.Key;
                        break;
                    }

                }
                if (_state == "")
                {
                    Console.Clear();
                    Console.Write("State not found! Please retry! \n");
                }
            }
        }
    }

    protected void setCallsign()
    {
        Console.Write("Callsign of Recived station (i.e. K7BYI) : ");
        _callsign = Console.ReadLine();
    }

    protected void setTime() //returns the date and time for the log
    {
        DateTime now = DateTime.UtcNow; // Format the DateTime object to the desired format 
        _date = now.ToString("dd, MMMM, yyyy - HH:mm:ss"); // Output the formatted date
    }


    protected float getFreq()
    {
        return _frequency;
    }

    protected int getTx()
    {
        return _rstTx;
    }

    protected int getRx()
    {
        return _rstRx;
    }

    protected string getState()
    {
        return _state;
    }

    protected string getCallsign()
    {
        return _callsign;
    }

    protected string getTime()
    {
        return _date;
    }

    public string returnQso()
    {
        getCallsign();
        string qsoString = ($"Frequency: {_frequency} \nCallsign: {_callsign} \nRX Signal Report: {_rstRx} \nTX Signal Report: {_rstTx} \nState: {_state} \nTime: {_date}");
        return qsoString;
    }

    public Qso()
    {
        setFreq();
        setCallsign();
        setRx();
        setTx();
        setState();
        setTime();
        Console.Clear();
    }

    public string exportAdif() //generates the standard Adif file for upload to QRZ.com. This is not yet completely correct.
    {
        string adifContent = "";

        adifContent += $"<CALL:{_callsign.Length}>{_callsign} <BAND:{_frequency.ToString().Length}>{_frequency} <MODE:USB> <RST_SENT:{_rstTx.ToString().Length}>{_rstTx} <RST_RCVD:{_rstRx.ToString().Length}>{_rstRx} <QTH:{_state.Length}>{_state} <TIME_ON:{_date.Length}>{_date}\n";

        return adifContent;
    }

}