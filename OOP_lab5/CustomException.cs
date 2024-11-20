using System;

namespace OOP_lab5
{
    public class InvalidUnitDataException : Exception
    {
        public InvalidUnitDataException(string message) : base(message) { }
    }

    public class UnitNotFoundException : Exception
    {
        public UnitNotFoundException(string message) : base(message) { }
    }

    public class ArmyOverflowException : Exception
    {
        public ArmyOverflowException(string message) : base(message) { }
    }
}
