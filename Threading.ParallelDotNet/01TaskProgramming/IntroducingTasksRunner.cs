using System;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet.TaskProgramming
{
    public class IntroducingTasksRunner
    {
        public static void Runner()
        {
            /*
            //Create i Start
            Task.Factory.StartNew(() => IntroducingTasks.Write('.'));
            //Only Create
            var t = new Task(() => IntroducingTasks.Write('?'));
            t.Start();
            */

            /*
            var tpTask = new Task(IntroducingTasks.Write,"hello");
            tpTask.Start();
            Task.Factory.StartNew(IntroducingTasks.Write, "123");
            */

            var text1 = "testing";
            var text2 = "this";
            var task1 = new Task<int>(IntroducingTasks.TextLenght, text1);
            task1.Start();
            Task<int> task2 = Task.Factory.StartNew(IntroducingTasks.TextLenght, text2);

            Console.WriteLine($"Lenght of '{text1}' is {task1.Result}");
            Console.WriteLine($"Lenght of '{text2}' is {task2.Result}");

        }
    }
}