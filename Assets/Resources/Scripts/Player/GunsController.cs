using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsController : MonoBehaviour
{
    List<GameObject> gunsInInventory = new List<GameObject>();
    private GameObject pickedGun;
    private int activeWeapon = 0;
    private bool wait = true;

    private Transform hand;
    
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("Hand").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaScroll = Input.GetAxisRaw("Mouse ScrollWheel");
        
        //Debug.Log(deltaScroll);
        if(deltaScroll != 0 && wait && gunsInInventory.Count > 1){
            wait = false;
            StartCoroutine(waitToChange());
            if (deltaScroll < 0)
                ChangeWeapon(1);
            if (deltaScroll > 0)
                ChangeWeapon(-1);
        }

        if (Input.GetKeyDown(KeyCode.Tab)) {
            ChangeWeapon(1);
        }
    }
    
    IEnumerator waitToChange() {
        yield return new WaitForSeconds(0.25f);
        wait = true;
    }

    void ChangeWeapon(int delta) {
        gunsInInventory[activeWeapon].SetActive(false);
        
        if (activeWeapon == 0 && delta < 0)
            activeWeapon = gunsInInventory.Count-1;
        else if (activeWeapon == gunsInInventory.Count-1 && delta > 0)
            activeWeapon = 0;
        else
            activeWeapon += delta;

        gunsInInventory[activeWeapon].transform.position = hand.position;
        gunsInInventory[activeWeapon].SetActive(true);

        SoundManager.PlaySound("ShotgunLoad");
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("ItemGun")) {
            string path = "Prefabs/Guns/Gun" + other.gameObject.name.Substring(7);
            pickedGun = (GameObject) Resources.Load(path, typeof(GameObject));
            
            if (gunsInInventory.Count > 0)
                gunsInInventory[activeWeapon].SetActive(false);
            
            Instantiate(pickedGun, transform.position, Quaternion.identity);
            gunsInInventory.Add(GameObject.Find("Gun"+other.gameObject.name.Substring(7)+"(Clone)"));

            activeWeapon = gunsInInventory.Count - 1;
            
            Destroy(other.gameObject);

            SoundManager.PlaySound("LeatherInventory");
        }
    }
}
