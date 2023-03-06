using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroyer : MonoBehaviour
{
    [SerializeField] private Boarder boarder;
    [SerializeField] private bool canDestroy = false;
    [SerializeField] private bool isDestorying = false;

    private void Update()
    {
        if (canDestroy && !isDestorying)
        {
            boarder.DestoryBoard(-1);
            isDestorying = true;

            StartCoroutine(Wait());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            canDestroy = true;
            boarder.BuildState(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            canDestroy = false;
            boarder.BuildState(true);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        isDestorying = false;
    }
}
