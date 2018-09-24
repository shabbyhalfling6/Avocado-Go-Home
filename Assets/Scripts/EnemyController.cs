using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float lifeTime = 10.0f;
    private float lifeTimeIn = 0.0f;

    private SpriteRenderer m_Renderer;

	// Use this for initialization
	void Start ()
    {
        lifeTimeIn = lifeTime;
        m_Renderer = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeTime -= Time.deltaTime;


		if(!m_Renderer.isVisible)
        {
            if(lifeTime <= 0)
                Destroy(gameObject);
        }
        else
        {
            lifeTime = lifeTimeIn;
        }
	}
}
