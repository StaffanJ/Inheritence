using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritence
{
    public class Enemy : Character
    {

        public List<Enemy> Enemies { get; set; }

        public Enemy EnemyBlob { get; private set; }

        public Enemy EnemySkeleton { get; private set; }

        public Enemy EnemyBlobMethod()
        {
            return EnemyBlob = new Enemy { Name = "Blob", Health = 50, MaxDamage = 3,MinDamage = 1, Crit = 25.0 / 100.0, Level = 1, Experience = 30 };
        }

        public Enemy EnemySkeletonMethod()
        {
            return EnemySkeleton = new Enemy { Name = "Skeleton", Health = 70, MaxDamage = 5, MinDamage = 3, Crit = 25.0 / 100.0, Level = 2, Experience = 40 };
        }

        public void StartFight(Hero hero)
        {
            //Få fram "rätt" fiende.
            Random random = new Random();

            if (hero.Level >= 1 && hero.Level <= 4)
            {
                Enemies.Add(EnemyBlob);
                Enemies.Add(EnemySkeleton);

                foreach (var enemy in Enemies)
                {

                }
            }
        }
    }
}
