using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GunsInventory : MonoBehaviour
{
    List<GameObject> gunsInInventory = new List<GameObject>();
    private GameObject pickedGun;
    private int activeWeapon = 0;
    private bool wait = true;

    private Transform hand;

    // For the interface
    private Image gunImage;
    
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("Hand").GetComponent<Transform>();

        gunImage = GameObject.Find("GunImage").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaScroll = Input.GetAxisRaw("Mouse ScrollWheel");
        
        //Debug.Log(deltaScroll);
        if(deltaScroll != 0 && wait && gunsInInventory.Count > 1){
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
        wait = false;
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
        gunsInInventory[activeWeapon].GetComponent<Shoot>().RestartValues();
        gunsInInventory[activeWeapon].SetActive(true);

        ChangeSpriteInInterface();

        SoundManager.PlaySound("ShotgunLoad");
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("ItemGun")) {
            string path = "Prefabs/Guns/Gun" + Regex.Replace(other.gameObject.name, "[^.0-9]", "");
            pickedGun = (GameObject) Resources.Load(path, typeof(GameObject));
            
            if (gunsInInventory.Count > 0)
                gunsInInventory[activeWeapon].SetActive(false);
            
            gunsInInventory.Add(Instantiate(pickedGun, transform.position, Quaternion.identity));

            activeWeapon = gunsInInventory.Count - 1;

            ChangeSpriteInInterface();
            
            Destroy(other.gameObject);

            SoundManager.PlaySound("LeatherInventory");
        }
    }

    private void ChangeSpriteInInterface() {
        gunImage.sprite = gunsInInventory[activeWeapon].transform.Find("Gun").GetComponent<SpriteRenderer>().sprite;
        gunImage.color = new Color(gunImage.color.r, gunImage.color.g, gunImage.color.b, 1f);
    }
}
