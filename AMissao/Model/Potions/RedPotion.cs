using AMissao.Model.Weapons;
using System;
using System.Drawing;

namespace AMissao.Model.Potions
{
    public class RedPotion : Weapon, IPotion
    {
        public override string Name
        {
            get { return "Red Potion"; }
        }

        public bool Used { get; private set; }

        public RedPotion(Game game, Point location) : base(game, location)
        {
            Used = false;
        }

        public override void Attack(Direction direction, Random random)
        {
            if (!Used)
            {
                this.game.IncreasePlayerHealth(10, random);
                Used = true;
            }
        }
    }
}
