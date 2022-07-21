using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
        private float deltaTime = 0.0f;

        public TextMeshProUGUI FPS;
        public TextMeshProUGUI Objects;
        public static int ObjectsCount;
        public static int averageFPS;
        // Update is called once per frame
        void Update()
        {
            // average the deltaTime for roughly ten frames (seconds per frame)
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

            // frame per second
            float fps = 1.0f / deltaTime;
            averageFPS= (int)((averageFPS+fps)/2f);
            // round up
            string text = Mathf.Ceil(fps).ToString();

            // set the text mesh
            FPS.text = "FPS:"+text;
            Objects.text = "Units:"+ObjectsCount;
        }
    }

