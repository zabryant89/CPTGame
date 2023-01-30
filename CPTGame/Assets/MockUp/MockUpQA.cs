/*Author: Zachary Bryant
 * NOTES: This is intentionally completed as a non-generalized program.  There are options here to give students
 *      that may be given to help them learn how to generalize solutions so it can accept the three questions assigned
 *      OR more!
 */

//@@@ TODO: finished the new question setup system.  Just need to do some testing with randomization!
//          I plan to use "Insert" function for lists in order to accomplish the random generation!

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

    private List<string[]> questions;

    //this must initialize first, therefore:
    public GameObject screen;
    

    private void Start()
    {
        questions = new List<string[]>();
        questions.Add(quest1);
        questions.Add(quest3);
        questions.Insert(1, quest2); //this was for testing, keeping it here!
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
        Randomize(temp); //randomization occurs here
        
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
            int roll = Random.Range(0, i);
            temp.Insert(roll, rand[i]);
        }

        rand = temp;
    }

    private void EnableScreen()
    {
        screen.SetActive(true);
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
