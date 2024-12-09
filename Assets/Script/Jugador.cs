using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float speed = 5f; // Velocidad del jugador
    public Vector2 direction; // Dirección del movimiento
    public int numObjectsCollected = 0; // Contador de objetos recolectados

    private Rigidbody2D rigidbody;
    private Animator animator;

    private int currentArea = 1; // Indica en qué área está el jugador
    public GameTimer gameTimer; // Referencia al script del GameTimer

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
        Animations();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void Movement()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void MoveCharacter()
    {
        rigidbody.linearVelocity = direction * speed;
    }

    private void Animations()
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);

        if (direction.magnitude != 0)
        {
            animator.Play("Run");
        }
        else
        {
            animator.Play("Idle");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puerta"))
        {
            if (numObjectsCollected >= 4 && currentArea == 1)
            {
                TeleportToNextArea(new Vector3(49.4f, 0.2f, 0f));
                currentArea++;
                numObjectsCollected = 0; // Reinicia el contador
            }
            else if (numObjectsCollected >= 4 && currentArea == 2)
            {
                // Llamar al método Victory del GameTimer
                gameTimer.Victory();
            }
            else
            {
                Debug.Log("Necesitas reunir 4 objetos para pasar al siguiente mapa");
            }
        }
        else if (other.CompareTag("Objeto"))
        {
            CollectObject(other.gameObject);
        }
    }

    private void CollectObject(GameObject obj)
    {
        numObjectsCollected++;
        Destroy(obj);
    }

    private void TeleportToNextArea(Vector3 nextAreaPosition)
    {
        transform.position = nextAreaPosition; // Teletransporta al jugador
    }
}
