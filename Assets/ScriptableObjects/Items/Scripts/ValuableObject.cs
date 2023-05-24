using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Valuable Object", menuName = "Inventory System/Items/Valuable")] //Attribute

public class ValuableObject : ItemObject
{
    public int sellValue;

    public void Awake()
    {
        type = ItemType.Valuable;
    }
}
