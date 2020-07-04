using System;
using System.Collections.Generic;

namespace Task_3
{
    public abstract class Guitar : IMusicInstrument
    {
        public string Name { get; set; }
        public virtual double Value { get { return QualityOfMaterials + NumOfChord + Durability; } }
        protected int NumOfChord; //кол-во струн
        protected double QualityOfMaterials; //качество материалов
        protected List<string> Songs = new List<string>();
        protected int Durability; //долговечность

        protected virtual void ReduceDurability()
        {
            --Durability;
        }
        public virtual string PlayMusic(string songName)
        {
            ReduceDurability();
            foreach(string tmp in Songs)
            {
                if(tmp==songName)
                    return tmp;
            }
            return null;
        }

       public void Reconfigure(int chords, double materials)
        {
            NumOfChord = chords;
            QualityOfMaterials = materials;
        }

    }
}
