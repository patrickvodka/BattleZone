using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShooting : MonoBehaviour
{
    private AudioSource AudioSource;
    private Transform player;
    private bool canShoot;
    public Transform SpawnObj;
    public GameObject Bullet;
    private Vector3 BulletTrans;
    private GameObject BulletReserve;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        BulletReserve = GameObject.FindGameObjectWithTag("BulletReserve");
        SpawnObj = gameObject.transform.Find("SpawnBullet");
        BulletTrans = SpawnObj.position;
        canShoot = true;
       
    }

     private void FixedUpdate()
    {
        
        if (canShoot == true)
        {

            canShoot = false;
            StartCoroutine(Shoot());

        }
        else return;

    }

    IEnumerator Shoot()
    {
        BulletTrans = SpawnObj.position;
        Instantiate(Bullet, BulletTrans,Quaternion.Euler(0,0,0),BulletReserve.transform);
        AudioSource.Play();
        yield return new WaitForSeconds(5);
        canShoot = true;
        
        
    }
}
