using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

/// <summary>
/// @Author Jake Skov
/// @Desc Creates the Editor Window for the map creation tool and handles the file's export
/// </summary>
public class EditorMapBuilder : EditorWindow
{
    public static string levelName;
    public static string authorName;

    public int SideLength { get; set; }

    [MenuItem("Editor Tools/Map Creator")]

    static void Init()
    {
        EditorMapBuilder mapCreator = (EditorMapBuilder)EditorWindow.GetWindow(typeof(EditorMapBuilder));
        mapCreator.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Map Builder");
        EditorGUILayout.Separator();

        EditorGUILayout.BeginVertical();

        //Sets up Map Select Data
        levelName = EditorGUILayout.TextField("Level Name:\t", levelName);
        authorName = EditorGUILayout.TextField("Created by:\t", authorName);

        EditorGUILayout.Separator();

        //Establishes Map Size
        EditorGUILayout.LabelField("Map Side Length (in hexes)");
        SideLength = EditorGUILayout.IntSlider(SideLength, 3, 5);

        EditorGUILayout.Separator();

        //Sets up the Map
        if (GUILayout.Button("Generate Map"))
        {
            EditorMapBuilderEditing.MapRandomize(SideLength);
        }

        //Displays the Map
        if (EditorMapBuilderEditing.type != null)
        {
            MapGenerator(EditorMapBuilderEditing.type, SideLength);
        }

        EditorGUILayout.Separator();

        //Exports map to a text file
        if (GUILayout.Button("Export Map") && EditorMapBuilderEditing.type != null)
        {
            EditorMapBuilderEditing.Export(EditorMapBuilderEditing.type);
        }

        EditorGUILayout.EndVertical();
    }

    public static void MapGenerator(ResourceTypes[] tile, int sideLength)
    {
        //Creates the "Map" as a collecton of buttons which cycle through the Resource types enum
        switch (sideLength)
        {
            case 3:
                //Row 1
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[0].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[0]);
                }
                if (GUILayout.Button(tile[1].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[1]);
                }
                if (GUILayout.Button(tile[2].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[2]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 2
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[3].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[3]);
                }
                if (GUILayout.Button(tile[4].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[4]);
                }
                if (GUILayout.Button(tile[5].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[5]);
                }
                if (GUILayout.Button(tile[6].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[6]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 3
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[7].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[7]);
                }
                if (GUILayout.Button(tile[8].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[8]);
                }
                if (GUILayout.Button(tile[9].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[9]);
                }
                if (GUILayout.Button(tile[10].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[10]);
                }
                if (GUILayout.Button(tile[11].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[11]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 4
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[12].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[12]);
                }
                if (GUILayout.Button(tile[13].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[13]);
                }
                if (GUILayout.Button(tile[14].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[14]);
                }
                if (GUILayout.Button(tile[15].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[15]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 5
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[16].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[16]);
                }
                if (GUILayout.Button(tile[17].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[17]);
                }
                if (GUILayout.Button(tile[18].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[18]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion;
                break;

            case 4:
                //Row 1
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[0].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[0]);
                }
                if (GUILayout.Button(tile[1].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[1]);
                }
                if (GUILayout.Button(tile[2].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[2]);
                }
                if (GUILayout.Button(tile[3].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[3]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 2
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[4].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[4]);
                }
                if (GUILayout.Button(tile[5].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[5]);
                }
                if (GUILayout.Button(tile[6].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[6]);
                }
                if (GUILayout.Button(tile[7].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[7]);
                }
                if (GUILayout.Button(tile[8].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[8]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 3
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[9].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[9]);
                }
                if (GUILayout.Button(tile[10].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[10]);
                }
                if (GUILayout.Button(tile[11].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[11]);
                }
                if (GUILayout.Button(tile[12].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[12]);
                }
                if (GUILayout.Button(tile[13].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[13]);
                }
                if (GUILayout.Button(tile[14].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[14]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 4
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[15].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[15]);
                }
                if (GUILayout.Button(tile[16].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[16]);
                }
                if (GUILayout.Button(tile[17].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[17]);
                }
                if (GUILayout.Button(tile[18].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[18]);
                }
                if (GUILayout.Button(tile[19].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[19]);
                }
                if (GUILayout.Button(tile[20].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[20]);
                }
                if (GUILayout.Button(tile[21].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[21]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 5
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[22].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[22]);
                }
                if (GUILayout.Button(tile[23].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[23]);
                }
                if (GUILayout.Button(tile[24].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[24]);
                }
                if (GUILayout.Button(tile[25].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[25]);
                }
                if (GUILayout.Button(tile[26].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[26]);
                }
                if (GUILayout.Button(tile[27].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[27]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 6
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[28].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[28]);
                }
                if (GUILayout.Button(tile[29].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[29]);
                }
                if (GUILayout.Button(tile[30].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[30]);
                }
                if (GUILayout.Button(tile[31].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[31]);
                }
                if (GUILayout.Button(tile[32].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[32]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 7
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[33].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[33]);
                }
                if (GUILayout.Button(tile[34].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[34]);
                }
                if (GUILayout.Button(tile[35].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[35]);
                }
                if (GUILayout.Button(tile[36].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[36]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion
                break;

            case 5:
                //Row 1
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[0].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[0]);
                }
                if (GUILayout.Button(tile[1].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[1]);
                }
                if (GUILayout.Button(tile[2].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[2]);
                }
                if (GUILayout.Button(tile[3].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[3]);
                }
                if (GUILayout.Button(tile[4].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[4]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 2
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[5].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[5]);
                }
                if (GUILayout.Button(tile[6].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[6]);
                }
                if (GUILayout.Button(tile[7].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[7]);
                }
                if (GUILayout.Button(tile[8].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[8]);
                }
                if (GUILayout.Button(tile[9].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[9]);
                }
                if (GUILayout.Button(tile[10].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[10]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 3
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[11].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[11]);
                }
                if (GUILayout.Button(tile[12].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[12]);
                }
                if (GUILayout.Button(tile[13].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[13]);
                }
                if (GUILayout.Button(tile[14].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[14]);
                }
                if (GUILayout.Button(tile[15].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[15]);
                }
                if (GUILayout.Button(tile[16].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[16]);
                }
                if (GUILayout.Button(tile[17].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[17]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 4
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[18].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[18]);
                }
                if (GUILayout.Button(tile[19].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[19]);
                }
                if (GUILayout.Button(tile[20].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[20]);
                }
                if (GUILayout.Button(tile[21].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[21]);
                }
                if (GUILayout.Button(tile[22].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[22]);
                }
                if (GUILayout.Button(tile[23].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[23]);
                }
                if (GUILayout.Button(tile[24].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[24]);
                }
                if (GUILayout.Button(tile[25].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[25]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 5
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[26].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[26]);
                }
                if (GUILayout.Button(tile[27].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[27]);
                }
                if (GUILayout.Button(tile[28].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[28]);
                }
                if (GUILayout.Button(tile[29].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[29]);
                }
                if (GUILayout.Button(tile[30].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[30]);
                }
                if (GUILayout.Button(tile[31].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[31]);
                }
                if (GUILayout.Button(tile[32].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[32]);
                }
                if (GUILayout.Button(tile[33].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[33]);
                }
                if (GUILayout.Button(tile[34].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[34]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 6
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[35].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[35]);
                }
                if (GUILayout.Button(tile[36].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[36]);
                }
                if (GUILayout.Button(tile[37].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[37]);
                }
                if (GUILayout.Button(tile[38].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[38]);
                }
                if (GUILayout.Button(tile[39].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[39]);
                }
                if (GUILayout.Button(tile[40].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[40]);
                }
                if (GUILayout.Button(tile[41].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[41]);
                }
                if (GUILayout.Button(tile[42].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[42]);
                }
                EditorGUILayout.EndHorizontal();

                #endregion

                //Row 7
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[43].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[43]);
                }
                if (GUILayout.Button(tile[44].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[44]);
                }
                if (GUILayout.Button(tile[45].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[45]);
                }
                if (GUILayout.Button(tile[46].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[46]);
                }
                if (GUILayout.Button(tile[47].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[47]);
                }
                if (GUILayout.Button(tile[48].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[48]);
                }
                if (GUILayout.Button(tile[49].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[49]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 8
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[50].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[50]);
                }
                if (GUILayout.Button(tile[51].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[51]);
                }
                if (GUILayout.Button(tile[52].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[52]);
                }
                if (GUILayout.Button(tile[53].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[53]);
                }
                if (GUILayout.Button(tile[54].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[54]);
                }
                if (GUILayout.Button(tile[55].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[55]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion

                //Row 9
                #region
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(tile[56].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[56]);
                }
                if (GUILayout.Button(tile[57].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[57]);
                }
                if (GUILayout.Button(tile[58].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[58]);
                }
                if (GUILayout.Button(tile[59].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[59]);
                }
                if (GUILayout.Button(tile[60].ToString()))
                {
                    EditorMapBuilderEditing.MapEdit(tile[60]);
                }
                EditorGUILayout.EndHorizontal();
                #endregion
                break;
        }
    }
}