using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class FolderGenerator : MonoBehaviour 
{
    [MenuItem("Folder Hierarchy/Generate Folder Hierarchy %#g")]
    public static void CreateFolderHierarchy()
    {
        GenerateHierarchy();

        GenerateReadMes();
        
        AssetDatabase.Refresh();

        Debug.Log("Folder Hierarchy Generated.");
    }

    /**
     * GenerateHierarchy generates the folder structure within the Unity
     * Assets database.
     */
    static void GenerateHierarchy()
    {
        Debug.Log("Generating Folder Hierarchy . . . . . . ");

        #region Dynamic Asset folder database
        AssetDatabase.CreateFolder("Assets", "Dynamic Assets");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets", "Animations");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets/Animations", "Sources");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets", "Animation Controllers");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets", "Effects");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets", "Models");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets/Models", "Characters");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets/Models", "Environment");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets", "Prefabs");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets/Prefabs", "Common");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets", "Sounds");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets/Sounds", "Music");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets/Sounds", "SFX");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets/Sounds/Music", "Common");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets/Sounds/SFX", "Common");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets", "Textures");
        AssetDatabase.CreateFolder("Assets/Dynamic Assets/Textures", "Common");
        #endregion

        AssetDatabase.CreateFolder("Assets", "Extensions");
        AssetDatabase.CreateFolder("Assets", "Gizmos");
        AssetDatabase.CreateFolder("Assets", "Plugins");
        AssetDatabase.CreateFolder("Assets", "Scripts");
        AssetDatabase.CreateFolder("Assets/Scripts", "Common");
        AssetDatabase.CreateFolder("Assets", "Shaders");
        AssetDatabase.CreateFolder("Assets", "Testing");

        #region Static Asset folder database
        AssetDatabase.CreateFolder("Assets", "Static Assets");
        AssetDatabase.CreateFolder("Assets/Static Assets", "Animations");
        AssetDatabase.CreateFolder("Assets/Static Assets/Animations", "Sources");
        AssetDatabase.CreateFolder("Assets/Static Assets", "Animation Controllers");
        AssetDatabase.CreateFolder("Assets/Static Assets", "Effects");
        AssetDatabase.CreateFolder("Assets/Static Assets", "Models");
        AssetDatabase.CreateFolder("Assets/Static Assets/Models", "Characters");
        AssetDatabase.CreateFolder("Assets/Static Assets/Models", "Environment");
        AssetDatabase.CreateFolder("Assets/Static Assets", "Prefabs");
        AssetDatabase.CreateFolder("Assets/Static Assets/Prefabs", "Common");
        AssetDatabase.CreateFolder("Assets/Static Assets", "Scenes");
        AssetDatabase.CreateFolder("Assets/Static Assets", "Sounds");
        AssetDatabase.CreateFolder("Assets/Static Assets/Sounds", "Music");
        AssetDatabase.CreateFolder("Assets/Static Assets/Sounds", "SFX");
        AssetDatabase.CreateFolder("Assets/Static Assets/Sounds/Music", "Common");
        AssetDatabase.CreateFolder("Assets/Static Assets/Sounds/SFX", "Common");
        AssetDatabase.CreateFolder("Assets/Static Assets", "Textures");
        AssetDatabase.CreateFolder("Assets/Static Assets/Textures", "Common");
        #endregion
    }

    /**
     * GenerateReadMes generates the text files explaining what goes in the
     * folders within the hierarchy
     */
    static void GenerateReadMes()
    {
        #region Folder Paths

        #region Dynamic Asset Filepaths
        string folder_Dynamic = Application.dataPath + "/Dynamic Assets/FolderStructure.txt",
               folder_DynamicAnimations = Application.dataPath + "/Dynamic Assets/Animations/FolderStructure.txt",
               folder_DynamicEffects = Application.dataPath + "/Dynamic Assets/Effects/FolderStructure.txt",
               folder_DynamicModels = Application.dataPath + "/Dynamic Assets/Models/FolderStructure.txt",
               folder_DynamicCharacterModels = Application.dataPath + "/Dynamic Assets/Models/Characters/FolderStructure.txt",
               folder_DynamicEnvironmentModels = Application.dataPath + "/Dynamic Assets/Models/Environment/FolderStructure.txt",
               folder_DynamicPrefabs = Application.dataPath + "/Dynamic Assets/Prefabs/FolderStructure.txt",
               folder_DynamicSounds = Application.dataPath + "/Dynamic Assets/Sounds/FolderStructure.txt",
               folder_DynamicSoundsMusic = Application.dataPath + "/Dynamic Assets/Sounds/Music/FolderStructure.txt",
               folder_DynamicSoundsSFX = Application.dataPath + "/Dynamic Assets/Sounds/SFX/FolderStructure.txt",
               folder_DynamicTextures = Application.dataPath + "/Dynamic Assets/Textures/FolderStructure.txt";
        #endregion

        string folder_Editor = Application.dataPath + "/Editor/FolderStructure.txt";
        string folder_Extensions = Application.dataPath + "/Extensions/FolderStructure.txt";
        string folder_Gizmos = Application.dataPath + "/Gizmos/FolderStructure.txt";
        string folder_Plugins = Application.dataPath + "/Plugins/FolderStructre.txt";
        string folder_Scripts = Application.dataPath + "/Scripts/FolderStructure.txt";
        string folder_ScriptsCommon = Application.dataPath + "/Scripts/Common/FolderStructure.txt";
        string folder_Shaders = Application.dataPath + "/Shaders/FolderStructure.txt";
        string folder_Testing = Application.dataPath + "/Testing/FolderStructure.txt";

        #region Static Asset Filepaths
        string folder_Static = Application.dataPath + "/Static Assets/FolderStructure.txt",
               folder_StaticAnimations = Application.dataPath + "/Static Assets/Animations/FolderStructure.txt",
               folder_StaticEffects = Application.dataPath + "/Static Assets/Effects/FolderStructure.txt",
               folder_StaticModels = Application.dataPath + "/Static Assets/Models/FolderStructure.txt",
               folder_StaticCharacterModels = Application.dataPath + "/Static Assets/Models/Characters/FolderStructure.txt",
               folder_StaticEnvironmentModels = Application.dataPath + "/Static Assets/Models/Environment/FolderStructure.txt",
               folder_StaticPrefabs = Application.dataPath + "/Static Assets/Prefabs/FolderStructure.txt",
               folder_StaticScenes = Application.dataPath + "/Static Assets/Scenes/FolderStructure.txt",
               folder_StaticSounds = Application.dataPath + "/Static Assets/Sounds/FolderStructure.txt",
               folder_StaticSoundsMusic = Application.dataPath + "/Static Assets/Sounds/Music/FolderStructure.txt",
               folder_StaticSoundsSFX = Application.dataPath + "/Static Assets/Sounds/SFX/FolderStructure.txt",
               folder_StaticTextures = Application.dataPath + "/Static Assets/Textures/FolderStructure.txt";
        #endregion

        #endregion

        #region Folder Structure Info

        File.WriteAllText(folder_Dynamic, "All assets that are loaded into the game at runtime go here.");
        File.WriteAllText(folder_DynamicAnimations, "All animations loaded at runtime and their objects they are associated with go here.\nWhen creating an animation, make a folder under sources with the object containing the animation and in animations named after the object.\nImport the animated object into its source folder, then copy the .anim file from the object in sources to its animations folder.\nCreate the animation controller for the object and put it in the AnimationControllers folder.");
        File.WriteAllText(folder_DynamicEffects, "Particle effects loaded at runtime go here.\nMake folders for each particle effect.");
        File.WriteAllText(folder_DynamicModels, "Single-looping animation and non-animated raw models loaded at runtime go here.");
        File.WriteAllText(folder_DynamicCharacterModels,"All models loaded at runtime for player and NPC character models go here.\nCreate folders for models used only in specific scenes.\nUse common for models used in multiple scenes.");
        File.WriteAllText(folder_DynamicEnvironmentModels, "All models loaded at runtime for environmental object models go here.\nCreate folders for models used only in specific scenes.\nUse common for models used in multiple scenes.");
        File.WriteAllText(folder_DynamicPrefabs, "Prefab objects loaded at runtime go here.\nMake sure to create new folders for scenes.\nPrefabs shared across scenes go in common.");
        File.WriteAllText(folder_DynamicSounds, "Sounds loaded at runtime go here.\nMake sure to create new folders for different scenes.\nSounds shared across scenes go in common.");
        File.WriteAllText(folder_DynamicSoundsMusic, "Music loaded at runtime goes here.\nCreate folders for music used in specific scenes.\nMusic shared across scenes goes in common.");
        File.WriteAllText(folder_DynamicSoundsSFX, "Sound effects loaded at runtime go here.\nCreate folders for effects used in specific scenes.\nEffects shared across scenes go in common.");
        File.WriteAllText(folder_DynamicTextures, "Textures applied to models/changed at runtime go here.");


        File.WriteAllText(folder_Editor, "All scripts that edit the editor go here.");
        File.WriteAllText(folder_Extensions, "Third-party assets go here (except for the Standard Assets folder).");
        File.WriteAllText(folder_Gizmos, "All gizmo scripts go here.");
        File.WriteAllText(folder_Plugins, "All plugin scripts go here.");
        File.WriteAllText(folder_Scripts, "All other scripts go here. Make sure to place common scripts (shared across scenes) in the common folder.");
        File.WriteAllText(folder_Shaders, "All shader scripts go here.");

        File.WriteAllText(folder_Static, "All assets not loaded into the game at runtime go here.");
        File.WriteAllText(folder_StaticAnimations, "All animations not loaded at runtime and their objects they are associated with go here.\nWhen creating an animation, make a folder under sources with the object containing the animation and in animations named after the object.\nImport the animated object into its source folder, then copy the .anim file from the object in sources to its animations folder.\nCreate the animation controller for the object and put it in the AnimationControllers folder.");
        File.WriteAllText(folder_StaticEffects, "Particle effects not loaded at runtime go here.\nMake folders for each particle effect.");
        File.WriteAllText(folder_StaticModels, "Single-looping animation and non-animated raw models not loaded at runtime go here.");
        File.WriteAllText(folder_StaticCharacterModels, "All models not loaded at runtime for player and NPC character models go here.\nCreate folders for models used only in specific scenes.\nUse common for models used in multiple scenes.");
        File.WriteAllText(folder_StaticEnvironmentModels, "All models not loaded at runtime for environmental object models go here.\nCreate folders for models used only in specific scenes.\nUse common for models used in multiple scenes.");
        File.WriteAllText(folder_StaticPrefabs, "Prefab objects not loaded at runtime go here.\nMake sure to create new folders for scenes.\nPrefabs shared across scenes go in common.");
        File.WriteAllText(folder_StaticSounds, "Sounds not loaded at runtime go here.\nMake sure to create new folders for different scenes.\nSounds shared across scenes go in common.");
        File.WriteAllText(folder_StaticSoundsMusic, "Music not loaded at runtime goes here.\nCreate folders for music used in specific scenes.\nMusic shared across scenes goes in common.");
        File.WriteAllText(folder_StaticSoundsSFX, "Sound effects not loaded at runtime go here.\nCreate folders for effects used in specific scenes.\nEffects shared across scenes go in common.");
        File.WriteAllText(folder_StaticScenes, "All game scenes go here.");
        File.WriteAllText(folder_StaticTextures, "Textures applied to models/changed at runtime go here.\nUI textures and 2D sprites also go here.\nCreate folders for scenes where textures appear.\nTextures used in multiple scenes go in common.");

        //File.WriteAllText(folder_Testing, "");

        #endregion
    }
}