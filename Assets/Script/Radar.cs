using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private PlayerMovement playermovement;
    private Transform SweepTrans;
    public float rotationSpeed;
    private Transform PlayerTrans;
    private Transform RaycastTrans;
    private Vector3 MoveRaycast;

    private int RotationAngle;
    //<>

    private void Awake()
    {
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        RaycastTrans = GameObject.FindGameObjectWithTag("Respawn").transform;
        SweepTrans = transform.Find("Sweeper");
        MoveRaycast = new Vector3(0f, 0f, 0f);
        RotationAngle = 0;
        rotationSpeed = 46f;
    }

    void FixedUpdate()
    {
        var RotationXRaycast = Mathf.Sin(Mathf.Deg2Rad * RotationAngle) * 100;
        MoveRaycast = new Vector3(RotationXRaycast, 0f,
            (Mathf.Cos(Mathf.Deg2Rad * RotationAngle) * 100));
        Debug.DrawRay(RaycastTrans.position, (MoveRaycast), Color.red);
        RotationAngle =(RotationAngle+1)%360;
        SweepTrans.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        var MyVector = GetVectorFromAngle(5);

        //PlayerTrans2.RotateAround(PlayerTrans.position, Vector3.up, 10 * Time.deltaTime);


        /*RaycastHit raycastHit = Physics.Raycast(PlayerTrans.position, GetVectorFromAngle(SweepTrans.eulerAngles.z), radarDistance);
        if (raycastHit.collider != null)
        {
         print("Hit");   
        }*/
    }

    private static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}