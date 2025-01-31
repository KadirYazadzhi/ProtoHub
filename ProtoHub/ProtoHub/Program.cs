using System;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        Console.Title = "ProtoHub";
        
        PrintBanner();
        PrintMenu();
        ChooseOptions();
    }

    private static void PrintBanner() {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(@"
   ▄███████▄    ▄████████  ▄██████▄      ███      ▄██████▄     ▄█    █▄    ███    █▄  ▀█████████▄  
  ███    ███   ███    ███ ███    ███ ▀█████████▄ ███    ███   ███    ███   ███    ███   ███    ███ 
  ███    ███   ███    ███ ███    ███    ▀███▀▀██ ███    ███   ███    ███   ███    ███   ███    ███ 
  ███    ███  ▄███▄▄▄▄██▀ ███    ███     ███   ▀ ███    ███  ▄███▄▄▄▄███▄▄ ███    ███  ▄███▄▄▄██▀  
▀█████████▀  ▀▀███▀▀▀▀▀   ███    ███     ███     ███    ███ ▀▀███▀▀▀▀███▀  ███    ███ ▀▀███▀▀▀██▄  
  ███        ▀███████████ ███    ███     ███     ███    ███   ███    ███   ███    ███   ███    ██▄ 
  ███          ███    ███ ███    ███     ███     ███    ███   ███    ███   ███    ███   ███    ███ 
 ▄████▀        ███    ███  ▀██████▀     ▄████▀    ▀██████▀    ███    █▀    ████████▀  ▄█████████▀  
               ███    ███                                                                          
                                                                            protohub - @anonyx_
        ");
    }

    private static void PrintMenu() {
        Console.WriteLine("Select a protocol:");
        Console.WriteLine("1. SMB");
        Console.WriteLine("2. RDP");
        Console.WriteLine("3. SSH");
        Console.WriteLine("4. FTP");
        Console.WriteLine("5. Telnet");
        Console.WriteLine("6. VNC");
        Console.WriteLine("7. MySQL");
        Console.WriteLine("8. PostgreSQL");
        Console.WriteLine("9. HTTP Basic Auth");
        Console.Write("Enter choice: ");
    }
    
    private static void ChooseOptions() {
        string choice = Console.ReadLine();

        Console.Write("Enter target IP: ");
        string ip = Console.ReadLine();

        while (!IsValidIp(ip)) {
            Console.WriteLine("Invalid IP address. Please enter a valid IPv4 or IPv6 address.");
            Console.Write("Enter target IP: ");
            ip = Console.ReadLine();
        }

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        string command = GenerateCommand(choice, ip, username, password);

        if (string.IsNullOrEmpty(command)) {
            Console.WriteLine("Invalid choice. Exiting...");
            return;
        }

        Console.WriteLine($"Executing: {command}");
        ExecuteCommand(command);
    }

    private static string GenerateCommand(string choice, string ip, string username, string password) {
        return choice switch {
            "1" => $"smbclient //{ip}/share -U {username}%{password}",
            "2" => $"xfreerdp /v:{ip} /u:{username} /p:{password}",
            "3" => $"ssh {username}@{ip}",
            "4" => $"ftp {ip}",
            "5" => $"telnet {ip}",
            "6" => $"vncviewer {ip} -Password {password}",
            "7" => $"mysql -h {ip} -u {username} -p{password}",
            "8" => $"psql -h {ip} -U {username} -d postgres -W {password}",
            "9" => $"curl -u {username}:{password} http://{ip}",
            _ => null
        };
    }

    private static void ExecuteCommand(string command) {
        string shell = Environment.OSVersion.Platform == PlatformID.Win32NT ? "cmd.exe" : "/bin/bash";
        string arguments = Environment.OSVersion.Platform == PlatformID.Win32NT ? $"/c {command}" : $"-c \"{command}\"";

        ProcessStartInfo psi = new ProcessStartInfo {
            FileName = shell,
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = new Process { StartInfo = psi };
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine(output);
        if (!string.IsNullOrEmpty(error))
            Console.WriteLine("Error: " + error);
    }

    private static bool IsValidIp(string ip) {
        string ipv4Pattern = @"^(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\." +
                             @"(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\." +
                             @"(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\." +
                             @"(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])$";
        
        string ipv6Pattern = @"^([\da-fA-F]{1,4}:){7}[\da-fA-F]{1,4}$";

        return Regex.IsMatch(ip, ipv4Pattern) || Regex.IsMatch(ip, ipv6Pattern);
    }
}
