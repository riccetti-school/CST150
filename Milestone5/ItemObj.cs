using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone5
{
    public class ItemObj
    {
        /// <summary>
        /// the unique identifier for this object
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// friendly description for this object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// what is the unit quantity amount
        /// </summary>
        public int PackageQty { get; set; } = 0;

        /// <summary>
        /// how much of this item do we have on hand
        /// </summary>
        public int QtyOnHand { get; set; } = 0;

        /// <summary>
        /// are we supposed to ship this item
        /// </summary>
        public bool ToShip { get; set; } = false;

        /// <summary>
        /// Is this item damanged
        /// </summary>
        public bool IsDamaged { get; set; } = false;

        public ItemObj()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// should we ship this item
        /// </summary>
        /// <param name="toShip"></param>
        public void ShipIt(bool toShip)
        {
            ToShip = toShip;
        }

        /// <summary>
        /// we have received this item in to our inventory
        /// </summary>
        /// <param name="qty"></param>
        public void Receive(int qty)
        {
            QtyOnHand = PackageQty * qty;
        }


        public override string ToString()
        {
            return $"{Description} - On Hand: {QtyOnHand}";
        }

    }
}
