using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone4
{
    public class InventoryManager
    {
        /// <summary>
        /// use a list instead of an array
        /// </summary>
        private List<ItemObj> items = new List<ItemObj>();


        public int GetInventoryCount() => items.Count();


        public List<ItemObj> GetInventoryList() => items;

        /// <summary>
        /// add an item to our inventory
        /// </summary>
        /// <param name="i"></param>
        public void Add(ItemObj i)
        {
            items.Add(i);
        }


        /// <summary>
        /// remove an item from our inventory
        /// </summary>
        /// <param name="id"></param>
        public void Remove(Guid id)
        {
            items.RemoveAll(c => c.Id.ToString() == id.ToString());
        }

        /// <summary>
        /// display the inventory list
        /// </summary>
        public void Display(bool UI = false, List<ItemObj> toDisplay = null)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in toDisplay == null ? items : toDisplay)
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
        public List<ItemObj> Search(int Qty = -1, bool Damaged = false)
        {
            var t = new List<ItemObj>();
            if (Qty > -1)
                t.AddRange(items.FindAll(c => c.QtyOnHand == Qty));
            t.AddRange(items.FindAll(c => c.IsDamaged == Damaged));

            return t;
        }

        /// <summary>
        /// receive or restock an item
        /// </summary>
        /// <param name="Qty"></param>
        /// <param name="id"></param>
        public void ReStock(int Qty, Guid id)
        {
            for (int i = 0; i < items.Count(); i++)
            {
                if (items[i].Id.ToString() == id.ToString())
                    items[i].QtyOnHand += Qty;
            }
        }
    }
}
