using UnityEngine;
using System.Collections;

public class HumanState : ZombieState 
{



    public override void LookAround()
    {    GameObject[] Zombies = GameObject.FindObjectsOfType<GameObject>();
            foreach(GameObject go in Zombies)
            {
                ZombieState z = go.GetComponent<ZombieState>();
                if(z == null || z == this)
                {
                    continue;
                }
                Vector3 v = go.transform.position - transform.position;
                float distanceToGo = v.magnitude;
                if(distanceToGo < closestDistance)
                {
                    if(z is ZombieState)
                    {
                        closestDistance = distanceToGo;
                        closestGameObject = go;
                    }
                }
                if(distanceToGo > futherstDistance)
                {
                    if(z is HumanState)
                    {
                        futherstDistance = distanceToGo;
                        futherstGameObject = go;
                    }
                }
            }
    }    
}
