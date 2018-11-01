using IAproject.BestFirstSEarch;
using IAproject.Uniforme;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IAproject
{
    class Program
    {
        //Affichage d'une matrice
        static void Afficher(int[,] m,int size)
        {
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(m[i, j] + "    ");
                }
                Console.WriteLine();
            }
        }
        //affichage d'une matrice
        public  static void Menu()
        {
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("Veullire choisir l'algorithme:");
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("1 - Best First Search");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("2 - Branch and Bound");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("3 - A*");
        }
        static void Main(string[] args)
        {
            //PriorityQueue<Node> ouverture = new PriorityQueue<Node>();

            Console.Title = "Le taquin ";
            
            Console.BufferHeight = 300;
            Console.WindowHeight = 42;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Le Menu principal
            Menu();
            int rep =0;
            do
            {
                Console.SetCursorPosition(40, 15);
                Console.WriteLine("Taper votre choix : ");
                Console.SetCursorPosition(40, 16);
                string Response = Console.ReadLine();
                if (int.TryParse(Response, out rep))
                    rep = int.Parse(Response);
                else
                {
                    Console.Write("Choix incorrecte");
                }
            } while (rep > 3 || rep < 1);


            Console.Clear();
            
            // La saisie de la taille de la matrice
            int size = 0;
            do
            {
                Console.WriteLine("Donnez la taille de la martice");
                string sz = Console.ReadLine();
                if (int.TryParse(sz, out size))
                    size = int.Parse(sz);
                else
                {
                    Console.Write("Choix incorrecte");
                }
            } while (size == 0);

            //LA saisie de matrice de depart
            var Matrice_depart = new int[size, size];
            Console.WriteLine("Donner la matrice de depart!");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.WriteLine("Donner M[{0},{1}]", i, j);
                    string s = Console.ReadLine();
                    if (int.TryParse(s, out Matrice_depart[i, j]))
                        Matrice_depart[i, j] = int.Parse(s);
                    else
                    {
                        Console.WriteLine("Vous devez saisir une entier");
                        j--;
                    }
                }
            }

            //LA saisie de matrice d'arrive
            var matrice_arrive = new int[size, size];
            Console.WriteLine("Donner la matrice de d'arrivee!");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.WriteLine("Donner M[{0},{1}]", i, j);
                    string s = Console.ReadLine();
                    if (int.TryParse(s, out matrice_arrive[i, j]))
                        matrice_arrive[i, j] = int.Parse(s);
                    else
                    {
                        Console.WriteLine("Vous devez saisir une entier");
                        j--;
                    }
                }
            }
            
            Console.WriteLine("Matrice d'arrivée");
            Afficher(matrice_arrive, size);

            Console.WriteLine("Matrice de depart");
            Afficher(Matrice_depart, size);
            Console.ReadKey(true);

            if (rep == 1)
            {

                BestFirstSearch firstnode = new BestFirstSearch();
                firstnode.matrice = Matrice_depart;
                firstnode.arrive = matrice_arrive;
                firstnode.size = size;
                firstnode.Heristique = firstnode.calculer_heutstique();
                Console.WriteLine("Heristique" + firstnode.calculer_heutstique());
                Console.WriteLine();
                firstnode.jouer();
            }
            else if (rep == 2)
            {
                Coutuniforme node = new Coutuniforme();
                node.matrice = Matrice_depart;
                node.arrive = matrice_arrive;
                node.size = size;
                node.Cout = 0;
                Console.WriteLine("Cout : " + node.Cout);
                Console.WriteLine();
                node.jouer();
            }
            else if (rep == 3)
            {
                Astar node = new Astar();
                node.matrice = Matrice_depart;
                node.arrive = matrice_arrive;
                node.size = size;
                node.Cout = 0;
                node.Heristique = node.calculer_heutstique();
                node.Coutheur = node.Heristique;
                node.jouer();
            }

                Console.ReadKey(true);
        }
    }
}
