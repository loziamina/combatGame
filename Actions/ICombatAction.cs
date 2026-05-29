public interface ICombatAction
{
  string Nom { get; }
  string Execute(Hero hero, Enemy enemy);
}