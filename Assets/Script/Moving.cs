using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Transform positionA;
    [SerializeField] private Transform positionB;
    [SerializeField] private float speed = 2f;
    private Vector3 target;
    private Vector3 originalScale;
    private Transform player;
    void Start()
    {
        target = positionA.position;
        originalScale = GameObject.FindWithTag("Player").transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            if (target == positionA.position)
            {
                target = positionB.position;
            }
            else
            {
                target = positionA.position;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.transform.SetParent(transform, true);
            collision.transform.localScale = originalScale;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            collision.transform.SetParent(null);
        }
    }
}
