using UnityEngine;

[RequireComponent(typeof(DeathEvent))]
public class CucuLadderController : MonoBehaviour
{

    public float mySpeed;

    private bool canClimb = false;
    private bool imDown = true;
    private bool isDying = false;

    public Sprite ladderSprite;




    void Update()
    {
        if(!isDying)
        transform.Translate(Vector2.right * mySpeed * Time.deltaTime);

        if(canClimb)
            if(Input.GetMouseButtonDown(0))
            {

                PlayerStats.clicks++;
                FindObjectOfType<UITextManager>().UpdateClicks();

                if (imDown)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + ladderSprite.bounds.size.y * .75f + 0.11f); // 75f because ladders are scaled down by .5 and .75
                    imDown = false;


                }
                else
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - ladderSprite.bounds.size.y * .75f - 0.11f); // 75f because ladders are scaled down by .5 and .75
                    imDown = true;


                }

            }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("ladder"))
            if (!canClimb)
            {
                canClimb = true;
            }

        if(col.transform.CompareTag("canKill"))
        {
            isDying = true;
            GetComponent<DeathEvent>().StartCoroutine("Die");
        }

        if (col.transform.CompareTag("activator"))
        {
            col.transform.GetComponent<Activator>().ChangeScene(5);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("ladder"))
                canClimb = false;
    }

}
