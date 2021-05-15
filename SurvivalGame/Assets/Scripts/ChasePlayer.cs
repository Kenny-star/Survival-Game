using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent nav;

    public static bool playerTookDamage = false; 
    public static bool lost = false; 


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.transform.position);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            playerTookDamage = true;

        }
        
    }


}
