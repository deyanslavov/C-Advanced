namespace P01
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Queue<string> cars = new Queue<string>();
            int totalCarsPassed = 0;
            bool crashed = false;

            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                if (line == "green")
                {
                    if (cars.Count == 0)
                    {
                        continue;
                    }
                    string currentCar = cars.Peek();

                    if (currentCar.Length <= greenLightDuration + freeWindowDuration)
                    {
                        cars.Dequeue();
                        totalCarsPassed++;

                        int timeLeft = greenLightDuration - currentCar.Length;

                        if (timeLeft > 0)
                        {
                            int count = cars.Count;
                            for (int i = 0; i < count; i++)
                            {
                                if (timeLeft < 1)
                                {
                                    break;
                                }
                                currentCar = cars.Peek();
                                if (currentCar.Length <= timeLeft + freeWindowDuration)
                                {
                                    timeLeft -= currentCar.Length;
                                    cars.Dequeue();
                                    totalCarsPassed++;
                                }
                                else
                                {
                                    int index = timeLeft + freeWindowDuration;
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{currentCar} was hit at {currentCar[index]}.");
                                    crashed = true;
                                    break;
                                }
                            }
                            if (crashed)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        int difference = currentCar.Length - (greenLightDuration + freeWindowDuration);

                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {currentCar[difference]}.");
                        crashed = true;
                        break;
                    }
                }
                else
                {
                    cars.Enqueue(line);
                }
            }

            if (!crashed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }
        }
    }
}
