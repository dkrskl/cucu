using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [HideInInspector]
    public float mySpeed;

    private void Start()
    {
        Destroy(gameObject, .75f);
    }
    void Update()
    {
        transform.Translate(Vector2.right * mySpeed * Time.deltaTime);
    }
}
