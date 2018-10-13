using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject[] BubblePrefabs;

    public float BubbleMinTime = 0.3f;
    public float BubbleMaxTime = 0.7f;

    private float _time;
    
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Animator>().speed = Random.Range(0.5f, 2.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        _time -= Time.deltaTime;

        if (_time < 0)
        {
            _time = Random.Range(BubbleMinTime, BubbleMaxTime);

            SpawnBubble(Random.insideUnitCircle * 0.2f);
        }
    }

    private void SpawnBubble(Vector2 push)
    {
        var pos = Random.insideUnitCircle * 0.5f;
        pos.y = Mathf.Abs(pos.y) + 0.1f;
        pos = pos + (Vector2) transform.position;
        
        var go =  Instantiate(BubblePrefabs.Pick(), pos, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().AddRelativeForce(push, ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        for (var i = 0; i < 20; i++)
        {
            SpawnBubble(Random.insideUnitCircle);
        }
    }
}
