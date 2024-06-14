using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoBreath
{
    internal class AllScripts
    {
        String ExePytPath;

        public AllScripts(String path)
        {
            ExePytPath = Path.Combine(path,@"ExePython\python.exe");
        }

        public string Appel_Script(string script, string arg1, string arg2, string path)
        {
            if (!File.Exists(path + script + arg1 + arg2 + ".png"))
            {
                Start_Script(script, arg1, arg2, path);
            }
            return script + arg1 + arg2 + ".png";
        }

        public String Start_Script(String script, String arg1, String arg2, string path)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = ExePytPath;

            var scriptemplacement = Path.Combine(path, script + ".py");
            var Image = Path.Combine(path, script + arg1 + arg2 + ".png");

            psi.Arguments = $"{scriptemplacement} {Image} {arg1} {arg2}";

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;

            var errors = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                results = process.StandardOutput.ReadToEnd();
                errors = process.StandardError.ReadToEnd();
            }
            return results;
        }


    }
}
