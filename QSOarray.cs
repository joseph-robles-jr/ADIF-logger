using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;

public class QSOarray
{
    //make a list to hold the QSO types
    private List<object> _qsoLists = new List<object>();

    // This function creates a new QSO object of a specified type and adds it to a list. It was created by AI but I now understand most of the code.
    private void createNewQSO<T>() where T : new() // The function is generic, allowing any type T that has a parameterless constructor.
    {
        // Create a new instance of the specified type T.
        T qso = new T();

        // Add the new instance to the _qsoLists list.
        _qsoLists.Add(qso);
    }

    public void newUsbQso()
    {
        createNewQSO<USB>();
    }

    public void newLsbQso()
    {
        createNewQSO<LSB>();
    }

    public void newCwQso()
    {
        createNewQSO<Cw>();
    }

    public void newAmQso()
    {
        createNewQSO<AM>();
    }

    public void newFmQso()
    {
        createNewQSO<FM>();
    }

    public string returnAllQso()
    {
        string wordWall = "";
        foreach (object qso in _qsoLists)
        {
            MethodInfo method = qso.GetType().GetMethod("returnQso");
            if (method != null)
            {
                string qsoString = (string)method.Invoke(qso, null);
                wordWall += qsoString + "\n\n";
            }

        }
        return wordWall;
    }

    public string returnAllAdif()
    {
        string adifHeader = "ADIF Export\n\n";
        string adifContent = "";
        foreach (Qso qso in _qsoLists)
        {
            adifContent += qso.exportAdif();
        }
        return adifHeader + adifContent + "<EOR>\n";

    }
}