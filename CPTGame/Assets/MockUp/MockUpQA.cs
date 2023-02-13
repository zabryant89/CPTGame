/*Author: Zachary Bryant
 * NOTES: This is intentionally completed as a non-generalized program.  There are options here to give students
 *      that may be given to help them learn how to generalize solutions so it can accept the three questions assigned
 *      OR more!
 */

//@@@ TODO: finished the new question setup system.  Just need to do some testing with randomization!
//          I plan to use "Insert" function for lists in order to accomplish the random generation!

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MockUpQA : MonoBehaviour
{
    private string[] quest1 = { "What day does the New Year begin?","January 1st", "Everyday", "June 1st", "This is ridiculous"};
    //private string quest1Ans = "January 1st";
    private string[] quest2 = { "What color are sith lightsabers?", "Red", "Blue", "Purple", "Green"};
    //private string quest2Ans = "Red";
    private string[] quest3 = { "Complete the quote: \"With great power, comes great _______\"", "Responsibility", "Control", "Disgust", "Happiness" };
    //private string quest3Ans = "Responsibility";

    //file stuff
    private List<string[]> questions;
    private string questionsFilename;
    private string answersFilename;
    private string[] lines, lines2;

    //this must initialize first, therefore:
    public GameObject screen;
    

    private void Start()
    {
        string[] question;
        string[,] answers;
        questions = new List<string[]>();
        questionsFilename = "Assets/MockUp/Questions.txt";
        answersFilename = "Assets/MockUp/Answers.txt";
        /*questions.Add(quest1);
        questions.Add(quest3);
        questions.Insert(1, quest2); //this was for testing, keeping it here!*/

        lines = File.ReadAllLines(questionsFilename);
        Debug.Log("Questions has " + lines.Length + " lines");

        question = new string[lines.Length];
        answers = new string[lines.Length, 4];

        for (int i = 0; i < lines.Length; i++)
        {
            question[i] = lines[i];
        }

        lines2 = File.ReadAllLines(answersFilename);
        Debug.Log("Answers has " + lines2.Length + " lines");

        for (int i = 2; i < lines2.Length; i++)
        {
            string[] elements = lines2[i].Split('|');
            for (int j = 0; j < 4; j++)
            {
                answers[i - 2, j] = elements[j];
            }
        }

        //time to take it all and put it into the questions array.

        for (int i = 0; i < lines.Length; i++)
        {
            string[] elements = new string[5];
            elements[0] = question[i];
            for (int j = 0; j < 4; j++)
            {
                elements[j + 1] = answers[i, j];
            }
            questions.Add(elements);
        }

        Debug.Log("questions in Start: " + questions.Count);

        
        EnableScreen();
    }

    //getters:
    //note: hardcoded but we can change that later.

    //retrieve a number of questions equal to the value passed (not randomized yet)
    public List<string[]> GetQuestions(int num)
    {
        List<string[]> val = new List<string[]>();

        List<string[]> temp = questions;
        Randomize(temp); //randomization of question order occurs here
        
        Debug.Log("questions size: " + questions.Count);
        Debug.Log("num value: " + num);

        if (num <= 0)
        {
            return null;
        }
        else
        {
            for (int i = 0; i < num; i++)
            {
                val.Add(questions[i]);
                Debug.Log("pause for debugging");
            }

            return val;
        }
    }

    private void Randomize(List<string[]> rand)
    {
        List<string[]> temp = new List<string[]>();
        
        for (int i = 0; i < rand.Count; i++)
        {
            int roll = UnityEngine.Random.Range(0, i);
            temp.Insert(roll, rand[i]);
        }

        rand = temp;
    }

    private void EnableScreen()
    {
        screen.SetActive(true);
    }

    //generalized solution (may not work)
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
            int swap = UnityEngine.Random.Range(0, 3);

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
