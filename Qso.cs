abstract class Qso
{

protected Dictionary<string, string[]> _stateCodes = new Dictionary<string, string[]>
{
    { "AL", new string[] { "Alabama", "al", "Al", "aL", "Alabama", "alabama" } },
    { "AK", new string[] { "Alaska", "ak", "Ak", "aK", "Alaska", "alaska" } },
    { "AZ", new string[] { "Arizona", "az", "Az", "aZ", "Arizona", "arizona" } },
    { "AR", new string[] { "Arkansas", "ar", "Ar", "aR", "Arkansas", "arkansas" } },
    { "CA", new string[] { "California", "ca", "Ca", "cA", "California", "california" } },
    { "CO", new string[] { "Colorado", "co", "Co", "cO", "Colorado", "colorado" } },
    { "CT", new string[] { "Connecticut", "ct", "Ct", "cT", "Connecticut", "connecticut" } },
    { "DE", new string[] { "Delaware", "de", "De", "dE", "Delaware", "delaware" } },
    { "FL", new string[] { "Florida", "fl", "Fl", "fL", "Florida", "florida" } },
    { "GA", new string[] { "Georgia", "ga", "Ga", "gA", "Georgia", "georgia" } },
    { "HI", new string[] { "Hawaii", "hi", "Hi", "hI", "Hawaii", "hawaii" } },
    { "ID", new string[] { "Idaho", "id", "Id", "iD", "Idaho", "idaho" } },
    { "IL", new string[] { "Illinois", "il", "Il", "iL", "Illinois", "illinois" } },
    { "IN", new string[] { "Indiana", "in", "In", "iN", "Indiana", "indiana" } },
    { "IA", new string[] { "Iowa", "ia", "Ia", "iA", "Iowa", "iowa" } },
    { "KS", new string[] { "Kansas", "ks", "Ks", "kS", "Kansas", "kansas" } },
    { "KY", new string[] { "Kentucky", "ky", "Ky", "kY", "Kentucky", "kentucky" } },
    { "LA", new string[] { "Louisiana", "la", "La", "lA", "Louisiana", "louisiana" } },
    { "ME", new string[] { "Maine", "me", "Me", "mE", "Maine", "maine" } },
    { "MD", new string[] { "Maryland", "md", "Md", "mD", "Maryland", "maryland" } },
    { "MA", new string[] { "Massachusetts", "ma", "Ma", "mA", "Massachusetts", "massachusetts" } },
    { "MI", new string[] { "Michigan", "mi", "Mi", "mI", "Michigan", "michigan" } },
    { "MN", new string[] { "Minnesota", "mn", "Mn", "mN", "Minnesota", "minnesota" } },
    { "MS", new string[] { "Mississippi", "ms", "Ms", "mS", "Mississippi", "mississippi" } },
    { "MO", new string[] { "Missouri", "mo", "Mo", "mO", "Missouri", "missouri" } },
    { "MT", new string[] { "Montana", "mt", "Mt", "mT", "Montana", "montana" } },
    { "NE", new string[] { "Nebraska", "ne", "Ne", "nE", "Nebraska", "nebraska" } },
    { "NV", new string[] { "Nevada", "nv", "Nv", "nV", "Nevada", "nevada" } },
    { "NH", new string[] { "New Hampshire", "nh", "Nh", "nH", "New Hampshire", "new hampshire" } },
    { "NJ", new string[] { "New Jersey", "nj", "Nj", "nJ", "New Jersey", "new jersey" } },
    { "NM", new string[] { "New Mexico", "nm", "Nm", "nM", "New Mexico", "new mexico" } },
    { "NY", new string[] { "New York", "ny", "Ny", "nY", "New York", "new york" } },
    { "NC", new string[] { "North Carolina", "nc", "Nc", "nC", "North Carolina", "north carolina" } },
    { "ND", new string[] { "North Dakota", "nd", "Nd", "nD", "North Dakota", "north dakota" } },
    { "OH", new string[] { "Ohio", "oh", "Oh", "oH", "Ohio", "ohio" } },
    { "OK", new string[] { "Oklahoma", "ok", "Ok", "oK", "Oklahoma", "oklahoma" } },
    { "OR", new string[] { "Oregon", "or", "Or", "oR", "Oregon", "oregon" } },
    { "PA", new string[] { "Pennsylvania", "pa", "Pa", "pA", "Pennsylvania", "pennsylvania" } },
    { "RI", new string[] { "Rhode Island", "ri", "Ri", "rI", "Rhode Island", "rhode island" } },
    { "SC", new string[] { "South Carolina", "sc", "Sc", "sC", "South Carolina", "south carolina" } },
    { "SD", new string[] { "South Dakota", "sd", "Sd", "sD", "South Dakota", "south dakota" } },
    { "TN", new string[] { "Tennessee", "tn", "Tn", "tN", "Tennessee", "tennessee" } },
    { "TX", new string[] { "Texas", "tx", "Tx", "tX", "Texas", "texas" } },
    { "UT", new string[] { "Utah", "ut", "Ut", "uT", "Utah", "utah" } },
    { "VT", new string[] { "Vermont", "vt", "Vt", "vT", "Vermont", "vermont" } },
    { "VA", new string[] { "Virginia", "va", "Va", "vA", "Virginia", "virginia" } },
    { "WA", new string[] { "Washington", "wa", "Wa", "wA", "Washington", "washington" } },
    { "WV", new string[] { "West Virginia", "wv", "Wv", "wV", "West Virginia", "west virginia" } },
    { "WI", new string[] { "Wisconsin", "wi", "Wi", "wI", "Wisconsin", "wisconsin" } },
    { "WY", new string[] { "Wyoming", "wy", "Wy", "wY", "Wyoming", "wyoming" } },
    { "DX", new string[] { "DX", "dx", "Dx", "dX", "Dx", "dx", "Dx", "dX" } } // Special case for DX
};

    protected float _frequency;
    protected int _rstRx;
    protected int _rstTx;
    protected string _state = ""; // 2 digit state abrv. (i.e. TX, AZ, ID)
    protected string _callsign; //callsign of rx station

    protected string _date; //set with getDateTime()
    protected string _time; //set with getDatTime()    
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
        _date = now.ToString("yyyyddMM"); // Output the formatted date 
        _time = now.ToString("HHmmss"); // sets the time to the _time Variable
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

    //generates the standard Adif file for upload to QRZ.com. This is not yet completely correct.
    public abstract string exportAdi();

}