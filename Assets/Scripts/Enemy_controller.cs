using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{
    public int maxHealth = 30; // Vida máxima del enemigo
    private int currentHealth; // Vida actual del enemigo
    public int damage = 10; // Daño que inflige el enemigo al jugador

    void Start()
    {
        currentHealth = maxHealth; // Inicializamos la vida actual con el valor máximo
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Restamos el daño recibido a la vida actua

        if (currentHealth <= 0)
        {
            Die(); // Llamamos a la función Die si la vida del enemigo es igual o menor a cero
            Contador_Enemigos contador = FindObjectOfType<Contador_Enemigos>();
            if (contador != null)
            {
                contador.IncrementEnemyKillCount();
            }
        }
    }

    void Die()
    {
        // Aquí puedes agregar cualquier lógica adicional al morir el enemigo
        Destroy(gameObject); // Destruimos el objeto del enemigo al morir
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_health playerHealth = collision.gameObject.GetComponent<Player_health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
