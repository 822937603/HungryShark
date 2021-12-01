using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float x;
    private float y;

    private Animator anim;

    private SpriteRenderer sr;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Movement(direction);
        Animate();
    }

    void Movement(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x + 0.5f;
        min.x = min.x - 0.5f;

        max.y = max.y + 0.2f;
        min.y = min.y - 0.2f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    void Animate()
    {
        if (x < 0)
        {
            sr.flipX = true;
        }
        if (x > 0)
        {
            sr.flipX = false;
        }
    }

} // class
