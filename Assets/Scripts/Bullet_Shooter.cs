using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // El prefab de la bala
    public Transform bulletOrigin;  // El punto de origen desde donde se dispararán las balas
    public float bulletSpeed = 20f; // La velocidad de la bala

    void Update()
    {
        // Disparar cuando se presiona el botón de disparo (por defecto "Fire1" es el clic izquierdo del ratón)
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Instanciar la bala en la posición del punto de origen
        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);

        // Ajustar la rotación de la bala para que apunte horizontalmente
        bullet.transform.rotation = Quaternion.Euler(110f, 0f, 0f);

        // Obtener el Rigidbody de la bala para aplicar la física
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Aplicar una fuerza a la bala en la dirección del punto de origen
        rb.velocity = bulletOrigin.forward * bulletSpeed;
    }
}
