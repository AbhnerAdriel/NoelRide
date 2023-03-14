using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Para acessar o Canvas
using UnityEngine.SceneManagement;  // Para ir para a tela de Game Over

public class playerController : MonoBehaviour
{
    private     Rigidbody2D     playerRb;
    public      float           velocidadeMovimento;
    private     int             presentes;  // armazena o número de presentes coletados
    public      int             tempoFase;
    public      Text            presenteTxt, tempoTxt;    
    public      GameObject      particula;

    // Start is called before the first frame update
    void Start()
    {
        playerRb    = GetComponent<Rigidbody2D>();

        // quando a fase começar, é chamada a função para fazer a contagem regressiva:
        StartCoroutine("ContagemRegressiva");  

        
    }

    // Update is called once per frame
    void Update()
    {
        // a cada frame, será testado todos os comandos aqui:

        // armazenar se o usuário está apertando a tecla a e d ou a seta esquerda e direita:
        // as respostas do pressionamento das teclas são: 
        // -1 (esquerda), 1 (direita) e 0 (nada) - horizontal
        float   horizontal  = Input.GetAxis("Horizontal"), 
                vertical    = Input.GetAxis("Vertical");
        // Debug.Log(horizontal);
        // Debug.Log(vertical);

        // movimento do player (x e y):
        playerRb.velocity = new Vector2(horizontal * velocidadeMovimento, 
                            vertical * velocidadeMovimento);

    }

    IEnumerator ContagemRegressiva() 
    {
        tempoTxt.text = tempoFase.ToString();
        yield return new WaitForSeconds(1);  // para e espere 1 segundo
        tempoFase -= 1;

        // se ainda tiver tempo disponível, essa função precisa ser 
        // chamada novamente até que o tempo acabe:
        if (tempoFase > 0)
            StartCoroutine("ContagemRegressiva");
        else
            SceneManager.LoadScene("titulo");
    }

    // função já nativa da unity:
    // quando bater em um trigger, precisamos saber se é um presente:
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag == "presente")
        {
            presentes += 1;
            presenteTxt.text = presentes.ToString();
            // quando o presente for pego, vamos jogar 'particula' na cena

            // objeto a ser instanciado, onde será instanciado, rotação tbm:
            Instantiate(particula, col.transform.position, col.transform.rotation);  // colocar um gameObject na cena
            Destroy(col.gameObject);  // destruir o objeto que foi colidido com o player
        }
    }
}
