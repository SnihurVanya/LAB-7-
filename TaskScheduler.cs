using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public delegate void TaskExecution<TTask>(TTask task);
    public class TaskScheduler<TTask, TPriority>
    {
        private SortedDictionary<TPriority, Queue<TTask>> taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();
        private TaskExecution<TTask> taskExecutor;
        private Queue<TTask> objectPool = new Queue<TTask>();

        public TaskScheduler(TaskExecution<TTask> taskExecutor)
        {
            this.taskExecutor = taskExecutor;
        }

        // Додавання завдання з пріоритетом
        public void AddTask(TTask task, TPriority priority)
        {
            if (!taskQueue.ContainsKey(priority))
            {
                taskQueue[priority] = new Queue<TTask>();
            }
            taskQueue[priority].Enqueue(task);
        }

        // Виконання завдання з найвищим пріоритетом
        public void ExecuteNext()
        {
            if (taskQueue.Count > 0)
            {
                TPriority highestPriority = taskQueue.Keys.Last();
                TTask task = taskQueue[highestPriority].Dequeue();
                if (taskQueue[highestPriority].Count == 0)
                {
                    taskQueue.Remove(highestPriority);
                }
                taskExecutor(task);
            }
            else
            {
                Console.WriteLine("No tasks in the queue.");
            }
        }

        // Додавання об'єкта в пул
        public void AddToPool(TTask obj)
        {
            objectPool.Enqueue(obj);
        }

        // Отримання об'єкта з пулу або створення нового
        public TTask GetFromPool(Func<TTask> objectInitializer)
        {
            if (objectPool.Count > 0)
            {
                return objectPool.Dequeue();
            }
            return objectInitializer();
        }

        // Повернення об'єкта в пул
        public void ReturnToPool(TTask obj)
        {
            objectPool.Enqueue(obj);
        }
    }
}
