<Query Kind="Program" />

void Main()
{
	var button = new System.Windows.Controls.Button {Content = "My Button"};
	button.Click += catchedEvent;
	button.StackWpfControl("Events");
}
private static void catchedEvent(object sender, System.EventArgs args)
{
        PanelManager.GetOutputPanel("Events").Close();
}
