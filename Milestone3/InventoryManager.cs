using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone3
{
    public class InventoryManager
    {
        private ItemObj[] Items = new ItemObj[0];

        /// <summary>
        /// add an item to our inventory
        /// </summary>
        /// <param name="i"></param>
        public void Add(ItemObj i)
        {
            var l = Items.Length + 1;
            Array.Resize<ItemObj>(ref Items, l);
            Items[l-1] = i;
        }


        /// <summary>
        /// remove an item from our inventory
        /// </summary>
        /// <param name="id"></param>
        public void Remove(Guid id)
        {
            if (Items == null) return;

            if (Items.Any(c => c.Id.ToString() == id.ToString()))
            {
                ItemObj[] temp = new ItemObj[Items.Length - 1];
                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i].Id != id)
                    {
                        temp[i - 1] = Items[i];
                    }
                }

                Array.Resize<ItemObj>(ref Items, Items.Length - 1);
                temp.CopyTo(Items, 0);
            }
        }

        /// <summary>
        /// display the inventory list
        /// </summary>
        public void Display()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in Items)
                sb.AppendLine(i.ToString());

            if (sb.Length > 0)
                System.Windows.Forms.MessageBox.Show(sb.ToString());
            else
                System.Windows.Forms.MessageBox.Show("No items in inventory");
        }


        /// <summary>
        /// search for inventory items by quantity and or if they are damaged
        /// </summary>
        /// <param name="Qty"></param>
        /// <param name="Damaged"></param>
        /// <returns></returns>
        public ItemObj[] Search(int Qty = -1, bool Damaged = false)
        {
            var l = new List<ItemObj>();
            foreach(var i in Items)
            {
                if(Qty > 0)
                {
                    if (i.QtyOnHand == Qty)
                        l.Add(i);
                }
                if (i.IsDamaged == Damaged)
                    l.Add(i);
            }
            return l.ToArray();
        }

        /// <summary>
        /// receive or restock an item
        /// </summary>
        /// <param name="Qty"></param>
        /// <param name="id"></param>
        public void ReStock(int Qty, Guid id)
        {
            for(int i=0;i<Items.Length;i++)
            {
                if (Items[i].Id.ToString() == id.ToString())
                    Items[i].Receive(Qty);
            }
        }
    }
}
