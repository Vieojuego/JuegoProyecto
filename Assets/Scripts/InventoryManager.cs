using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items; //LISTA DE ITEMS QUE TENEMOS
    public List<Item> items_add; //LISTA DE ITEMS POR AÑADIR

    public Transform ItemContent;
    public GameObject InventoryItem;
    public Toggle RemoveEnable;
    public InventoryItemController[] InventoryItems;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Items = new List<Item>();
        items_add = new List<Item>();
    }

    public void Add(Item item)
    {
        items_add.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {


        foreach (var item in items_add)
        {
            
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var itemRemoveBt = obj.transform.Find("RemoveItem").GetComponent<Button>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            Items.Add(item);
            if(RemoveEnable.isOn)
            {
                itemRemoveBt.gameObject.SetActive(true);
            }
        }

        items_add.Clear();
        SetInventoryItems();
        
    }

    public void EnableItemsRemove(){
        if(RemoveEnable.isOn)
        {

            foreach(Transform item in ItemContent) {
                item.Find("RemoveItem").gameObject.SetActive(true);

            }
        }else
        {
             foreach(Transform item in ItemContent) {
                item.Find("RemoveItem").gameObject.SetActive(false);

            }
        }
    }

    public void SetInventoryItems() 
    {
        InventoryItems  = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for(int i = 0; i < Items.Count; i++) {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
} 