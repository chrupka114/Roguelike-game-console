// See https://aka.ms/new-console-template for more information

using System;
using System.Text.RegularExpressions;
namespace project
{
    public class Rand
    {
        public int Run(int min, int max)
        {
            int range = (max - min) + 1;
            Random rng = new Random();
            return min + rng.Next() % range;
        }
    }


    public class Hero
    {
        public string Name;
        private int Strength;
        private int Dexterity;
        private int Intelligence;
        private int Constitution;
        public double HP;
        public double MP;
        private double Exp;
        private int lvl;
        private int cost;
        private int damage;
        public string spellname;

        private void Init(int strength = 1, int dexterity = 1, int intelligence = 1, int constitution = 1, bool mana = false, double exp = 0, int Lvl = 1)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Intelligence = intelligence;
            this.Constitution = constitution;
            HP = (Constitution * 10) + strength;
            if (mana == true) MP = 10 + (3 * intelligence);
            Exp = exp;
            lvl = Lvl;

        }

        public void randomencounter(Hero hero)
        {
            Rand rand = new Rand();
            int r = rand.Run(0, 1);
            Hero rat = new Hero("rat", "rat");
            Hero spider = new Hero("spider", "spider");
            switch (r)
            {
                case 0:
                    Console.WriteLine("spotykasz szczura");
                    hero.walka(rat, hero, 1);
                    break;
                case 1:
                    Console.WriteLine("spotykasz pająka");
                    hero.walka(spider, hero, 2);
                    break;
            }
        }

        public void drawrat()
        {
            Console.WriteLine("  (),())");
            Console.WriteLine("  oo   '''//,        _");
            Console.WriteLine(",/_;~,        ),    / '");
            Console.WriteLine("      ',|  )    |__.'");
            Console.WriteLine("      '~  '~----''");
        }
        public void drawspider()
        {
            Console.WriteLine("          (");
            Console.WriteLine("           )");
            Console.WriteLine("          (");
            Console.WriteLine("    /\\  .-'''-.  /\\");
            Console.WriteLine("   //\\/   ,,,  \\//\\\\");
            Console.WriteLine("   |/\\| ,;;;;;, |/\\\\|");
            Console.WriteLine("   //\\\\;-'''-;///\\\\");
            Console.WriteLine("  //  \\/   .   \\/  \\");
            Console.WriteLine("(| ,-_| \\ | / |_-, |)");
            Console.WriteLine("   //`__\\.-.-./__`\\\\");
            Console.WriteLine("  // /.-(() ())-.\\ \\\\");
            Console.WriteLine(" (\\ |)   '---'   (| /)");
            Console.WriteLine("  ` (|           |) `");
            Console.WriteLine("    \\)           (/");
        }

        public int GetDamage() { return this.damage; }
        public int GetCost() { return this.cost; }
        public int GetStrength() { return this.Strength; }
        public int GetDexterity() { return this.Dexterity; }
        public int GetIntelligence() { return this.Intelligence; }
        public int GetConstitution() { return this.Constitution; }
        public double GetExp() { return this.Exp; }

        public void UpStrength() { this.Strength += 5; this.HP += 5; }
        public void UpDexterity() { this.Dexterity += 5; }
        public void UpIntelligence() { this.Intelligence += 5; this.MP += (3 * this.Intelligence); }
        public void UpConstitution() { this.Constitution += 2; this.HP += (10 * this.Constitution); }

        private int spelldamage(string spellname)
        {
            switch (spellname)
            {
                case "fireball": return 15;
                case "thunderbolt": return 20;
                case "wind sheer": return 5;
                case "earth shock": return 10;
                case "heal": return 15;
                default: return 0;
            }
        }

        private double spellcost(string spellname)
        {
            switch (spellname)
            {
                case "fireball": return 5;
                case "thunderbolt": return 6;
                case "wind sheer": return 3;
                case "earth shock": return 4;
                case "heal": return 10;
                default: return 0;
            }
        }




        public Hero(string name, string myclass)
        {
            this.Name = name;
            switch (myclass)
            {
                case "warrior": Init(8, 5, 2, 5, true, 0, 1); break;
                case "assassin": Init(3, 8, 4, 5, true, 0, 1); break;
                case "sorcerer": Init(4, 2, 9, 5, true, 0, 1); break;
                case "rat": Init(2, 2, 2, 5, false, 0, 1); break;
                case "spider": Init(3, 5, 2, 5, false, 0, 1); break;
                default: Init(); break;
            }
        }

        public void walka(Hero enemy, Hero hero, int enemyid)
        {

            int? opt = 8, tour = 1;
            while (hero.HP > 0 && enemy.HP > 0)
            {
                if (tour == 1)
                {
                    Console.WriteLine("Your Turn: " + hero.Name);
                    Console.Write("1:Attack, 2:Spell, 3:eq, 4:ucieczka ");

                    opt = int.Parse(Console.ReadLine());

                }

                else { Console.WriteLine(enemy.Name + " attacks"); opt = 1; }

                switch (opt)
                {
                    case 1:
                        if (tour == 1) hero.Attack(enemy);
                        else enemy.Attack(hero);
                        break;

                    case 2:
                        int spell = 9;


                        while (spell >= 6)
                        {
                            Console.WriteLine("jaki spell(1:fireball 2:thunderbolt 3:Wind Sheer 4:Earth Shock 5:heal)");
                            spell = int.Parse(Console.ReadLine());
                            if (spell <= 0 || spell >= 6) Console.WriteLine("nie ma takiego spella");
                        }
                        switch (spell)
                        {
                            case 1:
                                if (hero.MP < spellcost("fireball"))
                                {
                                    Console.WriteLine("za mało many");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    enemy.HP = enemy.HP - spelldamage("fireball");
                                    hero.MP = hero.MP - spellcost("fireball");
                                }
                                break;

                            case 2:
                                if (hero.MP < spellcost("thunderbolt"))
                                {
                                    Console.WriteLine("za mało many");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    enemy.HP = enemy.HP - spelldamage("thunderbolt");
                                    hero.MP = hero.MP - spellcost("thunderbolt");
                                }
                                break;

                            case 3:
                                if (hero.MP < spellcost("wind sheer"))
                                {
                                    Console.WriteLine("za mało many");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    enemy.HP = enemy.HP - spelldamage("wind sheer");
                                    hero.MP = hero.MP - spellcost("wind sheer");
                                }
                                break;

                            case 4:
                                if (hero.MP < spellcost("earth shock"))
                                {
                                    Console.WriteLine("za mało many");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    enemy.HP = enemy.HP - spelldamage("earth shock");
                                    hero.MP = hero.MP - spellcost("earth shock");
                                }
                                break;
                            case 5:
                                if (hero.MP < spellcost("heal"))
                                {
                                    Console.WriteLine("za mało many");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    if (hero.HP + spelldamage("heal") > (hero.GetConstitution() * 10) + hero.GetStrength())
                                    {
                                        hero.HP = (hero.GetConstitution() * 10) + hero.GetStrength();
                                        hero.MP = hero.MP - spellcost("heal");
                                    }
                                    else
                                    {
                                        hero.HP = hero.HP + spelldamage("heal");
                                        hero.MP = hero.MP - spellcost("heal");
                                    }
                                }
                                break;


                            default:
                                Console.WriteLine("nie ma takiego spella");
                                break;
                        }


                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case null:
                        Console.WriteLine("nie ma takiej opcji ");
                        tour--;
                        break;

                    default:
                        Console.WriteLine("nie ma takiej opcji ");
                        tour--;
                        break;
                }

                Console.WriteLine(hero.Name + "  HP:{0}, Mp:{1}", hero.HP, hero.MP);
                Console.WriteLine(enemy.Name + " HP:{0}", enemy.HP);
                switch (enemyid)
                {
                    case 1:
                        drawrat();
                        break;

                    case 2:
                        drawspider();
                        break;
                }




                Console.WriteLine();
                Console.ReadLine();

                tour++;
                if (tour > 2) tour = 1;
            }
            Console.WriteLine("otrzymałeś " + (enemy.lvl * 10) + " expa");
            hero.Exp = hero.Exp + (enemy.lvl * 10);
            //hero.Exp = 100;

            if (hero.Exp == hero.lvl * 100)
            {
                Console.WriteLine("awans na " + (hero.lvl + 1) + " poziom");
                LevelUp();

            }

        }

        public void SpellAttack(Hero enemy) { }

        public void Attack(Hero enemy)
        {
            Rand rand = new Rand();
            double damage = Strength * rand.Run(5, 10) / 10;

            if (rand.Run(0, 100) > enemy.GetDexterity())
            {
                Console.WriteLine("Bang!");
                enemy.HP -= damage;
            }
            else Console.WriteLine("Dodge!");
        }
        public void LevelUp()
        {
            Console.Write("  1:Strength, 2:Dexterity, 3:Intelligence 4:Constitution ");
            int opt = int.Parse(Console.ReadLine());

            switch (opt)
            {
                case 1: UpStrength(); break;
                case 2: UpDexterity(); break;
                case 3: UpIntelligence(); break;
                case 4: UpConstitution(); break;
            }

            Console.WriteLine();
        }
    }

    class program
    {
        static void maprys(int[] playerposition, int[,] mapa)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (playerposition[0] == j && playerposition[1] == i) Console.Write("[ * ]");
                    else if (mapa[j, i] == 1) Console.Write("[" + j + "," + i + "]");
                    else if (mapa[j, i] == 3) Console.Write("[" + j + "+" + i + "]");
                    else if (mapa[j, i] == 2 || mapa[j, i] == 0) Console.Write("     ");
                }
                Console.WriteLine();
            }
        }



        static int mapgen(int[,] mapa, int iloscpokoi)
        {
            int[] pokoj = new int[2];

            //prawa strona
            for (int i = 5; i < 10; i++)
            {
                for (int j = 6; j > 0; j--)
                {
                    if (mapa[i, j] == 1)
                    {
                        pokoj[0] = i;
                        pokoj[1] = j;
                        iloscpokoi = pokojgen(pokoj, mapa, iloscpokoi);
                    }
                }
            }
            //lewa strona
            for (int i = 4; i > 0; i--)
            {
                for (int j = 6; j > 0; j--)
                {
                    if (mapa[i, j] == 1)
                    {
                        pokoj[0] = i;
                        pokoj[1] = j;
                        iloscpokoi = pokojgen(pokoj, mapa, iloscpokoi);
                    }
                }
            }



            return iloscpokoi;
        }
        static int pokojgen(int[] pokoj, int[,] mapa, int iloscpokoi)
        {
            int przod = 8, tyl = 8, prawo = 8, lewo = 8;
            bool exitexists = false;

            //mapa[x,y]:=0 niezbadane,=1 istnieje,=2 nie istnieje,=3 przeciwnik,=4 loot

            while (exitexists == false)
            {

                przod = pokoj[1] - 1;
                if (mapa[pokoj[0], przod] == 0)
                {
                    Random rng = new Random();
                    int nbr = rng.Next() % (3);
                    if (nbr == 0 || przod < 0) mapa[pokoj[0], przod] = 2; //brak pokoju
                    if (nbr == 2)
                    {                               //przeciwnk w pokoju
                        mapa[pokoj[0], przod] = 3;
                        iloscpokoi++;
                    }
                    if (nbr == 1)
                    {
                        mapa[pokoj[0], przod] = 1;  //pokoj istnieje        
                        iloscpokoi++;
                    }
                }

                tyl = pokoj[1] + 1;
                if (mapa[pokoj[0], tyl] == 0)
                {
                    Random rng = new Random();
                    int nbr = rng.Next() % (3);
                    if (nbr == 0 || tyl >= 6) mapa[pokoj[0], tyl] = 2;
                    if (nbr == 2)
                    {
                        mapa[pokoj[0], tyl] = 3;
                        iloscpokoi++;
                    }
                    if (nbr == 1)
                    {
                        mapa[pokoj[0], tyl] = 1;
                        iloscpokoi++;
                    }
                }

                prawo = pokoj[0] + 1;
                if (mapa[prawo, pokoj[1]] == 0)
                {
                    Random rng = new Random();
                    int nbr = rng.Next() % (3);
                    if (nbr == 0 || prawo > 10) mapa[prawo, pokoj[1]] = 2;
                    if (nbr == 2)
                    {
                        mapa[prawo, pokoj[1]] = 3;
                        iloscpokoi++;
                    }
                    if (nbr == 1)
                    {
                        mapa[prawo, pokoj[1]] = 1;
                        iloscpokoi++;
                    }
                }

                lewo = pokoj[0] - 1;
                if (mapa[lewo, pokoj[1]] == 0)
                {
                    Random rng = new Random();
                    int nbr = rng.Next() % (3);
                    if (nbr == 0 || lewo < 0) mapa[lewo, pokoj[1]] = 2;
                    if (nbr == 2)
                    {
                        mapa[lewo, pokoj[1]] = 3;
                        iloscpokoi++;
                    }
                    if (nbr == 1)
                    {
                        mapa[lewo, pokoj[1]] = 1;

                        iloscpokoi++;
                    }
                }


                if (mapa[lewo, pokoj[1]] == 2 && mapa[prawo, pokoj[1]] == 2 && mapa[pokoj[0], tyl] == 2 && mapa[pokoj[0], przod] == 2)
                {
                    mapa[lewo, pokoj[1]] = 0;
                    mapa[prawo, pokoj[1]] = 0;
                    mapa[pokoj[0], tyl] = 0;
                    mapa[pokoj[0], przod] = 0;
                }

                if (mapa[lewo, pokoj[1]] == 1 || mapa[prawo, pokoj[1]] == 1 || mapa[pokoj[0], tyl] == 1 || mapa[pokoj[0], przod] == 1)
                {
                    exitexists = true;
                }
                if (mapa[lewo, pokoj[1]] == 3 || mapa[prawo, pokoj[1]] == 3 || mapa[pokoj[0], tyl] == 3 || mapa[pokoj[0], przod] == 3)
                {
                    exitexists = true;
                }

            }

            return iloscpokoi;
        }

        static void Main(string[] args)
        {

            // spell fireball= new spell("fireball");
            // spell thunderbolt= new spell("thunderbolt");
            // spell WindSheer= new spell("wind sheer");
            // spell EarthShock= new spell("earth shock");

            string nazwa, klasa = "elo";
            bool poprawne = false;

            Console.WriteLine("podaj nazwę postaci");

            nazwa = Console.ReadLine();
            while (poprawne == false)
            {
                Console.WriteLine("wybierz klasę(1.sorcerer,2.warrior,3.assasin)");
                klasa = Console.ReadLine();
                switch (klasa)
                {
                    case "1":
                        klasa = "sorcerer"; poprawne = true;
                        break;

                    case "2":
                        klasa = "warrior"; poprawne = true;
                        break;

                    case "3":
                        klasa = "assassin"; poprawne = true;
                        break;

                    default:
                        Console.WriteLine("nieprawidłowa klasa");
                        break;


                }
            }

            Hero hero = new Hero(nazwa, klasa);
            Hero rat = new Hero("rat", "rat");
            Hero spider = new Hero("spider", "spider");

            //  Console.WriteLine(rat.Name + " Str:{0} Dex:{1} Int:{2} HP:{3} MP:{4}",
            //                  rat.GetStrength(),
            //                   rat.GetDexterity(),
            //                   rat.GetIntelligence(),
            //                   rat.GetIConstitution(),
            //                   rat.HP,
            //                   rat.MP

            //                   );

            int[] playerposition = { 5, 6 };
            int[] start = { 5, 6 };

            int[] tempokoj = new int[2];
            int[,] mapa = new int[12, 8];
            int iloscpokoi = 1;
            mapa[5, 6] = 1;

            //generowanie mapy
            while (iloscpokoi < 11 || iloscpokoi > 11)
            {
                mapa = new int[12, 8];
                iloscpokoi = 1;
                mapa[5, 6] = 1;

                iloscpokoi = mapgen(mapa, iloscpokoi);
            }

            string option = "g";
            while (option != "10")
            {

                maprys(playerposition, mapa);
                Console.WriteLine("jestes w pokoju co robisz");

                Console.WriteLine("w. idz na północ");
                Console.WriteLine("s. idz na połódnie");
                Console.WriteLine("a. idz na zachód");
                Console.WriteLine("d. idz na wschód");
                Console.WriteLine("5. pokaż mape");
                Console.WriteLine("6. pokaż  statystyki");
                Console.WriteLine("7. dychnij se");
                Console.WriteLine("8. pokaż -");
                Console.WriteLine("10. wyjdź z gry");


                Console.WriteLine("jestes w pokoju co robisz");

                option = Console.ReadLine();

                switch (option)
                {
                    case "w":
                        switch (mapa[playerposition[0], playerposition[1] - 1])
                        {
                            case 1:
                                playerposition[1] = playerposition[1] - 1;
                                Console.WriteLine("wchodzisz do nowego pokoju");
                                break;
                            case 3:
                                playerposition[1] = playerposition[1] - 1;
                                Console.WriteLine("wchodzisz do nowego pokoju");

                                hero.randomencounter(hero);
                                mapa[playerposition[0], playerposition[1]] = 1;
                                rat.HP = (rat.GetConstitution() * 5) + rat.GetStrength();
                                spider.HP = (spider.GetConstitution() * 5) + spider.GetStrength();
                                break;
                            default:
                                Console.WriteLine("nie ma przejscia");

                                break;

                        }

                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "s":
                        switch (mapa[playerposition[0], playerposition[1] + 1])
                        {
                            case 1:
                                playerposition[1] = playerposition[1] + 1;
                                Console.WriteLine("wchodzisz do nowego pokoju");
                                break;
                            case 3:
                                playerposition[1] = playerposition[1] + 1;
                                Console.WriteLine("wchodzisz do nowego pokoju");
                                hero.randomencounter(hero);
                                mapa[playerposition[0], playerposition[1]] = 1;
                                rat.HP = (rat.GetConstitution() * 5) + rat.GetStrength();
                                spider.HP = (spider.GetConstitution() * 5) + spider.GetStrength();
                                break;
                            default:
                                Console.WriteLine("nie ma przejscia");

                                break;

                        }

                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "d":
                        switch (mapa[playerposition[0] + 1, playerposition[1]])
                        {
                            case 1:
                                playerposition[0] = playerposition[0] + 1;
                                Console.WriteLine("wchodzisz do nowego pokoju");
                                break;
                            case 3:
                                playerposition[0] = playerposition[0] + 1;
                                Console.WriteLine("wchodzisz do nowego pokoju");
                                hero.randomencounter(hero);
                                mapa[playerposition[0], playerposition[1]] = 1;
                                rat.HP = (rat.GetConstitution() * 5) + rat.GetStrength();
                                spider.HP = (spider.GetConstitution() * 5) + spider.GetStrength();
                                break;
                            default:
                                Console.WriteLine("nie ma przejscia");

                                break;

                        }

                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "a":
                        switch (mapa[playerposition[0] - 1, playerposition[1]])
                        {
                            case 1:
                                playerposition[0] = playerposition[0] - 1;
                                Console.WriteLine("wchodzisz do nowego pokoju");
                                break;
                            case 3:
                                playerposition[0] = playerposition[0] - 1;
                                Console.WriteLine("wchodzisz do nowego pokoju");
                                hero.randomencounter(hero);
                                mapa[playerposition[0], playerposition[1]] = 1;
                                rat.HP = (rat.GetConstitution() * 5) + rat.GetStrength();
                                spider.HP = (spider.GetConstitution() * 5) + spider.GetStrength();
                                break;
                            default:
                                Console.WriteLine("nie ma przejscia");

                                break;

                        }

                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "5":
                        maprys(playerposition, mapa);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "6":
                        Console.WriteLine(hero.Name + " Str:{0} Dex:{1} Int:{2} Const:{3} HP:{4}/{5} MP:{6}/{7} Exp:{8}",
                                  hero.GetStrength(),
                                  hero.GetDexterity(),
                                  hero.GetIntelligence(),
                                  hero.GetConstitution(),
                                  hero.HP,
                                  (hero.GetConstitution() * 10) + hero.GetStrength(),
                                  hero.MP,
                                  10 + (3 * hero.GetIntelligence()),
                                  hero.GetExp()
                                  );
                        Console.ReadLine();
                        Console.Clear();

                        // HP = (Constitution* 10) + strength;
                        // MP = 10 + (3 * intelligence);
                        break;


                    default:
                        Console.WriteLine("Nie ma takiej opcji");
                        Console.ReadLine();
                        break;

                }
            }
            // walka z ratem i spiderem
            // hero.walka(rat,hero);
            // hero.walka(spider,hero);


        }
    }
}
