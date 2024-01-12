using System;
using System.Threading;

public class ThreadLocalValue
{
    // ThreadLocal variable
    private static readonly ThreadLocal<string> tlsVar = new ThreadLocal<string>();

    // Function to set thread-local value
    private static void SetTLSValue(string value)
    {
        tlsVar.Value = value;
    }

    // Function to get thread-local value
    private static string GetTLSValue()
    {
        return tlsVar.Value;
    }

    // Worker thread function
    private static void WorkerThread()
    {
        SetTLSValue("Thread-specific any value");
        Console.WriteLine(GetTLSValue());
    }

    public static void Main()
    {
        // Create and start multiple worker threads
        Thread[] threads = new Thread[3];
        for (int i = 0; i < 3; i++)
        {
            threads[i] = new Thread(WorkerThread);
            threads[i].Start();
        }

        // Wait for all threads to complete
        try
        {
            foreach (Thread t in threads)
            {
                t.Join();
            }
        }
        catch (ThreadInterruptedException e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}

/*
Thread-specific any value
Thread-specific any value
Thread-specific any value
*/