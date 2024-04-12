using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOOP
{
    internal class Professeur : Personne
    {
        #region Variable De la classe
        private float _salaire;
        public float salaire { get => _salaire; set => _salaire = value; }
        #endregion
        //Constructeur Simple de la classe avec une entrée étant nom
        //  Entrées : 
        //      nom -> String chaine de caractère indiquant le nom de l'intervenant (Variable héritée de la classe personne)
        public Professeur(string nom) : base(nom)
        {
        }
        //Constructeur Surcharger de la classe Professeur possédant plusieurs entrées 
        //  Entrées : 
        //      nom -> string chaine de caractère pour indiquer le nom de l'intervenant 
        //      prenom -> string chaine de caractère indiquant le prénom d'un intervenant
        //      age -> integer entier définissant l'age d'un intervenant 
        //      salaire -> float nombre a virgule définissant le salaire d'un intervenant
        public Professeur(string nom, string prenom, int age, float salaire) : base(nom, prenom, age)
        {
            _salaire = salaire;
        }
        //Function Afficher() permettant d'afficher les informations d'une classe en overridant celle du parent (Personne)        
        public override void Afficher()
        {
            Console.WriteLine(String.Format("nom du professeur {0}, prénom du professeur {1}, age du professeur {2}, salaire du professeur {3} €", this.nom, this.prenom, this.age, this._salaire));
        }

        //Fonction permettant de calculer le côut de revient d'un intervenant pour une année et retourne le résultat du calcul 
        //  Retour : 
        //      decimal -> retour du calcul sur une année du salaire de l'objet Professeur en question
        public decimal CalculCout()
        {
            return (decimal)this.salaire * 12;
        }

    }
}
