using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
    public float NextTime = 0f;
    public float Timer = 0.5f;
    public int Counter = 10;
    public int minHeight = 1;
    public int maxHeight = 10;
    public float HorizontalSpacing = 2f;
    public float VerticalSpacing = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
             if (Counter > 0 && Time.fixedTime > NextTime)
            {
                NextTime = Time.fixedTime + Timer;
                for (int j = 10; j > 0; j--)
                {

                    int randomNumber = Random.Range(minHeight, maxHeight);
                    for (int i = 0; i < randomNumber; i++)
                    {
                        CustomBox cbox = new CustomBox();
                        cbox.box.transform.position = new Vector3(Counter * HorizontalSpacing, i * VerticalSpacing, j * HorizontalSpacing);
                        
                    }

                }
                Counter--;
            }

	}
    class CustomBox { public GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);}
}
