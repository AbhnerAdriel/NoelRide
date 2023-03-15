using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverObjetos : MonoBehaviour
{

    private     Rigidbody2D     objetoRb;
    public      float           velocidade;

    // Start is called before the first frame update
    void Start()
    {
        objetoRb                = GetComponent<Rigidbody2D>();
        objetoRb.velocity       = new Vector2(velocidade, 0);
    }

    // Update is called once per frame
    void Update()
    {
        objetoRb.velocity       = new Vector2(-velocidade, 0);
    }
}
