/*
 * 
 * 
 * Level2 bizans okla vur
 * TAP = yürüme
 * 
 */

using System.Collections;
using UnityEngine;


[RequireComponent(typeof(DeathEvent))]
public class CucuArrowController : MonoBehaviour
{

    public float mySpeed;

    [Header("Arrow Settings")]
    public Transform arrowPoint;
    public GameObject arrowPrefab;
    public float arrowSpeed;
    public Transform arrowCharge;

    private float currentCharge = 100;
    private Vector3 tmplocalScale;

    public bool dying = false;


    private void Start()
    {
        tmplocalScale = arrowCharge.localScale;
    }


    void Update()
    {
        // can I fire?
        // timedeltatime <<<<<<<<<<<<<<<<<<< WIP
        if(currentCharge <= 100 && !dying)
        currentCharge++;

        // update arrow charge visuals
        tmplocalScale.x = currentCharge/100; // 125 to get 0.8 scale, it just fits nice
        arrowCharge.transform.localScale = tmplocalScale;


        // Move to right
        if(!dying)
        transform.Translate(Vector2.right * mySpeed * Time.deltaTime);

        // fire if you can
        if (Input.GetMouseButtonDown(0))
        {

            PlayerStats.clicks++;
            FindObjectOfType<UITextManager>().UpdateClicks();

            if (currentCharge >= 100 && !dying)
            {
                GameObject arrow = Instantiate(arrowPrefab, arrowPoint.position, transform.rotation);
                arrow.GetComponent<ArrowMovement>().mySpeed = arrowSpeed;
                currentCharge = 0;
            }
        }
     }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("canKill")) // so this object can kill the player, duh
        {
            dying = true;
            currentCharge = 0;
            GetComponent<DeathEvent>().StartCoroutine("Die");
            
        }

        if (col.transform.CompareTag("activator"))
            col.transform.GetComponent<Activator>().ChangeScene(3);
    }



}
