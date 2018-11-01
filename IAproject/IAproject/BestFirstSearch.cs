using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAproject
{
    class BestFirstSearch
    {
        public List<BestFirstSearch> fils { get; set; }
        public int Heristique { get; set; }
        public int[,] matrice { get; set; }
        public int[,] arrive { get; set; }
        public int size { get; set; }

        //calculer heuristique d'une matrice
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

        //determine les fils d'un noeud
        public List<BestFirstSearch> getfils()
        {
            string pos = getposition();
            int i = int.Parse(pos[0].ToString());
            int j = int.Parse(pos[1].ToString());
            var list = new List<BestFirstSearch>();
            if (i + 1 < size)
            {
                // i+1 permutation
                int[,] m = (int[,])matrice.Clone();
                int x;
                x = m[i, j];
                m[i, j] = m[i + 1, j];
                m[i + 1, j] = x;
                //affecter a une node
                BestFirstSearch s = new BestFirstSearch();
                s.matrice = m;
                s.size = size;
                s.arrive = this.arrive;
                s.Heristique = s.calculer_heutstique();
                list.Add(s);
            }

            if (i - 1 >=0)
            {
                // i+1 permutation
                int[,] m = (int[,])matrice.Clone();
                int x;
                x = m[i, j];
                m[i, j] = m[i - 1, j];
                m[i - 1, j] = x;
                //affecter a une node
                BestFirstSearch s1 = new BestFirstSearch();
                s1.matrice = m;
                s1.size = size;
                s1.arrive = this.arrive;
                s1.Heristique = s1.calculer_heutstique();
                list.Add(s1);
            }

            if (j + 1 < size)
            {
                // i+1 permutation
                int[,] m = (int[,])matrice.Clone();
                int x;
                x = m[i, j];
                m[i, j] = m[i , j + 1];
                m[i , j + 1] = x;
                //affecter a une node
                BestFirstSearch s2 = new BestFirstSearch();
                s2.matrice = m;
                s2.arrive = this.arrive;
                s2.size = size;
                s2.Heristique = s2.calculer_heutstique();
                list.Add(s2);
            }

            if (j - 1 >= 0)
            {
                // i+1 permutation
                int[,] m = (int[,])matrice.Clone();
                int x;
                x = m[i, j];
                m[i, j] = m[i, j-1];
                m[i, j-1] = x;
                //affecter a une node
                BestFirstSearch s3 = new BestFirstSearch();
                s3.matrice = m;
                s3.size = size;
                s3.arrive = this.arrive;
                s3.Heristique = s3.calculer_heutstique();
                list.Add(s3);
            }
            return list;
        }


        //Redefinition de la methode equals
        public override bool Equals(object o)
        {
            var n = (BestFirstSearch)o;
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


        public void jouer()
        {
            var fermeture = new List<BestFirstSearch>();
            var ouverture = new List<BestFirstSearch>();

            //Afficher(Matrice_depart);

            //creation de l'arbre 
            BestFirstSearch n = new BestFirstSearch();
            n.matrice = matrice;
            n.arrive = arrive;
            n.size = size;
            n.Heristique = n.calculer_heutstique();
            var racine = n;
            ouverture.Add(n);
            //Afficher(Matrice_depart);
            //Console.WriteLine("heuristique :" + n.calculer_heutstique(Matrice_depart));

            List<BestFirstSearch> l = new List<BestFirstSearch>();
            while (ouverture[0].Heristique != 0)
            {
                n = ouverture[0];
                l = n.getfils();
                n.fils = l;
                foreach (var x in l)
                {
                    if (!ouverture.Contains(x) && !fermeture.Contains(x))
                        ouverture.Add(x);
                }
                fermeture.Add(ouverture[0]);            
                ouverture.RemoveAt(0);
                ouverture = ouverture.OrderBy(o => o.Heristique).ToList();


                //foreach (var y in ouverture)
                //{
                //    Console.WriteLine(y.Heristique);
                //}
                //Afficher l'ouverture
                Console.WriteLine("L'ouverture : ");
                foreach (var x in ouverture)
                {
                    Afficher(x.matrice, x.size);
                    Console.WriteLine("heuristique :" + x.Heristique);
                  
                }

                //affichage de la fermeture
                Console.WriteLine("fermeture");
                foreach (var x in fermeture)
                {
                    Afficher(x.matrice, x.size);
                    Console.WriteLine("heuristique :" + x.Heristique);
                }
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
