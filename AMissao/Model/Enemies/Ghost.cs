using System;
using System.Drawing;

namespace AMissao.Model.Enemies
{
    public class Ghost : Enemy
    {
        public Ghost(Game game, Point location) : base(game, location, 8)
        {
        }

        public override void Move(Random random)
        {
            if(HitPoints > 0)
            {
                var action = random.Next(1, 4);
                switch (action)
                {
                    case 1:
                        Direction moveDirection = FindPlayerDirection(game.PlayerLocation);
                        this.location = this.Move(moveDirection, game.Boundaries);
                        break;

                    case 2:
                    case 3:
                        break;
                }
            }

            if (NearPlayer() && !Dead)
                game.HitPlayer(3, random);
        }
    }
}
