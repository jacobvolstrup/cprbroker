﻿/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in
 * compliance with the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS"basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The CPR Broker concept was initally developed by
 * Gentofte Kommune / Municipality of Gentofte, Denmark.
 * Contributor(s):
 * Steen Deth
 *
 *
 * The Initial Code for CPR Broker and related components is made in
 * cooperation between Magenta, Gentofte Kommune and IT- og Telestyrelsen /
 * Danish National IT and Telecom Agency
 *
 * Contributor(s):
 * Beemen Beshara
 * Niels Elgaard Larsen
 * Leif Lodahl
 * Steen Deth
 *
 * The code is currently governed by IT- og Telestyrelsen / Danish National
 * IT and Telecom Agency
 *
 * Alternatively, the contents of this file may be used under the terms of
 * either the GNU General Public License Version 2 or later (the "GPL"), or
 * the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
 * in which case the provisions of the GPL or the LGPL are applicable instead
 * of those above. If you wish to allow use of your version of this file only
 * under the terms of either the GPL or the LGPL, and not to allow others to
 * use your version of this file under the terms of the MPL, indicate your
 * decision by deleting the provisions above and replace them with the notice
 * and other provisions required by the GPL or the LGPL. If you do not delete
 * the provisions above, a recipient may use your version of this file under
 * the terms of any one of the MPL, the GPL or the LGPL.
 *
 * ***** END LICENSE BLOCK ***** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CprBroker.Utilities.ConsoleApps
{
    public class ConsoleEnvironment
    {
        public ConsoleEnvironment(string[] args)
        {
            ParseArguments(args);
            InitializeIO();
        }


        public string PartServiceUrl = "http://CprBroker/Services/Part.asmx";
        public string ApplicationToken = "";
        public string BrokerConnectionString = "";
        public string OtherConnectionString = "";

        string outDir;
        StreamWriter logFileWriter;
        StreamWriter succeededFileWriter;
        StreamWriter failedFileWriter;
        int count;
        int processed;

        public void ParseArguments(string[] args)
        {
            var urlArg = new CommandArgumentSpec() { Switch = "/url", ValueRequirement = ValueRequirement.NotRequired, MaxOccurs = 1 };
            var tokenArg = new CommandArgumentSpec() { Switch = "/appToken", ValueRequirement = ValueRequirement.NotRequired, MaxOccurs = 1 };
            var brokerArg = new CommandArgumentSpec() { Switch = "/brokerDb", ValueRequirement = ValueRequirement.NotRequired, MaxOccurs = 1 };
            var otherDbArg = new CommandArgumentSpec() { Switch = "/otherDb", ValueRequirement = ValueRequirement.NotRequired, MaxOccurs = 1 };

            var arguments = CommandlineParser.SplitCommandArguments(args);
            CommandlineParser.ValidateCommandline(arguments, new CommandArgumentSpec[] { urlArg, tokenArg, brokerArg, otherDbArg });
            PartServiceUrl = urlArg.FoundArguments.Select(a => a.Value).FirstOrDefault();
            ApplicationToken = tokenArg.FoundArguments.Select(a => a.Value).FirstOrDefault();
            BrokerConnectionString = brokerArg.FoundArguments.Select(a => a.Value).FirstOrDefault();
            OtherConnectionString = otherDbArg.FoundArguments.Select(a => a.Value).FirstOrDefault();
        }

        public void InitializeIO()
        {
            var nowDirectoryString = string.Format("Runs\\{0}\\", DateTime.Now.ToString("yyyy MM dd HH_mm"));
            if (!Directory.Exists(nowDirectoryString))
                Directory.CreateDirectory(nowDirectoryString);
            string logFileName = nowDirectoryString + "Log.txt";
            string succeededFileName = nowDirectoryString + "Succeeded.txt";
            string failedFileName = nowDirectoryString + "Failed.txt";
            outDir = nowDirectoryString + "Registrations\\";

            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            logFileWriter = new StreamWriter(logFileName, true) { AutoFlush = true };
            succeededFileWriter = new StreamWriter(succeededFileName, true) { AutoFlush = true };
            failedFileWriter = new StreamWriter(failedFileName, true) { AutoFlush = true };

        }

        public virtual string[] LoadCprNumbers()
        {
            return new string[0];
        }

        public void Run()
        {
            var cprNumbers = LoadCprNumbers();
            count = cprNumbers.Count();
            Console.WriteLine(string.Format("Found <{0}>citizens", count));
            processed = 0;

            foreach (var cprNumber in cprNumbers)
            {
                try
                {
                    Log(string.Format("Starting citizen <{0}>", cprNumber));
                    ProcessPerson(cprNumber);
                    Pass(cprNumber);
                }
                catch (Exception ex)
                {
                    Fail(cprNumber, ex.ToString());
                }
                finally
                {
                    End(cprNumber);
                }
            }
        }

        public virtual void ProcessPerson(string pnr)
        {

        }

        public void WriteObject(string cprNumber, object obj)
        {
            string registrationXml = obj is string ? obj as string : CprBroker.Utilities.Strings.SerializeObject(obj);
            string registrationFileName = string.Format("{0}{1}.xml", outDir, cprNumber);
            File.WriteAllText(registrationFileName, registrationXml);
        }

        public void Log(string text)
        {
            Console.WriteLine(text);
            logFileWriter.WriteLine(text);
        }

        public void Pass(string cprNumber)
        {
            succeededFileWriter.WriteLine(cprNumber);
            Log("Succeeded !!");
        }

        public void Fail(string cprNumber, string message)
        {
            failedFileWriter.WriteLine(cprNumber);
            Log(message);
        }

        public void End(string cprNumber)
        {
            processed++;
            var percent = (100 * processed / count).ToString();
            Log(string.Format("Processed <{0}> of <{1}> - <{2}%>", processed, count, percent));
        }

    }
}