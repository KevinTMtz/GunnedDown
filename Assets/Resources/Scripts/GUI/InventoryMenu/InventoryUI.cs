using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    
    ItemsInventory inventory;

    InventorySlot[] slots;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = ItemsInventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI() {
        for (int i=0; i < ItemsInventory.itemsInInventory.Count; i++) {
            slots[i].AddItem(ItemsInventory.itemsInInventory[i]);
        }

        for (int i=ItemsInventory.itemsInInventory.Count; i < slots.Length; i++) {
            slots[i].RemoveItem();
        }
    }
}
