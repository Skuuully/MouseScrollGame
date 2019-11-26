using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset;
    private Vector2 playerPosition;
    private Vector2 target;

    private void FixedUpdate() {
        playerPosition = player.transform.position;
        target = playerPosition + offset;
        Vector3 finalTarget = new Vector3(target.x, target.y, -10);
        transform.position = Vector3.Lerp(transform.position, finalTarget, 0.2f);
    }
}
