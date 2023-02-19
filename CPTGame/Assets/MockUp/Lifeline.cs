using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifeline : MonoBehaviour
{
    public MockUpQA mqa;
    public QuestionHandler qh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool fifty_fifty()
    {
        //removes 2 incorrect answers
        return true;
    }

    public bool scrape()
    {
        //removes 1 incorrect answer
        return true;
    }

    public bool golden_ticket()
    {
        //gives correct answer for the question you are on
        return true;
    }
}
