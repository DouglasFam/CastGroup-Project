﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CastGroup.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new int();
        }

        public int Id { get; set; }
    }
}
