using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    public MockUpQA template; //assign this in unity, easy peasy (click and drag)
    private TextMesh question; //this is the displayed question, will change as answers are given
    private string question1, question2, question3; //hard coded, but we can easily change to be dynamic/universal
    private string[] q1Answers = new string[4], q2Answers = new string[4], q3Answers = new string[4]; //answer sets for each corresponding question
    private string q1Correct, q2Correct, q3Correct; //will assign correct values here per question

    // Start is called before the first frame update
    void Start()
    {
        question = this.GetComponent<TextMeshProUGUI>();
        question1 = template.GetQuestion1();
        question.text = question1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
