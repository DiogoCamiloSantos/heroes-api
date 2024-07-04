public class IdGenerator
{
    private static readonly Random random = new Random();
    private static readonly object syncLock = new object();
    private static int nextId = 1;

    public static int GenerateId()
    {
        lock (syncLock)
        {
            return nextId++;
        }
    }
}
