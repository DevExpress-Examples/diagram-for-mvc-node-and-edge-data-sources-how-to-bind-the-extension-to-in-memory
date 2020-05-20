@Code
    ViewData("Title") = "Home Page"
End Code

@ModelType DiagramBindToListVB.Workflow

@Html.DevExpress().Diagram(Sub(settings)
                                    settings.Name = "Diagram"
                                    settings.BatchUpdateRouteValues = New With {.Controller = "Home", .Action = "DiagramUpdate"}
                                    settings.Mappings.Node.Key = "ID"
                                    settings.Mappings.Node.Type = "Type"
                                    settings.Mappings.Node.Text = "Text"
                                    settings.Mappings.Node.Width = "Width"
                                    settings.Mappings.Node.Height = "Height"
                                    settings.Mappings.Node.Style = "Style"
                                    settings.Mappings.Node.TextStyle = "TextStyle"

                                    settings.Mappings.Edge.Key = "ID"
                                    settings.Mappings.Edge.FromKey = "FromID"
                                    settings.Mappings.Edge.ToKey = "ToID"
                                    settings.Mappings.Edge.Text = "Text"

                                    settings.Units = DevExpress.Web.ASPxDiagram.DiagramUnit.Px
                                    settings.SettingsAutoLayout.Type = DevExpress.Web.ASPxDiagram.DiagramAutoLayout.Layered
                                    settings.SettingsAutoLayout.Orientation = Orientation.Vertical
                                End Sub).Bind(Model.Objects, Model.Connections).GetHtml()