using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class QuestionImporterWindow : EditorWindow
{
    private string jsonInput = "";
    private string folderPath = "Assets/Questions";

    [MenuItem("Tools/Question Importer")]
    public static void ShowWindow()
    {
        GetWindow<QuestionImporterWindow>("Question Importer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Paste JSON Data for Questions", EditorStyles.boldLabel);
        jsonInput = EditorGUILayout.TextArea(jsonInput, GUILayout.Height(150));

        GUILayout.Space(10);
        GUILayout.Label("Folder Path to Save ScriptableObjects", EditorStyles.label);
        folderPath = EditorGUILayout.TextField(folderPath);

        if (GUILayout.Button("Import Questions from JSON"))
        {
            ImportQuestionsFromJson();
        }
    }

    private void ImportQuestionsFromJson()
    {
        if (string.IsNullOrEmpty(jsonInput))
        {
            Debug.LogError("JSON input is empty!");
            return;
        }

        try
        {
            QuestionData[] questionDatas = JsonHelper.FromJson<QuestionData>(jsonInput);

            if (!AssetDatabase.IsValidFolder(folderPath))
            {
                Debug.LogError($"Invalid folder path: {folderPath}");
                return;
            }

            int questionIndex = 0;

            foreach (var q in questionDatas)
            {
                Question questionAsset = ScriptableObject.CreateInstance<Question>();

                // Use Reflection to set private fields (or you can add public setters)
                SerializedObject serializedQuestion = new SerializedObject(questionAsset);
                serializedQuestion.FindProperty("_info").stringValue = q.info;
                serializedQuestion.FindProperty("_useTimer").boolValue = q.useTimer;
                serializedQuestion.FindProperty("_timer").intValue = q.timer;
                serializedQuestion.FindProperty("_addScore").intValue = q.addScore;
                serializedQuestion.FindProperty("_answerType").enumValueIndex =
                    q.answerType == "Multi" ? (int)Question.AnswerType.Multi : (int)Question.AnswerType.Single;

                SerializedProperty answersArray = serializedQuestion.FindProperty("_answers");
                answersArray.arraySize = q.answers.Length;
                for (int i = 0; i < q.answers.Length; i++)
                {
                    SerializedProperty element = answersArray.GetArrayElementAtIndex(i);
                    element.FindPropertyRelative("_info").stringValue = q.answers[i].info;
                    element.FindPropertyRelative("_isCorrect").boolValue = q.answers[i].isCorrect;
                }

                serializedQuestion.ApplyModifiedProperties();

                string fileName = $"q{questionIndex + 1}";
                questionIndex++;

                string assetPath = AssetDatabase.GenerateUniqueAssetPath($"{folderPath}/{fileName}.asset");
                AssetDatabase.CreateAsset(questionAsset, assetPath);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("Questions successfully imported.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to import questions: " + ex.Message);
        }
    }

    [System.Serializable]
    public class QuestionData
    {
        public string info;
        public AnswerData[] answers;
        public bool useTimer;
        public int timer;
        public string answerType; // "Single" or "Multi"
        public int addScore;
    }

    [System.Serializable]
    public class AnswerData
    {
        public string info;
        public bool isCorrect;
    }

    // JSON Helper for Unity array handling
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            string wrappedJson = "{\"Items\":" + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(wrappedJson);
            return wrapper.Items;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
