using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformController : MonoBehaviour
{
    bool movingUp;
    Vector3 startingPos;

    public float moveSpeed;
    public float maxMoveDistance;

    // Start is called before the first frame update
    void Start()
    {
        movingUp = true;
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= startingPos.y + maxMoveDistance || transform.position.y <= startingPos.y - maxMoveDistance) {
            movingUp = !movingUp;
        }

        if (movingUp) {
            transform.position += new Vector3(0, moveSpeed, 0);
        }
        else {
            transform.position -= new Vector3(0, moveSpeed, 0);
        }
    }
}
