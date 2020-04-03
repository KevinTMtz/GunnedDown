using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Bullet
    private Transform shootPoint;
    private GameObject bullet;
    private float bulletForce = 25f;
    private string path;

    public float shootWaitTime;
    private bool wait;
    private float startTime;
    private float endTime;

    private bool heldOn;
    
    // Start is called before the first frame update
    void Start()
    {
        SelectBullet();

        // Get shootpoint transform and load bullet prefab
        shootPoint = GameObject.Find("ShootPoint").transform;
        bullet = (GameObject) Resources.Load(path, typeof(GameObject));

        wait = true;
    }

    public void RestartValues() {
        heldOn = false;
        wait = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            heldOn = true;

        if (Input.GetButtonUp("Fire1"))
            heldOn = false;

        if (Time.time > endTime && wait == false)
            wait = true;

        if ((Input.GetButtonDown("Fire1") || heldOn) && wait && Time.timeScale != 0) {
            ShootBullet();
            startTime = Time.time;
            endTime = startTime + shootWaitTime;
            wait = false;
        }
    }

    // Choose bullet depending on gun
    string SelectBullet() {
        path = "Prefabs/Bullets/Bullet" + gameObject.name.Substring(3,1);
        return path;
    }

    // Instantiate bullet
    void ShootBullet() {
        GameObject bulletInstantiated = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D bulletRB = bulletInstantiated.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);

        SoundManager.PlaySound("Shoot2");
    }

    public string bulletPath {
        get { return SelectBullet(); }
    }
}
