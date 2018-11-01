using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IAproject.Uniforme
{
    public class Uniforme
    {
        public int[,] Matrice_arrive = new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 0 } };

        public List<Uniforme> fils { get; set; }
        public int Cout { get; set; }
        public int[,] matrice { get; set; }

        
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

        public void jouer(int[,] Matrice_depart)
        {
            var fermeture = new List<Uniforme>();
            var ouverture = new List<Uniforme>();
            var arrive = new Uniforme();
            arrive.matrice = Matrice_arrive;
            //Afficher(Matrice_depart);

            //creation de l'arbre 
            Uniforme n = new Uniforme();
            n.matrice = Matrice_depart;
            n.Cout = 0;
            var racine = n;
            ouverture.Add(n);
            //Afficher(Matrice_depart);
            //Console.WriteLine("heuristique :" + n.calculer_heutstique(Matrice_depart));
            List<Uniforme> l = new List<Uniforme>();
            while (!ouverture.Contains(arrive))
            {
                n = ouverture[0];
                l = n.getfils(n);
                n.fils = l;
                foreach (var x in l)
                {
                    for (int i = 0 ;i < fermeture.Count; i++)
                    {
                        if(fermeture[i].Equals(x))
                        {
                            if (x.Cout < fermeture[i].Cout)
                                fermeture.RemoveAt(i);
                        }                        
                    }
                    if (!ouverture.Contains(x))
                        ouverture.Add(x);
                }
                fermeture.Add(ouverture[0]);
                ouverture.Remove(ouverture[0]);
                ouverture = ouverture.OrderBy(o => o.Cout).ToList();
                foreach (var y in ouverture)
                {
                    Console.WriteLine(y.Cout);
                }


                //affichage de la fermeture
                foreach (var x in fermeture)
                {
                    Afficher(x.matrice);
                    Console.WriteLine("Cout :" + x.Cout);
                }
                // Console.ReadKey(true);
                Console.Clear();
            }
        }


        public List<Uniforme> getfils(Uniforme n)
        {
            var list = new List<Uniforme>();
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
                Uniforme s = new Uniforme();
                s.matrice = m;
                s.Cout = n.Cout + 1;
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[0, 0];
                m[0, 0] = m[1, 0];
                m[1, 0] = x;
                Uniforme s1 = new Uniforme();
                s1.matrice = m;
                s1.Cout = n.Cout + 1;
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
                Uniforme s = new Uniforme();
                s.matrice = m;
                s.Cout = n.Cout + 1;
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[0, 4];
                m[0, 4] = m[1, 4];
                m[1, 4] = x;
                Uniforme s1 = new Uniforme();
                s1.matrice = m;
                s1.Cout = n.Cout + 1;
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
                Uniforme s = new Uniforme();
                s.matrice = m;
                s.Cout = n.Cout + 1;
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[4, 0];
                m[4, 0] = m[4, 1];
                m[4, 1] = x;
                Uniforme s1 = new Uniforme();
                s1.matrice = m;
                s1.Cout = n.Cout + 1;
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
                Uniforme s = new Uniforme();
                s.matrice = m;
                s.Cout = n.Cout + 1;
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[4, 4];
                m[4, 4] = m[3, 4];
                m[3, 4] = x;
                Uniforme s1 = new Uniforme();
                s1.matrice = m;
                s1.Cout = n.Cout + 1;
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
                Uniforme s = new Uniforme();
                s.matrice = m;
                s.Cout = n.Cout + 1;
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[0, int.Parse(pos[1].ToString())];
                m[0, int.Parse(pos[1].ToString())] = m[0, int.Parse(pos[1].ToString()) - 1];
                m[0, int.Parse(pos[1].ToString()) - 1] = x;
                Uniforme s1 = new Uniforme();
                s1.matrice = m;
                s1.Cout = n.Cout + 1;
                list.Add(s1);


                m = (int[,])n.matrice.Clone();
                x = m[0, int.Parse(pos[1].ToString())];
                m[0, int.Parse(pos[1].ToString())] = m[1, int.Parse(pos[1].ToString())];
                m[1, int.Parse(pos[1].ToString())] = x;
                Uniforme s2 = new Uniforme();
                s2.matrice = m;
                s2.Cout = n.Cout + 1;
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
                Uniforme s = new Uniforme();
                s.matrice = m;
                s.Cout = n.Cout + 1;
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[4, int.Parse(pos[1].ToString())];
                m[4, int.Parse(pos[1].ToString())] = m[4, int.Parse(pos[1].ToString()) - 1];
                m[4, int.Parse(pos[1].ToString()) - 1] = x;
                Uniforme s1 = new Uniforme();
                s1.matrice = m;
                s1.Cout = n.Cout + 1;
                list.Add(s1);


                m = (int[,])n.matrice.Clone();
                x = m[4, int.Parse(pos[1].ToString())];
                m[4, int.Parse(pos[1].ToString())] = m[3, int.Parse(pos[1].ToString())];
                m[3, int.Parse(pos[1].ToString())] = x;
                Uniforme s2 = new Uniforme();
                s2.matrice = m;
                s2.Cout = n.Cout + 1;
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
                Uniforme s = new Uniforme();
                s.matrice = m;
                 s.Cout = n.Cout + 1;
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), 0];
                m[int.Parse(pos[0].ToString()), 0] = m[int.Parse(pos[0].ToString()) - 1, 0];
                m[int.Parse(pos[0].ToString()) - 1, 0] = x;
                Uniforme s1 = new Uniforme();
                s1.matrice = m;
                s1.Cout = n.Cout + 1;
                list.Add(s1);


                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), 0];
                m[int.Parse(pos[0].ToString()), 0] = m[int.Parse(pos[0].ToString()), 1];
                m[int.Parse(pos[0].ToString()), 1] = x;
                Uniforme  s2 = new Uniforme();
                s2.matrice = m;
                s2.Cout = n.Cout + 1;
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
               Uniforme s = new Uniforme();
                s.matrice = m;
                s.Cout = n.Cout + 1;
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), 4];
                m[int.Parse(pos[0].ToString()), 4] = m[int.Parse(pos[0].ToString()) - 1, 4];
                m[int.Parse(pos[0].ToString()) - 1, 4] = x;
                Uniforme s1 = new Uniforme();
                s1.matrice = m;
                s1.Cout = n.Cout + 1;
                list.Add(s1);


                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), 4];
                m[int.Parse(pos[0].ToString()), 4] = m[int.Parse(pos[0].ToString()), 3];
                m[int.Parse(pos[0].ToString()), 3] = x;
                Uniforme s2 = new Uniforme();
                s2.matrice = m;
                s2.Cout = n.Cout + 1;
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
                Uniforme s = new Uniforme();
                s.matrice = m;
                s.Cout = n.Cout + 1;
                list.Add(s);

                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())] = m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString()) - 1];
                m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString()) - 1] = x;
                Uniforme s1 = new Uniforme();
                s1.matrice = m;
                s1.Cout = n.Cout + 1;
                list.Add(s1);


                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())] = m[int.Parse(pos[0].ToString()) + 1, int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()) + 1, int.Parse(pos[1].ToString())] = x;
                Uniforme s2 = new Uniforme();
                s2.matrice = m;
                s2.Cout = n.Cout + 1;
                list.Add(s2);

                m = (int[,])n.matrice.Clone();
                x = m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()), int.Parse(pos[1].ToString())] = m[int.Parse(pos[0].ToString()) - 1, int.Parse(pos[1].ToString())];
                m[int.Parse(pos[0].ToString()) - 1, int.Parse(pos[1].ToString())] = x;
                Uniforme s3 = new Uniforme();
                s3.matrice = m;
                s3.Cout = n.Cout + 1;
                list.Add(s3);
            }
            return list;
        }
    }
}
