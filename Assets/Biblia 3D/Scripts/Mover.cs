using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{//NESTE SCRIPT O PERSONAGEM DEVE SE MOVER PARA FRENTE NO EIXO Z(AZUL), PARA TIRAR DÚVIDAS, CONTATE WWW.SCHULTZGAMES.COM
    private float ponteiroX, ponteiroY, novaPosicX;
    private int indicePosic;
    private bool podeMover, estaNoChao, pulouR;
    private Vector3 posicInicial;
    [Range(0.01f, 1)] public float TempoParaMover = 0.15f;
    [Range(1, 5)] public int QuantoMover = 1;
    [Range(1, 20)] public float forcaDoPulo = 5.0f;
    [Range(0, 20)] public float velocidadeJogador = 5.0f;
    public bool podePular = true;
    public LayerMask LayersNaoIgnoradas = -1;
    private Rigidbody corpoRigido;

    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>();
        corpoRigido.constraints = RigidbodyConstraints.FreezeRotation;
        posicInicial = transform.position;
        novaPosicX = posicInicial.x + indicePosic * QuantoMover;
        indicePosic = 0;
        pulouR = false;
        podeMover = true;
    }

    void Update()
    {
        //estaNoChao = Physics.Linecast(transform.position, transform.position - Vector3.up, LayersNaoIgnoradas);
       // if (podeMover)
        //{
            DetectarMovimento();
       // }
    }

    IEnumerator EsperarParaMover(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        podeMover = true;
    }
    IEnumerator EsperarParaPular(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        pulouR = false;
    }

    void DetectarMovimento()
    {
        podeMover = false;
        StartCoroutine(EsperarParaMover(TempoParaMover));

        ponteiroX = ponteiroY = 0;
        if (Input.GetMouseButton(0))
        {
            ponteiroX = Input.GetAxis("Mouse X");
            ponteiroY = Input.GetAxis("Mouse Y");
        }
        if (Input.touchCount > 0)
        {
            ponteiroX = Input.touches[0].deltaPosition.x;
            ponteiroY = Input.touches[0].deltaPosition.y;
        }
        //DETECTAR EIXO X
        if (ponteiroX > 0 && indicePosic < 1)
        {
            indicePosic++;
            novaPosicX = posicInicial.x + indicePosic * QuantoMover;
        }
        else if (ponteiroX < 0 && indicePosic > -1)
        {
            indicePosic--;
            novaPosicX = posicInicial.x + indicePosic * QuantoMover;
        }
        //DETECTAR EIXO Y
        if (ponteiroY > 0.1f && indicePosic>1)
        {
            if (ponteiroY > 0 && indicePosic < 1)
            {
                indicePosic++;
                novaPosicX =   indicePosic+posicInicial.y * QuantoMover;
            }
            else if (ponteiroY < 0 && indicePosic > -1)
            {
                indicePosic--;
                novaPosicX =   indicePosic+posicInicial.y * QuantoMover;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 proximaPosic = new Vector3(novaPosicX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, proximaPosic, Time.deltaTime * 1);
        corpoRigido.velocity = new Vector3(corpoRigido.velocity.x, corpoRigido.velocity.y, velocidadeJogador);
    }

    void Pular()
    {
        if (estaNoChao == true && pulouR == false)
        {
            corpoRigido.AddForce(Vector3.up * forcaDoPulo, ForceMode.Impulse);
            pulouR = true;
            StartCoroutine(EsperarParaPular(0.5f));
        }
    }
}