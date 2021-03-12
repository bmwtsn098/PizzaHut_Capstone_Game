using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCube : MonoBehaviour {

    public Color first = Color.yellow;
    public Color second = Color.cyan;
    private float speed = 1;
    private float duration = 1;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((float).6, (float).6, (float).6);

        float lerp = Mathf.PingPong(Time.time * speed, duration);

        rend.material.color = Color.Lerp(first, second, lerp);
    }
}
