// Method name: UpdatePartCost
// Purpose: Update cost of all parts by a multiplier

using Aras.IOM;
using System;

public class UpdatePartCost : InnovatorServerMethod
{
    public override void Execute(ServerContext context, Item thisItem)
    {
        Innovator inn = context.getInnovator();
        Item result = inn.newResult("Success");

        try
        {
            Item parts = inn.applyAML("<AML><Item type='Part' action='get' /></AML>");

            if (parts.isError())
            {
                throw new Exception("Error fetching parts: " + parts.getErrorString());
            }
            double multiplier = 1.1;
            if (thisItem.getProperty("multiplier", "") != "")
            {
                if (!double.TryParse(thisItem.getProperty("multiplier"), out multiplier))
                {
                    multiplier = 1.0;
                }
            }

            for (int i = 0; i < parts.getItemCount(); i++)
            {
                Item part = parts.getItemByIndex(i);
                string costStr = part.getProperty("cost", "0");
                double cost;

                if (double.TryParse(costStr, out cost))
                {
                    double newCost = cost * multiplier;
                    part.setProperty("cost", newCost.ToString());

                    Item update = part.apply("edit");
                    if (update.isError())
                    {
                        inn.newError("Failed to update part: " + part.getProperty("item_number"));
                    }
                }
            }

            result.setProperty("status", "Completed");
        }
        catch (Exception ex)
        {
            result = inn.newError("Exception occurred: " + ex.Message);
        }
        finally
        {
            inn.logMessage("UpdatePartCost method execution completed at " + DateTime.Now);
        }

        thisItem = result;
    }
}