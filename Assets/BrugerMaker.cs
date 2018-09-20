using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrugerMaker : MonoBehaviour {

    public GameObject BunBottom;
    public GameObject BunTop;
    public GameObject Burger;
    public GameObject Tomato;
    public GameObject Cheese;

    List<GameObject> burgerParts = new List<GameObject>();
    System.Random random = new System.Random();

	// Use this for initialization
	void Start () {

        List<GameObject> myBurger;

        burgerParts.Add(BunBottom);
        burgerParts.Add(Burger);
        burgerParts.Add(Cheese);
        burgerParts.Add(Tomato);


        

        myBurger = simpleBurger();

        //Render a burger
        render(myBurger, 0, 0);

        for (int i = 0; i < 100; i++)
        {

            myBurger = randomBurger();

            render(myBurger, 0, i * 1.25f);
        }
        


    }

    List<GameObject> simpleBurger()
    {
        List<GameObject> myBurger = new List<GameObject>();


        myBurger.Add(BunBottom);
        myBurger.Add(Burger);
        myBurger.Add(Cheese);
        myBurger.Add(Tomato);
        myBurger.Add(BunBottom);

        return myBurger;
    }

    List<GameObject> randomBurger()
    {
        var toReturn = new List<GameObject>();
        for(int i = 0; i < 5; i++)
        {
            toReturn.Add(burgerParts[random.Next(0, burgerParts.Count)]);
        }

        return toReturn;
    }

    void render(List<GameObject> myBurger, float y, float x)
    {
        foreach (GameObject item in myBurger)
        {
            float myHalfSize;
            Renderer rend = item.transform.GetChild(0).GetComponent<Renderer>();
            Bounds bounds = rend.bounds;
            myHalfSize = bounds.size.y / 2;
            y += myHalfSize;
            Instantiate(item, new Vector3(x, y, 0), Quaternion.identity);
            y += bounds.size.y / 2;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
