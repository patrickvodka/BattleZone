using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTank : MonoBehaviour
{
    private GameObject Player;
    private float Angle = 0;
    public GameObject Tank;
    public bool TankDied = false;
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }

    
    void Update()
    {
        if (TankDied == true)
        {
            Instantiate(Tank, gameObject.transform.position,Quaternion.Euler(0,0,0),null);
            TankDied = false;
        }
        transform.RotateAround(Player.transform.position,Vector3.zero, 20*Time.deltaTime);
    }
   /* IEnumerator Spawn()
    {
        
        Instantiate(Tank, gameObject.transform.position,Quaternion.Euler(0,0,0),null);
       TankDied = false;
       yield return new WaitForSeconds(1);
    }*/
}
