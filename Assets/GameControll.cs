using UnityEngine;
using System.Collections;

public class GameControll : MonoBehaviour {

    public int monsterNumbers;
    public GameObject playerObject;
    // Use this for initialization
    void Start()
    {
        CreativeMonsters(monsterNumbers);
        SearchPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreativeMonsters(int numbers)
    {
        for (int i = 0; i < numbers; i++)
        {
            GameObject sphere =
                GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.AddComponent<Monster>();
            Vector3 pos = new Vector3();
            pos.x = Random.Range(-10, 10);
            pos.z = Random.Range(-10, 10);
            sphere.transform.position = pos;
        }
    }

    void SearchPlayer()
    {
        Vector3 pos = new Vector3();
        pos.x = Random.Range(-10f, 10f);
        pos.z = Random.Range(-10f, 10f);
        transform.position = pos;
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject aGameObject in allGameObjects)
        {
            Component aComponent = aGameObject.GetComponent<Player>();
            if (aComponent != null)
            {
                playerObject = aGameObject;
            }
        }
    }
}
