public class EnemyFactory
{
  public Enemy CreateEnemy(int numeroVague)
  {
    Enemy enemy = new Enemy();

    if (numeroVague == 1)
    {
      enemy.Nom = "Gobelin";
      enemy.Pv = 40;
      enemy.Attaque = 8;
    }
    else if (numeroVague == 2)
    {
      enemy.Nom = "Gobelin Archer";
      enemy.Pv = 35;
      enemy.Attaque = 11;
    }
    else if (numeroVague == 3)
    {
      enemy.Nom = "Boss Orc";
      enemy.Pv = 150;
      enemy.Attaque = 22;
    }

    return enemy;
  }
}