
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAproject
{

   public class Astar
    {
        public List<Astar> fils { get; set; }
        public int Heristique { get; set; }
        public int Cout { get; set; }
        public int[,] matrice { get; set; }
        public int[,] arrive { get; set; }
        public int size { get; set; }
        public int Coutheur { get; set; }


        public override bool Equals(object o)
        {
            var n = (Astar)o;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (this.matrice[i, j] != n.matrice[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Affichage d'une matrice
        static void Afficher(int[,] m, int size)
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


        //determine la position du 0 
        public string getposition()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrice[i, j] == 0)
                        return String.Format("{0}{1}", i, j);
                }
            }
            return "";
        }

        //calcluer l'heuristique
        public int calculer_heutstique()
        {
            int result = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrice[i, j] != arrive[i, j])
                        result++;
                }
            }
            return result;
        }

        //determine les fils d'un noeud
        public List<Astar> getfils()
        {
            string pos = getposition();
            int i = int.Parse(pos[0].ToString());
            int j = int.Parse(pos[1].ToString());
            var list = new List<Astar>();
            if (i + 1 < size)
            {
                // i+1 permutation
                int[,] m = (int[,])matrice.Clone();
                int x;
                x = m[i, j];
                m[i, j] = m[i + 1, j];
                m[i + 1, j] = x;
                //affecter a une node
                Astar s = new Astar();
                s.matrice = m;
                s.size = size;
                s.arrive = this.arrive;
                s.Cout = this.Cout + 1;
                s.Heristique = s.calculer_heutstique();              
                s.Coutheur = s.Cout + s.Heristique;
                list.Add(s);
            }

            if (i - 1 >= 0)
            {
                // i+1 permutation
                int[,] m = (int[,])matrice.Clone();
                int x;
                x = m[i, j];
                m[i, j] = m[i - 1, j];
                m[i - 1, j] = x;
                //affecter a une node
                Astar s1 = new Astar();
                s1.matrice = m;
                s1.size = size;
                s1.arrive = this.arrive;
                s1.Cout = this.Cout + 1;
                s1.Heristique = s1.calculer_heutstique();
                s1.Coutheur = s1.Cout + s1.Heristique;
                list.Add(s1);
            }

            if (j + 1 < size)
            {
                // i+1 permutation
                int[,] m = (int[,])matrice.Clone();
                int x;
                x = m[i, j];
                m[i, j] = m[i, j + 1];
                m[i, j + 1] = x;
                //affecter a une node
                Astar s2 = new Astar();
                s2.matrice = m;
                s2.arrive = this.arrive;
                s2.size = size;
                s2.Cout = this.Cout + 1;
                s2.Heristique = s2.calculer_heutstique();
                s2.Coutheur = s2.Cout + s2.Heristique;
                list.Add(s2);
            }

            if (j - 1 >= 0)
            {
                // i+1 permutation
                int[,] m = (int[,])matrice.Clone();
                int x;
                x = m[i, j];
                m[i, j] = m[i, j - 1];
                m[i, j - 1] = x;
                //affecter a une node
                Astar s3 = new Astar();
                s3.matrice = m;
                s3.size = size;
                s3.arrive = this.arrive;
                s3.Cout = this.Cout + 1;
                s3.Heristique = s3.calculer_heutstique();
                s3.Coutheur = s3.Cout + s3.Heristique;
                list.Add(s3);
            }
            return list;
        }


        public void jouer()
        {
            int[,] arrive = this.arrive;
            var fermeture = new List<Astar>();
            var ouverture = new List<Astar>();
            //Afficher(Matrice_depart);

            //creation de l'arbre 
            Astar n = new Astar();
            n.matrice = this.matrice;
            n.Cout = this.Cout;
            n.Heristique = this.Heristique;
            n.size = this.size;
            n.Coutheur = this.Coutheur;
            n.arrive = arrive;
            var racine = new Astar();
            racine.matrice = this.matrice;
            ouverture.Add(n);
            //Afficher(Matrice_depart);
            //Console.WriteLine("heuristique :" + n.calculer_heutstique(Matrice_depart));
            List<Astar> l = new List<Astar>();
            while (ouverture[0].Heristique != 0)
            {
                n = ouverture[0];
                l = n.getfils();
                n.fils = l;
                foreach (var x in l)
                {
                    for (int i = 0; i < fermeture.Count; i++)
                    {
                        if (fermeture[i].Equals(x))
                        {
                            if (x.Coutheur <= fermeture[i].Coutheur)
                            {
                                fermeture.RemoveAt(i);
                            }                     
                        }
                    }
                        if (!ouverture.Contains(x))
                            ouverture.Add(x);
                }
                fermeture.Add(ouverture[0]);
                ouverture.RemoveAt(0);
                ouverture = ouverture.OrderBy(o => o.Coutheur).ToList();

                //Afficher l'ouverture
                Console.WriteLine("Ouverture");
                foreach (var x in ouverture)
                {
                    Afficher(x.matrice, x.size);
                    Console.WriteLine("Cout :" + x.Cout);
                    Console.WriteLine("Heuristiue :" + x.Heristique);
                    Console.WriteLine("Cout + heuristique :" + x.Coutheur);
                }

                Console.WriteLine("-----------------------------------------");

                //affichage de la fermeture
                Console.WriteLine("fermeture");
                foreach (var x in fermeture)
                {
                    Afficher(x.matrice, x.size);
                    Console.WriteLine("Cout :" + x.Cout);
                    Console.WriteLine("Heuristiue :" + x.Heristique);
                    Console.WriteLine("Cout + heuristique :" + x.Coutheur);
                }
                // Console.ReadKey(true);
                Console.Clear();
            }


            //Afficher l'ouverture
            Console.WriteLine("Ouverture");
            foreach (var x in ouverture)
            {
                Afficher(x.matrice, x.size);
                Console.WriteLine("Cout :" + x.Cout);
                Console.WriteLine("Heuristiue :" + x.Heristique);
                Console.WriteLine("Cout + heuristique :" + x.Coutheur);
            }


            //affichage de la fermeture
            Console.WriteLine("fermeture");
            foreach (var x in fermeture)
            {
                Afficher(x.matrice, x.size);
                Console.WriteLine("Cout :" + x.Cout);
                Console.WriteLine("Heuristiue :" + x.Heristique);
                Console.WriteLine("Cout + heuristique :" + x.Coutheur);
            }
        }

        }
    }
