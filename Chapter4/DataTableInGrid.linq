<Query Kind="Statements">
  <Connection>
    <ID>7ac5fd27-655b-4515-ae84-833b8183c097</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>D:\LINQPad Samples\uspostalcodes\bin\Debug\uspostalcodes.dll</CustomAssemblyPath>
    <CustomTypeName>uspostalcodes.uspostalcodesEntities</CustomTypeName>
    <AppConfigPath>D:\LINQPad Samples\uspostalcodes\bin\Debug\uspostalcodes.dll.config</AppConfigPath>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

var statestable = states.Select(row => new {row.state_id,row.state_name, row.state_abbr});
statestable.DisplayInGrid("Custom Panel");