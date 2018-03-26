using System;
using System.Drawing;

namespace AMissao.Model.Enemies
{
    internal class Bat : Enemy
    {
       public Bat(Game game, Point location): base(game, location, 6) { }

        public override void Move(Random random)
        {
            Direction moveDirection;

            if(this.HitPoints >= 1)
            {
                moveDirection = FindPlayerDirection(game.PlayerLocation);
                this.location = this.Move(moveDirection, game.Boundaries);
            }
            else
            {
                moveDirection = (Direction)random.Next(0, 5);
                this.location = this.Move(moveDirection, game.Boundaries);
            }

            if(NearPlayer() && !Dead)
            {
                game.HitPlayer(2, random);
            }
        }
    }
}