using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_2
{
   public class Student
    {
        protected string _surname;
        protected double _averengeScore;
        protected int _kurs;
        public virtual double Quality { get { return 0.2 * _averengeScore * _kurs; } }
        public Student(string s, double score, int kurs)
        {
            _surname = s;
            _averengeScore = score;
            _kurs = kurs;
        }  

        public virtual string StudentInfo()
        {
            string info = "";
            info += "Student surname: ";
            info += _surname;
            info += Environment.NewLine;
            info += "Averenge Score: ";
            info += _averengeScore.ToString();
            info += Environment.NewLine;
            info += "Kurs: ";
            info += _kurs.ToString();
            info += Environment.NewLine;
            info += "Q= ";
            info += Quality.ToString();

            return info;
        }

    }
}
