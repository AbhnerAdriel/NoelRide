using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjetos : MonoBehaviour
{

    public      GameObject[]        objetos;  // pode ter vários game objects
    public      float               intervaloSpawn;
    public      Transform           spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn() 
    {
        int idObjeto = Random.Range(0, objetos.Length);
        
        Instantiate(objetos[idObjeto], new Vector2(spawnPosition.position.x, 
                    objetos[idObjeto].transform.position.y), spawnPosition.rotation);

        yield return new WaitForSeconds(intervaloSpawn);
        StartCoroutine("Spawn");
    }

}
