using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class UpdatePath : MonoBehaviour
{
    // Modifications to A* Pathfinding AI to update when the AI collides with a wall instead of every frame.

    AILerp lerp;
    Path path;
    Seeker seeker;
    Transform target;
    AIDestinationSetter destination;


    private void Start()
    {
        lerp = GetComponent<AILerp>();
        seeker = GetComponent<Seeker>();
        destination = GetComponent<AIDestinationSetter>();
        target = destination.target;
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            lerp.repathRate = System.Convert.ToSingle("Infinity");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            seeker.StartPath(transform.position, target.position, OnPathComplete);
        }
    }
}
