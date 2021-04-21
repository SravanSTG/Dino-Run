using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private float leftBound = -12.0f;

    public float speed = 10.0f;

    void Update()
    {
        transform.Translate(new Vector3(-GameManager.Instance.gameSpeed * Time.deltaTime, 0, 0));

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

        if (GameManager.Instance.gameOver)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
