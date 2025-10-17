using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridinitialize : MonoBehaviour
{
    public List<GameObject> lairList;
    // Start is called before the first frame update
    private void Start()
    {
        Grida grida = new Grida(140, 100, 1, gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
