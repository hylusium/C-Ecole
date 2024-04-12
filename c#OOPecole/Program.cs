using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace AppOOP
{
    internal class Program
    {
        // fonction Main point d'entrée du programme
        static void Main(string[] args)
        {
            //encodage UTF8 pour afficher les charactères spéciaux telle que "€"
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // liste d'élève de professeur et d'école utilliser pendant tout le temps de vie de l'application
            List<Eleve> eleves = new List<Eleve>();
            List<Professeur> prof = new List<Professeur>();
            List<Ecole> ecoles = new List<Ecole>();
            //
            //Boucle infinie pour afficher le Menu 
            //
            //  paramètres : 
            //      eleves est la référence de la liste d'élèves du programme
            //      prof est la référence de la liste d'intervennat du programme
            //      ecoles est la référence de la liste d'établissement du programme
            while (true)
            {
                Menu(eleves, prof, ecoles);
            }
        }
        //Fonction pour créer Des élèves dans le programme
        //  Retour : 
        //      Nouvelle Objet Eleve créer pour le programme
        static Eleve CreerEleve()
        {
            Console.WriteLine("Nom De L'élève : ");
            string name = Console.ReadLine();
            Console.WriteLine("Prénom de l'élève : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Age de l'élève : ");
            int age = int.Parse(Console.ReadLine());
            return new Eleve(name, prenom, age);
        }
        //Fonction pour créer des intervennats dans le programme 
        //  Retour : 
        //      Nouvelle Objet Professeur créer dans le programme
        static Professeur CreerProf()
        {
            Console.WriteLine("Nom de l'intervenants : ");
            string name = Console.ReadLine();
            Console.WriteLine("prénom de l'intervenant : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("age de l'intervenant : ");
            string temp = Console.ReadLine();
            int age = int.Parse(temp);
            Console.WriteLine("salaire de l'intervenant (mensuel en € et écris de façons xx,xx et pas xx.xx) : ");
            temp = Console.ReadLine();
            float salaire = float.Parse(temp);
            return new Professeur(name, prenom, age, salaire);
        }
        //Fonction Pour Ajouter Un Etablissement
        //  Retour : 
        //      Objet Ecole créer pour le cycle de vie de l'application
        static Ecole CreerEcole()
        {
            Console.WriteLine("Nom de l'établissement : ");
            string name = Console.ReadLine();
            Console.WriteLine("Adresse de l'établissement");
            string adresse = Console.ReadLine();
            Console.WriteLine("Budget de l'établissement");
            string temp = Console.ReadLine();
            float budget = float.Parse(temp);
            return new Ecole(name, adresse, budget);
        }

        //Fonction Layout Du Menu A Afficher 
        // Entrées Integer -> sélection Par une Case pour choisir quoi afficher en fonction du choix de l'utillisateur 
        static void Menu(List<Eleve> eleves, List<Professeur> professeur, List<Ecole> ecoles)
        {
            Console.WriteLine("0.Afficher Tous les élèves \n1.Afficher tous les intervenants \n2.Afficher tous les établissement \n3.Ajouter un élève \n4.Ajouter un intervenant " +
                "\n5.ajouter un établissement\n6.Ajouter des Notes\n7.Modifier Salaire d'un Intervenant \n8.lier un élève a un établissement \n9.lier un intervennat a un établissement" +
                "\n10.Vieillir un Eleve \n11.Vieillir Intervenant\n12.Nettoyer l'écran");
            string temp = Console.ReadLine();
            int choix = int.Parse(temp);
            switch (choix)
            {
                case 0:
                    ParcourirEleves(eleves);
                    break;
                case 1:
                    ParcourirProf(professeur);
                    break;
                case 2:
                    ParcourirEcole(ecoles);
                    break;
                case 3:
                    eleves.Add(CreerEleve());
                    ClearScreen();
                    break;
                case 4:
                    professeur.Add(CreerProf());
                    ClearScreen();
                    break;
                case 5:
                    ecoles.Add(CreerEcole());
                    ClearScreen();
                    break;
                case 6:
                    ParcourirEleves(eleves);
                    Console.WriteLine("Index de l'élève ?");
                    string temp2 = Console.ReadLine();
                    int id = int.Parse(temp2);
                    Console.WriteLine("Moyenne a ajouter");
                    string temp3 = Console.ReadLine();
                    double ajoutMoyenne = double.Parse(temp3);
                    AjouterMoyenneEleve(eleves, id, ajoutMoyenne);
                    ClearScreen();
                    break;
                case 7:
                    ParcourirProf(professeur);
                    Console.WriteLine("id de l'intervennat ");
                    string temp4 = Console.ReadLine();
                    int id2 = int.Parse(temp4);
                    Console.WriteLine("entrer nouveau salaire mensuel (xx,xx €)");
                    string temp5 = Console.ReadLine();
                    float salaire = float.Parse(temp5);
                    ModifierSalaireIntervenant(professeur, id2, salaire);
                    ClearScreen();
                    break;
                case 8:
                    ParcourirEleves(eleves);
                    Console.WriteLine("id élève a ajouter ");
                    string temp6 = Console.ReadLine();
                    int id3 = int.Parse(temp6);
                    ParcourirEcole(ecoles);
                    Console.WriteLine("id Ecole ou ajouter l'élève ");
                    string temp7 = Console.ReadLine();
                    int id4 = int.Parse(temp7);
                    AjouterEleveEtablissement(eleves, ecoles, id3, id4);
                    ClearScreen();
                    break;
                case 9:
                    ParcourirProf(professeur);
                    Console.WriteLine("id élève a ajouter ");
                    string temp8 = Console.ReadLine();
                    int id5 = int.Parse(temp8);
                    ParcourirEcole(ecoles);
                    Console.WriteLine("id Ecole ou ajouter l'élève ");
                    string temp9 = Console.ReadLine();
                    int id6 = int.Parse(temp9);
                    AjouterIntervennatEtablissement(professeur, ecoles, id5, id6);
                    ClearScreen();
                    break;
                case 10:
                    ParcourirEleves(eleves);
                    Console.WriteLine("id de l'élève a vieillir ");
                    string temp10 = Console.ReadLine();
                    int id11 = int.Parse(temp10);
                    VieillirEleve(eleves, id11);
                    ClearScreen();
                    break;
                case 11:
                    ParcourirProf(professeur);
                    Console.WriteLine("id de l'intervenant a vieillir ");
                    string temp12 = Console.ReadLine();
                    int id13 = int.Parse(temp12);
                    VieillirIntervenant(professeur, id13);
                    ClearScreen();
                    break;
                case 12:
                    ClearScreen();
                    break;
                default:
                    Console.WriteLine("La valeur entrer n'est pas bonne merci de choisir une option disponible dans le menu");
                    break;
            }


        }
        //Fonction Parcourir tous les élèves existant 
        // N.B aucune restriction Aucun filtres Affiche les élèves dans un établissement ou non 
        static void ParcourirEleves(List<Eleve> eleves)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < eleves.Count; i++)
            {
                //Appel A la fonction Afficher() de l'objet eleves en question + son id  dans la liste qui est une référence a son index 
                Console.WriteLine("id " + i);
                eleves[i].Afficher();
            }
            Console.WriteLine("\n");
        }
        //Fonction Pour parcourir tout les intervenants existants 
        static void ParcourirProf(List<Professeur> professeurs)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < professeurs.Count; i++)
            {
                //appel a la fonction Afficher de l'objet professeur en question + son id
                Console.WriteLine("id : " + i);
                professeurs[i].Afficher();
            }
            Console.WriteLine("\n");
        }
        //Fonction pour parcourir tous les établissement existants du programme et contenue dans la List de types Ecole
        static void ParcourirEcole(List<Ecole> ecoles)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < ecoles.Count; i++)
            {
                //Appel a la fonction AFficher() de l'objet ecoles en question + son id 
                Console.WriteLine("id : " + i);
                ecoles[i].Afficher();
            }
            Console.WriteLine("\n");
        }
        //Fonction pour nettoyer l'écran et ne laisser que le menu visible 
        static void ClearScreen()
        {
            Console.Clear();
        }
        //Fonction pour ajouter une moyenne a un eleve
        //  Entrées : 
        //      List<Eleve> -> type Eleve 
        //      Index -> Integer reference a l'index de l'élève dans la liste entrer par l'utillisateur dans le programme
        //      Moyenne -> Double valeur de la moyenne a ajouter a l'élève a rentrer par l'utillisateur 
        static void AjouterMoyenneEleve(List<Eleve> eleves, int index, double moyenne)
        {
            eleves[index].AjouterMoyenne(moyenne);
        }
        //Fonction pour Modifier le salaire d'un intervennats 
        //  Entrées : 
        //      List<T> -> type professeur Liste de de professeur renseigner dans le programme
        //      index -> integer reference a l'index de l'intervennats dans la liste entrer par l'utillisateur dans le programme
        //      salaire -> float valeur du salaire a modifier rentrer par l'utillisateur dans la durée de vie du programme
        static void ModifierSalaireIntervenant(List<Professeur> professeur, int index, float salaire)
        {
            professeur[index].salaire = salaire;
        }

        //Fonction pour ajouter des élèves a un établissement 
        //  Entrées : 
        //      List<T> eleves -> Types Eleve renseigner directement dans le programme
        //      List<T> ecole -> Types Ecole renseigner directement dans le programme
        //      indexEleve -> integer index de l'élève choisis et rentrer par l'utillisateur dans le programme
        //      indexEcole -> integer index de l'école choisie et rentrer directement par l'utillisateur dans le programme
        static void AjouterEleveEtablissement(List<Eleve> eleves, List<Ecole> ecole, int indexEleve, int indexEcole)
        {
            ecole[indexEcole].AjouterEleve(eleves[indexEleve]);
        }
        //Fonction pour ajouter un intervenant a un etablissement 
        //  Entrées : 
        //      List<T> professeur -> Types Professeur renseigner directement dans le programme
        //      List<T> ecole -> Types Ecole renseigner directement dans le programme
        //      indexIntervenant -> integer index de l'intervennat choisis et rentrer par l'utillisateur dans le programme
        //      indexEcole -> integer index de l'école choisie et rentrer directement par l'utillisateur dans le programme
        static void AjouterIntervennatEtablissement(List<Professeur> professeur, List<Ecole> ecole, int indexIntervenant, int indexEcole)
        {
            ecole[indexEcole].AjouterProfesseur(professeur[indexIntervenant]);
        }
        //Fonction Pour vieillir un Eleve de 1 an automatiquement 
        //  Entrées : 
        //      List<T> eleves -> Types Eleve renseigner directement dans le programme
        //      idEleve -> integer index de l'élève choisis et rentrer par l'utillisateur dans le programme
        static void VieillirEleve(List<Eleve> eleve, int idEleve)
        {
            eleve[idEleve].Vieillir();
        }
        //Fonction Pour vieillir un intervenant de un an automatiquement 
        //  Entrées : 
        //      List<T> professeur -> Types Professeur renseigner directement dans le programme
        //      idIntervenant -> integer index de l'intervennat choisis et rentrer par l'utillisateur dans le programme
        static void VieillirIntervenant(List<Professeur> intervenant, int idIntervenant)
        {
            intervenant[idIntervenant].Vieillir();
        }
    }
}
