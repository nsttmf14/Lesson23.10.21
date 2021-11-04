using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class Program
    {
        struct Task
        {
            public string name;
        }

        class meeting
        {
            static void Main(string[] args)
        {
                var Boris = new Worker();
                Boris.Set_Department("Управление");
                Boris.Set_Name("Борис");
                Boris.Set_Rank(1);

                var Rashid = new Worker();
                Rashid.Set_Department("Управление финансами");
                Rashid.Set_Name("Рашид");
                Rashid.Set_Rank(2);

                var Lukas = new Worker();
                Lukas.Set_Department("Управление финансами");
                Lukas.Set_Name("Лукас");
                Lukas.Set_Rank(3);

                var Ilham = new Worker();
                Ilham.Set_Department("Управление ит");
                Ilham.Set_Name("Ильхам");
                Ilham.Set_Rank(2);

                var Orkadiy = new Worker();
                Orkadiy.Set_Department("Управление ит");
                Orkadiy.Set_Name("Оркадий");
                Orkadiy.Set_Rank(3);

                var Volodya = new Worker();
                Volodya.Set_Department("Управление ит");
                Volodya.Set_Name("Оркадий");
                Volodya.Set_Rank(4);

                var Ilshat = new Worker();
                Ilshat.Set_Department("Управление ит - системщики");
                Ilshat.Set_Name("Ильшат");
                Ilshat.Set_Rank(5);

                var Ivanuch = new Worker();
                Ivanuch.Set_Department("Управление ит - системщики");
                Ivanuch.Set_Name("Иваныч");
                Ivanuch.Set_Rank(6);

                var Iluya = new Worker();
                Iluya.Set_Department("Системщики - угнетаемый пролетарий");
                Iluya.Set_Name("Илья");
                Iluya.Set_Rank(7);

                var Vitya = new Worker();
                Iluya.Set_Department("Системщики - угнетаемый пролетарий");
                Iluya.Set_Name("Витя");
                Iluya.Set_Rank(7);

                var Zhenya = new Worker();
                Zhenya.Set_Department("Системщики - угнетаемый пролетарий");
                Zhenya.Set_Name("Женя");
                Zhenya.Set_Rank(7);

                var Sergey = new Worker();
                Sergey.Set_Department("Управление ит - разрабы");
                Sergey.Set_Name("Сергей");
                Sergey.Set_Rank(5);

                var Lyaisan = new Worker();
                Lyaisan.Set_Department("Управление ит - разрабы");
                Lyaisan.Set_Name("Ляйсан");
                Lyaisan.Set_Rank(6);

                var Anton = new Worker();
                Anton.Set_Department("Разрабы - угнетаемый пролетарий");
                Anton.Set_Name("Антон");
                Anton.Set_Rank(7);

                var Marat = new Worker();
                Marat.Set_Department("Разрабы - угнетаемый пролетарий");
                Marat.Set_Name("Марат");
                Marat.Set_Rank(7);

                var Dina = new Worker();
                Marat.Set_Department("Разрабы - угнетаемый пролетарий");
                Marat.Set_Name("Дина");
                Marat.Set_Rank(7);

                var Ildar = new Worker();
                Ildar.Set_Department("Разрабы - угнетаемый пролетарий");
                Ilham.Set_Name("Ильдар");
                Ilham.Set_Rank(7);

                Task task1, task2, task3;
                task1.name = "принести кофе";
                task2.name = "перезагрузить компьютер";
                task3.name = "сделать волшебную кнопку";
                Ildar.Comand(Lyaisan, task1);
                Console.ReadKey();
            }
        }
        class Worker
        {
            private byte rank;
            public void Set_Rank(byte Rank)
            {
                rank = Rank;
            }
            private string name;
            public void Set_Name(string Name)
            {

                name = Name;
            }
            private string department;
            public void Set_Department(string Department)
            {
                department = Department;
            }
            private bool Сomparison(string worker1, Worker worker2)
            {
                if (Equals(worker1, "Управление") && (Equals(worker2.department, "Управление финансами") || Equals(worker2.department, "Управление ит")))
                { 
                    return true;
                }
                if (Equals(worker1, "Управление финансами") && Equals(worker2.department, "Управление финансами"))
                {
                    return true;
                }
                if (Equals(worker1, "Управление финансами") && Equals(worker2.department, "Управление"))
                {
                    return true; 
                }
                if (Equals(worker1, "Управление ит") && Equals(worker2.department, "Управление ит"))
                { 
                    return true;
                }
                if (Equals(worker1, "Управление ит") && Equals(worker2.department, "Управление"))
                { 
                    return true; 
                }
                if (Equals(worker1, "Управление ит") && Equals(worker2.department, "Управление ит - системщики"))
                { 
                    return true; 
                }
                if (Equals(worker1, "Управление ит - системщики") && Equals(worker2.department, "Управление ит"))
                {
                    return true; 
                }
                if (Equals(worker1, "Управление ит - системщики") && Equals(worker2.department, "Управление ит - системщики"))
                {
                    return true;
                }
                if (Equals(worker1, "Управление ит - системщики") && Equals(worker2.department, "Системщики - угнетаемый пролетарий"))
                { 
                    return true;
                }
                if (Equals(worker1, "Системщики - угнетаемый пролетарий") && Equals(worker2.department, "Управление ит - системщики"))
                { 
                    return true; 
                }
                if (Equals(worker1, "Управление ит") && Equals(worker2.department, "Управление ит - разрабы"))
                {
                    return true; 
                }
                if (Equals(worker1, "Управление ит - разрабы") && Equals(worker2.department, "Управление ит"))
                { 
                    return true; 
                }
                if (Equals(worker1, "Управление ит - разрабы") && Equals(worker2.department, "Разрабы - угнетаемый пролетарий"))
                { 
                    return true; 
                }
                if (Equals(worker1, "Разрабы - угнетаемый пролетарий") && Equals(worker2.department, "Управление ит - разрабы")) 
                { 
                    return true;
                }

                return false;
            }
            public void Comand(Worker worker2, Task task)
            {
                Console.WriteLine($"Задача {task.name} дается сотруднику {name} от {worker2.name}");
                if (Сomparison(name, worker2) && (rank == worker2.rank + 1))
                {
                    Console.WriteLine($"Сотрудник {name} говорит {worker2.name}: Слушаюсь и повинуюсь");
                }
                else
                {
                    Console.WriteLine($"Сотрудник {name} говорит {worker2.name}: У тебя здесь нет власти АХАХАХА");
                }
            }
        }
    }
}
