using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public Transform itemsParent;
    ItemsInventory inventory;
    InventorySlot[] slots;
    
    void Start() {
        inventory = ItemsInventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI() {
        for (int i = 0; i < ItemsInventory.itemsInInventory.Count; i++) {
            slots[i].AddItem(ItemsInventory.itemsInInventory[i]);
        }

        for (int i = ItemsInventory.itemsInInventory.Count; i < slots.Length; i++) {
            slots[i].RemoveItem();
        }
    }
}
