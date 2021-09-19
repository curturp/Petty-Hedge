using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Made using the help of Brackeys Tutorials - https://www.youtube.com/user/Brackeys

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        instance = this;
    }

    public GameObject standardWallPrefab;

    private void Start()
    {
        wallToBuild = standardWallPrefab;
    }

    private GameObject wallToBuild;

    public GameObject GetWallToBuild()
    {
        return wallToBuild;
    }
}
