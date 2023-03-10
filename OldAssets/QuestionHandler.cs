/*Author: Zachary Bryant
 * NOTES: This is intentionally completed as a non-generalized program.  There are options here to give students
 *      that may be given to help them learn how to generalize solutions so it can accept the three questions assigned
 *      OR more!
 *      Further we can also give "optimization" or even "alternate" solutions challenges to have students see ways
 *      they can change the code to improve it or simply attempt another approach.  Again some of this was intentionally done
 *      in a way that is not optimal or can be altered for this very purpose.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionHandler : MonoBehaviour
{
    public MockUpQA template; //assign this in unity, easy peasy (click and drag)
    public TextMeshProUGUI question; //this is the displayed question, will change as answers are given
    private string question1, question2, question3; //hard coded, but we can easily change to be dynamic/universal
    private string[] q1Answers = new string[4], q2Answers = new string[4], q3Answers = new string[4]; //answer sets for each corresponding question
    private string q1Correct, q2Correct, q3Correct; //will assign correct values here per question
    public Button[] buttons = new Button[4]; //array assigned in Unity
    int correctAns; //0 = no answer, 1 = true, 2 = false
    int correctCount, wrongCount; //counts right and wrong answers
    string[] finished; //used in the end of the game


    // Start is called before the first frame update
    void Start()
    {
        //set correct to no answer
        correctAns = 0;

        //set counts to 0
        correctCount = 0;
        wrongCount = 0;

        //initialize the text box with the question, we will grab all 3 questions here
        //question = this.GetComponent<TextMeshProUGUI>(); //this line for instantiating without Unity GUI
        question1 = template.GetQuestion1();
        question2 = template.GetQuestion2();
        question3 = template.GetQuestion3();
        //start with question 1
        question.text = question1;

        /*next we initialize each button with the answers... with steps:
        *      1 - Grab question 1 answers into an array (remember: our array total size is 5, but the answers are index 1-4)
        *      2 - Send array to be randomized
        *      3 - Input each answer into a button!
        *      4 - pull text for the correct answer
        *      5 - setup "listeners" for each button (note this can also be done strictly through unity)
        */

        //step 1 + 2: grab question 1 answers into an array, then randomize them
        q1Answers = template.RandomizeSet(template.GetAnswers1(), 0);
        q2Answers = template.RandomizeSet(template.GetAnswers2(), 0);
        q3Answers = template.RandomizeSet(template.GetAnswers3(), 0);

        //step 3: insert each answer into a button
        //note: we can get all the correct answers now, makes no difference!
        AssignButtons(q1Answers);

        //step 4: get the correct answers
        q1Correct = template.GetCorrect1();
        q2Correct = template.GetCorrect2();
        q3Correct = template.GetCorrect3();

        //step 5: listeners for buttons
        buttons[0].onClick.AddListener(delegate { AnswerCheck(buttons[0]); } );
        buttons[1].onClick.AddListener(delegate { AnswerCheck(buttons[1]); } );
        buttons[2].onClick.AddListener(delegate { AnswerCheck(buttons[2]); } );
        buttons[3].onClick.AddListener(delegate { AnswerCheck(buttons[3]); } );
    }

    // Update is called once per frame
    void Update()
    {
        //just need a check for the correct int
        if (correctAns == 1 || correctAns == 2)
        {
            if (correctAns == 1)
                correctCount++;
            else
                wrongCount++;

            //must reset the correct variable in order to prevent the scenes from infintely jumping!
            correctAns = 0;

            //check what question we are on and go forward accordingly
            if (question.text == question1)
            {
                //need to change the question and buttons
                question.text = question2;
                AssignButtons(q2Answers);
            }
            else if(question.text == question2)
            {
                question.text = question3;
                AssignButtons(q3Answers);
            }
            else
            {
                question.text = "GAME OVER";
                //assign all the text to finished variable
                finished = new string[] { "Right answers: " + correctCount, "Wrong answers: " + wrongCount, "", "" };
                AssignButtons(finished);
            }
        }
        
    }

    private void AssignButtons(string[] ans)
    {
        string tmp; //used to move everything into the text field for the buttons

        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            tmp = ans[i];
            text.text = tmp;
        }
    }

    private void AnswerCheck(Button b)
    {
        if (question.text == question1)
        {
            if (b.GetComponentInChildren<TextMeshProUGUI>().text == q1Correct)
                correctAns = 1;
            else
                correctAns = 2;
        }
        else if (question.text == question2)
        {
            if (b.GetComponentInChildren<TextMeshProUGUI>().text == q2Correct)
                correctAns = 1;
            else
                correctAns = 2;
        }
        else if (question.text == question3)
        {
            if (b.GetComponentInChildren<TextMeshProUGUI>().text == q3Correct)
                correctAns = 1;
            else
                correctAns = 2;
        }
        else
            Debug.Log("Game is over");
    }
}
