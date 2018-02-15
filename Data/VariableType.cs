using System;

namespace LCARS.Data
{
    [Flags]
    public enum VariableType
    {
        None = 0x00,
        MultipleChoice = 0x01,
        Drones = 0x02,
        Locations = 0x04,
        Crew = 0x08
    }
}
