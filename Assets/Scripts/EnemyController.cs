using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Behavior
    [SerializeField]
    public int patrol;
    public float time;
    public Animator animator;
    public Quaternion angle;
    public float grade;
    public float radius = 8.0f;

    public GameObject target;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void enemyBehavior()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > radius)
        {
            //Debug.Log("Walking");

            animator.SetBool("IsRunning", false);
            time += 1 * Time.deltaTime;
            if (time >= 4)
            {
                patrol = Random.Range(0, 2);
                time = 0;
            }
            switch (patrol)
            {
                case 0:
                    animator.SetBool("IsWalking", false);
                    break;

                case 1:
                    grade = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grade, 0);
                    patrol++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5F);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    animator.SetBool("IsWalking", true);
                    break;
            }
        }
        else
        {
            //Debug.Log("Running");

            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            animator.SetBool("IsWalking", false);

            animator.SetBool("IsRunning", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
    }


    public void Update()
    {
        enemyBehavior();
    }
}
