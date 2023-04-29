using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingStation : MonoBehaviour
{
    public List<Order> todaysOrders;

    public List<Item> itemsAtStation;

    public bool automagic = true;

    public Box PlaceItemAtStation(Item item)
    {
        itemsAtStation.Add(item);

        if (automagic)
        {
            return BoxOrder();
        }

        return null;
    }

    public Box BoxOrder()
    {
        Order completed = CheckAgainstAllOrders();

        if (completed != null)
        {
            Box box = new Box(completed);

            foreach (Item i in itemsAtStation)
            {
                box.AddItem(i);
            }

            return box;
        } // else

        return null;
    }

    // Checks to see if the items at the station
    // Correctly correspond to any order
    public Order CheckAgainstAllOrders()
    {
        foreach (Order o in todaysOrders)
        {
            bool check = o.CheckAgainstOrder(itemsAtStation);

            if (check == true)
            {
                return o;
            }
        }

        return null;
    }
}
