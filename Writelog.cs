using System;
using System.IO;
using System.Xml;

public class Writelog()
{

    public void WriteToDisk(string _input, string _path)
    {
        using (StreamWriter writer = new StreamWriter(_path))  // using ensures that the program contines when exceptions are thrown.
        {
            writer.Write(_input);
        }
    }


}