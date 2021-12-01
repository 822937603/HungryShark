using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleTanFishController : MonoBehaviour
{
    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, yMin, yMax;
    }

    [System.Serializable]
    public class FishSpeed
    {
        public float maxSpeed, minSpeed;
    }

    public FishSpeed speed;
    public Boundary boundary;
    public float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.x -= currentSpeed * Time.deltaTime;
        gameObject.GetComponent<Transform>().position = currentPosition;
        if(currentPosition.x <= boundary.xMin)
        {
            Reset();
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void Reset()
    {
        Vector2 resetPosition = new Vector2(boundary.xMax, Random.Range(boundary.yMin, boundary.yMax));
        gameObject.GetComponent<Transform>().position = resetPosition;
        this.currentSpeed = 2.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}// class
