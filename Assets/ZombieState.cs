using UnityEngine;
using System.Collections;

enum Zstate
{
    idleing,
    wandering,
}
public class ZombieState : MonoBehaviour
{
    Zstate myState;
    float stateTimer;
    public float closestDistance;
    public float futherstDistance;
    public GameObject closestGameObject;
    public GameObject futherstGameObject;
	// Use this for initialization
	void Start () 
    {
        stateTimer = 0.1f;
        myState = Zstate.idleing;
        closestDistance = Mathf.Infinity;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    switch(myState)
        {
            case Zstate.idleing:
                goto Ideling;
            case Zstate.wandering:
                goto Wandering;
            default:
                break;
        }
    Ideling:
        stateTimer -= Time.deltaTime;
        if(stateTimer < 0.0f)
        {
            myState = Zstate.wandering;
            stateTimer = 3.0f;
            closestDistance = Mathf.Infinity;
            futherstDistance = 0f;
            LookAround();
        }
        return;
    Wandering:
        stateTimer -= Time.deltaTime;
        MoveAround();
        if(stateTimer < 0.0f)
        {
            myState = Zstate.idleing;
            stateTimer = 3.0f;
        }
        return;
	}

    virtual public void LookAround()
    {
        GameObject[] Zombies = GameObject.FindObjectsOfType<GameObject>();
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
                closestDistance = distanceToGo;
                closestGameObject = go;
            }
            if(distanceToGo > futherstDistance)
            {
                futherstDistance = distanceToGo;
                futherstGameObject = go;
            }
        }
    }

    void MoveAround()
    {
        Vector3 MoveAway =
            (transform.position - closestGameObject.transform.position).normalized;
        Vector3 MoveTo =
            (transform.position - futherstGameObject.transform.position).normalized;
        Vector3 directionToMove = MoveAway - MoveTo;
        transform.forward = directionToMove;

        gameObject.rigidbody.velocity = directionToMove * Random.Range(10, 30) * 0.1f;
        Debug.DrawRay(transform.position, directionToMove, Color.blue);
        Debug.DrawLine(transform.position, closestGameObject.transform.position, Color.red);
        Debug.DrawLine(transform.position, futherstGameObject.transform.position, Color.green);
    }
}
