using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CountyProject
{
    public class QuestionEntry : IEquatable<QuestionEntry>
    {
        public QuestionEntry(int questionNumber, AttemptEntry attempt, string countyName, string
            selectedCountySeatName, string correctCountySeatName)
        {
            QuestionNumber = questionNumber;
            Attempt = attempt;
            CountyName = countyName;
            SelectedCountySeatName = selectedCountySeatName;
            CorrectCountySeatName = correctCountySeatName;
        }

        public int QuestionNumber
        {
            get;
        }

        public AttemptEntry Attempt
        {
            get;
        }

        public string CountyName
        {
            get;
        }

        public bool IsCorrect
        {
            get
            {
                return SelectedCountySeatName.Equals(CorrectCountySeatName);
            }
        }

        public string SelectedCountySeatName
        {
            get;
            set;
        }

        public string CorrectCountySeatName
        {
            get;
        }

        public bool Equals(QuestionEntry entry)
        {
            return QuestionNumber == entry.QuestionNumber &&
                Attempt.Equals(entry.Attempt) &&
                CountyName == entry.CountyName && 
                SelectedCountySeatName == entry.SelectedCountySeatName
                && CorrectCountySeatName == entry.CorrectCountySeatName;
        }

        public static QuestionEntry GetQuestion(DataRow row)
        {
            return new QuestionEntry(Convert.ToInt32(row["QuestionNumber"]),
                AttemptEntry.GetAttempt(Convert.ToInt32(row["AttemptID"])),
                row["CountyName"].ToString(), row["SelectedCountySeatName"].ToString(),
                row["CorrectCountySeatName"].ToString());
        }

        public static QuestionEntry GetQuestion(int questionNumber, int attemptID)
        {
            foreach (QuestionEntry question in Site2.Questions)
            {
                if (questionNumber == question.QuestionNumber && attemptID == question.Attempt.ID)
                {
                    return question;
                }
            }
            throw new DataException("Question Not Found!!!");
        }
    }
}