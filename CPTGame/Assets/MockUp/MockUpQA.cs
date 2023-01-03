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

    public string[] GenAnswers(string[] questSet)
    {
        return quest2;
    }
}
