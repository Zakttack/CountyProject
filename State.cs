using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace CountyApplication
{
    public class State
    {
        private readonly StateEntry state;
        public State(string stateName)
        {
            state = new StateEntry(stateName);
            Site1.StateEntries.Add(state);
            ReadFile();
        }

        public CountySeatEntry this[int index]
        {
            get
            {
                try
                {
                    DataRow entry = CountyTable.Rows[index];
                    CountyEntry countyEntry = new CountyEntry(entry["CountyName"].ToString());
                    return new CountySeatEntry(countyEntry, state, entry["CountySeatName"].ToString());
                }
                catch (Exception ex)
                {
                    Site1.ViewError(ex);
                    return null;
                }
            }
        }

        public DataTable CountyTable
        {
            get
            {
                Database database = new Database("County");
                return database.GetTableByState(state);
            }
        }

        public void FillCountySeats(DropDownList countySeatOptions)
        {
            countySeatOptions.Items.Clear();
            foreach (DataRow row in CountyTable.Rows)
            {
                string countySeatName = row["CountySeatName"].ToString();
                countySeatOptions.Items.Add(countySeatName);
            }
            countySeatOptions.AutoPostBack = true;
            countySeatOptions.SelectedIndex = 0;
        }

        private void ReadFile()
        {
            string fileName = @"C:\Users\zakme\OneDrive - North Dakota University System\Other\" +
                @"PersonalProgrammingProjects\CSharp\CountyApplication\States\" + state.StateName + ".txt";
            try
            {
                StreamReader stateReader = File.OpenText(fileName);
                while (!stateReader.EndOfStream)
                {
                    string line = stateReader.ReadLine();
                    string[] temp = line.Split('-');
                    string countyPart = temp[0].Trim();
                    CountyEntry countyEntry = new CountyEntry(countyPart.Substring(0, countyPart.Length - 7));
                    Site1.CountyEntries.Add(countyEntry);
                    string countySeatPart = temp[1].Trim();
                    CountySeatEntry countySeatEntry = new CountySeatEntry(countyEntry, state, countySeatPart);
                    Site1.CountySeatEntries.Add(countySeatEntry);
                }
            }
            catch (Exception ex)
            {
                Site1.ViewError(ex);
            }
        }

    }
}