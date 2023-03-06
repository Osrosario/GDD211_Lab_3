using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Boarder boarder;
    [SerializeField] private Transform plyrTransform;
    [SerializeField] private Transform waitTransform;
    [SerializeField] private GameObject objectToSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(objectToSpawn, gameObject.transform);
        }
    }

    public Boarder GetBoarder()
    {
        return boarder;
    }

    public Transform GetPlyrTransform()
    {
        return plyrTransform;
    }

    public Transform GetWaitTransform()
    {
        return waitTransform;
    }
}
