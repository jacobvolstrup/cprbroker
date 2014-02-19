﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Xml;

namespace SchemaGeneration
{
    class SplitCodeBySchemaSource
    {
        public static void Run(string partialSchemaDir)
        {
            if (!partialSchemaDir.EndsWith("\\"))
                partialSchemaDir += "\\";

            var allCodeFileName = GenerateCode(partialSchemaDir);

            SplitByFileSource(allCodeFileName, partialSchemaDir);

            File.Delete(allCodeFileName);
            File.Delete(allCodeFileName.Replace(".cs", ".xsd"));
            File.Delete(allCodeFileName.Replace(".cs", ".designer.cs"));
        }

        public static string GenerateCode(string partialSchemaDir)
        {
            Environment.CurrentDirectory = partialSchemaDir;

            var args = new List<string>();
            args.Add("/classes");
            args.Add("/n:CprBroker.Schemas.Part");

            foreach (var f in Directory.GetFiles(partialSchemaDir, "*.xsd"))
            {
                args.Add(string.Format("{0}", new FileInfo(f).Name));
            }

            var tmpFile = partialSchemaDir + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 7) + ".xsd";
            using (var w = new StreamWriter(tmpFile))
            {
                w.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?><schema xmlns=\"http://www.w3.org/2001/XMLSchema\"></schema>");
            }
            args.Add(string.Format(".\\{0}", new FileInfo(tmpFile).Name));

            var all = string.Join(" ", args.ToArray());
            Console.WriteLine(all);
            var ret = XsdTool.Xsd.Main(args.ToArray());

            if (ret != 0)
            {
                throw new Exception("XSD.exe failed");
            }
            return tmpFile.Replace(".xsd", ".cs");
        }

        public static void SplitByFileSource(string allCodeFile, string partialSchemaDir)
        {
            var sourceFile = new SourceCodeFile(allCodeFile);

            var files = Directory.GetFiles(partialSchemaDir, "*.xsd").Select(f => new WorkFile(f)).ToArray();

            foreach (var file in files)
            {
                var fileTypes = file.DefinedTypeNames;
                var fileNamespace = file.TargetNamespace;

                file.Types.AddRange(sourceFile.Types.Where(m => file.TypeDefinedInFile(m, fileNamespace, fileTypes)));
                file.WriteCodeFile(sourceFile.HeaderMatch, file);
            }
        }

    }
}
