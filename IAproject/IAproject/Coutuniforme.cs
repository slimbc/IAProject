using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAproject
{
   public class Coutuniforme
    {
        public List<Coutuniforme> fils { get; set; }
        public int Cout { get; set; }
        public int[,] matrice { get; set; }
        public int[,] arrive { get; set; }
        public int size { get; set; }

        //Redefinition de la methode equals
        public override bool Equals(object o)
        {
            var n = (Coutuniforme)o;
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
        public List<Coutuniforme> getfils()
        {
            string pos = getposition();
            int i = int.Parse(pos[0].ToString());
            int j = int.Parse(pos[1].ToString());
            var list = new List<Coutuniforme>();
            if (i + 1 < size)
            {
                // i+1 permutation
                int[,] m = (int[,])matrice.Clone();
                int x;
                x = m[i, j];
                m[i, j] = m[i + 1, j];
                m[i + 1, j] = x;
                //affecter a une node
                Coutuniforme s = new Coutuniforme();
                s.matrice = m;
                s.size = size;
                s.arrive = this.arrive;
                s.Cout = this.Cout + 1;
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
                Coutuniforme s1 = new Coutuniforme();
                s1.matrice = m;
                s1.size = size;
                s1.arrive = this.arrive;
                s1.Cout = this.Cout + 1;
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
                Coutuniforme s2 = new Coutuniforme();
                s2.matrice = m;
                s2.arrive = this.arrive;
                s2.size = size;
                s2.Cout = this.Cout + 1;
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
                Coutuniforme s3 = new Coutuniforme();
                s3.matrice = m;
                s3.size = size;
                s3.arrive = this.arrive;
                s3.Cout = this.Cout + 1;
                list.Add(s3);
            }
            return list;
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
            int[,] arrive = this.arrive;
            var fermeture = new List<Coutuniforme>();
            var ouverture = new List<Coutuniforme>();
            //Afficher(Matrice_depart);

            //creation de l'arbre 
            Coutuniforme n = new Coutuniforme();
            n.matrice = this.matrice;
            n.Cout = this.Cout;
            n.size = this.size;
            var rac = n;
            var racine = new Coutuniforme();
            racine.matrice = this.arrive;
            ouverture.Add(n);
            //Afficher(Matrice_depart);
            //Console.WriteLine("heuristique :" + n.calculer_heutstique(Matrice_depart));
            List<Coutuniforme> l = new List<Coutuniforme>();
            while (!ouverture.Contains(racine) || fermeture.Count == 0 )
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
                            if (x.Cout <= fermeture[i].Cout)
                                fermeture.RemoveAt(i);
                        }
                    }
                    if (!ouverture.Contains(x))
                        ouverture.Add(x);
                }
                fermeture.Add(ouverture[0]);
                ouverture.RemoveAt(0);
                ouverture = ouverture.OrderBy(o => o.Cout).ToList();

                //Afficher l'ouverture
                Console.WriteLine("Ouverture");
                foreach (var x in ouverture)
                {
                    Afficher(x.matrice, x.size);
                    Console.WriteLine("Cout :" + x.Cout);
                }


                //affichage de la fermeture
                Console.WriteLine("fermeture");
                foreach (var x in fermeture)
                {
                    Afficher(x.matrice,x.size);
                    Console.WriteLine("Cout :" + x.Cout);
                }
                // Console.ReadKey(true);
                Console.Clear();
            }

            ////Afficher l'ouverture
            //foreach (var y in ouverture)
            //{
            //    Afficher(y.matrice, y.size);
            //}


            ////affichage de la fermeture
            //foreach (var x in fermeture)
            //{
            //    Afficher(x.matrice, x.size);
            //    Console.WriteLine("Cout :" + x.Cout);
            //}
        }

    }
}
