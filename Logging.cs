using System;
using System.Collections.Generic;
using System.Web;


public class Logging
{

    private static int LOG_IND = 1;//if you want to disable it by config, get the value from resource of config file

    public static string LogFile_path = HttpContext.Current.Server.MapPath("~\\LOG\\") + DateTime.Now.ToString("yyyyMMdd") + ".txt";
 


    public static void writeSpecLog(string ps_text, string ps_path)
    {
        if (LOG_IND == 1)
        {

            if (!System.IO.Directory.Exists(ps_path.Substring(0, ps_path.LastIndexOf("\\"))))
            {
                System.IO.Directory.CreateDirectory(ps_path.Substring(0, ps_path.LastIndexOf("\\")));
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter(ps_path, true, System.Text.Encoding.UTF8);
            file.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + ps_text);

            file.Close();
            file.Dispose(); file = null;
        }
    }
    public static void writeLog(string ps_text)
    {
        writeSpecLog(ps_text, LogFile_path);
    }
    public static void writeLog(Exception ex)
    {
        if (ex.Source.ToLower() == "entityframework")
        {
            writeSpecLog(ex.InnerException.Message, LogFile_path);
        }
        writeSpecLog(ex.Message, LogFile_path);
        writeSpecLog(ex.StackTrace, LogFile_path);
    }
}
