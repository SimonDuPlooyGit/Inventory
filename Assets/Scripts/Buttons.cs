using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject player;
    public Canvas canvas;
    public int value;

    public void Awake()
    {
        player = GameObject.Find("PlayerBody");
        canvas = FindObjectOfType<Canvas>();
    }

    public void SellItem()
    {
        player.GetComponent<Character>().money += value;
        player.GetComponent<Character>().walletBC.text = "Money: " + player.GetComponent<Character>().money;
        player.GetComponent<Character>().walletBS.text = "Money: " + player.GetComponent<Character>().money;
        //canvas.GetComponent<displayInventory>().inventory.Container[]
    }
}
