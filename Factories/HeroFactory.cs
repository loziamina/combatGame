public class HeroFactory
{
  public Hero CreateHero(string heroName, string nomClasse)
  {
    Hero hero = new Hero();

    hero.Nom = heroName;
    hero.Classe = nomClasse;

    if (nomClasse == "Guerrier")
    {
      hero.Pv = 120;
      hero.Attaque = 18;
    }
    else if (nomClasse == "Mage")
    {
      hero.Pv = 80;
      hero.Attaque = 12;
    }
    else if (nomClasse == "Voleur")
    {
      hero.Pv = 90;
      hero.Attaque = 14;
    }

    return hero;
  }
}