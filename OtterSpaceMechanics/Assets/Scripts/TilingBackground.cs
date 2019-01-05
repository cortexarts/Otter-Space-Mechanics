using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingBackground : MonoBehaviour
{
    private Vector3 backPos;
    public float width = 0.0f;
    public float height = 0.0f;
    private float x, y;

    void OnBecameInvisible()
    {
        //calculate current position
        backPos = gameObject.transform.position;
        //calculate new position
        print(backPos);
        x = backPos.x + width * 2;
        y = backPos.y + height * 2;
        //move to new position when invisible
        gameObject.transform.position = new Vector3(x, y, 0f);
    }
}
