using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using UnityEngine;


public class DataLoader : MonoBehaviour
{
    [Header("Excel存储路径")]
    public string assetPath = "Assets/Resources/Data";
    [Header("Excel读取路径")]
    public string excelFolderPath = "/Data";

    public static DataLoader Instance { get; private set; }

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        excelFolderPath = Application.dataPath + excelFolderPath;
    }

    void Update()
    {
        
    }
}


// public class ExcelTool  
// {
//     public static Dialog[] CreatItemArrayWithExcel(string filePath)
//     {
//         //行与列
//         int columnNum = 0, rowNum = 0;
//         DataRowCollection collection = ReadExcel(filePath, ref columnNum, ref rowNum);//获得行与列的值
//         //从第三行开始才是有效数据
//         Dialog[] array = new Dialog[rowNum - 2];
//         for (int i = 2; i < rowNum; i++)
//         {
//             Dialog item = new Dialog
//             {
//                 ID = collection[i][0].ToString(),
//                 Char = collection[i][1].ToString(),
//                 Icon = collection[i][2].ToString(),
//                 TID = collection[i][3].ToString(),
//             };
//             array[i - 2] = item;
//         }
//         return array;
//     }

//     static DataRowCollection ReadExcel(string filePath, ref int columnnum, ref int rownum)
//     {
//         FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
//         IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
//         DataSet result = excelReader.AsDataSet(); 
//         //Tables[0] 下标0表示excel文件中第一张表的数据
//         columnnum = result.Tables[0].Columns.Count;
//         rownum = result.Tables[0].Rows.Count;
//         stream.Close();
//         return result.Tables[0].Rows; 
//     }
// }


public class ExcelLineManage: ScriptableObject  
{
    public Dialog[] dialogArray;
    public TID[] TIDArray;
}


[System.Serializable]
public class Dialog
{
    public string ID;
    public string Char;
    public string Icon;
    public string TID;
}


[System.Serializable]
public class TID
{
    public int ID;
    public string Text; 
}

