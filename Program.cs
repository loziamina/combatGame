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

// creation de l'objet hero avec la factory
HeroFactory heroFactory = new HeroFactory();
Hero hero = heroFactory.CreateHero(heroName, nomClasse);

Console.WriteLine("PV : " + hero.Pv);
Console.WriteLine("Attaque : " + hero.Attaque);

int numeroVague = 1;
int totalVagues = 3;
int cooldown = 0;

// boucle des vagues
while (numeroVague <= totalVagues && hero.Pv > 0)
{
  // creation de l'objet enemy

  int soinsRestants = 2;

  EnemyFactory enemyFactory = new EnemyFactory();
  Enemy enemy = enemyFactory.CreateEnemy(numeroVague);

  Console.WriteLine("=== VAGUE " + numeroVague + "/" + totalVagues + " ===");
  Console.WriteLine("Un " + enemy.Nom + " apparaît !");
  Console.WriteLine(enemy.Nom + " | PV : " + enemy.Pv + " | Attaque : " + enemy.Attaque);

  while (hero.Pv > 0 && enemy.Pv > 0)
  {
    // Reduit le cooldown au début de chaque tour
    if (cooldown > 0)
      cooldown = cooldown - 1;

    Console.WriteLine("--- Votre tour ---");
    Console.WriteLine(hero.Nom + " | PV : " + hero.Pv);
    Console.WriteLine(enemy.Nom + " | PV : " + enemy.Pv);

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
      enemy.Pv = enemy.Pv - hero.Attaque;

      Console.WriteLine("Vous attaquez le " + enemy.Nom + " ! Il perd " + hero.Attaque + " PV.");
    }
    else if (choixAction == "2")
    {
      // Soin
      if (soinsRestants > 0)
      {
        hero.Pv = hero.Pv + 25;
        soinsRestants = soinsRestants - 1;

        Console.WriteLine("Vous vous soignez de 25 PV ! PV actuels : " + hero.Pv + " | Soins restants : " + soinsRestants);
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
        int degats = (int)(hero.Attaque * 1.5);

        enemy.Pv = enemy.Pv - degats;
        cooldown = 2;

        Console.WriteLine("Frappe Lourde ! Vous infligez " + degats + " dégâts !");
      }
      else if (nomClasse == "Mage")
      {
        int degats = hero.Attaque + 10;

        enemy.Pv = enemy.Pv - degats;
        cooldown = 3;

        Console.WriteLine("Éclair ! Vous infligez " + degats + " dégâts magiques !");
      }
      else if (nomClasse == "Voleur")
      {
        Random aleatoire = new Random();
        int tirage = aleatoire.Next(1, 101);

        if (tirage <= 30)
        {
          int degats = hero.Attaque * 2;

          enemy.Pv = enemy.Pv - degats;

          Console.WriteLine("COUP CRITIQUE ! Vous infligez " + degats + " dégâts !");
        }
        else
        {
          enemy.Pv = enemy.Pv - hero.Attaque;

          Console.WriteLine("Pas de critique... Vous infligez " + hero.Attaque + " dégâts.");
        }

        cooldown = 2;
      }
    }

    // Lennemi attaque le hero
    if (enemy.Pv > 0)
    {
      hero.Pv = hero.Pv - enemy.Attaque;

      Console.WriteLine(enemy.Nom + " attaque " + heroName + " ! Vous perdez " + enemy.Attaque + " PV.");
    }
  }

  // fin de la vague
  if (hero.Pv > 0)
  {
    Console.WriteLine("Vague " + numeroVague + " terminée !");

    // recupere 20% des PV entre les vagues
    if (numeroVague < totalVagues)
    {
      int pvRestores = (int)(hero.Pv * 0.20);

      hero.Pv = hero.Pv + pvRestores;

      Console.WriteLine("Vous récupérez " + pvRestores + " PV ! PV actuels : " + hero.Pv);
    }

    numeroVague = numeroVague + 1;
  }
}

// affiche le résultat du combat
if (hero.Pv > 0)
  Console.WriteLine("VICTOIRE ! Vous avez vaincu toutes les vagues !");
else
  Console.WriteLine("Vous avez été vaincu...");