namespace GameEngine.Exceptions;

public class MemberOverwriteException : Exception
{
    public MemberOverwriteException(string message)
        : base(message) { }
}