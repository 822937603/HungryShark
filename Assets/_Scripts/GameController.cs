using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int edibleYellowFishCount;
    public GameObject edibleYellowFish;
    public float spawnRate = 20.0f;
    public Text scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EdibleYellowFishSpawner", 0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EdibleYellowFishSpawner()
    { 
            Instantiate(edibleYellowFish);
    }

}
