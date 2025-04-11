using System.IO;
namespace Lieferverwaltung
{
    class Program
    {
        static List<Lieferung> lieferungen = new List<Lieferung>();
        static void Main(string[] args)
        {
            BeispielobjekteAnlegen();
            Console.WriteLine(lieferungen.Count);
            JsonDateiErstellen();       
        }

        static void BeispielobjekteAnlegen()
        {
            lieferungen.Add(new Lieferung(
                new DateOnly(2024, 06,22)
                , "HHX05NNW0ZP"
                , "86309"
            ));
            
            lieferungen.Add(new Lieferung(
                new DateOnly(2024, 09, 4)
                , "GSV18EDC4BR"
                , "91139"
            ));
            
            lieferungen.Add(new Lieferung(
                new DateOnly(2023, 04, 8)
                , "CQX55KMY5RW"
                , "07708"
            ));
        }

        static void JsonDateiErstellen()
        {
            string json = "{\n";
            json += $"  \"anzahl\": {lieferungen.Count},\n";
            json += "  \"lieferungen\": [\n";

            for (int i = 0; i < lieferungen.Count; i++)
            {
                Lieferung l = lieferungen[i];
                json += "    {\n";
                json += $"      \"datum\": \"{l.Datum:yyyy-MM-dd}\",\n";
                json += $"      \"sendungsnummer\": \"{l.Sendungsnummer}\",\n";
                json += $"      \"plz\": {l.PLZ}\n";
                json += "    }";

                if (i < lieferungen.Count - 1)
                    json += ",";
                json += "\n";
            }

            json += "  ]\n";
            json += "}";

            string pfad = @"C:\Users\Marlon Esman\Downloads\lieferungen.json";
            File.WriteAllText(pfad, json);
            Console.WriteLine("JSON-Datei wurde unter Downloads gespeichert.");

        }

    }
}
