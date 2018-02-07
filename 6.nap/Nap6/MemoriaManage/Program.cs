using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoriaManage
{
    class Program
    {

        class Ember
        {
            public string Nev;
            public Ember Apam;
            public Ember sajat_magam;
            public Ember()
            {
                sajat_magam = this;
            }
        }

        static void M()
        {
            Ember reftipus = new Ember { Nev = "ifj. Gipsz Jakab" };


            // fel kellene szabaditani (c, (c++), delphi)
        }

        static void Main(string[] args)
        {
            int ertektipus = 12;

            Ember reftipus = new Ember { Nev = "Gipsz Jakab" };

            // GC = Garbage Collector: bizonyos idokozonkent fut le
            // minden szemet
            // osszegyujti ROOT elemeket: static, stack 
            // felepiti a fat es megjeloli a nem garbage elemeket

            // generaciok: 0(gyerek),1(szulok),2(nagyszulok)
            M();

            // soha nem fogod hasznalni
            reftipus = null;

            Ember[] emberek = new Ember[1000000];
            long meret1 = GC.GetTotalMemory(false);
            Ember[] tomb = new Ember[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                tomb[i] = new Ember();
                tomb[i].Nev = i.ToString();
            }
            long meret2 = GC.GetTotalMemory(false);
            Console.WriteLine("tomb ennyi byte-ot foglal="+(meret2-meret1));

            GC.Collect(0);
            GC.Collect(1);
            GC.Collect(2);

            // soha nem erem el az ifj. Gipsz Jakab

            Console.ReadLine();
        }
    }
}
