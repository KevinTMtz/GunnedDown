using UnityEngine;

public class LifeSpan : MonoBehaviour {
    public float lifeSpan;
    
    void Start() {
        Destroy(gameObject, lifeSpan);
    }
}
