using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownScript : MonoBehaviour
{
    private GameObject compare;
    private float height = 0;
    private bool Up = true;
    private int num;

    public float lowestNumBGUp;
    public int highestNumbeForChangeingBoolToFalse;

    public float highestNumBeforeGoingDown;
    public int lowestNumbeForChangeingBoolToTrue;

    public float upDownSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        height = Time.deltaTime;
        height += upDownSpeed;
        

        if (transform.position.y >= lowestNumBGUp && Up == true) {

            transform.position += new Vector3(0, height, 0);

            if (transform.position.y >= highestNumbeForChangeingBoolToFalse)
            {

                Up = false;

            }
        }

        if (transform.position.y <= highestNumBeforeGoingDown && Up == false) {

            transform.position -= new Vector3(0, height, 0);
            
            if (transform.position.y <= lowestNumbeForChangeingBoolToTrue)
            {
                
                    Up = true;
                
            }
        }



    }
}
