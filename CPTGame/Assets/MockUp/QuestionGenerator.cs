using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionGenerator : MonoBehaviour
{
    public MockUpQA template; //assign this in unity, easy peasy (click and drag)
    private TextMeshProUGUI question; //this is the displayed question, will change as answers are given
    private string question1, question2, question3; //hard coded, but we can easily change to be dynamic/universal
    private string[] q1Answers = new string[4], q2Answers = new string[4], q3Answers = new string[4]; //answer sets for each corresponding question
    private string q1Correct, q2Correct, q3Correct; //will assign correct values here per question
    

    // Start is called before the first frame update
    void Start()
    {
        string[] tmp; //will be used to move things around as needed.

        //initialize the text box with the question
        question = this.GetComponent<TextMeshProUGUI>();
        question1 = template.GetQuestion1();
        question.text = question1;

        /*next we initialize each button with the answers... with steps:
        *      1 - Grab question 1 answers into an array (remember: our array total size is 5, but the answers are index 1-4)
        *      2 - Send array to be randomized
        *      3 - Input each answer into a button!
        */

        //step 1: grab question 1 answers into an array
        q1Answers = template.GetAnswers1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
