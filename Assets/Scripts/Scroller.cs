using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Scroller : MonoBehaviour
{
    public float moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if(this.transform.position.y + 5 < Camera.main.ScreenToWorldPoint(Vector2.right * (float)Screen.width).y)
        {
            this.transform.position = Vector2.up * 20;
        }
    }
}
