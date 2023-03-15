using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Para acessar o Canvas
using UnityEngine.SceneManagement;  // Para ir para a tela de Game Over

public class playerController : MonoBehaviour
{
    private     Rigidbody2D     playerRb;
    private     Animator        playerAnimator;
    public      float           velocidadeMovimento;
    private     int             presentes;  // armazena o número de presentes coletados
    public      int             tempoFase;
    public      Text            presenteTxt, tempoTxt;    
    public      GameObject      particula;

    // Start is called before the first frame update
    void Start()
    {
        playerRb            = GetComponent<Rigidbody2D>();
        playerAnimator      = GetComponent<Animator>();

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
        // Debug.Log($"Horizontal: {horizontal}");
        // Debug.Log($"Vertical: {vertical}");

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
            StartCoroutine("GameOver");
    }

    // função já nativa da unity:
    // quando bater em um trigger, precisamos saber se é um presente:
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag == "presente")
        {
            presentes += 1;
            tempoFase += 5;
            presenteTxt.text = presentes.ToString();
            // quando o presente for pego, vamos jogar 'particula' na cena

            // objeto a ser instanciado, onde será instanciado, rotação tbm:
            Instantiate(particula, col.transform.position, col.transform.rotation);  // colocar um gameObject na cena
            Destroy(col.gameObject);  // destruir o objeto que foi colidido com o player
        }
    }

    // NÃO precisa de parâmetro, pois só tem como colisão os osbstáculos:
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player")
            StartCoroutine("GameOver");
    }

    /*
        OnCollisionEnter2D é usado para detectar colisões físicas entre objetos, enquanto 
        OnTriggerEnter2D é usado para detectar quando um objeto entra em uma determinada área.
    */

    // Esperar 1 segundo para então ir para a cena de Game Over:
    IEnumerator GameOver()
    {
        playerAnimator.SetBool("morte", true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("gameover");
    }
}
