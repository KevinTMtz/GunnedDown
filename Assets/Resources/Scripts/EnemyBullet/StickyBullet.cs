using UnityEngine;

public class StickyBullet : MonoBehaviour {
    public float delay;
    public float range;
    public int damage;
    public bool hit;

    void Start() {
        delay += Random.Range(-range, range);
    }

    void Update() {
        if (!hit && delay <= 0) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.GetComponent<Animator>().SetTrigger("hit");
            hit = true;
            damage = 2;
            PlaySound();
        }
        else delay -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!hit && collision.CompareTag("Player")) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.GetComponent<Animator>().SetTrigger("hit");
            hit = true;
            collision.gameObject.GetComponent<PlayerHealth>().decreaseHealth(damage);
            damage = 2;
            PlaySound();
        }

    }

    float SavedTime = 0;
    float DelayTime = 0.25f;
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && (Time.time - SavedTime) > DelayTime) {
            SavedTime = Time.time;
            collision.gameObject.GetComponent<PlayerHealth>().decreaseHealth(damage);
        }
    }

    public void AutoDestroy() {
        Destroy(gameObject);
    }

    public void PlaySound() {
        SoundManager.PlaySound("StickyBullet");
    }
}
