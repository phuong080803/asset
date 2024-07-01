using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform throwPoint;
    public float throwForce = 20f;




    public void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody2D rb = grenadePrefab.GetComponent<Rigidbody2D>();
        rb.AddForce(throwPoint.forward * throwForce, (ForceMode2D)ForceMode.VelocityChange);
    }
}
