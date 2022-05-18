using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkRandomly : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    public Animator animator;
    public List<GameObject> destination = new List<GameObject>();
    [SerializeField] private int listSize;
    [SerializeField] private float MinTimeToWait = 1.0f;
    [SerializeField] private float maxTimeToWait = 2.5f;
    private int checker = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
        if (agent.remainingDistance <= agent.stoppingDistance + 1)
        {
            if (checker == 0)
            {
                StartCoroutine(Wait());
            }
        }

    }

    IEnumerator Wait()
    {
        checker = 1;
        yield return new WaitForSeconds(Random.Range(MinTimeToWait, maxTimeToWait));
        agent.SetDestination(destination[Random.Range(0, listSize)].transform.position);
        checker = 0;
    }
}
