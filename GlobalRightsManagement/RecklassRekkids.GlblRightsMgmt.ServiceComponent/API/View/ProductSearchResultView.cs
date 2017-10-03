using System.Text;
using System.Collections.Generic;
using System.Linq;

using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.View;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.View
{
    public class ProductSearchResultView : IView<IEnumerable<Product>>
    {
        string IView<IEnumerable<Product>>.RenderView(IEnumerable<Product> entities)
        {
            StringBuilder msgHandler = new StringBuilder("output is:\r\n");

            if (entities == null || entities.Count<Product>() <= 0)
            {
                msgHandler.AppendLine("No data found for the given input, please try different input.");
            }
            else
            { 
                msgHandler.AppendLine("Artist | Title | Usage | StartDate | EndDate");

                if (entities != null)
                {
                    foreach (var e in entities)
                    {
                        msgHandler.AppendLine($"{e.Artist} | {e.Title} | {e.Usages} | {e.StartDate} | {e.EndDate}");
                    }
                }
            }
            return msgHandler.ToString();
        }
    }
}
