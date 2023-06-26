using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonobehaviour<InventoryManager> 
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;

    [SerializeField] private SO_ItemList itemList = null;
    protected override void Awake()
    {
        base.Awake();

        // Create item details dictionary
        CreateItemDetailsDictionary();
    }

    //Populates the itemDetailsDictionary from the scriptable objects items list
    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();

        foreach(ItemDetails itemDetails in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
    }

    //Return the itemDetails (from the SO_ItemList) for the itemCode, or null if the item code doesn't exist
    public ItemDetails GetItemDetails(int itemCode)
    {
        ItemDetails itemDetails;

        if(itemDetailsDictionary.TryGetValue(itemCode, out itemDetails)) 
        { 
            return itemDetails; 
        }
        else
        {
            return null;
        }
    }
}
