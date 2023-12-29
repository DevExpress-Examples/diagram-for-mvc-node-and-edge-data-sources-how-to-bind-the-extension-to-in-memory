<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/240053564/20.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T861989)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Diagram for MVC - Node and Edge data sources - How to bind the extension to in-memory data sources

The DevExpress ASP.NET MVC  [Diagram](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.DiagramExtension)  extension provides the  [Bind(object nodeDataObject, object edgeDataObject)](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.DiagramExtension.Bind(System.Object-System.Object))  method that allows you to load a tree or a graph structure from two data sources: the  **nodeDataObject**  for shapes and  **edgeDataObject**  for shape connectors.

While binding, the extension automatically creates shapes and connectors and retrieves their property values from the corresponding data items. The extension implements mapping properties that point to the data fields that contain the data:

* The  [DiagramSettings.Mappings.Node](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramMappings.Node)  property provides access to node mapping properties.
* The  [DiagramSettings.Mappings.Edge](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramMappings.Edge)  property provides access to edge mapping properties.

You should add mapping information for a shape's  [Key](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramMappingInfo.Key)  and a connector's  [Key](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramMappingInfo.Key),  [FromKey](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramEdgeMappingInfo.FromKey), and  [ToKey](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramEdgeMappingInfo.ToKey)  properties.

The  [BatchUpdateRouteValues](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.DiagramSettings.BatchUpdateRouteValues)  property specifies a Controller and Action that handle callbacks related to node and edge updates. When you update inserted items' data, use the  [MapInsertedItemKey](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.MVCxDiagramItemUpdateValues-2.MapInsertedItemKey(-0--1))  method to provide key values for the items.

The  [SettingsAutoLayout](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.DiagramSettings.SettingsAutoLayout)  property specifies the auto-layout algorithm and orientation the extension uses to build a diagram.  

## Files to Review

* [Index.cshtml](./CS/DiagramBindToList/Views/Home/Index.cshtml) (VB: [Index.vbhtml](./VB/DiagramBindToListVB/Views/Home/Index.vbhtml))
* [HomeController.cs](./CS/DiagramBindToList/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DiagramBindToListVB/Controllers/HomeController.vb))
* [Node.cs](./CS/DiagramBindToList/Models/Node.cs) (VB: [Node.vb](./VB/DiagramBindToListVB/Models/Node.vb))
* [Edge.cs](./CS/DiagramBindToList/Models/Edge.cs) (VB: [Edge.vb](./VB/DiagramBindToListVB/Models/Edge.vb))
* [WorkflowDataProvider.cs](./CS/DiagramBindToList/Models/WorkflowDataProvider.cs) (VB: [WorkflowDataProvider.vb](./VB/DiagramBindToListVB/Models/WorkflowDataProvider.vb))


## More Examples

* [Diagram for MVC - Tree from Linear Data Structure - How to bind the extension to an in-memory data source](https://github.com/DevExpress-Examples/diagram-for-mvc-tree-from-linear-data-structure-how-to-bind-to-an-in-memory-data-source)  
* [Diagram for MVC - How to bind containers to an in-memory data source](https://github.com/DevExpress-Examples/diagram-for-mvc-how-to-bind-containers-to-an-in-memory-data-source)
