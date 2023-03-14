using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // adicionar isso para controlar as cenas
public class buttons : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IrParaCena(string nomeDaCena) 
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
