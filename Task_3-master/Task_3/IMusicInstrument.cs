namespace Task_3
{
    public interface IMusicInstrument
    {
        string Name { get; set; }
        double Value { get; }
        string PlayMusic(string songName);
        void Reconfigure(int chords, double materials);
    }
}
