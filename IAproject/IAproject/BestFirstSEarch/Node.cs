using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAproject.BestFirstSEarch
{
    public class Node 
    {
        public List<Node> fils {get;set;}
        public int Heristique { get; set; }
        public  int[,] matrice { get; set; }
       



        public int[,] Matrice_arrive = new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 0 } };

        //calculer heuristique d'une matrice
        public int calculer_heutstique(int[,] m)
        {
            int result = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (m[i, j] != Matrice_arrive[i, j])
                        result++;
                }
            }
            return result;
        }

        public string getposition(int[,] m)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (m[i, j] == 0)
                        return String.Format("{0}{1}", i, j);
                }
            }
            return "";
        }


        static void Afficher(int[,] m)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(m[i, j] + "    ");
                }
                Console.WriteLine();
            }
        }



        public List<Node> getfils(Node n)
        {
            var list = new List<Node>();
            string pos = getposition(n.matrice);
            //si le zero se touve dans la premiere case a gauche en haut
            if (pos.Equals("00"))
            {
                int[,] m = (int[,])n.matrice.Clone();
                //permutation
                int x;
                x = m[0, 0];
                m[0, 0] = m[0, 1];
                m[0, 1] = x;
                //affecter a une node
                Node s = new Node();
                s.matrice = m;
                s.Heristique = calculer_heutstique(m);
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[0, 0];
                m[0, 0] = m[1, 0];
                m[1, 0] = x;
                Node s1 = new Node();
                s1.matrice = m;
                s1.Heristique = calculer_heutstique(m);
                list.Add(s1);
            }
            //si le zero se touve dans la derniere case a droite en haut
            else if (pos.Equals("04"))
            {
                int[,] m = (int[,])n.matrice.Clone();
                //permutation
                int x;
                x = m[0, 4];
                m[0, 4] = m[0, 3];
                m[0, 3] = x;
                //affecter a une node
                Node s = new Node();
                s.matrice = m;
                s.Heristique = calculer_heutstique(m);
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[0, 4];
                m[0, 4] = m[1, 4];
                m[1, 4] = x;
                Node s1 = new Node();
                s1.matrice = m;
                s1.Heristique = calculer_heutstique(m);
                list.Add(s1);
            }
            //si le zero se touve dans la derniere case a gauche en bas
            else if (pos.Equals("40"))
            {
                int[,] m = (int[,])n.matrice.Clone();
                //permutation
                int x;
                x = m[4, 0];
                m[4, 0] = m[3, 0];
                m[3, 0] = x;
                //affecter a une node
                Node s = new Node();
                s.matrice = m;
                s.Heristique = calculer_heutstique(m);
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[4, 0];
                m[4, 0] = m[4, 1];
                m[4, 1] = x;
                Node s1 = new Node();
                s1.matrice = m;
                s1.Heristique = calculer_heutstique(m);
                list.Add(s1);
            }
            //si le zero se touve dans la derniere case a droite en bas
            else if (pos.Equals("44"))
            {
                int[,] m = (int[,])n.matrice.Clone();
                //permutation
                int x;
                x = m[4, 4];
                m[4, 4] = m[4, 3];
                m[4, 3] = x;
                //affecter a une node
                Node s = new Node();
                s.matrice = m;
                s.Heristique = calculer_heutstique(m);
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[4, 4];
                m[4, 4] = m[3, 4];
                m[3, 4] = x;
                Node s1 = new Node();
                s1.matrice = m;
                s1.Heristique = calculer_heutstique(m);
                list.Add(s1);
            }
            //si le zero se trouve dans la premier ligne
            else if (pos[0] == '0')
            {
                int[,] m = (int[,])n.matrice.Clone();
                //permutation
                int x;
                x = m[0, int.Parse(pos[1].ToString())];
                m[0, int.Parse(pos[1].ToString())] = m[0, int.Parse(pos[1].ToString()) + 1];
                m[0, int.Parse(pos[1].ToString()) + 1] = x;
                //affecter a une node
                Node s = new Node();
                s.matrice = m;
                s.Heristique = calculer_heutstique(m);
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[0, int.Parse(pos[1].ToString())];
                m[0, int.Parse(pos[1].ToString())] = m[0, int.Parse(pos[1].ToString()) - 1];
                m[0, int.Parse(pos[1].ToString()) - 1] = x;
                Node s1 = new Node();
                s1.matrice = m;
                s1.Heristique = calculer_heutstique(m);
                list.Add(s1);


                m = (int[,])n.matrice.Clone();
                x = m[0, int.Parse(pos[1].ToString())];
                m[0, int.Parse(pos[1].ToString())] = m[1, int.Parse(pos[1].ToString())];
                m[1, int.Parse(pos[1].ToString())] = x;
                Node s2 = new Node();
                s2.matrice = m;
                s2.Heristique = calculer_heutstique(m);
                list.Add(s2);
            }
            //si le zero se trouve dans la derniere ligne
            else if (pos[0] == '4')
            {
                int[,] m = (int[,])n.matrice.Clone();
                //permutation
                int x;
                x = m[4, int.Parse(pos[1].ToString())];
                m[4, int.Parse(pos[1].ToString())] = m[4, int.Parse(pos[1].ToString()) + 1];
                m[4, int.Parse(pos[1].ToString()) + 1] = x;
                //affecter a une node
                Node s = new Node();
                s.matrice = m;
                s.Heristique = calculer_heutstique(m);
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[4, int.Parse(pos[1].ToString())];
                m[4, int.Parse(pos[1].ToString())] = m[4, int.Parse(pos[1].ToString()) - 1];
                m[4, int.Parse(pos[1].ToString()) - 1] = x;
                Node s1 = new Node();
                s1.matrice = m;
                s1.Heristique = calculer_heutstique(m);
                list.Add(s1);


                m = (int[,])n.matrice.Clone();
                x = m[4, int.Parse(pos[1].ToString())];
                m[4, int.Parse(pos[1].ToString())] = m[3, int.Parse(pos[1].ToString())];
                m[3, int.Parse(pos[1].ToString())] = x;
                Node s2 = new Node();
                s2.matrice = m;
                s2.Heristique = calculer_heutstique(m);
                list.Add(s2);
            }
            //si le zero se trouve dans la premiere colone
            else if (pos[1] == '0')
            {
                int[,] m = (int[,])n.matrice.Clone();
                //permutation
                int x;
                x = m[int.Parse(pos[0].ToString()), 0];
                m[int.Parse(pos[0].ToString()), 0] = m[int.Parse(pos[0].ToString()) + 1, 0];
                m[int.Parse(pos[0].ToString()) + 1, 0] = x;
                //affecter a une node
                Node s = new Node();
                s.matrice = m;
                s.Heristique = calculer_heutstique(m);
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), 0];
                m[int.Parse(pos[0].ToString()), 0] = m[int.Parse(pos[0].ToString()) - 1, 0];
                m[int.Parse(pos[0].ToString()) - 1, 0] = x;
                Node s1 = new Node();
                s1.matrice = m;
                s1.Heristique = calculer_heutstique(m);
                list.Add(s1);


                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), 0];
                m[int.Parse(pos[0].ToString()), 0] = m[int.Parse(pos[0].ToString()), 1];
                m[int.Parse(pos[0].ToString()), 1] = x;
                Node s2 = new Node();
                s2.matrice = m;
                s2.Heristique = calculer_heutstique(m);
                list.Add(s2);
            }
            //si le zero se trouve dans la derniere colone
            else if (pos[1] == '4')
            {
                int[,] m = (int[,])n.matrice.Clone();
                //permutation
                int x;
                x = m[int.Parse(pos[0].ToString()), 4];
                m[int.Parse(pos[0].ToString()), 4] = m[int.Parse(pos[0].ToString()) + 1, 4];
                m[int.Parse(pos[0].ToString()) + 1, 4] = x;
                //affecter a une node
                Node s = new Node();
                s.matrice = m;
                s.Heristique = calculer_heutstique(m);
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), 4];
                m[int.Parse(pos[0].ToString()), 4] = m[int.Parse(pos[0].ToString()) - 1, 4];
                m[int.Parse(pos[0].ToString()) - 1, 4] = x;
                Node s1 = new Node();
                s1.matrice = m;
                s1.Heristique = calculer_heutstique(m);
                list.Add(s1);


                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), 4];
                m[int.Parse(pos[0].ToString()), 4] = m[int.Parse(pos[0].ToString()), 3];
                m[int.Parse(pos[0].ToString()), 3] = x;
                Node s2 = new Node();
                s2.matrice = m;
                s2.Heristique = calculer_heutstique(m);
                list.Add(s2);
            }
            else
            {
                int[,] m = (int[,])n.matrice.Clone();
                //permutation
                int x;
                x = m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())] = m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString()) + 1];
                m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString()) + 1] = x;
                //affecter a une node
                Node s = new Node();
                s.matrice = m;
                s.Heristique = calculer_heutstique(m);
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())] = m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString()) - 1];
                m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString()) - 1] = x;
                Node s1 = new Node();
                s1.matrice = m;
                s1.Heristique = calculer_heutstique(m);
                list.Add(s1);


                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())] = m[int.Parse(pos[0].ToString()) + 1, int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()) + 1, int.Parse(pos[1].ToString())] = x;
                Node s2 = new Node();
                s2.matrice = m;
                s2.Heristique = calculer_heutstique(m);
                list.Add(s2);

                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())] = m[int.Parse(pos[0].ToString()) - 1, int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()) - 1, int.Parse(pos[1].ToString())] = x;
                Node s3 = new Node();
                s3.matrice = m;
                s3.Heristique = calculer_heutstique(m);
                list.Add(s3);
            }
            return list;
        }

        public override bool Equals(object o)
        {
            var n = (Node)o;
            for (int i = 0; i<5;i++)
            {
                for(int j=0; j<5;j++)
                {
                    if(this.matrice[i,j] != n.matrice[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void jouer(int[,] Matrice_depart)
        {
            var fermeture = new List<Node>();
            var ouverture = new List<Node>();
           

            //Afficher(Matrice_depart);

            //creation de l'arbre 
            Traitment T = new Traitment();
            Node n = new Node();
            n.matrice = Matrice_depart;
            n.Heristique = n.calculer_heutstique(Matrice_depart);
            var racine = n;
            ouverture.Add(n);
            //Afficher(Matrice_depart);
            //Console.WriteLine("heuristique :" + n.calculer_heutstique(Matrice_depart));
            List<Node> l = new List<Node>();
            while (ouverture[0].Heristique != 0)
            {
                n = ouverture[0];
                l = n.getfils(n);
                n.fils = l;
                foreach (var x in l)
                {
                    if (!ouverture.Contains(x) && !fermeture.Contains(x))
                        ouverture.Add(x);
                }
                fermeture.Add(ouverture[0]);
                ouverture.Remove(ouverture[0]);
                ouverture = ouverture.OrderBy(o => o.Heristique).ToList();
                foreach(var y in ouverture)
                {
                    Console.WriteLine(y.Heristique);
                }


                //affichage de la fermeture
                foreach (var x in fermeture)
                {
                    Afficher(x.matrice);
                    Console.WriteLine("heuristique :" + x.Heristique);
                }
                // Console.ReadKey(true);
                Console.Clear();
            }
        }

    }

}
