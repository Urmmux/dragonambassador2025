using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadColor : DragonBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        DragStats currentDrag = GetDragStats();

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        switch (currentDrag.skinColor)
        {
            case (1):
                spriteRenderer.color = new Color(1f, 0.8660802f, 0.7232704f, 1);
                break;
            case (2):
                spriteRenderer.color = new Color(1f, 0.9213123f, 0.81761f, 1);
                break;
            case (3):
                spriteRenderer.color = new Color(0.5754717f, 0.4366206f, 0.3510739f, 1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
