using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    public float distance;

    public Transform player;

    public NavMeshAgent NMA;

    void Start()
    {
        
    }


    void Update()
    {
        distance = Vector3.Distance(this.transform.position, player.position);

        if(distance < 10)
        {
            NMA.destination = player.position;
        }
    }
}
