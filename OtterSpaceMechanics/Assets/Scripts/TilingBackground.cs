using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingBackground : MonoBehaviour
{
    public int offsetX = 2; // the offset so that we don't get any weird errors
    public int offsetY = 2; // the offset so that we don't get any weird errors

    // this are used for checking if we need to instantiate stuff
    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;

    public bool hasATopBuddy = false;
    public bool hasADownBuddy = false;

    private float spriteWidth = 0f;
    private float spriteHeight = 0f;
    private Camera cam;
    private Transform myTransform;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
        spriteHeight = sRenderer.sprite.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        // does it still need buddies?  If not, do nothing
        if (hasALeftBuddy == false || hasARightBuddy == false)
        {
            // calculate the cameras extend (half the width) of what the camera can see in world coordinates
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // calculate the x position where the camera can see the edge of the sprite (element)
            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

            // checking if we can see the edge of the element and then calling MakeNewBuddy if we can
            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false)
            {
                MakeNewBuddy(false, true, false, false);
                hasARightBuddy = true;
            }
            else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false)
            {
                MakeNewBuddy(true, false, false, false);
                hasALeftBuddy = true;
            }
        }

        if (hasATopBuddy == false || hasADownBuddy == false)
        {
            // calculate the cameras extend (half the width) of what the camera can see in world coordinates
            float camVerticalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // calculate the x position where the camera can see the edge of the sprite (element)
            float edgeVisiblePositionTop = (myTransform.position.y + spriteHeight / 2) - camVerticalExtend;
            float edgeVisiblePositionBottom = (myTransform.position.y - spriteHeight / 2) + camVerticalExtend;

            // checking if we can see the edge of the element and then calling MakeNewBuddy if we can
            if (cam.transform.position.y >= edgeVisiblePositionTop - offsetY && hasATopBuddy == false)
            {
                MakeNewBuddy(false, false, true, false);
                hasATopBuddy = true;
            }
            else if (cam.transform.position.y <= edgeVisiblePositionBottom + offsetY && hasADownBuddy == false)
            {
                MakeNewBuddy(false, false, false, true);
                hasADownBuddy = true;
            }
        }
    }

    // a function that creates a buddy on the side required
    void MakeNewBuddy(bool left, bool right, bool top, bool bottom)
    {
        if (left)
        {
            // calculating the new position for our new buddy
            Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * -1, myTransform.position.y, myTransform.position.z);

            // instantiating our new buddy and storing him in a variable
            Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

            newBuddy.GetComponent<TilingBackground>().hasARightBuddy = true;

            newBuddy.parent = myTransform.parent;
        }
        else if (right)
        {
            // calculating the new position for our new buddy
            Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * 1, myTransform.position.y, myTransform.position.z);

            // instantiating our new buddy and storing him in a variable
            Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

            newBuddy.GetComponent<TilingBackground>().hasALeftBuddy = true;

            newBuddy.parent = myTransform.parent;
        }
        else if (top)
        {
            // calculating the new position for our new buddy
            Vector3 newPosition = new Vector3(myTransform.position.x, myTransform.position.y + spriteHeight * 1, myTransform.position.z);

            // instantiating our new buddy and storing him in a variable
            Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

            newBuddy.GetComponent<TilingBackground>().hasADownBuddy = true;

            newBuddy.parent = myTransform.parent;
        }
        else if (bottom)
        {
            // calculating the new position for our new buddy
            Vector3 newPosition = new Vector3(myTransform.position.x, myTransform.position.y + spriteHeight * -1, myTransform.position.z);

            // instantiating our new buddy and storing him in a variable
            Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

            newBuddy.GetComponent<TilingBackground>().hasATopBuddy = true;

            newBuddy.parent = myTransform.parent;
        }
    }
}
