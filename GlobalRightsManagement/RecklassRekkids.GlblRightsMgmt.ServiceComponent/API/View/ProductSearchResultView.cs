// <copyright file="ProductSearchResultView.cs" company="Recklass Rekkids">
//     Copyright (c) 2017 RecklassRekkids Ltd. All rights Reserved.
// </copyright>
// <author>Saravana</author>

using RecklassRekkids.GlblRightsMgmt.CoreAbstractions.Utilities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.View
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.View;
    using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

    /// <summary>
    /// Product search result view
    /// </summary>
    /// <seealso cref="RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.View.IView{System.Collections.Generic.IEnumerable{RecklassRekkids.GlblRightsMgmt.ServiceEntities.Product}}" />
    public class ProductSearchResultView : IView<IEnumerable<Product>>
    {
        /// <summary>
        /// Renders the view.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>the products</returns>
        string IView<IEnumerable<Product>>.RenderView(IEnumerable<Product> entities)
        {
            var msgHandler = new StringBuilder("output is:\r\n");

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
                        msgHandler.AppendLine($"{e.Artist} | {e.Title} | {e.Usages} | { DateTimeUtil.ConvertToString(e.StartDate)} | {e.EndDate}");
                    }
                }
            }

            return msgHandler.ToString();
        }
    }
}
