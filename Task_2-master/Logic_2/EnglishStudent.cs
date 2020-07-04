using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_2
{
    public class EnglishStudent:Student
    {
        private bool _isEnglish = false;
        public override double Quality { get {
                if (_isEnglish)
                {
                   return base.Quality * 2;
                }
                else
                {
                    return base.Quality * 0.9;
                }} }
        public EnglishStudent(string s, double score, int kurs,bool isEng):base(s,score,kurs)
        {
            _surname = s;
            _averengeScore = score;
            _kurs = kurs;
            _isEnglish = isEng;
        }public override string StudentInfo()
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

            if (_isEnglish)
                info += "Изучает Английский язык";
            else
            {
                info += "Не изучает Английский язык";
            }
            info += Environment.NewLine;
            info += "Q= ";
            info += Quality.ToString();

            return info;
        }


    }
}
