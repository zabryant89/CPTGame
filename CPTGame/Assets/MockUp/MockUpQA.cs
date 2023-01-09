using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockUpQA : MonoBehaviour
{
    private string[] quest1 = { "What day does the New Year begin?", "Everyday", "January 1st", "June 1st", "This is ridiculous"};
    private string quest1Ans = "January 1st";
    private string[] quest2 = { "What color are sith lightsabers?", "Red", "Blue", "Purple", "Green"};
    private string quest2Ans = "Red";
    private string[] quest3 = { "Complete the quote: \"With great power, comes great _______\"", "Responsibility", "Control", "Disgust", "Happiness" };
    private string quest3Ans = "Responsibility";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //getters:
    //note: hardcoded but we can change that later.
    public string GetQuestion1()
    {
        return quest1[0];
    }

    public string GetQuestion2()
    {
        return quest2[0];
    }

    public string GetQuestion3()
    {
        return quest3[0];
    }

    public string[] GetAnswers1()
    {
        string[] tmp = new string[4];
        for (int i = 1; i < 5; i++)
        {
            tmp[i - 1] = quest1[i];
        }
        return tmp;
    }

    public string[] GetAnswers2()
    {
        string[] tmp = new string[4];
        for (int i = 1; i < 5; i++)
        {
            tmp[i - 1] = quest2[i];
        }
        return tmp;
    }

    public string[] GetAnswers3()
    {
        string[] tmp = new string[4];
        for (int i = 1; i < 5; i++)
        {
            tmp[i - 1] = quest3[i];
        }
        return tmp;
    }

    public string[] GenAnswers(string[] questSet)
    {
        string[] tmp = new string[4]; //assign a tmp set to store all answers
        //insert the answers into tmp
        for (int i = 0; i < 4; i++)
        {
            tmp[i] = questSet[i + 1]; //important: answers are from index 1 - 4
        }

        RandomizeSet(tmp, 0); //method to randomize the answers, start at index 0
        return tmp;
    }

    public string[] RandomizeSet(string[] rand, int iteration)
    {
        if (iteration < 4)
        {
            //iteration: when = 4, stop
            int swap = Random.Range(0, 3);

            string tmp; //hold value if we need to do a swap
            //if the swap # and the iteration # differ: then we swap those two values in the array!
            if (iteration != swap)
            {
                tmp = rand[swap];
                rand[swap] = rand[iteration];
                rand[iteration] = tmp;
            }
            return RandomizeSet(rand, iteration + 1);
        }
        else
        {
            return rand;
        }
    }
}
