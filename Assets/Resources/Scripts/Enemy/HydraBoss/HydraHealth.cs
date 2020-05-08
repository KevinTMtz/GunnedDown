using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraHealth : MonoBehaviour
{
    public int health;
    public bool invulnerable;
    private int originalHealth;
    public bool scream1, scream2;
    // Start is called before the first frame update
    void Start()
    {
        originalHealth = health;
        scream1 = true;
        scream2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= originalHealth * 0.8 && scream1)
        {
            gameObject.GetComponent<Animator>().SetTrigger("scream");
            scream1 = false;
        }
        else
        {
            if (health <= originalHealth * 0.5 && scream2)
            {
                gameObject.GetComponent<Animator>().SetTrigger("scream");
                scream2 = false;
            }
            else
            {
                if (health <= 0) GetComponent<Animator>().SetTrigger("defeated");
            }
        }

    }
    public void TakeDamage(int damage)
    {
        if(!invulnerable) health = health - damage;
    }
}
