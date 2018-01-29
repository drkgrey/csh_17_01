using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid_game
{
    class ConsoleWritelineEventArgs: EventArgs
    {
        public string Message { get; }

        public ConsoleWritelineEventArgs(string message)
        {
            Message = message;
        }
    }
}
