using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone3
{
    public class InventoryManager
    {
        private ItemObj[] items = new ItemObj[0];


        public int GetInventoryCount() => items.Length;


        public ItemObj[] GetInventoryList() => items;

        /// <summary>
        /// add an item to our inventory
        /// </summary>
        /// <param name="i"></param>
        public void Add(ItemObj i)
        {
            var l = items.Length + 1;
            Array.Resize<ItemObj>(ref items, l);
            items[l - 1] = i;
        }


        /// <summary>
        /// remove an item from our inventory
        /// </summary>
        /// <param name="id"></param>
        public void Remove(Guid id)
        {
            if (items == null) return;

            if (items.Any(c => c.Id.ToString() == id.ToString()))
            {
                ItemObj[] temp = new ItemObj[items.Length - 1];
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].Id != id)
                    {
                        temp[i - 1] = items[i];
                    }
                }

                Array.Resize<ItemObj>(ref items, items.Length - 1);
                temp.CopyTo(items, 0);
            }
        }

        /// <summary>
        /// display the inventory list
        /// </summary>
        public void Display(bool UI = false)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in items)
                sb.AppendLine(i.ToString());

            if (sb.Length > 0)
            {
                if (UI)
                    System.Windows.Forms.MessageBox.Show(sb.ToString());
                else
                    System.Diagnostics.Debug.WriteLine(sb.ToString());
            }
            else
            {
                if (UI)
                    System.Windows.Forms.MessageBox.Show("No items in inventory");
                else
                    System.Diagnostics.Debug.WriteLine("No items in inventory");
            }
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
            foreach (var i in items)
            {
                if (Qty > 0)
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
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Id.ToString() == id.ToString())
                    items[i].QtyOnHand += Qty;
            }
        }
    }
}
