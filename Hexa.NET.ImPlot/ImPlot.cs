namespace Hexa.NET.ImPlot
{
    public static unsafe partial class ImPlot
    {
        static ImPlot()
        {
            InitApi();
        }

        public static string GetLibraryName()
        {
            return "cimplot";
        }
    }
}