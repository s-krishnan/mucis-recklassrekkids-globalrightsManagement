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
    public class ProductSearchErrorView : IView<IEnumerable<Error>>
    {
        string IView<IEnumerable<Error>>.RenderView(IEnumerable<Error> entities)
        {
            StringBuilder msgHandler = new StringBuilder("Error Occured in search, please check the user input. More details:");

            if (entities != null)
            {
                foreach (var e in entities)
                {
                    msgHandler.AppendLine(e.exception.ToString());
                }
            }

            return msgHandler.ToString();
        }
    }
}
