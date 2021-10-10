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
            Remove();
        }

        public void Remove()
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
