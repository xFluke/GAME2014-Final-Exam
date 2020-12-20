using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Miko Man 101127881
// Controller script for the Shrinking platform that shrinks or grows in size when the player steps on them

public class ShrinkingPlatformController : MonoBehaviour
{
    // Floating variables
    Vector3 startingPos;
    bool movingUp;
    public float moveSpeed;
    public float maxMoveDistance;

    // Shrinking variables
    Vector3 startingLocalScale;
    public bool isActive;
    public float shrinkSpeed;
    [SerializeField]
    AudioSource shrinkingSound;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        isActive = false;
        movingUp = true;
        startingPos = transform.position;
        startingLocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update() {
        Float();

        if (isActive) {
            Shrink();
        }
        else {
            Grow();
        }
    }

    private void Grow() {
        // Grow to original size
        if (transform.localScale.x < startingLocalScale.x)
            transform.localScale += new Vector3(shrinkSpeed, 0, 0);
        else
            transform.localScale = startingLocalScale;
    }

    private void Shrink() {
        // Shrink until localScale.x reaches 0
        if (!shrinkingSound.isPlaying) {
            shrinkingSound.Play();
        }

        if (transform.localScale.x > 0) {
            transform.localScale -= new Vector3(shrinkSpeed, 0, 0);
        }
        else {
            transform.localScale = new Vector3(0, startingLocalScale.y, startingLocalScale.z);
        }
    }

    private void Float() {
        // Move up and down
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
