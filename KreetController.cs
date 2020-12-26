using UnityEngine;
using UnityEngine.AI;


public class KreetController : MonoBehaviour
{

    public int distanceForAttack = 8;
    public float rangeAttack = 2.0f;
    public int speed = 5;

    NavMeshAgent agent;
    GameObject target;

    //  Todo:
#pragma warning disable
    modeEntity mode;
#pragma warning enable

    public float AttackSpeed = 2f;
    public float damage = 100f;
    public float variationOfDamage = 0.05f; //  Percent variation damage

    private float timeAttack;    //  Remaining for the next atack

    enum modeEntity
    {
        wander = 0,
        attack = 1
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<characters.PlayerController>().gameObject;
        timeAttack = 0f;
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, agent.transform.position);

        if (distance < distanceForAttack)
        {
            mode = modeEntity.attack;
            Atack(distance);
        }
        else
        {
            mode = modeEntity.wander;
        }

    }

    //  A simple atack system example
    void Atack(float distance)
    {
        
        if (distance > rangeAttack) agent.SetDestination(target.transform.position);

        else
        {
            agent.SetDestination(gameObject.transform.position);
            
            //  Atack!
            if (timeAttack <= 0)
            {
                
                target.GetComponent<HealthSystem>().NewDamage(damage * (variationOfDamage + 1));

                timeAttack = AttackSpeed;
            }

            //  Wait!
            else timeAttack -= Time.deltaTime;
        }
    }
}
