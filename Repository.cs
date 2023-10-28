using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public delegate bool Criteria<T>(T item);
    public class Repository<T>
    {
        private List<T> items = new List<T>();

        // Додавання елементу в репозиторій
        public void Add(T item)
        {
            items.Add(item);
        }

        // Пошук елементів, що задовольняють критерію
        public List<T> Find(Criteria<T> criteria)
        {
            List<T> result = new List<T>();
            foreach (T item in items)
            {
                if (criteria(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }

}
