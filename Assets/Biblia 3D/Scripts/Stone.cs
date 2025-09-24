using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public float ZForce;
    public float YForce;

    public float alturaMinima = 0.5f; // A altura do "chão invisível"
    private bool isSliding = false;   // Controla se a pedra já atingiu o chão

    private Rigidbody rb;
    private GameObject aim, davi, golias, story;

    // Função Start: inicializa as variáveis e posiciona o objeto de acordo com o contexto da narrativa.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aim = GameObject.FindWithTag("Mira");
        davi = GameObject.FindWithTag("Davi03");
        golias = GameObject.FindWithTag("Golias");
        story = GameObject.FindWithTag("Story_Manager");

        // Posiciona o objeto conforme o valor de "atualTrack" no Story_Manager
        
        if (story.GetComponent<Story_Manager>().atualTrack == "10"|| story.GetComponent<Story_Manager>().atualTrack == "Caneca")
        {
            transform.localPosition = new Vector3(
                aim.transform.localPosition.x,
                golias.transform.localPosition.y,
                davi.transform.localPosition.z);
        }
        else if (story.GetComponent<Story_Manager>().atualTrack == "04" ||
                 story.GetComponent<Story_Manager>().atualTrack == "VersoCarta")
        {
            transform.localPosition = new Vector3(
                aim.transform.localPosition.x,
                aim.transform.localPosition.y + 0.05f,
                davi.transform.localPosition.z);
        }

        // Agenda a destruição do objeto em 3 segundos
        Destroy(gameObject, 3f);

        // Aplica a força inicial ao objeto
        ApplyForce();
    }

    void Update()
    {
        // Só executa a verificação se a pedra ainda não estiver deslizando
        if (!isSliding && transform.position.y < alturaMinima)
        {
            // 1. Ativa o modo "deslize" para não entrar aqui de novo
            isSliding = true;

            // 2. Garante que a pedra fique exatamente na altura mínima
            transform.position = new Vector3(transform.position.x, alturaMinima, transform.position.z);

            // 3. Zera a velocidade vertical para parar a queda imediatamente
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

            // 4. Desliga a gravidade específica para este objeto
            rb.useGravity = false;

            // 5. Congela o movimento no eixo Y, mas libera X e Z
            // (Opcional, mas garante que nenhuma outra força moverá a pedra para cima ou para baixo)
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    // Aplica a força inicial ao objeto, impulsionando-o nos eixos Y e Z.
    void ApplyForce()
    {
        rb.AddRelativeForce(new Vector3(0, YForce, ZForce));
    }

    // Trata as colisões do objeto com os demais elementos da cena.
    void OnTriggerEnter(Collider colisor)
    {
        // Se colidir com objeto com tag "Golias"
        if (colisor.tag == "Golias")
        {
            rb.constraints = RigidbodyConstraints.None;
            Debug.Log("ColidiuGolias");
        }

        // Se colidir com objetos com nome "Urso" ou "Leão"
        if (colisor.name == "Urso" || colisor.name == "Leão")
        {
            Destroy(gameObject);
        }

        // Ao colidir com objeto com a tag "Barreira", o projétil ricocheteia e, a cada colisão,
        // reduz seus componentes de velocidade e altura.
        if (colisor.tag == "Barreira")
        {
            Vector3 currentVelocity = rb.velocity;
            rb.constraints = RigidbodyConstraints.None;

            // Fatores de amortecimento que reduzem a velocidade a cada colisão:
            // horizontalDamping é aplicado aos eixos X e Z (horizontalmente);
            // verticalDamping reduz o componente Y (altura) de forma mais acentuada.
            float horizontalDamping = 0.3f;
            float verticalDamping = 0.1f;

            // Gera um valor aleatório para a direção lateral (eixo X),
            // garantindo que o valor esteja fora do intervalo [-1, 1].
            float randomSide = Random.value < 0.5f
                ? Random.Range(-2f, -1f)
                : Random.Range(1f, 2f);

            // O novo vetor de velocidade é calculado multiplicando cada componente
            // pelos respectivos fatores de amortecimento. O eixo Z é invertido para simular o ricochete.
            Vector3 newVelocity = new Vector3(
                randomSide * Mathf.Abs(currentVelocity.z) * horizontalDamping, // Eixo X: direção lateral aleatória
                currentVelocity.y * verticalDamping,                             // Eixo Y: redução de altura
                -currentVelocity.z * horizontalDamping                             // Eixo Z: inversão e redução da velocidade
            );

            rb.velocity = newVelocity;
        }
    }
}