using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform plyrTransform;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        plyrTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        navMeshAgent.destination = plyrTransform.position;
    }
}
