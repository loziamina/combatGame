public class HealAction : ICombatAction
{
  public string Nom => "Se soigner (+25 PV)";

  public string Execute(Hero hero, Enemy enemy)
  {
    hero.Pv = hero.Pv + 25;
    return "Vous vous soignez de 25 PV ! PV actuels : " + hero.Pv;
  }
}