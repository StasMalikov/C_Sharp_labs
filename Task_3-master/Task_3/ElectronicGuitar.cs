using System;

namespace Task_3
{
    public class ElectronicGuitar : Guitar
    {
        private bool _on;
        public int[] SoundAmplification { get; set; }
        public override double Value
        {
            get
            {
                return QualityOfMaterials + NumOfChord + Durability + Convert.ToInt32(_on);
            }
        }

        public ElectronicGuitar(string name, int chords, double qualityOfMaterials, int durability)
        {
            Name = name;
            NumOfChord = chords;
            QualityOfMaterials = qualityOfMaterials;
            Durability = durability;
            _on = true;
        }

        public string GetInfo()
        {
            string info = "";
            info += Environment.NewLine;
            info += "Name: ";
            info += Name.ToString();
            info += Environment.NewLine;
            info += "Value: ";
            info += Value.ToString();
            info += Environment.NewLine;
            info += "QualityOfMaterials: ";
            info += QualityOfMaterials.ToString();
            info += Environment.NewLine;

            return info;
        }
    }
}
