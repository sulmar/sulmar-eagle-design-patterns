using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Command Pattern!");

           

            Message message = new Message("555000123", "555888000", "Hello World!");

            Queue<ICommand> queue = new Queue<ICommand>();
            queue.Enqueue(new SendCommand(message));
            queue.Enqueue(new SendCommand(message));
            queue.Enqueue(new SendCommand(message));
            queue.Enqueue(new PrintCommand(message, 3));

            while(queue.Count > 0)
            {
                ICommand command = queue.Dequeue();

                if (command.CanExecute())
                    command.Execute();
            }
        }
    }

}
