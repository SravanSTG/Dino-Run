using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private Material material;
    private Vector2 offset;

    public float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gameOver)
        {
            offset = new Vector2(GameManager.Instance.scrollSpeed, 0);
            material.mainTextureOffset += offset * Time.deltaTime;
        }
    }
}
