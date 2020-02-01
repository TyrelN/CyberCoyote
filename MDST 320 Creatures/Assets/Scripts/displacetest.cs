using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displacetest : MonoBehaviour
{
    public float displaceAmount;
    //public ParticleSystem explosionParticles;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        displaceAmount = Mathf.Lerp(displaceAmount, 0, Time.deltaTime);
        meshRenderer.material.SetFloat("_Amount", displaceAmount);

        if(Input.GetButtonDown("Jump")){
            displaceAmount += 0.5f;
            //explosionParticles.Play();
        }
    }
}
