using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

class Fighter :IEnumerable, IComparable                                       //Abstract Fighter
{
    //статические переменные
    static string[] array;
    static short iterator;
    static Fighter()
    {
        array = new string[20];
        iterator = 0;
    }
    //Constructor
    public Fighter(string name = "FaceLess", double str = 15, double agi = 15, double intil = 15, double arm = 0, int atck = 8, int spd = 100)
    {
        Name = name;
        Strength = str;
        Agility = agi;
        Intillegence = intil;
        Armor = arm;
        Attack = atck;
        Speed = spd;
        array[iterator++] = name;
        Console.WriteLine("Simple warrior, nothing special");
    }
    public Fighter() :this("NoName",15,15,15,0,8,10)
    {

    }
   
    //индексатор
    public string this[int index]{
        get {
            return array[index];
        }
        set
        {
            array[index] = value;
        }
    }

   IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator GetEnumerator()
    {
        return array.GetEnumerator();
    }

    public int CompareTo(Object obj)
    {
        #region exception
        try
        {
            if (!(obj is Fighter)) throw new ArgumentException();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.GetType());
            return -1;
        }
        #endregion
        if (Name == ((Fighter)obj).Name && Strength == ((Fighter)obj).Strength)
            return 0;
        else if (Strength > ((Fighter)obj).Strength)
            return 1;
        else return -1;

            }
    //Main characteristics
    protected string Name { get; set; }
    protected double Strength { get; set; }
    protected double Agility { get; set; }
    protected double Intillegence { get; set; }
    protected double Armor { get; set; }
    protected int Attack { get; set; }
    protected int Speed { get; set; }
    //---------------------------------------------------------


    //Virtual writing to file 
 
    public override string ToString()
    {
        string s = string.Format("Name: {0}, Strength: {1}",Name,Strength);
        return s;
    }
}

public interface A { }
class CollectionType<T> : IList<T>,IComparable where T: IComparable,new()
{
    private T[] array;
    private int _count;
    private int iterator;
    private int contains;
    
    public CollectionType(int size)
    {
        array = new T[size];
        _count = 0;
        iterator = -1;
    }
    public CollectionType() : this(10) { }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator<T>)(array.GetEnumerator());
    }

    public IEnumerator<T> GetEnumerator()
    {
        return (IEnumerator<T>)GetEnumerator();
    }

   
    
    public int CompareTo(Object obj)
    {
        if (this.GetCount() == ((CollectionType<T>)obj).GetCount())
            return 0;
        else if (this.GetCount() > ((CollectionType<T>)obj).GetCount())
            return 1;
        else return -1;

    }

    //public Fighter Query(CollectionType<T>[] mass)
    //{
    //  var result = from g in mass where g==g select g;
    //}

    public bool Contains(T value)
    {
        if (IsEmpty() == true) return false;
        for (int i = 0; i < _count; i++)
            if (array[i].CompareTo(value) == 0)
            {
                contains = i;
                return true;
            }

        return false;
    }
    private bool IsEmpty()
    {
        return _count == 0;
    }
    public bool Remove(T item)
    {
        #region exception
        if (IsEmpty() == false) return false;
        try
        {
            if (item == null) throw new NullReferenceException("Null parameter");
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.GetType());
            Console.WriteLine(e.Message);
        }
        #endregion
        if (Contains(item))
        {
            RemoveAt(contains);
            return true;
        }


        return false;
    }
    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }
    public bool WriteToFile()
    {
        if(System.IO.File.Exists(@"e:\4 семестр\c#\3\Collection.txt"))    
        System.IO.File.Delete(@"e:\4 семестр\c#\3\Collection.txt");

        for (int g = 0; g < _count; g++)
        {
            System.IO.File.AppendAllText(@"e:\4 семестр\c#\3\Collection.txt", array[g].ToString());
            System.IO.File.AppendAllText(@"e:\4 семестр\c#\3\Collection.txt", "\r\n");
        }
    return true;
    }

    public override string ToString()
    {
        string str = "Collection type:\n";
        for (int g = 0; g < this._count; g++)
        {
            str += array[g].ToString();
            str += "\n";
        }
        return str;
    }
    public void Add(T value)
    {
        array[++iterator] = value;
        _count++;
    }
    public void Clear()
    {
        if (IsEmpty() == true) return;
        for (int i = 0; i < _count; i++)
            array[i] = default(T);

        _count = 0;
        iterator = 0;
    }
    public void CopyTo(T[] newArray, int indexFrom)
    {
        #region exception
        try
        {
            if (newArray == null) throw new ArgumentNullException("Null argument");

        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);

        }
        #endregion
        for (int i = 0; i < _count; i++, indexFrom++)
            newArray[indexFrom] = array[i];
    }
    public void Insert(int index, T item)
    {
        #region exception
        try
        {
            if (index > _count || index < 0) throw new IndexOutOfRangeException("Index is out of range");

        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);

        }
        #endregion
        array[index] = item;

    }
    public void RemoveAt(int index)
    {
        #region exception
        if (IsEmpty() == true) return;
        try
        {
            if (index > _count || index < 0) throw new IndexOutOfRangeException("Index is out of range");
            if (array[index] == null) throw new ArgumentNullException("Index is null");

        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.GetType());
            Console.WriteLine(e.Message);

        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
        }
        #endregion
        for (int g = index; g < _count - 1; g++)
            array[g] = array[g + 1];

        _count--;
    }

    public int Count
    {
        get
        {
            return _count;
        }
    }
    public int IndexOf(T item)
    {
        if (IsEmpty() == true) return -1;
        Contains(item);
        return contains;
    }
    public int GetCount()
    {
        return _count;
    }
    

    public T this[int index]
    {
        get
        {
            #region exception
            try
            {
                if (array[index] == null) throw new ArgumentNullException("This index cotains null data");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
            return array[index];
        }
        set
        {
            #region exception
            try
            {
                if (index < 0 || index > 10) throw new ArgumentOutOfRangeException("Index is out of a range");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
            array[index] = value;
        }
    }

    
}

    class Program
    {
        static void Main(string[] args)
        {
            // новая коллекция Fighter
            CollectionType<Fighter> Hunters = new CollectionType<Fighter>();
            Fighter Jack = new Fighter("Jack", 13, 56, 34, 3, 9, 150);
            Fighter Sindy = new Fighter("Sindy", 5, 80, 23, 1, 12, 150);
            Fighter Lindsey = new Fighter("Lindsey", 4, 23, 12, 0, 5, 120);
            Fighter Moon = new Fighter("Moon", 4, 53, 45, 6, 5, 3);

            #region не смотреть!!!
            CollectionType<Fighter> Hunters1 = new CollectionType<Fighter>();
            CollectionType<Fighter> Hunters2 = new CollectionType<Fighter>();
            CollectionType<Fighter> Hunters3 = new CollectionType<Fighter>();

            Hunters1.Add(Jack);
            Hunters1.Add(Sindy);

            Hunters2.Add(Lindsey);
            Hunters2.Add(Moon);

            Hunters3.Add(new Fighter());
            Hunters3.Add(Moon);
            Hunters3.Add(Jack);
            #endregion
                   
            
            Hunters.Add(Jack);
            Hunters.Add(Sindy);
            Hunters.Add(Lindsey);

            //contains
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Is Hunters contains Jack? : {0}",Hunters.Contains(Jack));
            Console.WriteLine("Is Hunters contains Moon? : {0}", Hunters.Contains(Moon));

            //ToString()
            Console.WriteLine("------------------------------------------------------");
            for (int i = 0; i < Hunters.GetCount();i++ )
                Console.WriteLine(Hunters[i].ToString());
            Console.WriteLine("------------------------------------------------------");

            //removing/add element
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("First element is: {0}",Hunters[0].ToString());
            Console.WriteLine("Removing first element");
            Hunters.RemoveAt(0);
            Console.WriteLine("First element is now: {0}",Hunters[0].ToString());
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------");

            //using index
            Console.WriteLine("Return me index of Lindsey: {0}",Hunters.IndexOf(Lindsey));
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Hunters[1].ToString() = {0}", Hunters[1].ToString());
            Console.WriteLine("Now insert Moon to 1 index");
            Hunters.Insert(1, Moon);
            Console.WriteLine("Hunters[1].ToString() = {0}", Hunters[1].ToString());
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------");

            //comparing
            Console.WriteLine("Now lets compare Moon from Main() and Moon from Hunters");
            Console.WriteLine("Are they are the same instance? : {0}", Hunters[Hunters.IndexOf(Moon)].CompareTo(Moon));
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------");

            //using IO
            Console.WriteLine("Writing to file...");
            Hunters.WriteToFile();
            Console.WriteLine("Done!");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------");

            //LINQ
            CollectionType<Fighter>[] Ct = new CollectionType<Fighter>[4] {Hunters,Hunters1,Hunters2,Hunters3};
            var query = Ct.Where<CollectionType<Fighter>>(g => g.Count == 2).Select(g => g);                     //collections, where count = 2
            var query1 = from g in Ct where g.Count == 2 select g;                                               //same butanother syntax
            var query2 = Ct.Max<CollectionType<Fighter>>();                                                      //select max element
            var query3 = from g in Ct where g.Count < 10 select g;                                               //choose elements where count<10

            Console.WriteLine("Collections where count equal 2 :");
            foreach (var j in query)
                Console.WriteLine(j);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("Maximal element from collection: ");
            //foreach (var j in query)
            //    Console.WriteLine(j);
            //foreach (var j in query1)
            //    Console.WriteLine(j);
            Console.WriteLine(query2[0]);
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("Collections where count less than 10 :");
            foreach (var j in query3)
                Console.WriteLine(j);

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------");


            
            LinkedList<string> lil = new LinkedList<string>();
            lil.AddLast("First");
            lil.AddLast("Second");
            lil.AddLast("Third");
            lil.AddLast("Fourth");
            
            foreach (var j in lil)
                Console.WriteLine(j);

            Console.WriteLine("Should find count of words with length equal 5: ");
            long l = lil.LongCount(g=>g.Length==5);
            Console.WriteLine(l);

            
            //Console.WriteLine("Now Clear();");
            //Hunters.Clear();
            //Console.WriteLine("Number of element is now: {0}", Hunters.GetCount());
            //Console.WriteLine(Hunters[0].ToString());
        }
    }

