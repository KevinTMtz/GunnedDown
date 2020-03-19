using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    public float lifeSpan;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
}
