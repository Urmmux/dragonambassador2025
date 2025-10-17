using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeColor : DragonBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        DragStats currentDrag = GetDragStats();

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        switch (currentDrag.eyeColor)
        {
            case (1):
                spriteRenderer.color = new Color(1f, 0f, 0f, 1);
                break;
            case (2):
                spriteRenderer.color = new Color(0.1237354f, 0.7169812f, 0.08567693f, 1);
                break;
            case (3):
                spriteRenderer.color = new Color(0.5754717f, 0.4366206f, 0.3510739f, 1);
                break;
            case (4):
                spriteRenderer.color = new Color(0.2044024f, 0.3537807f, 1f, 1);
                break;
            case (5):
                spriteRenderer.color = new Color(0.90588235294f, 0.78039215686f, 0.22745098039f, 1);
                break;
            case (6):
                spriteRenderer.color = new Color(0.3490566f, 0.0841817f, 0.00878127f, 1);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
