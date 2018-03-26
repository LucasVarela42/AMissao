using System;
using System.Drawing;

namespace AMissao.Model.Weapons
{
    public class Sword : Weapon
    {
        public override string Name { get { return "Sword"; } }

        public Sword(Game game, Point location) : base(game, location)
        {
        }

        public override void Attack(Direction direction, Random random)
        {
            var directionForAttack = direction;

            while (!DamageEnemy(directionForAttack, 10, 3, random) && (int)directionForAttack <= 3)
            {
                directionForAttack++;
            }

            while (!DamageEnemy(directionForAttack, 10, 3, random) && (int)directionForAttack >= 0)
            {
                directionForAttack--;
            }

        }
    }
}