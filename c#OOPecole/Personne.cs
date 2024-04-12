using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOOP
{
    internal class Personne
    {
        #region Variable
        protected string _nom;
        protected int _age;
        protected string _prenom;

        public string nom { get => _nom; set => _nom = value; }
        public int age { get => _age; set => _age = value; }
        public string prenom { get => _prenom; set => _prenom = value; }
        #endregion
        //Constructeur Ne prenant Qu'une entrée 
        //  Entrée :
        //      nom -> string chaine de charactère définissant le nom d'une personne 
        public Personne(string nom)
        {
            _nom = nom;
        }
        //Constructeur prenant plusieurs entrées en paramètres 
        //  Entrée :
        //      nom -> string chaine de charactère définissant le nom d'une personne 
        //      prenom -> string chaine de caractère définissant le prénom d'une personne 
        //      age -> integer entier définissant l'age de la personne 
        public Personne(string nom, string prenom, int age)
        {
            _nom = nom;
            _prenom = prenom;
            _age = age;
        }
        // Fonction permettant d'afficher les informations de la classe Personne en question
        public virtual void Afficher()
        {
            Console.WriteLine(String.Format("nom de la personne {0}, prénom de la personne {1}, age de la personne {2} an", this.nom, this.prenom, this.age));
        }
        // Fonction virtuelle permettant de faire vieillir la classe personne 
        public virtual void Vieillir()
        {
            this._age += 1;
        }
    }
}
