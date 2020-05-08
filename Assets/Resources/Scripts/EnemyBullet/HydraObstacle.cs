using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraObstacle : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AutoDestroy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().decreaseHealth(damage);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, -collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void PlaySound()
    {
        SoundManager.PlaySound("Obstacle");   
    }

}
