using System;
using System.Collections.Generic;
using System.IO;

public enum SubscriberType
{
    Regular,
    SeniorCitizen,
    Student
}

public struct Subscriber
{
    public int AccountNumber;
    public string Name;
    public string Address;
    public string PhoneNumber;
    public int ContractNumber;
    public DateTime ContractDate;
    public bool HasDiscount;
    public SubscriberType Type;
    public string TariffPlan;

    public Subscriber(int accountNumber, string name, string address, string phoneNumber, int contractNumber, DateTime contractDate, bool hasDiscount, SubscriberType type, string tariffPlan)
    {
        AccountNumber = accountNumber;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        ContractNumber = contractNumber;
        ContractDate = contractDate;
        HasDiscount = hasDiscount;
        Type = type;
        TariffPlan = tariffPlan;
    }

    public override string ToString()
    {
        return $"Номер рахунку: {AccountNumber}, П.І.П.: {Name}, Адреса: {Address}, Телефон: {PhoneNumber}, Номер договору: {ContractNumber}, Дата укладення: {ContractDate.ToShortDateString()}, Пільги: {HasDiscount}, Тип абонента: {Type}, Тарифний план: {TariffPlan}";
    }
}

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Subscriber> subscribers = new List<Subscriber>
        {
            new Subscriber(1, "Іванов Іван Іванович", "м. Київ, вул. Хрещатик, 1", "123-456-789", 1001, new DateTime(2020, 1, 15), true, SubscriberType.SeniorCitizen, "Basic"),
            new Subscriber(2, "Петренко Петро Петрович", "м. Харків, вул. Сумська, 2", "987-654-321", 1002, new DateTime(2021, 5, 20), false, SubscriberType.Regular, "Premium"),
            new Subscriber(3, "Сидоренко Сидір Сидорович", "м. Одеса, вул. Дерибасівська, 3", "555-666-777", 1003, new DateTime(2022, 3, 10), true, SubscriberType.Student, "Standard")
        };

        Console.WriteLine("Пошук за номером договору:");
        int contractNumberToFind = 1002;
        Subscriber? resultByContractNumber = FindByContractNumber(subscribers, contractNumberToFind);
        if (resultByContractNumber != null)
        {
            Console.WriteLine(resultByContractNumber.ToString());
        }
        else
        {
            Console.WriteLine("Абонента з таким номером договору не знайдено.");
        }

        Console.WriteLine("\nПошук за іменем абонента:");
        string nameToFind = "Петренко Петро Петрович";
        Subscriber? resultByName = FindByName(subscribers, nameToFind);
        if (resultByName != null)
        {
            Console.WriteLine(resultByName.ToString());
        }
        else
        {
            Console.WriteLine("Абонента з таким іменем не знайдено.");
        }

        Console.WriteLine("\nПошук за тарифним планом:");
        string tariffPlanToFind = "Premium";
        List<Subscriber> resultsByTariffPlan = FindByTariffPlan(subscribers, tariffPlanToFind);
        if (resultsByTariffPlan.Count > 0)
        {
            foreach (var subscriber in resultsByTariffPlan)
            {
                Console.WriteLine(subscriber.ToString());
            }
        }
        else
        {
            Console.WriteLine("Абонентів з таким тарифним планом не знайдено.");
        }
    }

    public static Subscriber? FindByContractNumber(List<Subscriber> subscribers, int contractNumber)
    {
        foreach (var subscriber in subscribers)
        {
            if (subscriber.ContractNumber == contractNumber)
            {
                return subscriber;
            }
        }
        return null;
    }

    public static Subscriber? FindByName(List<Subscriber> subscribers, string name)
    {
        foreach (var subscriber in subscribers)
        {
            if (subscriber.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return subscriber;
            }
        }
        return null;
    }

    public static List<Subscriber> FindByTariffPlan(List<Subscriber> subscribers, string tariffPlan)
    {
        List<Subscriber> results = new List<Subscriber>();
        foreach (var subscriber in subscribers)
        {
            if (subscriber.TariffPlan.Equals(tariffPlan, StringComparison.OrdinalIgnoreCase))
            {
                results.Add(subscriber);
            }
        }
        return results;
    }
}
