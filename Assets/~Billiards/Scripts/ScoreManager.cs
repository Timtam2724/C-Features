using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Billiards
{

    public class ScoreManager : MonoBehaviour
    {

        public Text scoreText;
        public int score = 0; // Sets the initial score to zero

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score" + score;
        }
    }
}
