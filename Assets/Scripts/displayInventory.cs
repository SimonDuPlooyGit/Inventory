using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class displayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int xspace;
    public int yspace;
    public int numCols;
    public float xstart;
    public float ystart;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }

    
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, transform.rotation * Quaternion.Euler(0f, 0f, 0f), transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(xstart + (xspace * (i % numCols)), ystart + (-yspace * (i/numCols)), 0f);
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            } else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, transform.rotation * Quaternion.Euler(0f, 0f, 0f), transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
}
