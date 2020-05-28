using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    public Image icon;

    GameObject item;
    
    public void AddItem (GameObject newItem) {
        item = newItem;
        icon.sprite = newItem.GetComponent<SpriteRenderer>().sprite;
        icon.color = newItem.GetComponent<SpriteRenderer>().color;
        icon.enabled = true;
    }

    public void RemoveItem() {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
