using AMissao.Model.Enemies;
using System;
using System.Drawing;

namespace AMissao.Model.Weapons
{
    public abstract class Weapon: Mover
    {
        private bool pickedUp;
        public bool PickedUp
        {
            get { return pickedUp; }
        }

        public abstract string Name { get; }

        public Weapon(Game game, Point location): base(game, location)
        {
            pickedUp = false;
        }

        public void PickUpWeapon() { pickedUp = true; }

        public abstract void Attack(Direction direction, Random random);
        
        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if(Nearby(enemy.Location, target, radius))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                target = Move(direction, target, game.Boundaries);
            }
            return false;
        }

        /*For the DamageEnemy()
        * calculation, you’ll need to add an overloaded Nearby() method that 
        * compares two points and returns true if they’re within the specified 
        * distance of each other.
        */
        public bool Nearby(Point locationA, Point locationB, int distance)
        {
            return Math.Abs(locationA.X - locationB.X) < distance && (Math.Abs(locationA.Y - locationB.Y) < distance);
        }

        /*You’ll also need an overloaded Move() method to 
         * move a Point in a direction and return the new Point.
         */
        public Point Move(Direction direction, Point locationToMove, Rectangle boundaries)
        {
            location = locationToMove;
            return Move(direction, boundaries);
        }
    }
}