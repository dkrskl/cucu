using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DeathEvent))]
public class EnemyMove : MonoBehaviour
{

   // private Rigidbody2D myRigidbody;

    public float mySpeed;

    private bool dying = false;


    void Update()
    {
        if(!dying)
        transform.Translate(Vector2.left * mySpeed *  Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("arrow") && !dying)
        {
            GetComponent<DeathEvent>().StartCoroutine("Die");
            dying = true;
        }
    }

}

