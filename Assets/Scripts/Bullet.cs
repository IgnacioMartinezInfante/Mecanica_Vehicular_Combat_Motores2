using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab; // El prefab de la explosión

    void OnCollisionEnter(Collision collision)
    {
        // Instanciar la explosión en la posición de la bala
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Activar el sistema de partículas de explosión
        ParticleSystem particleSystem = explosion.GetComponent<ParticleSystem>();
         particleSystem.Play();
        

        // Destruir la bala
        Destroy(gameObject);


        // Destruir la explosión después de que termine
        Destroy(explosion, particleSystem.main.duration);
    }
}
