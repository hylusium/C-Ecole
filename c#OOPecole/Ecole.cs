using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOOP
{
    internal class Ecole
    {
        #region Variable
        private string _name;
        private string _adresse;
        private float _budget;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }
        public float budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
        #endregion
        #region Liste 
        private List<Eleve> _eleves;
        public List<Eleve> eleves { get => _eleves; set => _eleves = value; }

        private List<Professeur> _prof;
        public List<Professeur> prof { get => _prof; set => _prof = value; }
        #endregion
        //constructeur simple 
        public Ecole()
        {
            _eleves = new List<Eleve>();
            _prof = new List<Professeur>();
        }
        //surcharge du constructeur acceptant plusieurs paramètres telle que le nom / le prénom / l'adresse et le budget
        public Ecole(string name, string adresse, float budget)
        {
            //initialisation des variables du constructeur
            _name = name;
            _adresse = adresse;
            _budget = budget;
            //initialisation des listes 
            _eleves = new List<Eleve>();
            _prof = new List<Professeur>();
        }


        //fonctions permettant d'afficher les infos de l'objet 
        public void Afficher()
        {
            Console.WriteLine(String.Format("nom de l'établissement : {0}, adresse de l'établissement : {1}, budget de l'établissement {2} €",
                this.name, this.adresse, this.budget));
            Console.WriteLine("élèves de l'établissement " + this.name + " : ");
            //affichage des infos d'élèves associer a une école (si des élèves existe)
            if (this.eleves != null)
            {
                Console.WriteLine("nombre d'élèves dans l'établissement : " + eleves.Count());

                for (int i = 0; i < this.eleves.Count(); i++)
                {
                    this.eleves[i].Afficher();
                }
            }
            //affichage des infos des intervennats si il existe 
            Console.WriteLine("listes des enseignants de l'établissement " + this.name + " : ");
            if (this.prof != null)
            {
                for (int i = 0; i < prof.Count(); i++)
                {
                    this.prof[i].Afficher();
                }
            }

        }
        //
        // Résumé :
        //     Ajoute un objet professeur a l'objet école associer 
        //
        // Paramètres :
        //   professeur : 
        //      objet a ajouter a l'école associer 
        public void AjouterProfesseur(Professeur professeur)
        {
            this.prof.Add(professeur);
        }
        //
        // Résumé :
        //     Ajoute un objet Eleve a l'objet école associer 
        //
        // Paramètres :
        //   eleve : 
        //      objet a ajouter a l'école associer 
        public void AjouterEleve(Eleve eleve)
        {
            this.eleves.Add(eleve);
        }
    }
}
