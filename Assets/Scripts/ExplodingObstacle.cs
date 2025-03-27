using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingObstacle : Obstacle
{
    protected override void PlayerCollision()
    {
        base.PlayerCollision();
        Destroy(gameObject);
        Debug.Log("Exploding obstacle collided with player: " + name);
    }
}
