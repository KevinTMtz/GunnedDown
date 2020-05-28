using UnityEngine;

public class HydraShoot : MonoBehaviour {
    public GameObject bullet;
    public Transform[] firePoints;
    public GameObject target;
    public float fireForce;
    private float aimAngle;
    public GameObject[] b;
    public GameObject stickyBullet;
    public Transform shootPoint;

    private void Start() {
        fireForce = 15f;
        b = new GameObject[firePoints.Length];
        target = GameObject.Find("Player");
    }

    void rotateFirePoint() {
        for (int i = 0; i < firePoints.Length; i++) {
            Vector2 aim = firePoints[i].transform.position - new Vector3(
                target.transform.position.x + Random.Range(-2.5f,2.5f),
                target.transform.position.y + Random.Range(-2.5f, 2.5f), 0);
            aimAngle = Mathf.Atan2(-aim.x, aim.y) * Mathf.Rad2Deg;
            firePoints[i].transform.rotation = Quaternion.Euler(0, 0, aimAngle);
        }
    }

    public void ChargeBullet() {
        rotateFirePoint();
        for (int i = 0; i < firePoints.Length; i++) {
            b[i] = Instantiate(bullet, firePoints[i].position, firePoints[i].rotation);
        }
    }

    public void ShootBullet() {
        rotateFirePoint();
        for (int i = 0; i < firePoints.Length; i++) {
            b[i].transform.position = firePoints[i].transform.position;
            b[i].transform.rotation = firePoints[i].transform.rotation;
            b[i].GetComponent<CircleCollider2D>().enabled = true;
            Rigidbody2D bRB = b[i].GetComponent<Rigidbody2D>();
            bRB.AddForce(-firePoints[i].up * fireForce, ForceMode2D.Impulse);
            b[i] = null;
        }
        int times = 1;
        if (!GetComponent<HydraHealth>().scream1) times = 2;
        if (!GetComponent<HydraHealth>().scream2) times = 3;
        for (int t = 0; t < times; t++) {
            ChargeBullet();
            rotateFirePoint();
            for (int i = 0; i < firePoints.Length; i++) {
                b[i].transform.position = firePoints[i].transform.position;
                b[i].transform.rotation = firePoints[i].transform.rotation;
                b[i].GetComponent<CircleCollider2D>().enabled = true;
                Rigidbody2D bRB = b[i].GetComponent<Rigidbody2D>();
                bRB.AddForce(-firePoints[i].up * fireForce, ForceMode2D.Impulse);
                b[i] = null;
            }
        }
    }


    public void CircleCharge() {
        for (int i = 0; i < 360; i += 20) {
            shootPoint.transform.rotation = Quaternion.Euler(0, 0, i);
            GameObject bulletInstantiated = Instantiate(stickyBullet, shootPoint.position, shootPoint.rotation);
            Rigidbody2D bulletRB = bulletInstantiated.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(shootPoint.right * fireForce, ForceMode2D.Impulse);
        }
    }

    public int obstacleOffset;
    public int numberArms;
    public GameObject obstacle;
    public void CreateObstacles()  {
        if (gameObject.GetComponent<HydraHealth>().scream1) return;
        bool xObstacle = false;
        bool yObstacle = false;
        if (target.transform.position.x - gameObject.transform.position.x >= 0) xObstacle = true;
        if (target.transform.position.y - gameObject.transform.position.y >= 0) yObstacle = true;
        for(int i = obstacleOffset + 2; i <= obstacleOffset*numberArms + 2; i += obstacleOffset) {
            if (xObstacle)
                Instantiate(obstacle, transform.position + new Vector3(i, 0, 0), Quaternion.identity);
            else
                Instantiate(obstacle, transform.position + new Vector3(-i, 0, 0), Quaternion.identity);
            if (yObstacle)
                Instantiate(obstacle, transform.position + new Vector3(0, i, 0), Quaternion.identity);
            else
                Instantiate(obstacle, transform.position + new Vector3(0, -i, 0), Quaternion.identity);
        }

        if (!gameObject.GetComponent<HydraHealth>().scream2) {
            for (int i = 0; i < numberArms / 2; i++) {
                Instantiate(
                    obstacle,
                    target.transform.position + new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0),
                    Quaternion.identity
                );
            }
        }
        
    }
}
