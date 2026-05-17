using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] protected Transform Player;
    [SerializeField] protected GameObject Boulder;
    [SerializeField] protected int boulder_zone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Boulder.transform.position.z <= boulder_zone - 19) 
        {
            Boulder.SetActive(false);
        }

        if (Player.position.z >= boulder_zone)
        {
           Boulder.SetActive(true);
        }
    }

}
