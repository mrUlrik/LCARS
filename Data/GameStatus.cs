using System;

namespace LCARS.Data
{
    [Flags]
    public enum GameStatus
    {
        Ended = 0x01,
        Running = 0x02,
        Paused = 0x04,
        NextRound = 0x08
    }
}
