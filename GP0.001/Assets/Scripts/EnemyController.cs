using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float speed;
    [SerializeField] float startWaitTime;

    float waitTime;
    int currentPointIndex;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        transform.position = patrolPoints[0].position;
        transform.rotation = patrolPoints[0].rotation;
        waitTime = startWaitTime;
    }

    void Update()
    {
        Patrolling();
    }

    void Patrolling()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                 patrolPoints[currentPointIndex].position,
                                                 speed * Time.deltaTime);

        if (transform.position == patrolPoints[currentPointIndex].position)
        {
            transform.rotation = patrolPoints[currentPointIndex].rotation;
            anim.SetBool("isPatrolling", false);

            if (waitTime <= 0)
            {
                if (currentPointIndex + 1 < patrolPoints.Length)
                {
                    currentPointIndex++;
                }
                else
                {
                    currentPointIndex = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            anim.SetBool("IsPatrolling", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

            SceneManager.LoadScene("Menu");


            //AudioSource.PlayClipAtPoint(_Sound, Camera.main.transform.position);

        }







    }

}
