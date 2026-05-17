using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] private NavMeshAgent enemy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy.updateRotation = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
    }

    private void SetTarget() 
    {
        enemy.SetDestination(Player_Controller.instance.transform.position);
        Vector3 direction = (Player_Controller.instance.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
