using UnityEngine;

public class TurretHead : MonoBehaviour {
    private PlayerTurret playerTurret;
    
    void Start() {
        playerTurret = FindObjectOfType<PlayerTurret>();
    }

    public void CallShoot() {
        playerTurret.ShootEnemies();
    }
}
