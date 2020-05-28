using System.Collections;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
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

    private GameObject muzzle1;

    // For Ammunition
    private int remainingBulletsInCartridge;
    public int cartridgeSize;
    private int remainingBulletsTotal;
    public int ammobagSize;
    public float reloadTime;
    private bool reloading;

    private Text cartridgeTxt;
    private Text ammoBagTxt;

    private GameObject reloadIndicator;
    
    void Start() {
        cartridgeTxt = GameObject.Find("CartridgeTxt").GetComponent<Text>();
        ammoBagTxt = GameObject.Find("AmmoBagTxt").GetComponent<Text>();
        reloadIndicator = GameObject.Find("Player").transform.Find("ReloadIndicator").gameObject;
        
        SelectBullet();

        // Get shootpoint transform and load bullet prefab
        shootPoint = GameObject.Find("ShootPoint").transform;
        bullet = Resources.Load<GameObject>(path);
        muzzle1 = Resources.Load<GameObject>("Prefabs/Effects/ShotEffect1");

        wait = true;

        remainingBulletsInCartridge = cartridgeSize;
        remainingBulletsTotal = ammobagSize;
        UpdateGUI();
    }

    public void RestartValues() {
        heldOn = false;
        wait = true;
    }

    void Update() {
        if (Input.GetButtonDown("Fire1"))
            heldOn = true;

        if (Input.GetButtonUp("Fire1"))
            heldOn = false;

        if (Time.time > endTime && wait == false)
            wait = true;

        if ((Input.GetButtonDown("Fire1") || heldOn) && wait && Time.timeScale!=0 && remainingBulletsInCartridge>0 && !reloading) {
            ShootBullet();
            startTime = Time.time;
            endTime = startTime + shootWaitTime;
            wait = false;
        }

        if ((Input.GetKeyDown(KeyCode.R) || (remainingBulletsInCartridge == 0 && Input.GetButtonDown("Fire1"))) &&
            !reloading &&
            remainingBulletsInCartridge < cartridgeSize &&
            remainingBulletsTotal > 0) {
            StartCoroutine(ReloadTime());
        }
    }

    public void UpdateGUI() {
        cartridgeTxt.text = $"{remainingBulletsInCartridge}/{cartridgeSize}";
        ammoBagTxt.text = $"{remainingBulletsTotal}/{ammobagSize}";
    }

    private IEnumerator ReloadTime() {
        reloading = true;
        reloadIndicator.SetActive(true);
        SoundManager.PlaySound("Reload1");
        yield return new WaitForSeconds(reloadTime);
        ReloadCartridge();
        UpdateGUI();
        reloading = false;
        reloadIndicator.SetActive(false);
    }

    private void ReloadCartridge() {
        if (remainingBulletsTotal > 0 && remainingBulletsInCartridge < cartridgeSize)
            if (cartridgeSize - remainingBulletsInCartridge > remainingBulletsTotal) {
                remainingBulletsInCartridge += remainingBulletsTotal;
                remainingBulletsTotal = 0;
            } else if (remainingBulletsInCartridge > 0) {
                remainingBulletsTotal -= cartridgeSize - remainingBulletsInCartridge;
                remainingBulletsInCartridge = cartridgeSize;
            } else {
                remainingBulletsInCartridge = cartridgeSize;
                remainingBulletsTotal -= cartridgeSize;
            }
    }

    public void FillAmmo() {
        SoundManager.PlaySound("Reload1");
        remainingBulletsInCartridge = cartridgeSize;
        remainingBulletsTotal = ammobagSize;
        UpdateGUI();
    }

    // Choose bullet depending on gun
    string SelectBullet() {
        path = "Prefabs/Bullets/Bullet" + Regex.Replace(gameObject.name, "[^.0-9]", "");
        return path;
    }

    // Instantiate bullet
    void ShootBullet() {
        GameObject bulletInstantiated = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        GameObject muzzle = Instantiate(muzzle1, shootPoint.position, shootPoint.rotation);
        muzzle.transform.SetParent(shootPoint);

        Rigidbody2D bulletRB = bulletInstantiated.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);

        remainingBulletsInCartridge--;
        UpdateGUI();

        SoundManager.PlaySound("Shoot2");
    }

    public string bulletPath {
        get { return SelectBullet(); }
    }

    public bool Reloading {
        set { 
            reloading = value;
            reloadIndicator.SetActive(value);
        }
    }

    public bool AbleToRefill {
        get {
            if (remainingBulletsTotal < ammobagSize || remainingBulletsInCartridge < cartridgeSize)
                return true;
            else
                return false;
        }
    }
}
