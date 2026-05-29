public class SpecialAttackAction : ICombatAction
{
  // les compétences
  public string Nom => "Compétence spéciale";
  public string Execute(Hero hero, Enemy enemy)
  {
    if (hero.Classe == "Guerrier")
    {
      int degats = (int)(hero.Attaque * 1.5);
      enemy.Pv = enemy.Pv - degats;
      return "Frappe Lourde ! Vous infligez " + degats + " dégâts !";
    }
    else if (hero.Classe == "Mage")
    {
      int degats = hero.Attaque + 10;
      enemy.Pv = enemy.Pv - degats;
      return "Éclair ! Vous infligez " + degats + " dégâts magiques !";
    }
    else if (hero.Classe == "Voleur")
    {
      Random aleatoire = new Random();
      int tirage = aleatoire.Next(1, 101);

      if (tirage <= 30)
      {
        int degats = hero.Attaque * 2;
        enemy.Pv = enemy.Pv - degats;
        return "COUP CRITIQUE ! Vous infligez " + degats + " dégâts !";
      }
      else
      {
        enemy.Pv = enemy.Pv - hero.Attaque;
        return "Pas de critique... Vous infligez " + hero.Attaque + " dégâts.";
      }
    }

    return "Compétence inconnue !";
  }
}