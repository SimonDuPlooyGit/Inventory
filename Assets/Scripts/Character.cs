using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public InventoryObject inventory;

    private CharacterController controller;
    public Canvas BC;
    public Canvas BS;
    public TextMeshProUGUI walletBC;
    public TextMeshProUGUI walletBS;

    public float speed = 5f;
    private bool isMenuOpen = false;
    private bool BCOpen;
    private bool BSOpen;

    public int money = 100;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        BC.gameObject.SetActive(false);
        BS.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(isMenuOpen == false)
            {
                openBackPack();
            } else if (isMenuOpen == true)
            {
                closeBackPack();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isMenuOpen == false)
            {
                openShop();
            }
            else if (isMenuOpen == true)
            {
                closeShop();
            }
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        controller.Move(move * Time.deltaTime * speed);
    }

    private void openBackPack()
    {
        Time.timeScale = 0f;
        isMenuOpen = true;
        BC.gameObject.SetActive(true);
        walletBC.text = "Money: " + money;
        BCOpen = true;
    }

    private void closeBackPack()
    {
        Time.timeScale = 1f;
        isMenuOpen = false;
        BC.gameObject.SetActive(false);
        BCOpen = false;
    }

    private void openShop()
    {
        Time.timeScale = 0f;
        isMenuOpen = true;
        BS.gameObject.SetActive(true);
        walletBS.text = "Money: " + money;
        BSOpen = true;
    }

    private void closeShop()
    {
        Time.timeScale = 1f;
        isMenuOpen = false;
        BS.gameObject.SetActive(false);
        BSOpen= false;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("ItemEntered");
        var item = other.GetComponent<Item>();
        if (item && inventory.uniqueItems < 3)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        inventory.uniqueItems = 0;
    }
}
