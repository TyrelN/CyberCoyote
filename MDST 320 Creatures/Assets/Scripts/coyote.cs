using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coyote : MonoBehaviour
{
    private float timer = 0.0f;
     private float timer2 = 0.0f;
   
    private float randomTime = 0.0f;
    private float walking = 0.0f;
    private float reset = 0.0f;
     private bool switching;
     private bool walker;
    public bool positionswitch = false;
     private bool disappear;
    private Animator animate;
     GameObject coyotee;
     private bool refresh = false;
    Vector3 resetPos;
    private int counter;
    private bool setup;

    private bool teardown;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        switching = false;
        randomTime = UnityEngine.Random.Range(5.0f, 25.0f);
        coyotee = GameObject.Find("coyote thing animations control click (1)");
        resetPos = GameObject.Find("coyote thing animations control click (1)").transform.position;
        counter = 0;
    }

  

    // Update is called once per frame
    void Update()
    {

if(refresh == false){

         if(Input.GetButtonDown("Fire2") && counter == 0 )
         {
            walker = true;
            counter = 2;
        setup = true;
        refresh = true;
        }
           if(Input.GetButtonDown("Fire2") && counter == 1 )
         {
             counter = 3;

                 teardown = true;
                refresh = true;
            }

}
        if(teardown == true){
            walking += Time.deltaTime;
            if(walking >= 2.5f){
                
              transform.position = resetPos;
                walker = false;
                
                walking = reset;
                teardown = false;
                refresh = false;
            }
        }
        
        if (switching == true){
            animate.SetFloat("vert", -1, 0.6f, Time.deltaTime);
            timer += Time.deltaTime;
            if(timer >= randomTime){

              
                switching = false;
                randomTime = UnityEngine.Random.Range(5.0f, 25.0f);
                timer = reset;
            }

      
        }else if (walker == true){
         
            animate.SetFloat("vert", -1, 0.2f, Time.deltaTime);
            transform.position += Vector3.back * Time.deltaTime;
            walking += Time.deltaTime;
            if(walking >= 4.5f){

              
                walker = false;
                refresh = false;
                walking = reset;
            }
        }else{
              animate.SetFloat("hor", Input.GetAxis("Horizontal"), 0.5f, Time.deltaTime);
        animate.SetFloat("vert", Input.GetAxis("Vertical"), 0.5f, Time.deltaTime);

        }
 
        
        // animate.SetFloat("hor", Input.GetAxis("Horizontal"), 0.5f, Time.deltaTime);
        // animate.SetFloat("vert", Input.GetAxis("Vertical"));
       if(Input.GetKeyDown("t")){
           switching = true;
           animate.SetFloat("hor", 1, 0.5f, Time.deltaTime);
       }
     
          if(counter == 2){
        counter = 1;
    }
     if(counter == 3){
        counter = 0;
    }
    }
 
    
    }
