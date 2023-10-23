using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BoldScript : MonoBehaviour
{
    public TMP_Text textMeshPro;

    private void Start()
    {
        FormatBionic();
    }

    public void FormatBionic()
    {
        string fullText = textMeshPro.text;

        string[] words = fullText.Split(' ');

        List<string> formattedWords = new List<string>();

        foreach (string word in words)
        {
            int halfLength = word.Length / 2;
            string formattedWord = "<b><color=#000000FF>" + word.Substring(0, halfLength) + "</color></b>" + word.Substring(halfLength);

            formattedWords.Add(formattedWord);
        }

        string formattedText = string.Join(" ", formattedWords);

        textMeshPro.text = formattedText;
    }



}
