using UnityEngine;


[RequireComponent(typeof(DeathEvent))]

public class CucuTrapDoorController : MonoBehaviour
{

    public GameObject trapDoor;

    private int tileNumber = 1; // third tile is the trapped one 
    private bool isDying = false;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (tileNumber < 4 && !isDying) 
            {

                transform.Translate(Vector2.right * 2);
                tileNumber++;

                PlayerStats.clicks++;
                FindObjectOfType<UITextManager>().UpdateClicks();
            }

        }

        if (tileNumber == 3 && !isDying)
            if (trapDoor.GetComponent<TrapDoor>().isOpen)
            {
                isDying = true;
                GetComponent<DeathEvent>().StartCoroutine("Die");
            }


        if(tileNumber == 4 & !isDying)
            FindObjectOfType<Activator>().ChangeScene(6);
    }
}
