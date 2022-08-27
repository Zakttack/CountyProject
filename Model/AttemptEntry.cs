using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CountyProject
{
    public class AttemptEntry : IEquatable<AttemptEntry>
    {
        public AttemptEntry(string stateName, Time attemptDate, double score, string userName)
        {
            StateName = stateName;
            AttemptDate = attemptDate;
            Score = score;
            UserName = userName;
        }

        public int ID
        {
            get
            {
                foreach (DataRow row in Site2.Attempts.AttemptTable.Rows)
                {
                    string stateName = row["StateName"].ToString();
                    Time attemptDate = Time.ToTime(row["AttemptDate"]);
                    double score = Convert.ToDouble(row["Score"]);
                    string userName = row["UserName"].ToString();
                    if (stateName.Equals(StateName) && attemptDate == AttemptDate &&
                        score == Score && userName.Equals(UserName))
                    {
                        return Convert.ToInt32(row["AttemptID"]);
                    }
                }
                throw new DataException("The Attempt doesn't exist");
            }
        }

        public string StateName
        {
            get;
        }

        public Time AttemptDate
        {
            get;
        }

        public double Score
        {
            get;
            set;
        }

        public string UserName
        {
            get;
        }

        public bool Equals(AttemptEntry entry)
        {
            try
            {
                return ID == entry.ID && StateName.Equals(entry.StateName) && 
                    AttemptDate == entry.AttemptDate && Score == entry.Score && 
                    UserName.Equals(entry.UserName);
            }
            catch (DataException)
            {
                return false;
            }
        }

        public static AttemptEntry GetAttempt(DataRow entry)
        {
            return new AttemptEntry(entry["StateName"].ToString(),
                Time.ToTime(entry["AttemptDate"]), Convert.ToDouble(entry["Score"]),
                entry["UserName"].ToString());
        }

        public static AttemptEntry GetAttempt(int id)
        {
            foreach (DataRow row in Site2.Attempts.AttemptTable.Rows)
            {
                if (id == Convert.ToInt32(row["AttemptID"]))
                {
                    return GetAttempt(row);
                }
            }
            throw new DataException("The Attempt doesn't exist!!!");
        }
    }
}