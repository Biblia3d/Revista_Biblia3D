using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public float ZForce;
    public float YForce;

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
        if (story.GetComponent<Story_Manager>().atualTrack == "10")
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

    // A cada frame, garante que o objeto mantenha seu pai original.
    void Update()
    {
        transform.SetParent(this.transform.parent);
    }

    // Aplica a força inicial ao objeto, impulsionando-o nos eixos Y e Z.
    void ApplyForce()
    {
        rb.AddForce(new Vector3(0, YForce, ZForce));
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