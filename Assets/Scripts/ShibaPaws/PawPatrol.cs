using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class PawPatrol : MonoBehaviour
{
    private Random rand = new Random();

    private bool[] pawWasActive = {false, false, false, false, false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            StartCoroutine(SelectRandom());
        }
        
        Debug.Log("Game finshed.");
    }

    IEnumerator SelectRandom()
    {
        yield return new WaitForSeconds(rand.Next(1, 11));
        int index;
        while (true)
        {
            index = rand.Next(0, 8);
            if (!pawWasActive[index])
            {
                pawWasActive[index] = true;
                gameObject.transform.GetChild(index).gameObject.SetActive(true);
                break;
            }
        }

    }
}
