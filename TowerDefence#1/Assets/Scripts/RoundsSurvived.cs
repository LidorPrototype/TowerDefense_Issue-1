using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    void OnEnable()
    {
        //roundsText.text = PlayerStates.Rounds.ToString();
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.7f);

        while(round < PlayerStates.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(0.5f);
        }
    }

}
