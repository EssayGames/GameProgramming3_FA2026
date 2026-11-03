using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(NPC_Interact))]
public class custom_NPCI : Editor
{
    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();

        serializedObject.Update();

        SerializedProperty typeProp = serializedObject.FindProperty("type");
        EditorGUILayout.PropertyField(typeProp);

        iType currentType = (iType)typeProp.enumValueIndex;

        if(currentType == iType.npc)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("camData"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("textData"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("storyData"));
            EditorGUILayout.HelpBox("Warning: Manually Load npcData variable", MessageType.Info);

            GUILayout.Space(15);

            NPC_Interact npcI = (NPC_Interact)target;
            if (GUILayout.Button("Set NPC Cam"))
            {
                npcI.setNpcCam();
            }
            else if (GUILayout.Button("Get Text Prompt Obj"))
            {
                npcI.loadText();
            }
            else if (GUILayout.Button("Get Yarn Spinner Dialog Runner"))
            {
                npcI.loadYS();
            }
            
        }
        else if (currentType == iType.item)
        {

        }

        serializedObject.ApplyModifiedProperties();

        
    }

}
