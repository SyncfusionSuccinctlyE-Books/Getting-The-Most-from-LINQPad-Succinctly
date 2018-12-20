<Query Kind="Statements">
  <Connection>
    <ID>7ac5fd27-655b-4515-ae84-833b8183c097</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>D:\LINQPad Samples\uspostalcodes\bin\Debug\uspostalcodes.dll</CustomAssemblyPath>
    <CustomTypeName>uspostalcodes.uspostalcodesEntities</CustomTypeName>
    <AppConfigPath>D:\LINQPad Samples\uspostalcodes\bin\Debug\uspostalcodes.dll.config</AppConfigPath>
  </Connection>
</Query>

var statesView = states.Take(20);
statesView.MyDump("Custom Dump","background-color: #F4D7A3; color: #DE8900;",false);
