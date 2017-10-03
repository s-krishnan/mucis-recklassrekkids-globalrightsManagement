// <copyright file="ProductSearchErrorView.cs" company="Recklass Rekkids">
//     Copyright (c) 2017 RecklassRekkids Ltd. All rights Reserved.
// </copyright>
// <author>Saravana</author>

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.View
{
    using System.Collections.Generic;
    using System.Text;
    using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.View;
    using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

    /// <summary>
    /// Product search error view
    /// </summary>
    /// <seealso cref="RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.View.IView{System.Collections.Generic.IEnumerable{RecklassRekkids.GlblRightsMgmt.ServiceEntities.Error}}" />
    public class ProductSearchErrorView : IView<IEnumerable<Error>>
    {
        /// <summary>
        /// Renders the view.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>the errors</returns>
        string IView<IEnumerable<Error>>.RenderView(IEnumerable<Error> entities)
        {
            var msgHandler = new StringBuilder("Error Occured in search, please check the user input. More details:");

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
