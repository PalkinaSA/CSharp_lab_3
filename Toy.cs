using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_lab_3
{
    [Serializable]
    public struct Toy
    {
        public string Name;         // Название игрушки
        public int Price;          // Стоимость игрушки
        public int MinAge;        // Минимальный возраст
        public int MaxAge;        // Максимальный возраст

        public Toy(string name, int price, int minAge, int maxAge) 
        {
            Name = name;
            Price = price;
            MinAge = Math.Min(minAge, maxAge);
            MaxAge = Math.Max(maxAge, minAge);
        }
    }
}
