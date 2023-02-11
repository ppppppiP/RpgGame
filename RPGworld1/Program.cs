using RPGworld1;

    BackPack backPack = new(5);
backPack.Looting(1);
backPack.Looting(1);
backPack.Looting(1);
backPack.Looting(1);
backPack.Looting(1);
Hero hero = new("Hero", 10, 100);
Enemy enemy = new("Дракон", 11, 150, 15);
BattleArena arena = new(enemy, hero, backPack);
arena.Battle();




