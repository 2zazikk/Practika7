using System;
using System.Collections.Generic;

// Класс клиента
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ServiceType { get; set; }

    public Customer(int id, string name, string serviceType)
    {
        Id = id;
        Name = name;
        ServiceType = serviceType;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Service: {ServiceType}";
    }
}

// Класс очереди банка
public class BankQueue
{
    private Queue<Customer> queue = new Queue<Customer>();

    // Добавить клиента в очередь
    public void Enqueue(Customer customer)
    {
        queue.Enqueue(customer);
        Console.WriteLine($"Добавлен: {customer.Name}");
    }

    // Обработать (удалить) следующего клиента
    public void Dequeue()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("Очередь пуста");
            return;
        }

        var customer = queue.Dequeue();
        Console.WriteLine($"Обслужен: {customer.Name}");
    }

    // Показать следующего клиента
    public void Peek()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("Очередь пуста");
            return;
        }

        var customer = queue.Peek();
        Console.WriteLine($"Следующий: {customer.Name}");
    }

    // Показать всех клиентов
    public void ShowAll()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("Очередь пуста");
            return;
        }

        Console.WriteLine("Клиенты в очереди:");
        foreach (var customer in queue)
        {
            Console.WriteLine(customer);
        }
    }
}

// Точка входа
class Program
{
    static void Main()
    {
        var bankQueue = new BankQueue();

        bankQueue.Enqueue(new Customer(1, "Иван", "Кредит"));
        bankQueue.Enqueue(new Customer(2, "Мария", "Депозит"));
        bankQueue.Enqueue(new Customer(3, "Алексей", "Консультация"));

        bankQueue.ShowAll();

        bankQueue.Peek();
        bankQueue.Dequeue();
        bankQueue.Dequeue();

        bankQueue.ShowAll();
    }
}