using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homelabs
{
    class Program
    {
        private const string PathToPeople = @"..\..\files\People.txt";
        private const string PathToEmail = @"..\..\files\Email.txt";
        static string SearchMail(ref string stringfile)
        {
            string[] data = stringfile.Split();
            stringfile = data[4];
            return stringfile;
        }
        class Song
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public Song PrevSong { get; set; } = null;//смотрим предыдущую песню

            public Song(string name, string author) : this(name, author, null)//представляет ссылку на текущий экземпляр класса, не дублировать функции конструкторов
            {

            }
            public Song(string name, string author, Song song)
            {
                Name = name;
                Author = author;
                PrevSong = song;
            }
            public string Title()
            {
                return Name + " " + Author;
            }
            public void Display()
            {
                Console.WriteLine($"\"{Name}\" by {Author}");
            }
            public override bool Equals(object obj)
            {
                Song songEqual = (Song)obj;//явное приведение типов
                if (Title().Equals(songEqual.Title()))
                {
                    return true;
                }
                return false;
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Homework 8.1");
                List<string> Emails = new List<string>();
                StreamReader people = new StreamReader(PathToPeople);
                string stringfromfile;
                while ((stringfromfile = people.ReadLine()) != null) //считывает файл построчно пока не кончатся символы
                {
                    Emails.Add(SearchMail(ref stringfromfile));
                }
                StreamWriter str = new StreamWriter(PathToEmail);
                for (int i = 0; i < 2; i++)
                {
                    str.WriteLine(Emails[i]);
                }
                str.Close();//все записали, файл закрыли, сохранили

                Console.WriteLine("Homework 8.2");
                LinkedList<Song> songs = new LinkedList<Song>();
                songs.AddLast(new Song("Parson James", "Stole the show"));
                songs.AddLast(new Song("The Weeknd", "Power is Power", songs.Last.Value));
                songs.AddLast(new Song("Markul", "Cuba Libre", songs.Last.Value));
                songs.AddLast(new Song("Mr.Kitty", "After Dark", songs.Last.Value));
                foreach (var item in songs)
                {
                    item.Display();
                }
                if (songs.First.Value.Equals(songs.First.Next.Value))
                {
                    Console.WriteLine("1-ая и 2-ая песни равны");
                }
                else
                {
                    Console.WriteLine("1-ая и 2-ая песни неравны");
                }
                Console.ReadKey();
            }
        }
    }
}
