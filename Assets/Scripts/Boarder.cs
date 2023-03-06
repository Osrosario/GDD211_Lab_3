using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boarder : MonoBehaviour
{
    [SerializeField] private Builder builder;
    [SerializeField] private Destroyer destroyer;
    [SerializeField] private OffMeshLink navMeshLink;
    [SerializeField] private List<GameObject> boardList = new List<GameObject>();
    [SerializeField] private List<bool> boolList = new List<bool> { true, true, true, true };

    private bool isDestroyed = false;
    private bool canPlyrBuild = true;
    private int index = 3;

    private void Update()
    {
        boardList[0].SetActive(boolList[0]);
        boardList[1].SetActive(boolList[1]);
        boardList[2].SetActive(boolList[2]);
        boardList[3].SetActive(boolList[3]);

        if (isDestroyed)
        {
            navMeshLink.activated = true;
        }
        else
        {
            navMeshLink.activated = false;
        }
    }

    public void BuildState(bool value)
    {
        canPlyrBuild = value;
    }

    public bool GetBuildState()
    {
        return canPlyrBuild;
    }

    public void DestoryBoard(int value)
    {
        boolList[index] = false;
        index += value;

        if (index < 0)
        {
            index = 0;
        }

        if (!boolList.Contains(true))
        {
            isDestroyed = true;
        }
    }

    public void BuildBoard(int value)
    {
        boolList[index] = true;
        index += value;

        if (index > boardList.Count - 1)
        {
            index = boardList.Count - 1;
        }

        if (boolList.Contains(true))
        {
            isDestroyed = false;
        }
    }

    public bool GetWindowStatus()
    {
        return isDestroyed;
    }
}
