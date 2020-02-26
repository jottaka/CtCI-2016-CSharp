using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CtDI
{
    interface IExercise
    {
        void Run();
        Task RunAsync();
    }
}
