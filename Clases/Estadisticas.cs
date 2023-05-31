using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estadisticasStreaming.Clases
{
    internal static class Estadisticas
    {
        private static int totalUsuarios = 0; //Igual al numero de registros
        private static int noStarters = 0;
        private static int noWatchers = 0;
        private static int noCompleters = 0;

        public static int TotalUsuarios { get => totalUsuarios; set => totalUsuarios = value; }
        public static int NoStarters { get => noStarters; set => noStarters = value; }
        public static int NoWatchers { get => noWatchers; set => noWatchers = value; }
        public static int NoCompleters { get => noCompleters; set => noCompleters = value; }
    }
}
