using System;
using System.Collections.Generic;

namespace GeradorCodigoId
{
    class Program
    {
        static void Main(string[] args)
        {
            var guids = new List<string>();
            var limite = 5;

            while (guids.Count < limite)
            {
                var id = Guid.NewGuid().ToString();
                guids.Add(id);
            }
        }
    }
}
