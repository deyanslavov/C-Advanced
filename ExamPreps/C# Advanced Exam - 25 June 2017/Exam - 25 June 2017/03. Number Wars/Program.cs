using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "0abcdefghijklmnopqrstuvwxyz";
            var firstHand = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var secondHand = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> firstPlayerCards = new Queue<string>(firstHand);
            Queue<string> secondPlayerCards = new Queue<string>(secondHand);
            int turnsCount = 0;
            bool wasThereAWar = false;
            bool firstPWin = false;
            bool secondPWin = false;
            bool isDraw = false;
            while (firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0 && turnsCount <= 1000000)
            {
                turnsCount++;
                var currHand1 = firstPlayerCards.Dequeue();
                var currHand2 = secondPlayerCards.Dequeue();

                int firstNum = int.Parse(currHand1.Substring(0, currHand1.Length - 1));
                int secondNum = int.Parse(currHand2.Substring(0, currHand2.Length - 1));
                if (firstNum > secondNum)
                {
                    firstPlayerCards.Enqueue(currHand1);
                    firstPlayerCards.Enqueue(currHand2);
                }
                else if (secondNum > firstNum)
                {
                    secondPlayerCards.Enqueue(currHand2);
                    secondPlayerCards.Enqueue(currHand1);
                }
                else
                {
                    wasThereAWar = true;
                    if (secondPlayerCards.Count < 3 && firstPlayerCards.Count < 3)
                    {
                        isDraw = true;
                        break;
                    }
                    else if (firstPlayerCards.Count < 3)
                    {
                        secondPWin = true;
                        break;
                    }
                    else if (secondPlayerCards.Count < 3)
                    {
                        firstPWin = true;
                        break;
                    }
                    else
                    {
                        List<string> cards = new List<string>();
                        int firstSum = GetSum(alphabet, firstPlayerCards, cards);
                        int secondSum = GetSum(alphabet, secondPlayerCards, cards);
                        cards = cards.OrderByDescending(a => a).ToList();

                        if (firstSum > secondSum)
                        {
                            for (int i = 0; i < cards.Count; i++)
                            {
                                firstPlayerCards.Enqueue(cards[i]);
                            }
                            cards.Clear();
                        }
                        else if(secondSum > firstSum)
                        {
                            for (int i = 0; i < cards.Count; i++)
                            {
                                secondPlayerCards.Enqueue(cards[i]);
                            }
                            cards.Clear();
                        }
                        else
                        {
                            bool gameEnded = false;
                            while (true)
                            {
                                if (firstSum == secondSum)
                                {
                                    if (secondPlayerCards.Count < 3 && firstPlayerCards.Count < 3)
                                    {
                                        gameEnded = true;
                                        isDraw = true;
                                        break;
                                    }
                                    else if (firstPlayerCards.Count < 3)
                                    {
                                        gameEnded = true;
                                        secondPWin = true;
                                        break;
                                    }
                                    else if (secondPlayerCards.Count < 3)
                                    {
                                        gameEnded = true;
                                        firstPWin = true;
                                        break;
                                    }
                                    firstSum += GetSum(alphabet, firstPlayerCards, cards);
                                    secondSum += GetSum(alphabet, secondPlayerCards, cards);
                                }
                                else
                                {
                                    if (firstSum > secondSum)
                                    {
                                        firstPWin = true;
                                        gameEnded = true;
                                        break;
                                    }
                                    else if (secondSum > firstSum)
                                    {
                                        secondPWin = true;
                                        gameEnded = true;
                                        break;
                                    }
                                    else
                                    {
                                        isDraw = true;
                                        gameEnded = true;
                                        break;
                                    }
                                }
                            }
                            if (gameEnded)
                            {
                                break;
                            }
                            cards.OrderByDescending(a => a).ToList();
                            if (firstSum > secondSum)
                            {
                                for (int i = 0; i < cards.Count; i++)
                                {
                                    firstPlayerCards.Enqueue(cards[i]);
                                }
                                cards.Clear();
                            }
                            else if (secondSum > firstSum)
                            {
                                for (int i = 0; i < cards.Count; i++)
                                {
                                    secondPlayerCards.Enqueue(cards[i]);
                                }
                                cards.Clear();
                            }
                        }
                    }
                }
            }
            if (wasThereAWar == false)
            {
                if (firstPlayerCards.Count == 0)
                {
                    Console.WriteLine($"Second player wins after {turnsCount} turns");
                }
                else if (secondPlayerCards.Count == 0)
                {
                    Console.WriteLine($"First player wins after {turnsCount} turns");
                }
                else if (firstPlayerCards.Count == 0 && secondPlayerCards.Count == 0)
                {
                    Console.WriteLine($"Draw after {turnsCount} turns");
                }
            }
            else
            {
                if (isDraw)
                {
                    Console.WriteLine($"Draw after {turnsCount} turns");
                }
                else if (secondPWin)
                {
                    Console.WriteLine($"Second player wins after {turnsCount} turns");
                }
                else if (firstPWin)
                {
                    Console.WriteLine($"First player wins after {turnsCount} turns");
                }
            }
        }

        private static int GetSum(string alphabet, Queue<string> firstPlayerCards, List<string> cards)
        {
            int sum = 0;

            var player1card1 = firstPlayerCards.Dequeue();
            var player1card1Value = player1card1[player1card1.Length - 1];
            var player1card2 = firstPlayerCards.Dequeue();
            var player1card2Value = player1card2[player1card2.Length - 1];
            var player1card3 = firstPlayerCards.Dequeue();
            var player1card3Value = player1card3[player1card3.Length - 1];
            cards.Add(player1card1); cards.Add(player1card2); cards.Add(player1card3);

            return sum = alphabet.IndexOf(player1card1Value) + alphabet.IndexOf(player1card2Value) + alphabet.IndexOf(player1card3Value);
        }
    }
}
