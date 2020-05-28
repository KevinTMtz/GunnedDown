using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class ItemsInventory : MonoBehaviour {
    public static ItemsInventory instance;

    void Awake () {
        if (instance != null) {
            Debug.LogWarning("More than one ItemInventory instance");
            return;
        }
        instance = this;
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    
    public static List<GameObject> itemsInInventory = new List<GameObject>();
    private GameObject pickedItem;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PassiveItem")) {
            string path = "Prefabs/PassiveItems/PassiveItem" + Regex.Replace(other.gameObject.name, "[^.0-9]", "");
            pickedItem = (GameObject) Resources.Load(path, typeof(GameObject));
            
            GameObject itemInstance = Instantiate(pickedItem, transform.position, Quaternion.identity);
            itemsInInventory.Add(itemInstance);
            
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
            
            itemsInInventory[itemsInInventory.Count - 1].SetActive(false);
            
            Destroy(other.gameObject);

            SoundManager.PlaySound("LeatherInventory");
        }
    }
}
