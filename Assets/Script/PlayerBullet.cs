using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private int speed = 10;
    private Rigidbody rb;
    private GameObject SpawnBullet;
    private int Rota = 0;
    private Transform trans;
    private Vector3 direction;
    private GameObject Player;
    public GameObject Spawner;
    public SpawnerTank spawnerTank;


    private void Awake()
    {
        trans = GetComponent<Transform>();
        SpawnBullet = GameObject.FindWithTag("SpawnBullet");
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        Spawner = GameObject.FindWithTag("Spawner");
        spawnerTank = Spawner.GetComponent<SpawnerTank>();


    }
    private void Start()
    {
        direction = (SpawnBullet.transform.position - Player.transform.position).normalized;
        rb.velocity = direction * speed;
         StartCoroutine(Bullet());
    }

    private void FixedUpdate()
    {
       // trans.Rotate(0,0,Rota);
       //Rota = (Rota+1)%360;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EnemyTank"))
        {
            ScoreManager.instance.TankPoints();
            Destroy(collision.transform.parent.gameObject);
            spawnerTank.TankDied = true;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyTankRange"))
        {
            ScoreManager.instance.RangedTankPoints();
            Destroy(collision.transform.parent.gameObject); 
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("EnemyTankMele"))
        {
            ScoreManager.instance.MeleeTankPoints();
            Destroy(collision.transform.parent.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject); 
        }
        if (collision.gameObject.CompareTag("Cube"))
        {
            Destroy(gameObject); 
        }
        else return;
        
    }

    private IEnumerator Bullet()
    {
       
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    
}
