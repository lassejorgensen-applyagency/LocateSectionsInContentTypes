using Newtonsoft.Json;
using System.Xml;
using Types;

// File paths
string contentTypesDirectory = "C:\\Solutions\\Apply.Brobizz\\Apply.BroBizz.Web\\uSync\\v8\\ContentTypes";
string dataTypesJson = "C:\\Scripts\\ComponentsAndThemes_V2\\UDF_DTKEY.json";
string outputJsonPath_V1 = "C:\\Scripts\\ComponentsAndThemes_V2\\ContentTypesSections.json";
string outputJsonPath_V2 = "C:\\Scripts\\ComponentsAndThemes_V2\\ComponentsAndTheirContentSections_V2.json";
string outputUniqueValuesPath = "C:\\Scripts\\ComponentsAndThemes_V2\\UniqueDataTypeValues.json";
string outputUniqueComponentsPath = "C:\\Scripts\\ComponentsAndThemes_V2\\OutputUniqueComponents.json";

// Ignored values
var ignoredValues = new List<string>
{
    "75a49726-889f-4dfe-b780-527fb3ba8975",
    "de2b4f2b-dda8-4aab-8f7d-20dcc70af2d8",
    "dbfb3960-800b-4d48-9639-b1a92a18996e",
    "7b7b474b-ecbe-498f-b1bc-d762b78c2739",
    "c88cc3df-b802-4153-8925-a6f31ea49abc",
    "7780a021-85e1-4689-a5f3-17bad770b9e5",
    "da1830f4-3011-4570-891b-f19a80fdfed3",
    "00459ddf-d792-4501-9a9b-f0f83af951f1",
    "21cb31d1-9e40-432f-a36f-309a37e16e2f",
    "8de33a53-3ff9-485d-8c7e-42e479e4cacc",
    "c07a3bc4-1910-4da8-b366-d5c6ed1644fe",
    "4579848f-92e2-405d-8bba-11c91c4bc880",
    "e0c32eb9-f5f6-4a5c-b44d-de9b73247932",
    "035d2aea-6ebf-47e7-8dfa-abf7389ae021",
    "5c2201e0-6a6f-4124-af72-a527303253e2",
    "43826fb9-b098-4ec3-9321-9fd781e92ed6",
    "aa71d855-6166-46e6-a217-1788c1657b48",
    "8cfbbec4-acdb-4981-be5b-ea1ab9231df9",
    "51cdea22-8869-48e7-aec3-73bec3a7f919",
    "5500ed9e-8a6d-495b-8474-c03ad18d21b4",
    "76f16f3a-7e2f-4f99-ab89-ad3942b476c8",
    "a0ef37b3-4b3c-4e79-b452-62df5dde9aba",
    "85e08192-48d4-4e26-8ee9-b6229e22da79",
    "9481c923-eedf-4250-92eb-3c934f553481",
    "e7f0ebe7-435f-4028-b53a-3bbee16a2e93",
    "597d9653-b684-482a-84fc-a91a4e49932c",
    "faa82e8b-60af-471b-a89d-1004b60e3584",
    "2dc13fec-813f-482e-b109-8805004e517b",
    "7f6a4ca5-a436-474d-a3ea-f6cd1e808c22",
    "3d8ff86d-53a1-4e07-8cce-d5c328d186ff",
    "4af4a95d-8ee0-4c69-bb65-89fc189b8c44",
    "6455ff8d-66bd-4928-be56-5de3156aae0b",
    "f532bb1a-19b8-4065-be2b-53dd6e3c0e8c",
    "7e8bd2ca-2396-41f2-8aa8-1719c695e615",
    "cd36ca37-c02c-477f-8a97-e7abf90eb81b",
    "3df3902e-beaa-4726-8f3d-1ab56d4a5315",
    "45f416b9-4c2b-4103-8a18-e55f57e5d1d9",
    "23948c2d-92c9-4cfc-ac5d-afe34e7d11d9",
    "f08ed18d-8ec8-496a-bc32-9cbf69f05cee",
    "65271331-73b3-41b0-8d00-86c58cc407b8",
    "ab5516c7-ae09-4e99-a4ec-e498895cad78",
    "bdbfd2d9-a5b3-4412-9938-ec1acc7ba56b",
    "663bd7f5-6812-4ed6-b062-29fce1caa55b",
    "84ab8fde-5f81-409a-ad41-6ff3c9753092",
    "b585d342-72ba-42cd-92c1-9419113a19a3",
    "5042844c-8db3-4b7a-ac86-a0ed8cc363ea",
    "8c359654-8cf6-4067-933c-7c833952904d",
    "e05d3f14-b501-4dd5-b0e5-0492199cbdba",
    "d16b8198-aff6-4a45-ae8b-6154e2171fac",
    "1ce44a99-1dc0-4eef-929d-dc27c40827ae",
    "57a5eeb8-ac2e-4e12-8af7-30606ede3a2a",
    "ccdd9051-bfee-460d-b6c1-547d89629dea",
    "c833d4c1-b09d-411d-be20-665df23bf9ee",
    "d26cc43a-3c00-4e5e-9ea6-2471da275726",
    "c0ab6acd-65b9-4a4b-922e-9992365f421b",
    "ea67b5de-e3b7-44a4-87e3-06f9301f2377",
    "0e8a5bd4-fbb0-4a8d-a97f-fdd6b0cafd8d",
    "01bf5f30-0f7a-46b3-abdc-4c5996a9ca1e",
    "c44f263a-e890-4b58-a5c4-1770bc60cab8",
    "d0372d2d-1f6b-409f-86d5-d0e9739d185a",
    "a7caafcb-1bc0-46ba-8d2f-9f5cd3860e91",
    "aba4ee82-77c3-4eaf-b703-f57760aad632",
    "95b39609-721b-4760-a63d-06a889a5fbe6",
    "34b1f8b5-68d3-4947-9477-94d9847ca0e6",
    "c3a37b50-f725-44d5-b80a-0be40a2f0818",
    "d288e525-b1cb-448f-b9dd-265fc689ab44",
};

// Ensure content directory exists
if (!Directory.Exists(contentTypesDirectory))
{
    Console.WriteLine($"The directory path '{contentTypesDirectory}' does not exist. Exiting script.");
    Environment.Exit(0);
}

// Load content type files
var contentTypeFiles = Directory.GetFiles(contentTypesDirectory);
if (contentTypeFiles.Length == 0)
{
    Console.WriteLine("No files found in the directory. Exiting script.");
    Environment.Exit(0);
}

// Ensure data types JSON exists
if (!File.Exists(dataTypesJson))
{
    Console.WriteLine("File not read successfully.");
    Environment.Exit(0);
}

// Load JSON data
string dataTypesJsonString = File.ReadAllText(dataTypesJson);
var jsonArray = JsonConvert.DeserializeObject<List<DataTypesJsonObject>>(dataTypesJsonString);

// Initialize data structures
var definitionKeysSet = new HashSet<string>(jsonArray.Select(item => item.DataTypeKeyAttribute));
var groupedData_V2 = new Dictionary<string, DataTypesJsonObject>();
List<string> uniqueValues = new List<string>();
List<string> uniqueComponents = new List<string>();

// Process content type files
foreach (var file in contentTypeFiles)
{
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(file);

    XmlNode? contentTypeNode = xmlDoc.SelectSingleNode("//ContentType/Info/Name");
    string? contentTypeName = contentTypeNode?.InnerText;

    XmlNodeList? genericPropertyChild = xmlDoc.SelectNodes("//ContentType/GenericProperties/GenericProperty");
    if (genericPropertyChild == null) continue;

    foreach (XmlNode nestedGenericProperty in genericPropertyChild)
    {
        XmlNode? contentTypeKeyAtt = nestedGenericProperty.SelectSingleNode("Definition");
        XmlNode? nameAtt = nestedGenericProperty.SelectSingleNode("Name");

        string? contentTypeKeyValue = contentTypeKeyAtt?.InnerText;
        string? nameValue = nameAtt?.InnerText;
        var sectionsSyntax = contentTypeName + " -> " + nameValue;

        if (definitionKeysSet.Contains(contentTypeKeyValue) && !ignoredValues.Contains(contentTypeKeyValue))
        {
            if (!string.IsNullOrEmpty(contentTypeName) && !string.IsNullOrEmpty(nameValue))
            {
                // Match definition key
                var matchedObject = jsonArray.FirstOrDefault(obj => obj.DataTypeKeyAttribute == contentTypeKeyValue);
                if (matchedObject?.DataTypeValues != null)
                {
                    // Collect unique values
                    foreach (var dataTypeValue in matchedObject.DataTypeValues)
                    {
                        if (!uniqueValues.Contains(dataTypeValue))
                        {
                            uniqueValues.Add(dataTypeValue);
                        }
                    }

                    // Collect unique components
                    if (!uniqueComponents.Contains(matchedObject.DataTypeInfoName))
                    {
                        uniqueComponents.Add(matchedObject.DataTypeInfoName);
                    }

                    // Populate grouped data
                    if (!groupedData_V2.ContainsKey(matchedObject.DataTypeInfoName))
                    {
                        groupedData_V2[matchedObject.DataTypeInfoName] = new DataTypesJsonObject();
                    }

                    groupedData_V2[matchedObject.DataTypeInfoName].DataTypeKeyAttribute = contentTypeKeyValue;
                    foreach (var dataTypeValue in matchedObject.DataTypeValues)
                    {
                        if (!groupedData_V2[matchedObject.DataTypeInfoName].DataTypeValues.Contains(dataTypeValue))
                        {
                            groupedData_V2[matchedObject.DataTypeInfoName].DataTypeValues.Add(dataTypeValue);
                        }
                    }

                    if (!groupedData_V2[matchedObject.DataTypeInfoName].DataTypeSections.Contains(sectionsSyntax))
                    {
                        groupedData_V2[matchedObject.DataTypeInfoName].DataTypeSections.Add(sectionsSyntax);
                    }
                }
            }
        }
    }
}

// Sort and save unique values and components
uniqueValues.Sort();
uniqueComponents.Sort();
var sortedGroupedData_V2 = groupedData_V2
    .OrderBy(entry => entry.Key)
    .ToDictionary(entry => entry.Key, entry => entry.Value);

File.WriteAllText(outputJsonPath_V2, JsonConvert.SerializeObject(sortedGroupedData_V2, Newtonsoft.Json.Formatting.Indented));
File.WriteAllText(outputUniqueValuesPath, JsonConvert.SerializeObject(uniqueValues, Newtonsoft.Json.Formatting.Indented));
File.WriteAllText(outputUniqueComponentsPath, JsonConvert.SerializeObject(uniqueComponents, Newtonsoft.Json.Formatting.Indented));

Console.WriteLine($"Processing complete. Grouped data saved to {outputJsonPath_V1}.");
Console.WriteLine($"Unique values saved to {outputUniqueValuesPath}.");
Console.WriteLine($"Unique components saved to {outputUniqueComponentsPath}.");
