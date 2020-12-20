using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformController : MonoBehaviour
{
    bool movingUp;
    Vector3 startingPos;
    Vector3 startingLocalScale;

    public float moveSpeed;
    public float maxMoveDistance;

    public bool isActive = false;
    public float shrinkSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movingUp = true;
        startingPos = transform.position;
        startingLocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update() {
        Float();

        if (isActive) {
            if (transform.localScale.x > 0) {
                transform.localScale -= new Vector3(shrinkSpeed, 0, 0);
            }
            else {
                transform.localScale = new Vector3(0, startingLocalScale.y, startingLocalScale.z);
            }
        }
        else {
            if (transform.localScale.x < startingLocalScale.x)
                transform.localScale += new Vector3(shrinkSpeed, 0, 0);
            else
                transform.localScale = startingLocalScale;

        }


    }

    private void Float() {
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
