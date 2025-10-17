using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireColor : DragonBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        DragStats currentDrag = GetDragStats();

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        switch (currentDrag.affinity)
        {
            case "fire":
                spriteRenderer.color = new Color(0.9150943f, 0.2379309f, 0.1784145f, 1);
                break;
            case "ice":
                spriteRenderer.color = new Color(0.5345911f, 0.9999998f, 1f, 1);
                break;
            case "nature":
                spriteRenderer.color = new Color(0.1721461f, 0.6320754f, 0.1590126f, 1);
                break;
            case "void":
                spriteRenderer.color = new Color(0.2088811f, 0.072505f, 0.490566f, 1);
                break;
            case "lightning":
                spriteRenderer.color = new Color(0.8390363f, 1f, 0f, 1);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}