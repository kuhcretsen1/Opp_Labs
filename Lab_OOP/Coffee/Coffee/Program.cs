using System;
using System.Collections.Generic;

public interface ICoffeeMachine
{
    bool MakeEspresso();
    bool MakeLatte();
    string CheckStatus();
}

public class CoffeeMachine : ICoffeeMachine
{
    private const int EspressoBeansRequired = 20;
    private const int LatteBeansRequired = 25;
    private const int MinWaterRequired = 1;
    private const int HeatingWaterThreshold = 50;

    private int _water;
    private int _beans;
    private bool _isWaterHeated;

    public CoffeeMachine(int initialWater, int initialBeans)
    {
        _water = initialWater;
        _beans = initialBeans;
        _isWaterHeated = false;
    }

    public bool MakeEspresso()
    {
        if (!CanMakeDrink(EspressoBeansRequired))
        {
            return false;
        }

        _beans -= EspressoBeansRequired;
        Console.WriteLine("Espresso made.");
        return true;
    }

    public bool MakeLatte()
    {
        if (!CanMakeDrink(LatteBeansRequired))
        {
            return false;
        }

        _beans -= LatteBeansRequired;
        Console.WriteLine("Latte made.");
        return true;
    }

    public string CheckStatus()
    {
        return $"Water: {_water} units, Beans: {_beans} grams, Water Heated: {_isWaterHeated}";
    }

    private bool CanMakeDrink(int beansRequired)
    {
        EnsureWaterHeated();

        if (_beans < beansRequired)
        {
            Console.WriteLine("Not enough beans.");
            return false;
        }

        if (_water < MinWaterRequired)
        {
            Console.WriteLine("Not enough water.");
            return false;
        }

        return true;
    }

    private void EnsureWaterHeated()
    {
        if (_water >= HeatingWaterThreshold && !_isWaterHeated)
        {
            _isWaterHeated = true;
            Console.WriteLine("Water heated.");
        }
        else if (_water < HeatingWaterThreshold)
        {
            Console.WriteLine("Not enough water to heat.");
        }
    }
}

class Program
{
    private static readonly Dictionary<string, Action<CoffeeMachine>> Commands = new()
    {
        { "make espresso", machine =>
            {
                if (machine.MakeEspresso())
                {
                    Console.WriteLine("Espresso made successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to make Espresso.");
                }
            }
        },
        { "make latte", machine =>
            {
                if (machine.MakeLatte())
                {
                    Console.WriteLine("Latte made successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to make Latte.");
                }
            }
        },
        { "status", machine =>
            {
                Console.WriteLine(machine.CheckStatus());
            }
        }
    };

    static void Main()
    {
        var coffeeMachine = new CoffeeMachine(100, 50); 

        while (true)
        {
            Console.WriteLine("Commands: make espresso, make latte, status, exit");
            var command = Console.ReadLine()?.ToLower();

            if (command == "exit")
            {
                break;
            }

            if (Commands.TryGetValue(command, out var action))
            {
                action(coffeeMachine);
            }
            else
            {
                Console.WriteLine("Unknown command.");
            }
        }
    }
}
