using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVScrolling : MonoBehaviour
{
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
    public string textureName = "_MainTex";

    Vector2 uvOffset = Vector2.zero;

    void LateUpdate()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);

        if (GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}
