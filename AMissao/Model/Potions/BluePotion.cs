using AMissao.Model.Weapons;
using System;
using System.Drawing;

namespace AMissao.Model.Potions
{
    public class BluePotion : Weapon, IPotion
    {
        public override string Name
        {
            get { return "Blue Potion"; }
        }

        public bool Used { get; private set; }

        public BluePotion(Game game, Point location) : base(game, location)
        {
            Used = false;
        }

        public override void Attack(Direction direction, Random random)
        {
            if (!Used)
            {
                this.game.IncreasePlayerHealth(5, random);
                Used = true;
            }
        }
    }
}
