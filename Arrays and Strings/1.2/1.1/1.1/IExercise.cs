using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CtDI
{
    interface IExercise
    {
        public void Run();
        public Task RunAsync();
    }
}
