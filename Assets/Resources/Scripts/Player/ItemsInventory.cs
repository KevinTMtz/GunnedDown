using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInventory : MonoBehaviour
{
    List<GameObject> itemsInInventory = new List<GameObject>();
    private GameObject pickedItem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            for (int i=0; i<itemsInInventory.Count; i++) {
                itemsInInventory[i].SetActive(true);
            } 
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("PassiveItem")) {
            string path = "Prefabs/PassiveItems/PassiveItem" + other.gameObject.name.Substring(11);
            pickedItem = (GameObject) Resources.Load(path, typeof(GameObject));
            
            Instantiate(pickedItem, transform.position, Quaternion.identity);
            itemsInInventory.Add(GameObject.Find("PassiveItem"+other.gameObject.name.Substring(11)+"(Clone)"));
            
            // TODO: Change Later, just hide the sprite
            itemsInInventory[itemsInInventory.Count-1].SetActive(false);
            
            Destroy(other.gameObject);

            SoundManager.PlaySound("LeatherInventory");
        }
    }
}
