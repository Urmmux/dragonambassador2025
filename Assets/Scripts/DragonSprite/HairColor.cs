using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairColor : DragonBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        DragStats currentDrag = GetDragStats();

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        switch (currentDrag.hairColor)
        {
            case 1:
                spriteRenderer.color = new Color(0.254717f, 0.1890352f, 0.2223766f, 1);
                break;
            case 2:
                spriteRenderer.color = new Color(0.2641509f, 0.1512996f, 0.0265812f, 1);
                break;
            case 3:
                spriteRenderer.color = new Color(0.3867925f, 0.06012519f, 0.05351841f, 1);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
