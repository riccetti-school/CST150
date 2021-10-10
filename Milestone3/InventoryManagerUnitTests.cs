using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone3
{
    public class InventoryManagerUnitTests
    {
        public InventoryManagerUnitTests()
        {
            
        }

        public void RunTests()
        {
            CheckAdd();
            CheckRemove();
            CheckDisplay();
            CheckReStock();
            CheckDamageSearch();
            CheckSearch();
        }

        public void CheckDamageSearch()
        {
            var t = new InventoryManager();
            var id = Guid.NewGuid();
            t.Add(new ItemObj
            {
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                IsDamaged = false,
                PackageQty = 8,
                QtyOnHand = 64,
                ToShip = false,
                Id = id
            });

            t.ReStock(100, id);

            // check for our item
            var y = t.Search(-1, true);

            if (y.Any(c => c.Id.ToString() == id.ToString()))
                Debug.WriteLine("FAILED!!! - Found something we should not have");
            else
                Debug.WriteLine("We didn't find any damanaged items.");
        }

        public void CheckSearch()
        {
            var t = new InventoryManager();
            var id = Guid.NewGuid();
            t.Add(new ItemObj
            {
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                IsDamaged = false,
                PackageQty = 8,
                QtyOnHand = 64,
                ToShip = false,
                Id = id
            });

            t.ReStock(100, id);

            // check for our item
            var y = t.Search(164);

            if (y.Any(c => c.Id.ToString() == id.ToString()))
                Debug.WriteLine("We found our item from search");
            else
                Debug.WriteLine("FAILED!!! - Did not find item with quantity 164");
        }

        public void CheckReStock()
        {
            var t = new InventoryManager();
            var id = Guid.NewGuid();
            t.Add(new ItemObj
            {
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                IsDamaged = false,
                PackageQty = 8,
                QtyOnHand = 64,
                ToShip = false,
                Id = id
            });

            t.ReStock(100, id);

            if (t.GetInventoryList()[0].QtyOnHand == 164)
                Debug.WriteLine("We restocked!");
            else
                Debug.WriteLine("FAILED!!! - Did not restock item");
        }

        public void CheckDisplay()
        {
            var t = new InventoryManager();
            var id = Guid.NewGuid();
            t.Add(new ItemObj
            {
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                IsDamaged = false,
                PackageQty = 8,
                QtyOnHand = 64,
                ToShip = false,
                Id = id
            });

            // we will check to see if this throws an exception
            try
            {
                t.Display();
                Debug.WriteLine("Display ran!");
            }
            catch (Exception)
            {
                Debug.WriteLine("FAILED!!! Display failed to run!");
            }
        }

        public void CheckRemove()
        {
            var t = new InventoryManager();
            var id = Guid.NewGuid();
            t.Add(new ItemObj
            {
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                IsDamaged = false,
                PackageQty = 8,
                QtyOnHand = 64,
                ToShip = false,
                Id = id
            });

            t.Remove(id);

            if (t.GetInventoryCount() == 0)
                Debug.WriteLine("We removed our item");
            else
                Debug.WriteLine("FAILED!!! Item was not removed");
        }

        /// <summary>
        /// check the add function
        /// </summary>
        public void CheckAdd()
        {
            var t = new InventoryManager();
            t.Add(new ItemObj
            {
                Description = $"New Test Item: {DateTime.Now.Ticks}",
                IsDamaged = false,
                PackageQty = 8,
                QtyOnHand = 64,
                ToShip = false,
                Id = Guid.NewGuid()
            });

            if(t.GetInventoryCount() == 1)
            {
                Debug.WriteLine("We have our item!");
                return;
            }

            Debug.WriteLine("FAILED!!!!!! No item found");
        }
    }
}
