using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppOOP
{
    internal class Eleve : Personne
    {
        #region Variable
        private List<double> _moyenne;
        public List<double> moyenne { get => _moyenne; set => _moyenne = value; }
        private double _moyenneGen;
        public double moyenneGen { get => _moyenneGen; set => _moyenneGen = value; }
        private double _temp;
        #endregion
        //Constructeur simple ne prennat que le nom en entrer et l'héritant de la classe personne 
        //  Entrée : 
        //      nom -> string chaine de caractère définissant le nom d'un élève hériter de la classe personne 
        public Eleve(string nom) : base(nom) { }
        //Surcharge du constructeur 
        //  Entrées : 
        //      nom -> string chaine de caractère définissant le nom d'un élève hériter de la classe personne 
        //      prenom -> String chaine de caractère définissant le prénom d'un élève (variable héritée de la classe Personne)
        //      age -> integer entier définissant l'age d'un élève (variable héritée de la classe Personne)
        public Eleve(string nom, string prenom, int age) : base(nom, prenom, age)
        {
        }
        //Surcharge du constructeur 
        //  Entrées : 
        //      nom -> string chaine de caractère définissant le nom d'un élève hériter de la classe personne 
        //      prenom -> String chaine de caractère définissant le prénom d'un élève (variable héritée de la classe Personne)
        //      age -> integer entier définissant l'age d'un élève (variable héritée de la classe Personne)
        //      List<T> moyenne -> Type double définissant la liste de moyenne de l'objet élève en question
        public Eleve(string nom, string prenom, int age, List<double> moyenne) : base(nom, prenom, age)
        {
            _moyenne = new List<double>(moyenne);
        }

        //Fonction pour afficher les informations de l'objet Eleve
        //  N.B. si l'élève ne possède pas de moyenne alors la moyenne générale ne sera pas afficher dans le programme
        public override void Afficher()
        {
            if (this.moyenne != null)
            {
                double moyenneEleve = MoyenneGen();
                Console.WriteLine(String.Format("nom de l'apprenant: {0}, prenom de l'apprenant : {1}, age de l'apprenant : {2}, moyenne de l'apprennant : {3}", this.nom, this.prenom, this.age, moyenneEleve));
            }
            else
            {
                Console.WriteLine(String.Format("nom de l'apprenant: {0}, prenom de l'apprenant : {1}, age de l'apprenant : {2}", this.nom, this.prenom, this.age));
            }
        }
        //Fonction Pour Calculer la moyenne Générale d'un objet élève 
        //  Retour : 
        //      Doucle -> retour du calcul de la moyenne générale de l'élève 
        public double MoyenneGen()
        {
            moyenneGen = 0;
            for (int i = 1; i < moyenne.Count; i++)
            {
                moyenneGen += moyenne[i];
            }
            _temp = moyenneGen;

            return _temp / moyenne.Count;
        }
        //Fonction pour Ajouter une moyenne a un L'objet Eleve
        //  Entrée : 
        //      moyenne -> double valeur de l amoyenne rentrer par l'utillisateur au cours de la vie du programme
        public void AjouterMoyenne(double moyenne)
        {
            this.moyenne.Add(moyenne);
        }
    }
}
