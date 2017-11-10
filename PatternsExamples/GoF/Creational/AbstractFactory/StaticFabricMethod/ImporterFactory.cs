using System;
using System.Collections.Generic;
using System.IO;

namespace PatternsExamples.GoF.Creational.AbstractFactory.StaticFabricMethod
{
    public class Start
    {
        public Start()
        {
            var importer = ImporterFactory.Create(".json");
        }
    }


    static class ImporterFactory
    {
        private static readonly Dictionary<string, Func<Importer>> _map =
            new Dictionary<string, Func<Importer>>();

        static ImporterFactory()
        {
            _map[".json"] = () => new JsonImporter();
            _map[".xls"] = () => new XlsImporter();
            _map[".xlsx"] = () => new XlsImporter();
        }

        public static Importer Create(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            var creator = GetCreator(extension);
            if (creator == null)
                throw new UnsupportedImporterTypeException(extension);
            return creator();
        }

        private static Func<Importer> GetCreator(string extension)
        {
            Func<Importer> creator;
            _map.TryGetValue(extension, out creator);
            return creator;
        }
    }

    internal class UnsupportedImporterTypeException : Exception
    {
        public UnsupportedImporterTypeException(string extension)
        {
            
        }
    }

    internal class XlsImporter : Importer
    {
    }

    internal class JsonImporter : Importer
    {
    }

    internal class Importer
    {
    }
}