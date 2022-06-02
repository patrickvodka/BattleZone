using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShootPlayer : MonoBehaviour
{
 public Transform Self;
 public GameObject Bullet;
 private Transform SpawnObj;
 private bool canShoot;
 private Vector3 BulletTrans;
 private AudioSource clipShoot;
 private GameObject BulletReserve;
 private void Awake()
 {
     clipShoot = GetComponent<AudioSource>();
     Self = GetComponent<Transform>();
     SpawnObj= gameObject.transform.Find("SpawnBullet");
     BulletReserve = GameObject.FindGameObjectWithTag("BulletReserve");
     BulletTrans = SpawnObj.position;
     canShoot = true;


 }
 public void OnShootPressed(InputAction.CallbackContext context)
 {
     if (context.performed) {
         if (canShoot == true)
         {
             canShoot = false;
             StartCoroutine(Shoot());
             clipShoot.Play();
         }
         else return;
     } 

 }

 IEnumerator Shoot()
    {
        BulletTrans = SpawnObj.position;
        Instantiate(Bullet, BulletTrans,Quaternion.Euler(0,0,0),null);
        yield return new WaitForSeconds(1);
        canShoot = true;
        
    }
}
