namespace Kairos.Presentation.Source.Core.FileLogger;
public static class Logger
{
    public static void LogToFile(string title, string logMessage)
    {
        string fileName = "Kairos_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
        StreamWriter swLog;
        if(File.Exists(fileName))
        {
            swLog = File.AppendText(fileName);
        }
        else
        {
            swLog = new StreamWriter(fileName);
        }
        swLog.WriteLine("Log:");
        swLog.WriteLine(DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
        swLog.WriteLine($"Título da Mensagem: {title}");
        swLog.WriteLine($"Mensagem: {logMessage}");
        swLog.WriteLine("-------------------------------------------------------------");
        swLog.WriteLine("");
        swLog.Close();
    }
}
