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
    public MockUpQA template; //assign this in unity, easy peasy (click and drag) - references our MockUpQA script
    public TextMeshProUGUI question; //this is the displayed question, will change as answers are given
    //private string question1, question2, question3; //hard coded, but we can easily change to be dynamic/universal
    private List<string[]> questionBank; //holds questions AND answers (all answers) for all questions
    private List<string[]> questionPool; //used to display the current question, the correct answer, and up to 3 wrong answers. Randomizing the answers
    private string[] correct; //will assign correct values here per question
    public Button[] buttons = new Button[4]; //array assigned in Unity
    int correctAns; //0 = no answer, 1 = true, 2 = false
    int count; //number of questions iterated.  references by index not actual count
    int correctCount, wrongCount; //counts right and wrong answers
    string[] finished; //used in the end of the game
    bool gameOver; //is the game over?


    // Start is called before the first frame update
    //void OnEnable()
    void OnEnable()
    {
        foreach (Button but in buttons)
        {
            TextMeshProUGUI text = but.GetComponentInChildren<TextMeshProUGUI>();
            text.overflowMode = TextOverflowModes.Overflow;
            text.enableWordWrapping = true;
        }
        gameOver = false;
        count = -1; //starting value
        //set correct to no answer
        correctAns = 0;

        //set counts to 0
        correctCount = 0;
        wrongCount = 0;

        //initialize the text box with the question, we will grab all 3 questions here
        //question = this.GetComponent<TextMeshProUGUI>(); //this line for instantiating without Unity GUI
        questionBank = template.GetQuestions(10);

        /*next we initialize each button with the answers... with steps:
        *      1 - Grab question 1 answers into an array (remember: our array total size is 5, but the answers are index 1-4)
        *                   CHANGE: also need to store the correct answer here!
        *      2 - Send array to be randomized
        *      3 - Input each answer into a button!
        *      4 - pull text for the correct answer
        *      5 - setup "listeners" for each button (note this can also be done strictly through unity)
        */

        //step 1 + 2: grab question 1 answers into an array, then randomize them (including change: store the correct answer!)
        questionPool = new List<string[]>();
        correct = new string[questionBank.Count];

        for (int i = 0; i < questionBank.Count; i++)
            correct[i] = questionBank[i][1];

        for (int i = 0; i < questionBank.Count; i++)
        {
            questionPool.Add(questionBank[i]);
        }

        //step 3: insert each answer into a button and display the question!
        //note: we can get all the correct answers now, makes no difference!
        //STUDENT WORK: take the code in lines 71 - 83 and place them into a function, replace that function here AND inside the Update function!
        question.text = questionPool[count + 1][0]; //changed to count + 1 to be consistent with rest of code AND generalized
        string[] tmp = new string[4];
        
        for (int i = 0; i < 4; i++)
            tmp[i] = questionPool[count + 1][i + 1];
        tmp = template.GenAnswers(tmp);
        for (int i = 0; i < 4; i++)
            questionPool[count + 1][i + 1] = tmp[i];

        for (int i = 0; i < 4; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = questionPool[count + 1][i + 1];
        }

        Debug.Log("Stop");

        //step 4: get the correct answers - IGNORE STEP, MOVED TO STEP 1


        //step 5: listeners for buttons
        buttons[0].onClick.AddListener(delegate { AnswerCheck(buttons[0], questionPool, correct); } );
        buttons[1].onClick.AddListener(delegate { AnswerCheck(buttons[1], questionPool, correct); } );
        buttons[2].onClick.AddListener(delegate { AnswerCheck(buttons[2], questionPool, correct); } );
        buttons[3].onClick.AddListener(delegate { AnswerCheck(buttons[3], questionPool, correct); } );
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime <= 0.00 )
            questionBank = template.GetQuestions(3);
        //just need a check for the correct int
        if (correctAns == 1 || correctAns == 2)
        {
            if (correctAns == 1)
                correctCount++;
            else
                wrongCount++;

            //must reset the correct variable in order to prevent the scenes from infintely jumping!
            correctAns = 0;

            //set next question (count + 1)
            if (count != questionPool.Count - 1)
            {
                question.text = questionPool[count + 1][0];

                string[] tmp = new string[4];
                for (int i = 0; i < 4; i++)
                    tmp[i] = questionPool[count + 1][i + 1];
                tmp = template.GenAnswers(tmp);
                for (int i = 0; i < 4; i++)
                    questionPool[count + 1][i + 1] = tmp[i];

                for (int i = 0; i < 4; i++)
                {
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = questionPool[count + 1][i + 1];
                }
            }
            else
            {
                question.text = "GAME OVER";
                gameOver = true;
                //assign all the text to finished variable
                finished = new string[] { "Right answers: " + correctCount, "Wrong answers: " + wrongCount, "Close Game", "Close Game" };
                AssignButtons(finished);
            }
        }

    }

    private void EndGame()
    {
        Application.Quit();
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

    public string GetCorrect()
    {
        return correct[count];
    }

    private void AnswerCheck(Button b, List<string[]> pool, string[] ans)
    {
        count++;

        if (gameOver)
            EndGame();
        else if (!gameOver)
        {
            if (b.GetComponentInChildren<TextMeshProUGUI>().text == correct[count])
                correctAns = 1;
            else
                correctAns = 2;
        }
    }
}
