using CountyLibrary.Models;
using Microsoft.VisualBasic.FileIO;
using System.Collections;
namespace CountyLibrary.Tables
{
    public class EntriesTable : IEnumerable<Entry>
    {
        private readonly ICollection<Entry> contents;

        public EntriesTable()
        {
            contents = new HashSet<Entry>();
            string filePath = $"{GetInitialPathLocation(".")}\\CountyLibrary\\Resources\\Entries.csv";
            TextFieldParser entryParcer = new TextFieldParser(filePath);
            entryParcer.TextFieldType = FieldType.Delimited;
            entryParcer.SetDelimiters(",");
            bool isHeader = true;
            while (!entryParcer.EndOfData)
            {
                string[] values = entryParcer.ReadFields();
                if (isHeader)
                {
                    isHeader = !isHeader;
                }
                else
                {
                    County county = new County(values[0]);
                    string countySeatName = values[1];
                    State state = new State(values[2]);
                    contents.Add(new Entry(county, countySeatName, state));
                }
            }
        }

        public IEnumerator<Entry> GetEnumerator()
        {
            return contents.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private string GetInitialPathLocation(string currentLocation)
        {
            DirectoryInfo temp = Directory.GetParent(currentLocation);
            if (temp.Name.Equals("CountyProject"))
            {
                return temp.FullName;
            }
            return GetInitialPathLocation(temp.FullName);
        }
    }
}