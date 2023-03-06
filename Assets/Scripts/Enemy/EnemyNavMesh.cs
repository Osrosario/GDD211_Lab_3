using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    private Spawner spawner;
    private Boarder boarder;
    private Transform plyrTransform;
    private Transform waitTransform;
    private NavMeshAgent navMeshAgent;

    private Transform targetTransfrom;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        spawner = GetComponentInParent<Spawner>();

        boarder = spawner.GetBoarder();
        plyrTransform = spawner.GetPlyrTransform();
        waitTransform = spawner.GetWaitTransform();

        targetTransfrom = waitTransform;
    }

    private void Update()
    {
        if (boarder.GetWindowStatus())
        {
            targetTransfrom = plyrTransform;
        }

        navMeshAgent.destination = targetTransfrom.position;
    }
}
