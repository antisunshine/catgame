using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private float xMin, xMax;
    private float yMin, yMax;

    private void Start()
    {
        var spriteSize = GetComponent<SpriteRenderer>().bounds.size.x * .5f; // Working with a simple box here, adapt to you necessity

        var cam = Camera.main;// Camera component to get their size, if this change in runtime make sure to update values
        var camHeight = cam.orthographicSize;
        var camWidth = cam.orthographicSize * cam.aspect;

        yMin = -camHeight + (spriteSize); // lower bound
        yMax = camHeight - spriteSize; // upper bound

        xMin = -camWidth + (spriteSize); // left bound
        xMax = camWidth - (spriteSize); // right bound 
    }

    private void Update()
    {
        // Get buttons
        var ver = Input.GetAxis("Vertical");
        var hor = Input.GetAxis("Horizontal");

        // Calculate movement direction
        var direction = new Vector2(hor, ver).normalized;
        direction *= moveSpeed * Time.deltaTime; // apply speed

        var xValidPosition = Mathf.Clamp(transform.position.x + direction.x, xMin, xMax);
        var yValidPosition = Mathf.Clamp(transform.position.y + direction.y, yMin, yMax);

        transform.position = new Vector3(xValidPosition, yValidPosition, 0f);
    }
}