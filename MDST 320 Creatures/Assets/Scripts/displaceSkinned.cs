using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displaceSkinned : MonoBehaviour{
 public float displaceAmount;
 public float dissolveAmount;

    public ParticleSystem explosionParticles;

    public ParticleSystem sparks;
    public ParticleSystem electric;
    private float timer = 0.0f;
    private float walktime = 0.0f;
    private float timer2 = 0.0f;
    private float reset = 0.0f;

    private bool refresh = false;
    private bool flip;
    private bool setup;
    private bool starting;
    private bool teardown;
    private bool flip2;
    private bool ready;
    private bool dissolve = false;
    private int counter;
    coyote coyo;

       SkinnedMeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        
        flip = false;
        dissolveAmount = 1;
        ready = false;
        flip2 = false;
        setup = false;
        teardown = false;
        counter = 0;
        starting = true;
        // coyo = GetComponent<coyote>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(refresh == false){
          if(Input.GetButtonDown("Fire2") && starting == true)
         {
             
             dissolve = true;
          
            if(dissolve == true){
                setup = true;
                refresh = true;


        }
         }
            if(Input.GetButtonDown("Fire2") && starting == false)
         {
             
            //  coyo.positionswitch = true;
             dissolve = false;
            
            if(dissolve == false){
                teardown = true;
                refresh = true;


        }
         }
        }
        if(setup == true){
            walktime += Time.deltaTime;
            if(walktime >= 4.5f){

              starting = false;
                setup = false;
                ready = true;
                walktime = reset;
                refresh = false;
            }
        }
           if(teardown == true){
            
            walktime += Time.deltaTime;
            if(walktime >= 2.5f){

              
                starting = true;
               
                walktime = reset;
                refresh = false;
                teardown = false;
            }
        }
         if(dissolve == true){
               
                dissolveAmount = Mathf.Lerp(dissolveAmount, 0, Time.deltaTime);
                meshRenderer.material.SetFloat("_visibility", dissolveAmount);
            }else if(dissolve == false){
    
                dissolveAmount = Mathf.Lerp(dissolveAmount, 1, Time.deltaTime);
                meshRenderer.material.SetFloat("_visibility", dissolveAmount);
            }

        if(ready == true){
       
      
        displaceAmount = Mathf.Lerp(displaceAmount, 0.0f, Time.deltaTime);
        meshRenderer.material.SetFloat("_Amount", displaceAmount);
       
        
        if(Input.GetButtonDown("Submit")){
            displaceAmount -= 0.5f;
            explosionParticles.Play();
            flip = true;
        }
        
       
        if(Input.GetButtonDown("Fire3")){
            displaceAmount+= 0.5f;
        }
         if(Input.GetButtonDown("Fire1")){
            sparks.Play();
            electric.Play();
            flip2 = true;

        }
        if(Input.GetKeyDown("g")){ dissolve = !dissolve;}
        
      

        
 
        
        if (flip == true){
            timer += Time.deltaTime;
            if(timer >= 1.0f){
                explosionParticles.Stop();
                flip = false;
                timer = reset;
            }
        }
           if (flip2 == true){
            timer2 += Time.deltaTime;
            if(timer2 >= 5.5f){
                sparks.Stop();
                electric.Stop();
                flip = false;
                timer2 = reset;
            }
        }
    }

    }
}
