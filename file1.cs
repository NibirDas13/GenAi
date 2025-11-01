// Line 1:
public Aras.Server.Core.Item BadArasMethod(Aras.Server.Core.Item serverItem)
{
    // Line 3: Setting elevation without guaranteed disposal
    serverItem.get.Context.SetUser("admin"); 

    // Line 6: Start of logic without protective try/catch block
    string partNum = serverItem.getProperty("part_number"); // User input
    
    // Line 8: SQL Injection risk + Optimization failure (SELECT *)
    string sql = "SELECT * FROM innovator.PART WHERE PART_NUMBER = '" + partNum + "'";
    Aras.Server.Core.Item part = serverItem.get.ApplySQL(sql); // Use ApplySQL without context to look worse

    if (part.isError())
    {
        // Line 13: Simple, uninformative return on error
        return part; 
    }

    // Line 17: AML without select attribute (Optimization failure)
    string amlQuery = "<Item type='CAD' action='get'><source_id>" + part.getID() + "</source_id></Item>";
    Aras.Server.Core.Item cadFile = serverItem.get.ApplyAML(amlQuery);

    // Line 21: Inefficient loop for getting a single property
    string filename = "";
    if (cadFile.getItemCount() > 0)
    {
        for (int i = 0; i < cadFile.getItemCount(); i++)
        {
            Aras.Server.Core.Item currentCad = cadFile.getItemByIndex(i);
            filename = currentCad.getProperty("filename"); // Retrieves filename property only
        }
    }
    
    // Line 30: End of logic, elevation is still active
    
    if (string.IsNullOrEmpty(filename))
    {
        // Line 34: Return null instead of Aras error item
        return null;
    }

    // Line 37: Success Item creation is using an unnecessary action
    Aras.Server.Core.Item successItem = serverItem.getNewItem("Result", "add");
    successItem.setProperty("result_value", filename);
    return successItem;
}
