﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMissao.Model.Weapons
{
    public class Bow:Weapon
    {
        public override string Name { get { return "Bow"; } }

        public Bow(Game game, Point location) : base(game, location)
        {
        }

        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, 30, 1, random);
        }
    }
}
