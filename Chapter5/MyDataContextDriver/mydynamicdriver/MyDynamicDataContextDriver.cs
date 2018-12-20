using System;
using System.Collections.Generic;
using System.Reflection;
using LINQPad.Extensibility.DataContext;

namespace MyDataContextDriver.mydynamicdriver
{
    public class MyDynamicDataContextDriver : DynamicDataContextDriver
    {
        public override string GetConnectionDescription(IConnectionInfo cxInfo)
        {
            throw new System.NotImplementedException();
        }

        public override bool ShowConnectionDialog(IConnectionInfo cxInfo, bool isNewConnection)
        {
            throw new NotImplementedException();
        }

        public override string Name => "My Dynamic Data Context Driver (Demo)";
        public override string Author => "Getting the Most from LINQPad Succinctly";

        public override List<ExplorerItem> GetSchemaAndBuildAssembly(IConnectionInfo cxInfo, AssemblyName assemblyToBuild, ref string nameSpace,ref string typeName)
        {
            throw new System.NotImplementedException();
        }
    }
}
