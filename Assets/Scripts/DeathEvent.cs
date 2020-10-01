using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathEvent : MonoBehaviour
{

    SpriteRenderer myRenderer;
    Collider2D myCollider;

    [HideInInspector]
    public bool done;

    void Start()
    {

        myRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();

    }
    public IEnumerator Die()
    {
        // there are some Cucus with no colliders at all
        if(myCollider != null)
        myCollider.enabled = false;

        Color clr = myRenderer.material.color;
        Vector3 rot = transform.rotation.eulerAngles;

        while (clr.a > 0)
        {

            // change alpha during death
            clr.a -= 1.5f * Time.deltaTime;
            myRenderer.material.color = clr;


            // rotate "animation" during death
            rot.z -= 20 * Time.deltaTime;
            transform.Rotate(rot);

            yield return null;
        }

        StartCoroutine("RestartLevel");
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(.8f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // 2 for level2, might be changed later?
    }

}
