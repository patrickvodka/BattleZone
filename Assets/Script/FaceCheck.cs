using System.Collections;
using UnityEngine;



public class FaceCheck : MonoBehaviour
{
    private Transform player;
    private Transform enemy;
    private Vector3 eulerAngle3d;
    private bool CanRota;
    private Vector3 Player3D;

    void Awake()
    {
        CanRota = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy= GameObject.FindGameObjectWithTag("EnemyTank").transform;
    }

    private void FixedUpdate()
    {
        if (CanRota == true)
        {
            CanRota = false;
            StartCoroutine(LookAtPlayer());
        }

        IEnumerator LookAtPlayer()
        {
            transform.LookAt(player);
           
            var Vector3Rota = transform.eulerAngles;
            // eulerAngle3d = Vector3Rota;
           enemy.eulerAngles = Vector3Rota ;
           yield return new WaitForSeconds(3);
            CanRota = true;
        }
    }
}
