using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private Boarder boarder;
    [SerializeField] private bool inBuildRange = false;
    [SerializeField] private bool isBuilding = false;

    private void Update()
    {
        if (boarder.GetBuildState())
        {
            if (inBuildRange)
            {
                if (Input.GetKeyDown(KeyCode.F) && !isBuilding)
                {
                    boarder.BuildBoard(1);
                    isBuilding = true;

                    StartCoroutine(Wait());
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            inBuildRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            inBuildRange = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        isBuilding = false;
    }
}
