// See https://aka.ms/new-console-template for more information
Console.WriteLine("jeu de combat");
Console.WriteLine("Biencenue dans le jeu");


Console.Write("Entrez le nom de votre héros : ");
string heroName = Console.ReadLine();

Console.WriteLine("bonjour " + heroName);

Console.WriteLine("Choisissez votre classe :");
Console.WriteLine("1. Guerrier  (120 PV, 18 attaque)");
Console.WriteLine("2. Mage      (80 PV, 12 attaque)");
Console.WriteLine("3. Voleur    (90 PV, 14 attaque)");

Console.Write("Votre choix (1/2/3) : ");
string choixClasse = Console.ReadLine();

//Console.WriteLine("Vous avez choisi : " + choixClasse);
// On vérifie que le joueur a tapé 1, 2 ou 3
// Sinon on lui redemande
while (choixClasse != "1" && choixClasse != "2" && choixClasse != "3")
{
  Console.WriteLine("Choix invalide ! Tapez 1, 2 ou 3.");
  Console.Write("Votre choix (1/2/3) : ");
  choixClasse = Console.ReadLine();
}


string nomClasse = "";

if (choixClasse == "1")
  nomClasse = "Guerrier";
else if (choixClasse == "2")
  nomClasse = "Mage";
else if (choixClasse == "3")
  nomClasse = "Voleur";

Console.WriteLine("Vous jouez : " + heroName + " le " + nomClasse + " !");


// definir les stats 

int pyHero = 0;
int attaqueHero = 0;

if (nomClasse == "Guerrier")
{
  pyHero = 120;
  attaqueHero = 18;
}
else if (nomClasse == "Mage")
{
  pyHero = 80;
  attaqueHero = 12;
}
else if (nomClasse == "Voleur")
{
  pyHero = 90;
  attaqueHero = 14;
}

Console.WriteLine("PV : " + pyHero);
Console.WriteLine("Attaque : " + attaqueHero);