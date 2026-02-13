namespace SmartHouse.BlaisePascal.Domain.ElectroDomestics.CCTV
{
    public sealed record FOV
    {
        public int _fov { get; }

        public const int Min = 30;
        public const int Max = 120;

        public FOV(int fov) { _fov = fov; }

        public static FOV Create(int fov) => new FOV(Math.Clamp(fov, Min, Max));

        public static bool operator >(FOV f1, FOV f2) => f1._fov > f2._fov;

        public static bool operator <(FOV f1, FOV f2) => f1._fov < f2._fov;

        public static FOV operator -(FOV f, int i) => new FOV(f._fov - i);

        public static FOV operator +(FOV f, int i) => new FOV(f._fov + i);
    }
}
