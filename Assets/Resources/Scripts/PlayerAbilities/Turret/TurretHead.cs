using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHead : MonoBehaviour
{
    private PlayerTurret playerTurret;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTurret = FindObjectOfType<PlayerTurret>();
    }

    public void CallShoot() {
        playerTurret.ShootEnemies();
    }
}
