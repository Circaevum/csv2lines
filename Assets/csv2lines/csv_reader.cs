using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using CsvHelper;
using System.Globalization;
using System.IO;

public class csv_reader : MonoBehaviour
{
    public GameObject LineBool;
    public GameObject LineInt;
    public GameObject LineDouble;

    void Start()
    {
        List<SchoolData> dataList;
        string filePath = Application.streamingAssetsPath + "/data.csv";
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            dataList = csv.GetRecords<SchoolData>().ToList();
        }
        int i = 0;
        //Iterate through each property of the SchoolData data class
        foreach (var property in typeof(SchoolData).GetProperties())
        {
            var columnValues = dataList.Select(property.GetValue).ToList();
            

            switch (Type.GetTypeCode(property.PropertyType))
            {
                //Create lineRenderer specific to INT value types
                case TypeCode.Int32:
                    var intArray = columnValues.Cast<int>().ToArray();
                    GameObject newIntLine = Instantiate(LineInt);
                    newIntLine.SetActive(true);
                    newIntLine.transform.SetParent(transform);
                    newIntLine.transform.position = new Vector3(0, 0, 0);
                    newIntLine.GetComponent<line_int>().Run(intArray, (float)i / 10.0f);
                    break;

                //Create lineRenderer specific to DOUBLE value types
                case TypeCode.Double:
                    var doubleArray = columnValues.Cast<double>().ToArray();
                    GameObject newDoubleLine = Instantiate(LineDouble);
                    newDoubleLine.SetActive(true);
                    newDoubleLine.transform.SetParent(transform);
                    newDoubleLine.transform.position = new Vector3(0,0,0);
                    newDoubleLine.GetComponent<line_double>().Run(doubleArray, (float)i /10.0f);
                    break;

                //Create lineRenderer specific to BOOLEAN value types
                case TypeCode.Boolean:
                    var booleanArray = columnValues.Cast<bool>().ToArray();
                    GameObject newBoolLine = Instantiate(LineBool);
                    newBoolLine.SetActive(true);
                    newBoolLine.transform.SetParent(transform);
                    newBoolLine.transform.position = new Vector3(0, 0, 0);
                    newBoolLine.GetComponent<line_bool>().Run(booleanArray, (float)i / 10.0f);
                    break;

                //Skip STRING value types for now. All strings are same length for this dataset. Will improve later
                case TypeCode.String:
                    break;

                default:
                    throw new NotSupportedException($"Unsupported type: {property.PropertyType}");
            }
            i++;
        }
    }
}