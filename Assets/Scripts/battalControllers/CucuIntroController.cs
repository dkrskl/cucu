/*
 * 
 * 
 * Level1 Senem
 * TAP = yürüme
 * 
 */

using UnityEngine;

public class CucuIntroController : MonoBehaviour
{



    // character speed
    public float mySpeed;


    // Can it move? (changed with activators)
    public bool canMove = true;


    private void Start()
    {

    }

    private void Update()
    {

        if (Input.GetMouseButton(0) && canMove)
         TapToMove();
        

    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.transform.CompareTag("activator"))
        {
            canMove = false;
            col.transform.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        else if(col.transform.CompareTag("Player"))
        {
            col.transform.GetComponent<CucuArrowController>().dying = true;

        }
    }


    private void TapToMove()
    {

        transform.Translate(Vector2.right * mySpeed * Time.deltaTime);

    }




}
