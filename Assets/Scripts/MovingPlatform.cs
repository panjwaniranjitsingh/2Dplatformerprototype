using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]private Transform[] points;

    private int i;

    private void Start()
    {
        transform.position = points[i].position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.1f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        PlayerController playerController = col.gameObject.GetComponent<PlayerController>();
        if (playerController != null && CheckSideCollision(col))
        {
            col.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        PlayerController playerController = col.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            col.transform.SetParent(null);
        }
    }

    private bool CheckSideCollision(Collision2D col)
    {
        return transform.position.y < (col.transform.position.y - col.collider.bounds.size.y / 2);
    }
}