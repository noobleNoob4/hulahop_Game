using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocksScript : MonoBehaviour
{
    
    public  GameObject blockers;
   
    [SerializeField] private objectPoolBall objectPool = null;
  

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && TrueBall.score >= 100)
        {
            SpawnBlockers();



            Destroy(gameObject);
        }




    }

    public void SpawnBlockers()
    {
        bool blockerSpawned = false;
        while (!blockerSpawned)
        {
            Vector3 blockposition = new Vector3(Random.Range(-3.50f, 2.61f),Random.Range(10.5f, -2.50f), 0.2f);
         
            if ((blockposition - transform.position).magnitude < 3)
            {

                continue;
 
            }
            else
            {

                
                  
                Instantiate(blockers, blockposition, Quaternion.identity);
                blockerSpawned = true;
            }
        }

    }

    






}
