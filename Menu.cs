using System.Runtime.CompilerServices;

public class Menu()
{

    private QSOarray qsoArray = new QSOarray(); //innitialize the storage for QSO's
    private Writelog writelog = new Writelog();

    public void mainMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Create New QSO");
            Console.WriteLine("2. List all QSS's");
            Console.WriteLine("3. Write .TXT file to Disk");
            Console.WriteLine("4. Write .ADIF file to Disk");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    qsoMenu();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n" + qsoArray.returnAllQso());
                    Console.WriteLine("Press enter to continue... :");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 3:
                    
                    Console.Write("\nWhat do you want this file to be called? : ");
                    string path = Console.ReadLine();
                    writelog.WriteToDisk(qsoArray.returnAllQso(), path);
                    Console.Clear();
                    break;
                
                case 4:
                    Console.Write("What do you want this .ADIF file to be called? : ");
                    path = Console.ReadLine();
                    writelog.WriteToDisk(qsoArray.returnAllAdif(), path + ".adif");
                    Console.Clear();
                    break;
            
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");

                    break;
            }
            Console.Clear();
        }
    }



    private void qsoMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nQSO Menu:");
            Console.WriteLine("1. Create USB QSO");
            Console.WriteLine("2. Create LSB QSO");
            Console.WriteLine("3. Create CW QSO");
            Console.WriteLine("4. Create AM QSO");
            Console.WriteLine("5. Create FM QSO");
            Console.WriteLine("6. Return to Main Menu");
            Console.Write("Select an option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    qsoArray.newUsbQso();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    qsoArray.newLsbQso();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    qsoArray.newCwQso();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    qsoArray.newAmQso();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    qsoArray.newFmQso();
                    Console.Clear();
                    break;
                case 6:
                    exit = true;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
    }

}