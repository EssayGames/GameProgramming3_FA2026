using UnityEngine;
using UnityEditor;
using Yarn;

//the below attribute for this class ensures that this editor script affects the NPC_Interact class
[CustomEditor(typeof(NPC_Interact))]
public class customNPC_Interact : Editor
{
    public override void OnInspectorGUI()
    {
        //this built-in method "draws" the inspector as it normally would be viewed
        //"draw" in this instance means to visually render in the editor
        //DrawDefaultInspector();

        //This build-in method on this object will continue to "draw" the editor code within this OnInspectorGUI method
        serializedObject.Update();

        SerializedProperty typeProp = serializedObject.FindProperty("type");
        EditorGUILayout.PropertyField(typeProp);

        iType currentType = (iType)typeProp.enumValueIndex;

        if(currentType == iType.npc)
        {
            NPC_Interact npcI = (NPC_Interact)target;
            
            //"draw" properties/variables associated with this interaction type
            EditorGUILayout.PropertyField(serializedObject.FindProperty("textData"));
            EditorGUILayout.HelpBox("Warning: Make sure to write the Prompt Text String before entering playmode", MessageType.Warning);
            if(GUILayout.Button("Load Prompt Text"))
            {
                npcI.loadText();
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("dialogueData"));
            if(GUILayout.Button("Load Yarn Spinner Dialog Runner"))
            {
                npcI.loadYS();
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("camData"));
            EditorGUILayout.HelpBox("Manually Load the NPC_Cam_Prefab before Instantiating in Scene", MessageType.Info);
            if(GUILayout.Button("Instantiate NPC Cam Prefab"))
            {
                npcI.loadNpcCamPrefab();
            }
            //to affect and add to the inspector, we need to gain access to the methods in the NPC_Interact class
            //the below line of code, grants us access to those methods using a temporary variable "npcI"

            //for an editor script if we're using an IF statement with GUILayout as the condition
            //then the editor will generate that button as opposed to check to see if the condition is true
        }

        //ESSENTIAL LINE OF CODE to make sure we can edit the properties/variables of our class
        //without this ApplyModifiedProperties method, we won't be able to add any data to our variables
        serializedObject.ApplyModifiedProperties();


    }
}
