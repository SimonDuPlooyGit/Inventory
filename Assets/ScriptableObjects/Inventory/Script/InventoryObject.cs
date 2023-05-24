using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public int uniqueItems = 0;
    public int maxUniqueItems = 3;
    public void AddItem(ItemObject it, int am)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == it)
            {
                Container[i].AddAmount(am);
                hasItem = true;
                break;
            }
        }
        if (!hasItem && uniqueItems < 3)
        {
            Container.Add(new InventorySlot(it, am));
            uniqueItems++;
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject it, int am)
    {
        item = it;
        amount = am;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
