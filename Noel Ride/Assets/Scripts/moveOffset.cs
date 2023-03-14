using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour
{
    // modificadores de acesso utilizados em variáveis globais:
    // private -> acessado pelo próprio script (variável interna do script)
    // public -> pode ser acessada por outro script e tbm pelo inspector

    // declarando algumas propriedades, características:

    // tipo de acesso       tipo de variável        nome da variável
    private                 Material                materialAtual;
    public                  float                   velocidadeX, velocidadeY;
    private                 float                   escalaMovimento;


    // Start is called before the first frame update
    void Start()
    {
        // pegar o componente do inspector e o material
        materialAtual       = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // faz com que o cenário ande:
        // valor atualizado a cada update no frame (próximo frame):
        escalaMovimento = escalaMovimento + 0.01f;  // escalaMovimento += 0.01f

        // passar um valor para Offset:
        // new -> criar um novo
        materialAtual.SetTextureOffset("_MainTex", new Vector2(escalaMovimento * velocidadeX, 
        escalaMovimento * velocidadeY));
    }
}
