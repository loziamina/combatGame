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

int pvHero = 0;
int attaqueHero = 0;

if (nomClasse == "Guerrier")
{
  pvHero = 120;
  attaqueHero = 18;
}
else if (nomClasse == "Mage")
{
  pvHero = 80;
  attaqueHero = 12;
}
else if (nomClasse == "Voleur")
{
  pvHero = 90;
  attaqueHero = 14;
}

Console.WriteLine("PV : " + pvHero);
Console.WriteLine("Attaque : " + attaqueHero);


string nomEnnemi = "Gobelin";
int pvEnnemi = 40;
int attaqueEnnemi = 8;

Console.WriteLine("Un " + nomEnnemi + " apparaît ! ");
Console.WriteLine(nomEnnemi + " | PV : " + pvEnnemi + " | Attaque : " + attaqueEnnemi);

// tant que le hero et lennemi en vie le combat continue 
while (pvHero > 0 && pvEnnemi > 0)
{
  // Affiche l'état du combat
  Console.WriteLine("--- Votre tour ---");
  Console.WriteLine(heroName + " | PV : " + pvHero);
  Console.WriteLine(nomEnnemi + " | PV : " + pvEnnemi);

  // Le héros attaque l'ennemi
  Console.WriteLine("Vous attaquez le " + nomEnnemi + " !");
  pvEnnemi = pvEnnemi - attaqueHero;
  Console.WriteLine(nomEnnemi + " perd " + attaqueHero + " PV. PV restants : " + pvEnnemi);

  // L'ennemi attaque le hero 
  if (pvEnnemi > 0)
  {
    Console.WriteLine(nomEnnemi + " attaque " + heroName + " !");
    pvHero = pvHero - attaqueEnnemi;
    Console.WriteLine(heroName + " perd " + attaqueEnnemi + " PV. PV restants : " + pvHero);
  }
}

if (pvHero > 0)
  Console.WriteLine("Vous avez vaincu le " + nomEnnemi + " !");
else
  Console.WriteLine("Vous avez ete vaincu...");