using System;
using System.Management.Automation;

public class InsecurePowerShellHost
{
    public static int Main(string[] args)
    {
        using (PowerShell ps = PowerShell.Create())
        {
            if (args.Length == 2)
            {
                String command = "";
                if (args[0].ToLower() == "-e" || args[0].ToLower() == "--enc" || args[0].ToLower() == "--encodedcommand")
                {
                    byte[] commandBytes = Convert.FromBase64String(args[1]);
                    command = System.Text.Encoding.UTF8.GetString(commandBytes);
                }
                else if (args[0].ToLower() == "-c" || args[0].ToLower() == "--com" || args[0].ToLower() == "--command")
                {
                    command = args[1];
                }
                else
                {
                    Console.Error.WriteLine("usage: InsecurePowerShellHost.exe [--EncodedCommand encoded_command | --Command command]");
                }
                var results = ps.AddScript(command + " | Out-String").Invoke();
                Console.WriteLine(results[0].ToString());
                ps.Commands.Clear();
            }
            else
            {
                Console.Error.WriteLine("usage: InsecurePowerShellHost.exe [--EncodedCommand encoded_command | --Command command]");
            }
        }

        return 0;
    }
}
