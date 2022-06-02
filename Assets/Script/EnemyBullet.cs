using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    private int speed = 10;
    private Rigidbody rb;
    private GameObject SpawnBullet;
    private int Rota = 0;
    private Transform trans;
    private Vector3 direction;
    private GameObject Self;
    

    private void Awake()
    {
        trans = GetComponent<Transform>();
        SpawnBullet = GameObject.FindWithTag("BulletSpawnTank");
        Self = GameObject.FindWithTag("EnemyTank");
        rb = GetComponent<Rigidbody>();

    }
    private void Start()
    {
        direction = (SpawnBullet.transform.position - Self.transform.position).normalized;
        rb.velocity = direction * speed;
        Debug.Log(direction);
        StartCoroutine(Bullet()); 
    }
    private void FixedUpdate()
    {
        trans.Rotate(0,0,Rota);
        Rota = (Rota+1)%360;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");
            //ScoreManager.instance.LifeCount();
        }
        if (collision.gameObject.CompareTag("Cube"))
        {
           Destroy(gameObject);
            //ScoreManager.instance.LifeCount();
        }
        else return;
    }

    private IEnumerator Bullet()
    {
       
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
