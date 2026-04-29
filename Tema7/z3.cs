using System;
using System.Collections.Generic;

// Обобщённый интерфейс управления списками
public interface IListManager<T>
{
    void Add(T item);
    void Remove(T item);
    T GetAt(int index);
    IEnumerable<T> GetAll();
}

// Реализация интерфейса через List<T>
public class SimpleListManager<T> : IListManager<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public T GetAt(int index)
    {
        if (index < 0 || index >= items.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return items[index];
    }

    public IEnumerable<T> GetAll()
    {
        return items;
    }
}

// Бизнес-логика поверх менеджера
public class ListManager<T>
{
    private readonly IListManager<T> listManager;

    public ListManager(IListManager<T> manager)
    {
        listManager = manager;
    }

    public void PrintAll()
    {
        foreach (var item in listManager.GetAll())
        {
            Console.WriteLine(item);
        }
    }

    public bool Contains(T item)
    {
        foreach (var element in listManager.GetAll())
        {
            if (EqualityComparer<T>.Default.Equals(element, item))
                return true;
        }

        return false;
    }
}

// Точка входа
class Program
{
    static void Main()
    {
        IListManager<string> simple = new SimpleListManager<string>();
        var manager = new ListManager<string>(simple);

        simple.Add("Apple");
        simple.Add("Banana");
        simple.Add("Orange");

        manager.PrintAll();

        Console.WriteLine(manager.Contains("Banana")); // True
        Console.WriteLine(manager.Contains("Grape"));   // False

        simple.Remove("Banana");

        manager.PrintAll();
    }
}