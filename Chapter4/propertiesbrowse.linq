<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

void Main()
{
	var custombutton = new CustomButton();
	var properties = custombutton.Properties();
	properties.Dump();
}

// Define other methods and classes here
public class CustomButton : System.Windows.Forms.Button
{
    public CustomButton()
	{
         Text = "Custom Button Class";
         Font = new System.Drawing.Font("Segoe UI",12);
	}
}