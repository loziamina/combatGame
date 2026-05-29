public class BasicAttackAction : ICombatAction
{
  public string Nom => "Attaquer";
  public string Execute(Hero hero, Enemy enemy)
  {
    enemy.Pv = enemy.Pv - hero.Attaque;
    return "Vous attaquez le " + enemy.Nom + " ! Il perd " + hero.Attaque + " PV.";
  }
}