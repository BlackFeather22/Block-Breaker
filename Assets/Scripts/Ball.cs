using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayStart());
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(5f, 5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindFirstObjectByType<LevelController>().DecreaseLives();
        Destroy(gameObject);
    }
    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(250f, 250f));
    }
}