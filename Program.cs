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
int soinsRestants = 2;

Console.WriteLine("Un " + nomEnnemi + " apparaît ! ");
Console.WriteLine(nomEnnemi + " | PV : " + pvEnnemi + " | Attaque : " + attaqueEnnemi);

// tant que le hero et lennemi en vie le combat continue 
while (pvHero > 0 && pvEnnemi > 0)
{

  Console.WriteLine("--- Votre tour ---");
  Console.WriteLine(heroName + " | PV : " + pvHero);
  Console.WriteLine(nomEnnemi + " | PV : " + pvEnnemi);

  // le menu daction
  Console.WriteLine("Que voulez-vous faire ?");
  Console.WriteLine("1. Attaquer");
  Console.WriteLine("2. Se soigner (+25 PV)");

  Console.Write("Votre choix (1/2) : ");
  string choixAction = Console.ReadLine();

  while (choixAction != "1" && choixAction != "2")
  {
    Console.WriteLine("Choix invalide ! Tapez 1 ou 2.");
    Console.Write("Votre choix (1/2) : ");
    choixAction = Console.ReadLine();
  }

  if (choixAction == "1")
  {
    // Attaque
    pvEnnemi = pvEnnemi - attaqueHero;
    Console.WriteLine("Vous attaquez le " + nomEnnemi + " ! Il perd " + attaqueHero + " PV.");
  }
  else if (choixAction == "2")
  {
    if (soinsRestants > 0)
    {
      pvHero = pvHero + 25;
      soinsRestants = soinsRestants - 1;
      Console.WriteLine("Vous vous soignez de 25 PV ! PV actuels : " + pvHero + " | Soins restants : " + soinsRestants);
    }
    else
    {
      Console.WriteLine("Vous n'avez plus de soins restants ");
    }
  }

  // L'ennemi attaque le hero
  if (pvEnnemi > 0)
  {
    pvHero = pvHero - attaqueEnnemi;
    Console.WriteLine(nomEnnemi + " attaque " + heroName + " ! Vous perdez " + attaqueEnnemi + " PV.");
  }
}