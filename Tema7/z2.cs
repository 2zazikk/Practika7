using System;
using System.Collections.Generic;

// Собственная коллекция "один ключ → много значений"
public class MyMultiMap<TKey, TValue>
{
    private Dictionary<TKey, List<TValue>> data = new Dictionary<TKey, List<TValue>>();

    // Добавление значения к ключу
    public void Add(TKey key, TValue value)
    {
        if (!data.ContainsKey(key))
        {
            data[key] = new List<TValue>();
        }

        data[key].Add(value);
    }

    // Удаление конкретного значения у ключа
    public bool Remove(TKey key, TValue value)
    {
        if (!data.ContainsKey(key))
            return false;

        bool removed = data[key].Remove(value);

        // если список пуст — удаляем ключ
        if (data[key].Count == 0)
        {
            data.Remove(key);
        }

        return removed;
    }

    // Поиск всех значений по ключу
    public List<TValue> Find(TKey key)
    {
        if (data.ContainsKey(key))
        {
            return data[key];
        }

        return new List<TValue>();
    }
}

// Класс-менеджер для работы с MultiMap
public class MultiMapManager<TKey, TValue>
{
    private MyMultiMap<TKey, TValue> multiMap = new MyMultiMap<TKey, TValue>();

    public void Add(TKey key, TValue value)
    {
        multiMap.Add(key, value);
    }

    public void Remove(TKey key, TValue value)
    {
        multiMap.Remove(key, value);
    }

    public void Search(TKey key)
    {
        var values = multiMap.Find(key);

        if (values.Count == 0)
        {
            Console.WriteLine("Ничего не найдено");
            return;
        }

        Console.WriteLine($"Значения для ключа {key}:");
        foreach (var value in values)
        {
            Console.WriteLine(value);
        }
    }
}

// Точка входа
class Program
{
    static void Main()
    {
        var manager = new MultiMapManager<string, string>();

        manager.Add("IT", "Ivan");
        manager.Add("IT", "Maria");
        manager.Add("HR", "Anna");

        manager.Search("IT");

        manager.Remove("IT", "Ivan");

        manager.Search("IT");
    }
}