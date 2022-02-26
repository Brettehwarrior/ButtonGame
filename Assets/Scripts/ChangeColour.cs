using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class ChangeColour : MonoBehaviour
{
    private bool[] filled = {false, false, false, false, false, false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        Random rand = new Random();
        float speed = 1f;
        // var randomBtnIndex = rand.Next(0, 10);
        // int round = 1;
        for (int i = 0; i < 9; i++)
        {                
            GameObject theBtn = this.gameObject.transform.GetChild(i).gameObject;
            // theLight.SetActive(false);
            
            if (theBtn.name != "RealButton")
            {
                var btnRenderer = theBtn.GetComponent<Renderer>();
                btnRenderer.material.color = new Color32(255, (byte)rand.Next(0,200), (byte)rand.Next(0,200),255);
            }

            // theBtnParent.transform.localPosition = new Vector3((float)0.4, -0.1570001f, (float)-0.4);
            int index;
            
            
            while (true)
            {
                index = rand.Next(0, 9);
                if (!filled[index])
                {
                    
                    filled[index] = true;
                    switch (index)
                    {
                        case 0:
                            theBtn.transform.localPosition = new Vector3((float)-0.4, -0.1570001f, (float)0.4);        
                            Debug.Log(index);
                            break;
                        case 1:
                            theBtn.transform.localPosition = new Vector3((float)0, -0.1570001f, (float)0.4);        
                            Debug.Log(index);
                            break;
                        case 2:
                            theBtn.transform.localPosition = new Vector3((float)0.4, -0.1570001f, (float)0.4);        
                            Debug.Log(index);
                            break;
                        case 3:
                            theBtn.transform.localPosition = new Vector3((float)-0.4, -0.1570001f, (float)0);        
                            Debug.Log(index);
                            break;
                        case 4:
                            theBtn.transform.localPosition = new Vector3((float)0, -0.1570001f, (float)0);        
                            Debug.Log(index);
                            break;
                        case 5:
                            theBtn.transform.localPosition = new Vector3((float)0.4, -0.1570001f, (float)0);        
                            Debug.Log(index);
                            break;
                        case 6:
                            theBtn.transform.localPosition = new Vector3((float)-0.4, -0.1570001f, (float)-0.4);        
                            Debug.Log(index);
                            break;
                        case 7:
                            theBtn.transform.localPosition = new Vector3((float)0, -0.1570001f, (float)-0.4);        
                            Debug.Log(index);
                            break;
                        case 8:
                            theBtn.transform.localPosition = new Vector3((float)0.4, -0.1570001f, (float)-0.4);                            
                            Debug.Log(index);
                            break;
                    }
            
                    break;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}