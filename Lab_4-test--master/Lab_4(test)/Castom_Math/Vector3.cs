namespace Lab_4_test_
{
    public struct Vector3
    {
        private float[] coordinates;
        public Vector3(float x, float y, float z)
        {
            coordinates = new float[3];
            coordinates[0] = x;
            coordinates[1] = y;
            coordinates[2] = z;
        }
        public Vector3(Vector4 v) : this(v.X, v.Y, v.Z)
        {
        }
        public float X
        {
            get { return coordinates[0]; }
            set { coordinates[0] = value; }
        }
        public float Y
        {
            get { return coordinates[1]; }
            set { coordinates[1] = value; }
        }
        public float Z
        {
            get { return coordinates[2]; }
            set { coordinates[2] = value; }
        }
        public float this[int i]
        {
            get { return coordinates[i]; }
            set { coordinates[i] = value; }
        }
    }
}
