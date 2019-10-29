using ItsUmbria.Game.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Game.Items
{
    public class ItemFactory
    {
        public Item Create(ItemType type, string Name)
        {
            switch (type)
            {
                case ItemType.Medikit:
                    return new Medikit();
                case ItemType.Granade:
                    return new Granade();
                default:
                    return null;
            }
        }
    }
}
