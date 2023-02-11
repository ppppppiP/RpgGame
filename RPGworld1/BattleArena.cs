using RPGworld1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGworld1
{
    public class BattleArena
    {
        public Enemy Enemy { get; set; }
        public Hero Hero { get; set; }
     public Item Item { get; set; } 
        BackPack BackPack { get; set; }


        public BattleArena(Enemy enemy, Hero hero, BackPack backPack)
        {
            Enemy = enemy;
            Hero = hero;
            BackPack= backPack;
        }



        public void Battle()
        {
            Random rand = new Random();
            int Chance;
            var Enemy = new Enemy("Дракон", 11, 125, 15);
        
            Console.WriteLine($"Выберите оружие из рюкзака {BackPack.Show}");
            BackPack.Show();
            Console.WriteLine("введите 1/2/3/4/5 в зависимости от того что вы хотите взять");
            int aa = Convert.ToInt32(Console.ReadLine());
            double HeroDamage = 0;
            double hp = Hero.Hp;
            if (aa == 1)
            {if (BackPack.ItemNameGet(0) == "Зелье лечения")
                {
                    hp = hp + 50;
                }
                else
                {
                    HeroDamage = Hero.Damage + BackPack.ItemGet(0);
                }
            }else if(aa == 2)
            {
                if (BackPack.ItemNameGet(1) == "Зелье лечения")
                {
                    hp = hp + 50;
                }
                else
                {
                    HeroDamage = Hero.Damage + BackPack.ItemGet(0);
                }
            }
            else if (aa == 3)
            {
                if (BackPack.ItemNameGet(2) == "Зелье лечения")
                {
                    hp = hp + 50;
                }
                else
                {
                    HeroDamage = Hero.Damage + BackPack.ItemGet(0);
                }
            }
            else if (aa == 4)
            {
                if (BackPack.ItemNameGet(3) == "Зелье лечения")
                {
                    hp = hp + 50;
                }
                else
                {
                    HeroDamage = Hero.Damage + BackPack.ItemGet(0);
                }
            }
            else if (aa == 5)
            {
                if (BackPack.ItemNameGet(4) == "Зелье лечения")
                {
                    hp = hp + 50;
                }
                else
                {
                    HeroDamage = Hero.Damage + BackPack.ItemGet(0);
                }
            }
            Console.WriteLine("Теперь вы готовы к битве со своими противниками. Первым противником будет " + Enemy.Name);
            string[] step = { "Нападение", "Защита" };
            
            bool stepN = false;
        restart:
            
                do
                {

                    Console.WriteLine("Противник нападает, выберите действие 1 - защититься, 2 - напасть в ответ");
                    int change = Convert.ToInt32(Console.ReadLine());
                    if (change == 1 && rand.Next(0, 100) < 80)
                    {
                        Console.WriteLine("Вы смогли защититься от атаки, с этих пор атаковать уже будете вы");
                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                        stepN = true;

                    }
                    else if (change == 1 && rand.Next(0, 100) > 80)
                    {
                        Console.WriteLine("Вы не смогли защититься, вам нанесли урон");
                        hp -= Enemy.Damage;
                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1);
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли(");
                    }
                    else
                    {


                        goto restart;
                    }
                        
                    }
                    else if (change == 2 && rand.Next(0, 100) > 80)
                    {
                        Console.WriteLine("Вы смогли ударить в ответ и попали!");
                        Enemy.Hp -= Enemy.Damage;

                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1);
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли(");
                    }
                    else
                    {


                        stepN = true;
                    }
                    }
                    else if (change == 2 && rand.Next(0, 100) < 80)
                    {
                        Console.WriteLine("Ваша попытка атаковать закончилась провалом. Попробуйте в следущий раз, может быть вам повезет");
                        hp -= Enemy.Damage;
                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1);
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли(");
                    }
                    else
                    {


                        goto restart;
                    }
                    }
                } while (stepN == false);
            
        start:
            
                do
                {

                    Console.WriteLine("");
                    Console.WriteLine("1 - нападайте");
                    int change = Convert.ToInt32(Console.ReadLine());
                    if (change == 1 && rand.Next(0, 100) > 20 && rand.Next(0, 100) > 50)
                    {
                        Console.WriteLine("Враг не смог увернуться, вы попали!");
                        Enemy.Hp -= Enemy.Damage;

                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1);
                        break;
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли("); break;
                    }
                    else
                    {


                        goto start;
                    }

                    }
                    else if (change == 1 && rand.Next(0, 100) < 20 && rand.Next(0, 100) > 50)
                    {
                        Console.WriteLine("Вы промахнулись, враг увернулся. Попробуйте в следущий раз, может быть вам повезет");
                       
                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                    if (Enemy.Hp < 0)
                    {
                        Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1); break;
                    }
                    else if (hp < 0)
                    {
                        Console.WriteLine("Вы проиграли("); break;
                    }
                    else
                    {
                       

                        stepN = false;
                        goto restart;
                    }
                    }else if (change == 1 && rand.Next(0, 100) > 20 && rand.Next(0, 100) < 50)
                    {
                        Console.WriteLine("Враг решил атаковать в ответ!");
                        Console.WriteLine("Продолжить атаку или защититься? 1 / 2");
                        int aaa = Convert.ToInt32(Console.ReadLine());
                    if (aaa == 1 && rand.Next(0, 100) < 80)
                    {
                        Enemy.Hp -= Enemy.Damage;
                        Console.WriteLine("Враг не смог вас атаковать в ответ и потерпел поражение");
                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                        if (Enemy.Hp < 0)
                        {
                            Console.WriteLine("Вы победили! Поздравляю"); BackPack.Looting(1); break;
                        }
                        else if (hp < 0)
                        {
                            Console.WriteLine("Вы проиграли("); break;
                        }
                        else
                        {


                            goto start;
                        }
                    }
                    
                    
                    else if (aaa == 1 && rand.Next(0, 100) > 80)
                    {
                        Console.WriteLine("Враг успешно атаковал в ответ");
                        hp -= Enemy.Damage;
                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                        if (hp < 0)
                        {
                            Console.WriteLine("Вы проиграли("); break;
                        }
                        else
                        {


                            stepN = false;
                            goto restart;
                        }
                    }
                    else if (aaa == 2 && rand.Next(0, 100) < 80)
                    {
                        Console.WriteLine("Вы успешно защитились");
                        goto start;
                    }
                    else if(aaa == 2 && rand.Next(0, 100) >= 80)
                    {
                        Console.WriteLine("Вы не смогли защититься от ответной атаки враг");
                        hp -= Enemy.Damage;
                        Console.WriteLine($"Ваше здоровье:{hp} Здоровье противника: {Enemy.Hp} ");
                        
                         if (hp < 0)
                        {
                            Console.WriteLine("Вы проиграли("); break;
                        }
                        else
                        {


                            stepN = false;
                            goto restart;
                        }
                    }
                    }
                } while (stepN == true);
            
           

        }

    }
}
