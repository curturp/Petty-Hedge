using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Node : MonoBehaviour
{
    // Made using the help of Brackeys Tutorials - https://www.youtube.com/user/Brackeys

    private Color startColor;
    public Color hoverColor;
    public Color clickColor;
    SpriteRenderer rend;

    private GameObject wallObject;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
    }

    private void OnMouseDown()
    {
        if (GameManager.GameStart && !GameManager.GameIsPause && !GameManager.GameIsOver)
        {
            rend.color = clickColor;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (wallObject != null)
        {
            Debug.Log("Can't Grow Here! //TODO - - Display on Screen");
            return;
        }

        //Build a Wall 
        if (GameManager.GameStart && !GameManager.GameIsPause && !GameManager.GameIsOver)
        {
            rend.color = hoverColor;
            GameObject wallToBuild = BuildManager.instance.GetWallToBuild();
            wallObject = (GameObject)Instantiate(wallToBuild, transform.position, transform.rotation);
            Object.Destroy(gameObject);
        }        
    }

    private void OnMouseEnter()
    {
        if (GameManager.GameStart && !GameManager.GameIsPause && !GameManager.GameIsOver)
        {
            rend.color = hoverColor;
        }            
    }

    private void OnMouseExit()
    {
        rend.color = startColor;
    }
}
