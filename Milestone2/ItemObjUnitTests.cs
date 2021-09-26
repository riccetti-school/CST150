using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone2
{
    public class ItemObjUnitTests
    {

        private static ItemObj _i;

        /// <summary>
        /// this is the unit test driver function
        /// </summary>
        public static void RunTests()
        {

            _i = new ItemObj();

            if (!HasAnId()) throw new Exception("No id in class");
            if (!IdShouldMatch()) throw new Exception("Id does not match");
            if (!DescriptionShouldMatch()) throw new Exception("Description does not match");
            if (!PackageQtyShouldMatch()) throw new Exception("PackageQty does not match");
            if (!QtyOnHandShouldMatch()) throw new Exception("QtyOnhand does not match");
            if (!ToShipShoulsMatch()) throw new Exception("ToShip does not match");
            if (!IsDamagedShouldMatch()) throw new Exception("IsDamaged does not match");
            if (!ShipItShouldChangeToShip()) throw new Exception("ShipIt dod not change ToShip");
            if (!ReceiveShouldChangeQtyOnHand()) throw new Exception("Receive did not change QtyOnHand");


            // all passed
            System.Diagnostics.Debug.WriteLine("All tests passed");

        }


        // place unit tests here

        private static bool HasAnId()
        {
            return _i.Id != Guid.Empty;
        }

        private static bool IdShouldMatch()
        {
            var g = Guid.NewGuid();
            _i.Id = g;
            return _i.Id == g;
        }

        private static bool DescriptionShouldMatch()
        {
            var d = "This is my item";
            _i.Description = d;
            return _i.Description == d;
        }

        private static bool PackageQtyShouldMatch()
        {
            var q = 11;
            _i.PackageQty = q;
            return _i.PackageQty == q;
        }

        private static bool QtyOnHandShouldMatch()
        {
            var q = 13;
            _i.QtyOnHand = q;
            return _i.QtyOnHand == q;
        }

        private static bool ToShipShoulsMatch()
        {
            var t = true;
            _i.ToShip = t;
            return _i.ToShip == t;
        }

        private static bool IsDamagedShouldMatch()
        {
            var t = true;
            _i.IsDamaged = t;
            return _i.IsDamaged == t;
        }

        private static bool ShipItShouldChangeToShip()
        {
            _i.ToShip = true;
            _i.ShipIt(false);
            return _i.ToShip == false;
        }

        private static bool ReceiveShouldChangeQtyOnHand()
        {
            _i.PackageQty = 10;
            _i.Receive(10);
            return _i.QtyOnHand == 100;
        }

    }
}
