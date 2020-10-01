using UnityEngine;


[RequireComponent(typeof(DeathEvent))]
public class CucuJumpController : MonoBehaviour
{
    public GameObject chargeBarParent;
    public Transform myJumpCharge;

    public float mySpeed;

    float currentCharge = 0;
    bool isGrounded = false;


    private Vector3 tmplocalScale;
    private Rigidbody2D myRigidbody;

    private void Start()
    {
        tmplocalScale = myJumpCharge.localScale;
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        myRigidbody.velocity = new Vector2(mySpeed, myRigidbody.velocity.y);

        if (currentCharge <= 100 && Input.GetMouseButton(0) && isGrounded)
        {
            currentCharge += 100 * Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0) )
        {

            PlayerStats.clicks++;
            FindObjectOfType<UITextManager>().UpdateClicks();

            if (currentCharge >= 10 && isGrounded) 
            { 
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, currentCharge / 20); // adjust the values
            currentCharge = 0;
            isGrounded = false; }
        }

        tmplocalScale.x = currentCharge / 100; // 125 to get 0.8 scale, it just fits nice
        myJumpCharge.transform.localScale = tmplocalScale;


    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("ground"))
        {
            isGrounded = true;

        }

        if (col.transform.CompareTag("canKill"))
        {
            chargeBarParent.SetActive(false);
            GetComponent<DeathEvent>().StartCoroutine("Die");

        }

        if(col.transform.CompareTag("activator"))
        {
            col.transform.GetComponent<Activator>().ChangeScene(4);
        }

    }



}
