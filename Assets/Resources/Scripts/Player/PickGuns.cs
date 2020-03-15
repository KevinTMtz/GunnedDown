using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGuns : MonoBehaviour
{
    List<GameObject> gunsInInventory = new List<GameObject>();
    private GameObject pickedGun;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mouseScrollDelta.y);
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("ItemGun")) {
            string path = "Prefabs/Guns/Gun" + other.gameObject.name.Substring(7);
            pickedGun = (GameObject) Resources.Load(path, typeof(GameObject));
            Instantiate(pickedGun, transform.position, Quaternion.identity);
            gunsInInventory.Add(GameObject.Find("Gun"+other.gameObject.name.Substring(7)));
            
            Destroy(other.gameObject);
        }
    }
}
