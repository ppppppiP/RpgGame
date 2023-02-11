using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RPGworld1
{
    public class BackPack
    {
        private readonly Item[] items;
        public int maxWeight { get; set; }


        public BackPack(int Freespace)
        {
            items = new Item[Freespace];
            maxWeight = Freespace + 100;
            for (int i = 0; i < Freespace; i++)
            {
                var Item = new Item("0", 0, 0);
                items[i] = Item;
            }
        }
        public static string[] Loot =  new string[5]{ "Очень тёмный меч", "Алмазный меч", "Зелье лечения",  "Броня из оперативной памяти(Тут есть и такое?)",
        "Самый лучший дроп в мире"};

        public int count = 0;
        public void Add(Item item)
        {
            int a = GetWeigth();
            int b = GetSpace();
            Console.WriteLine($"Общий вес = {a}, свободного места - {b}");
            if (a < maxWeight && b > 0 && count < items.Length)
            {
                items[count] = item;
                count++;
                Console.WriteLine("Предмет переместился к вам в рюкзак.");
            }
            else
            {
                Console.WriteLine("Перевес.");
            }
        }

        public int GetWeigth()
        {
            int result = 0;
            for (int i = 0; i < items.Length; i++)
            {
                result += items[i].Weigth;
            }
            return result;
        }
        public int GetSpace()
        {
            int Freespace = items.Length;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Weigth != 0)
                {
                    Freespace--;
                }
                else
                {
                    continue;
                }

            }
            return Freespace;
        }
        public void Looting(int a)
        {
            if (a == 1)
            {
                Random rand = new();
                var Item = new Item(Loot[rand.Next(0, 5)], 0, 0);
                
                    
                   if (Item.Name == "Очень тёмный меч")
                    {
                        Item.Weigth = 5;
                        Item.Damage = 20;
                     
                    }
                    else if (Item.Name == "Алмазный меч")
                    {
                        Item.Weigth = 10;
                        Item.Damage = 10;
                    
                    }
                    else if (Item.Name == "Зелье лечения")
                    {
                        Item.Weigth = 2;
                        Item.Damage = 0;
                      
                    }
                    else if (Item.Name == "Броня из оперативной памяти(Тут есть и такое?)")
                    {
                        Item.Weigth = 15;
                        Item.Damage = 0;

                    }
                    else if (Item.Name == "Самый лучший дроп в мире")
                    {
                        Item.Weigth = 30;
                        Item.Damage = rand.Next(20,100);


                    }
                
            start:
                Console.WriteLine();
                Console.Write($"Вы собрали с поверженной звезды некоторые ресурсы: ");
                Console.Write($"{Item.Name}", Console.ForegroundColor = ConsoleColor.Magenta);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine($"Что вы с ним сделаете?");
                Console.WriteLine("1 - Посмотреть сведения | 2 - Взять | 3 - Выбросить | 4 - Проверить рюкзак");
                Console.Write("Ответ: ");
                int ans = int.Parse(Console.ReadLine());
                
                if (ans == 1)
                {
                    Console.WriteLine();
                    Console.Write($"Вы изучаете предмет и понимаете, что его урон равен ");

                    Console.Write($" {Item.Damage}, ", Console.ForegroundColor = ConsoleColor.Yellow);
                    if (Item.Damage == 0)
                    {
                        Console.WriteLine("Урон равен нулю? Что за фигня? Возможно этим надо не бить ");
                    }else if(Item.Name == "Самый лучший дроп в мире")
                    {
                        Console.WriteLine("Урон не известен? Говорят, что в этом мире есть предмет с уроном, который дается рандомно, и узнать его получится только в бою");
                    }  
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"а вес - {Item.Weigth}.");
                    Console.WriteLine();
                    goto start;
                }
                else if (ans == 2)
                {
                    Add(Item);
                }
                else if (ans == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Вы выбрасываете предмет за ненадабностью и идёте дальше.");
                }
                else if (ans == 4)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Предмет/ Вес / Урон");
                    Console.WriteLine();
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].Name == "0" && items[i].Weigth == 0 && items[i].Damage == 0)
                        {
                            Console.WriteLine("Пустой слот");
                        }
                        else if (items[i].Name == "Очень тёмный меч")
                        {
                            
                            Console.WriteLine($"{items[i].Name} / {items[i].Weigth} / {items[i].Damage}");
                        }
                        else if (items[i].Name == "Алмазный меч")
                        {
                         
                            Console.WriteLine($"{items[i].Name} / {items[i].Weigth} / {items[i].Damage}");
                        }
                        else if (items[i].Name == "Зелье лечения")
                        {
                           
                            Console.WriteLine($"{items[i].Name} / {items[i].Weigth} / {items[i].Damage}");
                        }
                        else if (items[i].Name == "Броня из оперативной памяти(Тут есть и такое?)")
                        {

                            Console.WriteLine($"{items[i].Name} / {items[i].Weigth} / {items[i].Damage}");
                        }
                        else if (items[i].Name == "Самый лучший дроп в мире")
                        {

                            Console.WriteLine($"{items[i].Name} / {items[i].Weigth} / Засекречено");
                        }
                    }
                    goto start;
                }
            }
            else if (a == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Вы обессилено падаете на землю, теряя последнии остатки сознания...");
                Console.WriteLine();
                Console.WriteLine("...");
                Console.WriteLine();


                Console.WriteLine("Вы очухиваетесь на том же месте, однако понимаете, что все ваши вещи были растосканы местными обитателями");
                Console.WriteLine("Что ж, ничего не поделать..");
            }
          
        }
        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine($"Предмет/ Вес / Цена");
            Console.WriteLine();
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Name == "0" && items[i].Weigth == 0 && items[i].Damage == 0)
                {
                    Console.WriteLine("Пустой слот");
                }
                else
                {
                    Console.WriteLine($"{items[i].Name} / {items[i].Weigth} / {items[i].Damage}");
                }
            }

        }
        public double ItemGet(int a)
        {
            return items[a].Damage;
            
            
        }
        public string ItemNameGet(int a) {
            return items[a].Name;
        }
        public void DeleteItem(int a)
        {
            items[a].Weigth = 0;
            items[a].Damage = 0;
            items[a].Name = "0";
        }

    }
}
