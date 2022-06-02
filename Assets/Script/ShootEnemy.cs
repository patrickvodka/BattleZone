using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public GameObject Player;
    private Transform Target;
    [SerializeField] EnemyMoveTank enemyMoveTank;

    private void Awake()
    {
        enemyMoveTank = FindObjectOfType<EnemyMoveTank>();
        Player = GameObject.FindWithTag("Player");
        Target = Player.GetComponent<Transform>();
    }

    private void Update()
    {
        
    }
}
