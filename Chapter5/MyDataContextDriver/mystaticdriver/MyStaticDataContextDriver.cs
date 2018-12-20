using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LINQPad.Extensibility.DataContext;

namespace MyDataContextDriver.mystaticdriver
{
    public class MyStaticDataContextDriver : StaticDataContextDriver
    {
        // We'll use the description of the custom type and its assembly for Static Drivers
        public override string GetConnectionDescription(IConnectionInfo cxInfo) => cxInfo.CustomTypeInfo.GetCustomTypeDescription();

        public override bool ShowConnectionDialog(IConnectionInfo cxInfo, bool isNewConnection) => new ConnectionDialog(cxInfo).ShowDialog() == true;

        public override string Name => "My Static Data Context Driver (Demo)";
        public override string Author => "Getting the Most from LINQPad Succinctly";

        public override List<ExplorerItem> GetSchema(IConnectionInfo cxInfo, Type customType)
        {
            //First, we iterate throught all top level properties of custumType
            var topLevelProps =
            (
                from prop in customType.GetProperties()
                where prop.PropertyType != typeof (string)

                // Get and display all properties of IEnumerable<T>
                let ienumerableOfT = prop.PropertyType.GetInterface ("System.Collections.Generic.IEnumerable`1")
                where ienumerableOfT != null

                orderby prop.Name

                select new ExplorerItem (prop.Name, ExplorerItemKind.QueryableObject, ExplorerIcon.Table)
                {
                    IsEnumerable = true,
                    ToolTipText = FormatTypeName (prop.PropertyType, false),

                    // Store entity type to the Tag property. This will be used later.
                    Tag = ienumerableOfT.GetGenericArguments()[0]
                }

            ).ToList ();

            // Create a lookup element, associating each element type to the properties of that type.
            // This will allow to build hyperlinks which let the user click between relationships.
            var elementTypeLookup = topLevelProps.ToLookup (tp => (Type)tp.Tag);

            // Populate the properties of each entity
            foreach (var table in topLevelProps)
                table.Children = ((Type)table.Tag)
                    .GetProperties()
                    .Select (childProp => GetChildItem (elementTypeLookup, childProp))
                    .OrderBy (childItem => childItem.Kind)
                    .ToList ();

            return topLevelProps;
        }

        private ExplorerItem GetChildItem (ILookup<Type, ExplorerItem> elementTypeLookup, PropertyInfo childProp)
        {
            //if the property's type is in the list of entities, then we're going to assume that it's a Many:1 or
            //1:1 referefence. It's not reliable to identify 1:1s relationships purely from reflection.
            if (elementTypeLookup.Contains (childProp.PropertyType))
                return new ExplorerItem (childProp.Name, ExplorerItemKind.ReferenceLink, ExplorerIcon.ManyToOne)
                {
                    HyperlinkTarget = elementTypeLookup [childProp.PropertyType].First (),
                    ToolTipText = FormatTypeName (childProp.PropertyType, true) // FormatTypeName is a LINQPad's helper method that returns a nicely formatted type name.
                };

            //We're going to check if the property's type is a collection of entities
            var ienumerableOfT = childProp.PropertyType.GetInterface ("System.Collections.Generic.IEnumerable`1");

            // If it isn't we return the Name and Type of the property as an ExplorerItem
            if (ienumerableOfT == null) return new ExplorerItem(childProp.Name + " (" + FormatTypeName(childProp.PropertyType, false) + ")",ExplorerItemKind.Property, ExplorerIcon.Column);

            //Now, we're going to check if it is a 1:Many relationship
            var elementType = ienumerableOfT.GetGenericArguments()[0];

            if (elementTypeLookup.Contains(elementType))
                return new ExplorerItem (childProp.Name, ExplorerItemKind.CollectionLink, ExplorerIcon.OneToMany)
                {
                    HyperlinkTarget = elementTypeLookup [elementType].First (),
                    ToolTipText = FormatTypeName (elementType, true)
                };

            //If it isn't, this is an ordinary property.
            return new ExplorerItem (childProp.Name + " (" + FormatTypeName (childProp.PropertyType, false) + ")",
                ExplorerItemKind.Property, ExplorerIcon.Column);
        }
    }
}
