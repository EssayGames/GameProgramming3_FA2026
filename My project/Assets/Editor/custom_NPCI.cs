using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(NPC_interact))]
public class custom_NPCI : Editor
{
    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();

        serializedObject.Update();

        SerializedProperty typeProp = serializedObject.FindProperty("type");
        EditorGUILayout.PropertyField(typeProp);

        i_type currentType = (i_type)typeProp.enumValueIndex;

        if(currentType == i_type.npc)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("camData"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("textData"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("storyData"));
            EditorGUILayout.HelpBox("Warning: Manually Load npcData variable", MessageType.Info);

            GUILayout.Space(15);

            NPC_interact npcI = (NPC_interact)target;
            if (GUILayout.Button("Create NPC Cam Rig"))
            {
                npcI.loadNpcCam();
            }
            else if (GUILayout.Button("Set NPC Cam"))
            {
                npcI.setNpcCam();
            }
            else if (GUILayout.Button("Get Text Prompt Obj"))
            {
                npcI.loadTextObj();
            }
            else if (GUILayout.Button("Get Yarn Spinner Dialog Runner"))
            {
                npcI.loadYS();
            }
            
        }
        else if (currentType == i_type.item)
        {

        }

        serializedObject.ApplyModifiedProperties();

        
    }

}
