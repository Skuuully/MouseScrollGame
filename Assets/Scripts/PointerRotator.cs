using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerRotator : MonoBehaviour
{
    private GameObject hole;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    void Start() {
        hole = GameObject.FindGameObjectWithTag("Hole");
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update() {
        if (hole.GetComponent<Hole>().isVisible()) {
            spriteRenderer.enabled = false;

        } else {
            Vector2 playerPos = player.transform.position;
            Vector2 holePos = hole.transform.position;

            Vector2 direction = holePos - playerPos;
            Vector2 UpVector = new Vector2(0, 1);
            float angle = Vector2.SignedAngle(UpVector, direction);
            Quaternion target = Quaternion.Euler(0, 0, angle);
            transform.rotation = target;
            spriteRenderer.enabled = true;
        }
    }
}
