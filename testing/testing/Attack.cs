﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    public class Attack : Action
    {
        public Attack(Unit Source, Unit Target, bool Undo) : base(Source, Target, Undo)
        {
        }
        public void Execute()
        {
            int damage = Source.Stats["STR"] + Source.Weapon.Stats["MT"] - Target.Stats["DEF"];
            if (Undo)
            {
                damage *= -1;
            }
            Target.TakeDamage(damage);
        }
    }
}
