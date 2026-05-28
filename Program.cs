// See https://aka.ms/new-console-template for more information
Console.WriteLine("jeu de combat");
Console.WriteLine("Bienvenue dans le jeu");

Console.Write("Entrez le nom de votre héros : ");
string heroName = Console.ReadLine();

Console.WriteLine("bonjour " + heroName);

Console.WriteLine("Choisissez votre classe :");
Console.WriteLine("1. Guerrier  (120 PV, 18 attaque)");
Console.WriteLine("2. Mage      (80 PV, 12 attaque)");
Console.WriteLine("3. Voleur    (90 PV, 14 attaque)");

Console.Write("Votre choix (1/2/3) : ");
string choixClasse = Console.ReadLine();

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
int cooldown = 0;

Console.WriteLine("Un " + nomEnnemi + " apparaît !");
Console.WriteLine(nomEnnemi + " | PV : " + pvEnnemi + " | Attaque : " + attaqueEnnemi);

while (pvHero > 0 && pvEnnemi > 0)
{
  // Reduit le cooldown au début de chaque tour
  if (cooldown > 0)
    cooldown = cooldown - 1;

  Console.WriteLine("--- Votre tour ---");
  Console.WriteLine(heroName + " | PV : " + pvHero);
  Console.WriteLine(nomEnnemi + " | PV : " + pvEnnemi);

  // Menu d'actions
  Console.WriteLine("Que voulez-vous faire ?");
  Console.WriteLine("1. Attaquer");
  Console.WriteLine("2. Se soigner (+25 PV) - reste : " + soinsRestants);

  // Affiche la compétence selon la classe et le cooldown
  if (cooldown > 0)
    Console.WriteLine("3. Compétence (recharge dans " + cooldown + " tour(s))");
  else if (nomClasse == "Guerrier")
    Console.WriteLine("3. Frappe Lourde (dégâts x1.5)");
  else if (nomClasse == "Mage")
    Console.WriteLine("3. Éclair (ignore 50% armure)");
  else if (nomClasse == "Voleur")
    Console.WriteLine("3. Coup Critique (30% chance x2)");

  Console.Write("Votre choix (1/2/3) : ");
  string choixAction = Console.ReadLine();

  while (choixAction != "1" && choixAction != "2" && choixAction != "3")
  {
    Console.WriteLine("Choix invalide ! Tapez 1, 2 ou 3.");
    Console.Write("Votre choix (1/2/3) : ");
    choixAction = Console.ReadLine();
  }

  if (choixAction == "1")
  {
    // Attaque normale
    pvEnnemi = pvEnnemi - attaqueHero;
    Console.WriteLine("Vous attaquez le " + nomEnnemi + " ! Il perd " + attaqueHero + " PV.");
  }
  else if (choixAction == "2")
  {
    // Soin
    if (soinsRestants > 0)
    {
      pvHero = pvHero + 25;
      soinsRestants = soinsRestants - 1;
      Console.WriteLine("Vous vous soignez de 25 PV ! PV actuels : " + pvHero + " | Soins restants : " + soinsRestants);
    }
    else
    {
      Console.WriteLine("Plus de soins disponibles !");
    }
  }
  else if (choixAction == "3")
  {
    // definir les compétences pour chaque classes
    if (cooldown > 0)
    {
      Console.WriteLine("Compétence pas encore disponible !");
    }
    else if (nomClasse == "Guerrier")
    {
      int degats = (int)(attaqueHero * 1.5);
      pvEnnemi = pvEnnemi - degats;
      cooldown = 2;
      Console.WriteLine("Frappe Lourde ! Vous infligez " + degats + " dégâts !");
    }
    else if (nomClasse == "Mage")
    {
      int degats = attaqueHero + 10;
      pvEnnemi = pvEnnemi - degats;
      cooldown = 3;
      Console.WriteLine("Éclair ! Vous infligez " + degats + " dégâts magiques !");
    }
    else if (nomClasse == "Voleur")
    {
      Random aleatoire = new Random();
      int tirage = aleatoire.Next(1, 101);
      if (tirage <= 30)
      {
        int degats = attaqueHero * 2;
        pvEnnemi = pvEnnemi - degats;
        Console.WriteLine("COUP CRITIQUE ! Vous infligez " + degats + " dégâts !");
      }
      else
      {
        pvEnnemi = pvEnnemi - attaqueHero;
        Console.WriteLine("Pas de critique... Vous infligez " + attaqueHero + " dégâts.");
      }
      cooldown = 2;
    }
  }

  // Lennemi attaque le hero
  if (pvEnnemi > 0)
  {
    pvHero = pvHero - attaqueEnnemi;
    Console.WriteLine(nomEnnemi + " attaque " + heroName + " ! Vous perdez " + attaqueEnnemi + " PV.");
  }
}

// affiche le résultat du combat
if (pvHero > 0)
  Console.WriteLine("Vous avez vaincu le " + nomEnnemi + " !");
else
  Console.WriteLine("Vous avez été vaincu...");