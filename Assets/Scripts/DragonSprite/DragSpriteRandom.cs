using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSpriteRandom : DragonBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        DragStats currentDrag = GetDragStats();

        Sprite[] hornsArray = new Sprite[5];

        hornsArray[0] = Resources.Load("horns1", typeof(Sprite)) as Sprite;
        hornsArray[1] = Resources.Load("horns2", typeof(Sprite)) as Sprite;
        hornsArray[2] = Resources.Load("horns3", typeof(Sprite)) as Sprite;
        hornsArray[3] = Resources.Load("horns4", typeof(Sprite)) as Sprite;
        hornsArray[4] = Resources.Load("horns5", typeof(Sprite)) as Sprite;

        int randomIndex = Random.Range(0, hornsArray.Length);

        Sprite sp = hornsArray[randomIndex];

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sp;

        switch (currentDrag.hornColor)
        {
            case (1):
                spriteRenderer.color = new Color(0.90588235294f, 0.78039215686f, 0.22745098039f, 1);
                break;
            case (2):
                spriteRenderer.color = new Color(0.81176470588f, 0.87843137254f, 0.86666666666f, 1);
                break;
            case (3):
                spriteRenderer.color = new Color(0.87843137254f, 0.85490196078f, 0.76862745098f, 1);
                break;
            case (4):
                spriteRenderer.color = new Color(0.5377358f, 0.3135765f, 0.1961552f, 1);
                break;
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}


