using System;
using System.Speech.Synthesis;  

namespace NewsCaster
{
    static class Text2Speech
    {
        public static void Speak(string Text2Speak)
        {
            SpeechSynthesizer obj_speak = new SpeechSynthesizer();
            obj_speak.SetOutputToDefaultAudioDevice();
            obj_speak.Speak(Text2Speak);
        }
    }
}
