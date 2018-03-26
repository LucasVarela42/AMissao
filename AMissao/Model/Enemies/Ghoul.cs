using System;
using System.Drawing;

namespace AMissao.Model.Enemies
{
    public class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location) : base(game, location, 10)
        {
        }

        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                var action = random.Next(1, 4);
                switch (action)
                {
                    case 1:
                        break;
                    case 2:
                    case 3:
                        Direction moveDirection = FindPlayerDirection(game.PlayerLocation);
                        this.location = this.Move(moveDirection, game.Boundaries);
                        break;
                }
            }

            if (NearPlayer() && !Dead)
                game.HitPlayer(4, random);
        }
    }
}
